// 
//  FormsDataGridView.cs
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
using System.ComponentModel;
using Gtk;

namespace GtkForms
{
	public class FormsGridView : TreeView, IBindableComponent, IDecoratedGridView
	{
		private GridViewDecorator<FormsGridView> decorator;
		internal GridViewDecorator<FormsGridView> Decorator { 
			get {
				if (decorator == null)
					decorator = new GridViewDecorator<FormsGridView>(this);
				
				return decorator;
			}
		}
		
		public bool AutoGenerateColumns {
			get { return Decorator.AutoGenerateColumns; }
			set { Decorator.AutoGenerateColumns = value; }
		}
		
		public object DataSource {
			get { return Decorator.DataSource; }
			set { Decorator.DataSource = value; }
		}

		public FormsGridView ()
			: base ()
		{
		}
		
		public FormsGridView (IntPtr raw)
			: base (raw)
		{
		}
		
		public FormsGridView (TreeModel model)
			: base (model)
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
		
		#region IDecoratedGridView implementation
		
		TreeModel IDecoratedBaseListWidget.Model {
			get { return Model; }
			set { Model = value; }
		}
		
		void IDecoratedBaseListWidget.SetActiveIter (TreeIter iter) {
			Selection.SelectIter (iter);
		}
	
		#endregion
		
		protected override void OnCursorChanged ()
		{
			base.OnCursorChanged ();
			
			TreeIter iter;
			
			if (Selection.GetSelected (out iter))
				Decorator.SetPositionFromIter (iter);
		}
	}
}
