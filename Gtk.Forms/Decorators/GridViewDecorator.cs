// 
//  DataGridViewDecorator.cs
//  
//  Author:
//       Krzysztof Marecki 
// 
//	Copyright (c) 2010 Krzysztof Marecki 
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
using System.Collections.Generic;
using System.ComponentModel;
using Gtk;

namespace GtkForms
{

	public class GridViewDecorator <T> : BaseListWidgetDecorator<T>
		where T : TreeView, IDecoratedGridView
	{
		private T grid;
		
		private bool auto_generate_columns = true;
		public bool AutoGenerateColumns {
			get { return auto_generate_columns; }
			set { auto_generate_columns = value; }
		}

		public GridViewDecorator (T widget)
			: base (widget)
		{
			grid = widget;
		}
		
		protected override ListStore CreateStore ()
		{
			ListStore store = null;
			var types = new List<Type>();
			
			if (AutoGenerateColumns) {
				
				foreach (PropertyDescriptor prop in DataManager.GetItemProperties ()) 
//					types.Add (prop.PropertyType);	
					types.Add (typeof (string));	
			}
			
			store = new ListStore (types.ToArray ());
			return store;
		}
		
		protected override void SetCellRenderers ()
		{
			if (AutoGenerateColumns) {
				
				int count = 0;
				foreach (PropertyDescriptor prop in DataManager.GetItemProperties ()) {
					CellRendererText ct = new CellRendererText ();
					ct.Editable = true;
					TreeViewColumn treecol = new TreeViewColumn (prop.DisplayName, ct, "text", count++);
					grid.AppendColumn (treecol);
				}
			}
		}
		
		protected override object[] GetItemValues (object item)
		{
			var values = new List<object> ();
			
			if (AutoGenerateColumns) {
				
				foreach (PropertyDescriptor prop in DataManager.GetItemProperties ())
					values.Add (prop.GetValue (item).ToString ());
			}
			
			return values.ToArray ();
		}
	}
}
