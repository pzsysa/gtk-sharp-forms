// 
//  FormsComboBox.cs
//  
//  Author:
//       Krzysztof Marecki <marecki.krzysztof@gmail.com>
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
using System.Collections;
using System.ComponentModel;
using Gtk;

namespace GtkForms
{
	[ToolboxItem(true)]
	public class FormsComboBox : Gtk.ComboBox, IBindableComponent, IDecoratedListWidget, IListWidget
	{
		private ListWidgetDecorator<FormsComboBox> decorator;
		internal ListWidgetDecorator<FormsComboBox> Decorator { 
			get {
				if (decorator == null)
					decorator = new  ListWidgetDecorator<FormsComboBox>(this);
				
				return decorator;
			}
		}

		public FormsComboBox ()
			: base ()
		{
		}
		
		public FormsComboBox (IntPtr raw)
			: base (raw)
		{
		}
		
		public FormsComboBox (string[] entries)
			: base (entries)
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
		
		#region IListWidget implementation
		
		public object DataSource {
			get { return Decorator.DataSource; }
			set { Decorator.DataSource = value; }
		}
		
		public string DisplayMember {
			get { return Decorator.DisplayMember; }
			set { Decorator.DisplayMember = value; }
		}
		
		public string ValueMember {
			get { return Decorator.ValueMember; }
			set { Decorator.ValueMember = value; }
		}
		#endregion
		
		#region IDecoratedListWidget implementation
		
		TreeModel IDecoratedBaseListWidget.Model {
			get { return Model; }
			set { Model = value; }
		}
	
		#endregion
		
		protected override void OnChanged ()
		{
			base.OnChanged ();
			
			TreeIter iter;
			if (GetActiveIter (out iter))
				Decorator.SetPositionFromIter (iter);
		}
	}
}
