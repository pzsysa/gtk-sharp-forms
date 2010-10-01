// 
//  FormsTextView.cs
//  
//  Author:
//       Krzysztof Marecki <freefirma@gmail.com>
// 
//  Copyright (c) 2010 Krzysztof Marecki
// 
//  This library is free software; you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as
//  published by the Free Software Foundation; either version 2.1 of the
//  License, or (at your option) any later version.
// 
//  This library is distributed in the hope that it will be useful, but
//  WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
//  Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public
//  License along with this library; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
using System;
using System.ComponentModel;
using Gtk;

namespace GtkForms
{
	[ToolboxItem(true)]
	public class FormsTextView : TextView, IBindableComponent
	{
		private WidgetDecorator decorator;
		internal WidgetDecorator Decorator { 
			get {
				if (decorator == null)
					decorator = new WidgetDecorator (this);
				
				return decorator;
			}
		}
		
		public FormsTextView ()
			: base ()
		{
		}
		
		public FormsTextView (IntPtr raw)
			: base ()
		{
		}
		
		public FormsTextView (TextBuffer buffer)
			: base (buffer)
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
		
		public int FontSize {
			get { return Decorator.FontSize; }
			set { Decorator.FontSize = value; }
		}
		
		public string Text {
			get { return Buffer.Text; }
			set { 
				if (value == null) {
					return;
				}
				if (Buffer.Text != value) {
					Buffer.Text = value;
				}
			}
		}
		
		[EditorBrowsable (EditorBrowsableState.Never)]
		public event EventHandler TextChanged {
			add { Buffer.Changed += value; }
			remove { Buffer.Changed -= value; }
		}
	}
}

