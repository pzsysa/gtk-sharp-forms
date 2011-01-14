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
using System.Text;
using Gtk;

namespace GtkForms
{

	public class GridViewDecorator <T> : BaseListWidgetDecorator<T>
		where T : TreeView, IDecoratedGridView
	{
		private T grid;
		private Dictionary<TreeViewColumn, PropertyDescriptor> treecolumns;
		private List <ListSortDescription> sorts;
		
		private bool auto_generate_columns = true;
		public bool AutoGenerateColumns {
			get { return auto_generate_columns; }
			set { auto_generate_columns = value; }
		}

		public GridViewDecorator (T widget)
			: base (widget)
		{
			grid = widget;
			sorts = new List<ListSortDescription> ();
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
			treecolumns = new Dictionary<TreeViewColumn, PropertyDescriptor> ();
			
			if (AutoGenerateColumns) {
				
				int count = 0;
				foreach (PropertyDescriptor prop in DataManager.GetItemProperties ()) {
					CellRendererText ct = new CellRendererText ();
					ct.Editable = false;
					TreeViewColumn treecol = new TreeViewColumn (prop.DisplayName, ct, "text", count++);
					treecol.Clicked += HandleTreeColumnClicked;
					grid.AppendColumn (treecol);
					treecolumns.Add (treecol, prop);
				}
			}
		}
		
		protected override object[] GetItemValues (object item)
		{
			var values = new List<object> ();
			
			if (AutoGenerateColumns) {
				
				foreach (PropertyDescriptor prop in DataManager.GetItemProperties ()) {
					object propval = prop.GetValue (item);
					string val = (propval != null) ? propval.ToString () : string.Empty;
					values.Add (val);
				}
			}
			
			return values.ToArray ();
		}
		
		void UpdateSorts (TreeViewColumn treecol)
		{
			PropertyDescriptor prop = treecolumns [treecol];
			ListSortDescription lsd = sorts.Find (l => l.PropertyDescriptor == prop);
			
			if (lsd == null) {
				lsd = new ListSortDescription (prop, ListSortDirection.Ascending);
				sorts.Add (lsd);
			} else {
				if (lsd.SortDirection == ListSortDirection.Ascending) {
					lsd.SortDirection = ListSortDirection.Descending;
				} else {
					sorts.Remove (lsd);
				}
			}
		}
		
		void UpdateHeaders ()
		{
			foreach (TreeViewColumn treecol in treecolumns.Keys) {
				PropertyDescriptor prop = treecolumns [treecol];
				ListSortDescription lsd = sorts.Find (l => l.PropertyDescriptor == prop);
				if (lsd == null) {
					treecol.Title = prop.DisplayName;
				} else {
					int n = sorts.IndexOf (lsd) + 1; //column order number
					treecol.Title = string.Format ("{0} {1}{2}", 
						prop.DisplayName, (lsd.SortDirection == ListSortDirection.Ascending) ? "\u2193" : "\u2191", n);                               
				}
			}
		}
		
		string GetSortExpression ()
		{
			if (sorts.Count == 0)
				return string.Empty;
			
			var sortexpr = new StringBuilder ();
			for (int i = 0; i < sorts.Count; i++) {
				if (i != 0) {
					sortexpr.Append (", ");
				}
				ListSortDescription lsd = sorts [i];
				sortexpr.AppendFormat ("{0} {1}", 
					lsd.PropertyDescriptor.Name, 
					(lsd.SortDirection == ListSortDirection.Ascending) ? "ASC" : "DESC");
			}
			return sortexpr.ToString ();
		}
		
		void Sort ()
		{
			if (DataSource is BindingSource) {
				var bsrc = (BindingSource) DataSource;
				string sortexpr = GetSortExpression ();
				bsrc.Sort = sortexpr;
			} else if (DataSource is IBindingListView) {
				var listview = (IBindingListView) DataSource;
				listview.ApplySort (new ListSortDescriptionCollection (sorts.ToArray ()));
				RefreshDataSource ();
			}
		}
		
		void HandleTreeColumnClicked (object sender, EventArgs e)
		{
			var treecol = (TreeViewColumn) sender;
			
			UpdateSorts (treecol);
			UpdateHeaders ();
			Sort ();
		}
	}
}
