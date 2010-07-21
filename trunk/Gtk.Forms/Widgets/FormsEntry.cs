// 
//  EntryDecorator.cs
//  
//  Author:
//       Krzysztof Marecki 
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
	[ToolboxItem(true)]
	public class FormsEntry : Entry, IBindableComponent
	{
		private EntryDecorator decorator;
		internal EntryDecorator Decorator { 
			get {
				if (decorator == null)
					decorator = new EntryDecorator (this);
				
				return decorator;
			}
		}
		
		public FormsEntry ()
			: base ()
		{
		}
		
		public FormsEntry (IntPtr raw)
			: base (raw)
		{
		}
		
		public FormsEntry (string initialText)
			:base (initialText)
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
		
		public Gdk.Color BackgroundColor {
			get { return Decorator.BackgroundColor; }
			set { Decorator.BackgroundColor = value; }
		}
		
		public new string Text {
			get { return base.Text; }
			set {
				if (value == null) {
					return;
				}
				if (base.Text != value ) {
					base.Text = value; 
				}
			}
		}
		
		[EditorBrowsable (EditorBrowsableState.Never)]
		public event EventHandler TextChanged {
			add { base.Changed += value; }
			remove { base.Changed -= value; }
		}
	}
}

