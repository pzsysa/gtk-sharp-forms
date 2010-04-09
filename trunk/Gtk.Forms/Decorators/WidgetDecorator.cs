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

namespace Gtk.Forms
{
	public class WidgetDecorator
	{
		private Widget widget; 
		
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
				if (data_bindings == null)
					data_bindings = new ControlBindingsCollection (widget);
				return data_bindings;
			}
		}
		
		public bool IsHandleCreated {
			get { return widget.GdkWindow != null; }
		}
		
		public WidgetDecorator (Widget widget)
		{
			this.widget = widget;
			
			this.widget.Realized += widget_Realized;
		}

		private void widget_Realized (object sender, EventArgs e)
		{
			OnHandleCreated (EventArgs.Empty);
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
	
		public event EventHandler BindingContextChanged;
		public event EventHandler HandleCreated;
		public event CancelEventHandler Validating;

		
	}
}

