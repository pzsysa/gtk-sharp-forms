// 
//  FormsWindow.cs
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
using System.Threading;
using Gtk;

namespace GtkForms
{
	public class FormsWindow : Window, IBindableComponent
	{ 
		bool destroyed;
		
		private WindowDecorator decorator;
		internal WindowDecorator Decorator { 
			get {
				if (decorator == null)
					decorator = new WindowDecorator (this);
				
				return decorator;
			}
		}
		
		public FormsWindow (IntPtr raw)
			: base (raw)
		{
			BindingContext = new BindingContext ();
			Visible = false;
		}
		
		public FormsWindow (WindowType type)
			: base (type)
		{
			BindingContext = new BindingContext ();
			Visible = false;
		}
		
		public FormsWindow (string title)
			: base (title)
		{
			BindingContext = new BindingContext ();
			Visible = false;
		}
		
		#region IBindableComponent implementation
		public event EventHandler HandleCreated {
			add { Decorator.HandleCreated += value; }
			remove { Decorator.HandleCreated -= value; }
		}
	
		public event CancelEventHandler Validating {
			add { Decorator.Validating += value; }
			remove { Decorator.Validating -= value; }
		}
		
		
		public BindingContext BindingContext {
			get { return Decorator.BindingContext; }
			set { Decorator.BindingContext = value; }
		}
		
		
		public ControlBindingsCollection DataBindings { get { return Decorator.DataBindings; } }
		
		public bool IsHandleCreated { get { return Decorator.IsHandleCreated; } }
		#endregion
		
		public Gdk.Color BackgroundColor {
			get { return Decorator.BackgroundColor; }
			set { Decorator.BackgroundColor = value; }
		}
		
		ResponseType responseType = ResponseType.None;
		public ResponseType ResponseType {
			get { return responseType; }
			protected set { responseType = value; }
		}
		
		public void Close ()
		{
			Destroy ();
		}
		
		public new void Show ()
		{
			Gdk.Window active = Gdk.Screen.Default.ActiveWindow;
			
			if (WindowPosition == WindowPosition.CenterOnParent) {
				foreach (var toplevel in Gtk.Window.ListToplevels()) {
					if (toplevel.GdkWindow == active) {
						TransientFor = toplevel;
						WindowPosition = WindowPosition.CenterOnParent;
						break;
					}
				}
			}
	
			base.Show ();
		}
		
		public void ShowModal ()
		{
			Modal = true;
			Show ();
		
			while (!destroyed) {
				Gtk.Application.RunIteration ();
			}
		}
		
		
		protected override void OnDestroyed ()
		{
			base.OnDestroyed ();
			destroyed = true;
		}
	}
}

