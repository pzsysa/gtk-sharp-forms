// 
//  WidgetAdapter.cs
//  
//  Author:
//       Krzysztof Marecki <marecki.krzysztof@gmail.com>
//  
//  Copyright (c) 2010 Krzysztof Marecki
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.ComponentModel;
using Gtk;

namespace GtkForms
{
	public class WidgetDecorator : IBindableDecorator
	{
		Widget widget; 
		bool? validated;
		Gdk.Color backgroundColor;
		Gdk.Color foregroundColor;
		
		#region IBindableDecorator
		
		private BindingContext binding_context;
		public virtual BindingContext BindingContext {
			get {
				if (binding_context != null)
					return binding_context;
		
				Widget parent = widget.Parent;		
				while ((parent != null) && !(parent is IBindableComponent))
					parent = parent.Parent;
				
				if (parent == null)
					return null;
				
				binding_context = ((IBindableComponent)parent).BindingContext; 
				return binding_context;
			}
			set {
				if (binding_context != value) {
					binding_context = value;
					OnBindingContextChanged(EventArgs.Empty);
				}
			}
		}
		
		private ControlBindingsCollection data_bindings;
		public ControlBindingsCollection DataBindings {
			get {
				if (data_bindings == null) {
					var bindable = 
						((widget as IBindableComponent) != null) ? 
						(IBindableComponent) widget : 
						(IBindableComponent) this;
					data_bindings = new ControlBindingsCollection (bindable);
				}
				return data_bindings;
			}
		}
		
		public object Component {
			get { return widget; }
		}
		
		public event EventHandler HandleCreated;
		
		public event CancelEventHandler Validating;
		#endregion
		
		public bool IsHandleCreated {
			get { return widget.GdkWindow != null; }
		}
		
		public bool Validated {
			get {
				validated = null;
				//need to rethink how to cache validated value
				if (validated == null) {
					CancelEventArgs args = new CancelEventArgs ();
					OnValidating (args);
					validated = !args.Cancel;
				}
				
				return validated.Value;
			}
		}
		
		public virtual Gdk.Color BackgroundColor {
			get { return backgroundColor; }
			set {
				backgroundColor = value;
				widget.ModifyBg (StateType.Normal, backgroundColor);
			}
		}
		
		public virtual Gdk.Color ForegroundColor {
			get { return foregroundColor; }
			set {
				foregroundColor = value;
				widget.ModifyFg (StateType.Normal, foregroundColor);
			}
		}
		
		int? fontsize;
		public virtual int FontSize {
			get { return fontsize.HasValue ? 
							fontsize.Value :
							(int) (widget.Style.FontDescription.Size / Pango.Scale.PangoScale);
				} 
			set {
				if (FontSize != value) {
					fontsize = value;
					var font = widget.Style.FontDescription;
					string fontname = string.Format ("{0} {1}", font.Family, value);
					var fontnew = Pango.FontDescription.FromString (fontname);
//					var fontnew = font.Copy ();
//					widget.ModifyFont (fontnew);
//					fontnew.Size = (int) (value * Pango.Scale.PangoScale);
					fontnew.Weight = font.Weight;
					widget.ModifyFont (fontnew);
				}
			}
		}
		
		Pango.Weight? fontweight;
		public virtual Pango.Weight FontWeight
		{
			get {
				return fontweight.HasValue ? fontweight.Value : widget.Style.FontDescription.Weight;
			}
			set {
				if (FontWeight != fontweight) {
					fontweight = value;
					
					var font = widget.Style.FontDescription;
					string fontname = string.Format ("{0} {1}", font.Family, FontSize);
					var fontnew = Pango.FontDescription.FromString (fontname);
					fontnew.Weight = value;
					widget.ModifyFont (fontnew);
				}
			}
		}
		
		public WidgetDecorator (Widget widget)
		{
			this.widget = widget;
			
			this.widget.ButtonPressEvent += widget_ButtonPressEvent;
			this.widget.FocusInEvent += widget_FocusInEvent;
			this.widget.FocusOutEvent += widget_FocusOutEvent;
			
			if (this.widget is IFocusableWidget) {
				IFocusableWidget focuswidget = (IFocusableWidget) this.widget;
				focuswidget.FocusOut += focuswidget_FocusOut;
			}
		
			HandleWidgetRealized ();
		}
		
		[GLib.ConnectBefore]
		void widget_ButtonPressEvent (object o, ButtonPressEventArgs args)
		{
			if (widget.Toplevel is FormsWindow) {
				var window = (FormsWindow)widget.Toplevel;
				
				if(window.Decorator.Focused != null) {
					var focused = window.Decorator.Focused;
					
					if(!focused.Validated)
						args.RetVal=true;
				}
			}
		}

		void HandleWidgetRealized ()
		{
			if (widget.IsRealized)
				widget_Realized (widget, EventArgs.Empty);
			else
				widget.Realized += widget_Realized;
		}
		
		private void widget_FocusInEvent (object o, FocusInEventArgs args)
		{
			if (widget.Toplevel is FormsWindow) {
				var window = (FormsWindow)widget.Toplevel;
				window.Decorator.Focused = this;
			}
		}
		
		[GLib.ConnectBefore]
		private void widget_FocusOutEvent (object o, FocusOutEventArgs args)
		{
			args.RetVal = OnWidgetFocusOutEvent ();
		}
		
		private bool OnWidgetFocusOutEvent ()
		{
			if (!Validated) {
				widget.GrabFocus ();
				
//				args.RetVal = true;
				return true;
			}
			
			if (widget.Toplevel is FormsWindow) {
				var window = (FormsWindow)widget.Toplevel;
				window.Decorator.Focused = null;
			}
			
			return false;
		}
		
		private void focuswidget_FocusOut (object o, EventArgs e)
		{
			OnWidgetFocusOutEvent ();
		}

		private void widget_Realized (object sender, EventArgs e)
		{
			OnHandleCreated (EventArgs.Empty);
			if (widget.GdkWindow != null)
				widget.GdkWindow.AddFilter (new Gdk.FilterFunc(FocusableFilter));
		}
		
		private Gdk.FilterReturn FocusableFilter(IntPtr xevent, Gdk.Event evnt)
		{			
			//user changed something in control, need to validate again
			//but, which is no suprise, gdk.filterfunc does not work in windows :(
			validated = null;
			
			return Gdk.FilterReturn.Continue;
		}
		
		protected void OnBindingContextChanged (EventArgs args)
		{
			var handler = BindingContextChanged;
			if (handler != null)
				handler (this, args);
		}
	
		protected void OnHandleCreated (EventArgs args)
		{
			var handler = HandleCreated;
			if (handler != null)
				handler (this, args);
		}
		
		protected void OnValidating (CancelEventArgs args)
		{
			var handler = Validating;
			if (handler != null)
				handler (this, args);
		}
	
		public event EventHandler BindingContextChanged;
	}
}

