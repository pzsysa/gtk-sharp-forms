//  
//  FormsButton.cs
//  
//  Author:
//       Krzysztof Marecki 
// 
//  Copyright (c) 2010 KrzysztofMarecki
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.ComponentModel;
using System.Linq;
using Gtk;

namespace GtkForms
{
	public class FormsButton : Button, IBindableComponent
	{
		private WidgetDecorator decorator;
		internal WidgetDecorator Decorator { 
			get {
				if (decorator == null)
					decorator = new WidgetDecorator (this);
				
				return decorator;
			}
		}
		
		public FormsButton ()
			: base ()
		{
		}
		
		public FormsButton (IntPtr raw)
			: base (raw)
		{
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
		
		public new string Label {
			get { return base.Label; }
			set {
				//otheriwse after setting the Label property, Image was cleared
				Label label = FindLabelChild (this);
				if (label != null) {
					label.Text = value;
				} else {
					base.Label = value;
				}
			}
		}
		
		public Gdk.Color BackgroundColor {
			get { return Decorator.BackgroundColor; }
			set { Decorator.BackgroundColor = value; }
		}
		
		public int FontSize {
			get { return Decorator.FontSize; }
			set { Decorator.FontSize = value; }
		}
		
	
		Label FindLabelChild (Gtk.Container container)
		{
			var widgets = (
				from child in container.Children
				where typeof (Label).IsAssignableFrom (child.GetType ())
				select (Label) child
			).Union (
				from child in container.Children
				where typeof (Gtk.Container).IsAssignableFrom (child.GetType ())
			    select FindLabelChild ((Gtk.Container) child)
			);
			
			var labels = widgets.ToArray ();
			return labels.Length > 0 ? labels.First (w => (w != null)) : null;
		}
		
	}
}

