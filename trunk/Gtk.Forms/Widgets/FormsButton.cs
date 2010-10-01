//  
//  FormsButton.cs
//  
//  Author:
//       Krzysztof Marecki <freefirma@gmail.com>
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
using System.Linq;
using Gtk;

namespace GtkForms
{
	public class FormsButton : Button
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
		
	
		Label FindLabelChild (Container container)
		{
			var widgets = (
				from child in container.Children
				where typeof (Label).IsAssignableFrom (child.GetType ())
				select (Label) child
			).Union (
				from child in container.Children
				where typeof (Container).IsAssignableFrom (child.GetType ())
			    select FindLabelChild ((Container) child)
			);
			
			var labels = widgets.ToArray ();
			return labels.Length > 0 ? labels.First (w => (w != null)) : null;
		}
		
	}
}

