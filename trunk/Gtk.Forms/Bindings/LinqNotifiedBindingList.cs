// 
//  LinqNotifiedBindingList.cs
//  
//  Author:
//       Krzysztof Marecki <marecki.krzysztof@gmail.com>
// 
//  Copyright (c) 2011 KrzysztofMarecki
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
using System.Linq;
using System.Reflection;

namespace GtkForms
{
	public class LinqNotifiedBindingList<T> : NotifiedBindingList<T>, IBindingListView
	{
		Dictionary<int, int> view_indexes;
		
		public LinqNotifiedBindingList ()
			: base ()
		{
		}
		
		public LinqNotifiedBindingList (IList<T> list)
			: base (list)
		{
		}
		
		public LinqNotifiedBindingList (System.Collections.IEnumerable list)
			: base (list)
		{
		}

		#region IBindingListView implementation
		
		IOrderedEnumerable<T> SortBy (IOrderedEnumerable<T> sorted, ListSortDescriptionCollection sorts, int i)
		{
			if (i >= sorts.Count)
				return sorted;
			
			PropertyInfo propi = typeof (T).GetProperty (sorts[i].PropertyDescriptor.Name);
			if (sorts[i].SortDirection == ListSortDirection.Ascending) {
					return SortBy(sorted.ThenBy(item => propi.GetValue (item, null)), sorts, i + 1);
			} else {
					return SortBy(sorted.ThenByDescending (item => propi.GetValue (item, null)), sorts, i + 1);
			}
		}
		
		void IBindingListView.ApplySort (ListSortDescriptionCollection sorts)
		{
			if (Count == 0)
				return;
			
			if (sorts.Count == 0) {
				view_indexes = null;
				return;
			}
			
			view_indexes = new Dictionary<int, int> ();
			
			var items = from item in this 
							select item;
			IOrderedEnumerable<T> sorted;

			
			PropertyInfo propi = typeof (T).GetProperty (sorts[0].PropertyDescriptor.Name);
			if (sorts[0].SortDirection == ListSortDirection.Ascending) {
				sorted = SortBy (items.OrderBy (item => propi.GetValue (item, null)), sorts, 1);
				
			} else {
				sorted = SortBy (items.OrderByDescending (item => propi.GetValue (item, null)), sorts, 1);
			}
			
//			Does not work, first ordeby is ignored
//			if (sorts.Count > 1) {
//				for (int i = 1; i < sorts.Count; i++) {
//					propi = typeof (T).GetProperty (sorts[i].PropertyDescriptor.Name);
//					if (sorts[i].SortDirection == ListSortDirection.Ascending) {
//						sorted = sorted.ThenBy(item => propi.GetValue (item, null));
//					} else {
//						sorted = sorted.ThenByDescending (item => propi.GetValue (item, null));
//					}
//				}
//			}
			
			int key=0;
			foreach (var item in sorted) {
				view_indexes.Add (key++, IndexOf (item));
			}
		}

		void IBindingListView.RemoveFilter ()
		{
		}

		string IBindingListView.Filter {
			get {
				return string.Empty;
			}
			set {
				
			}
		}

		ListSortDescriptionCollection IBindingListView.SortDescriptions {
			get {
				throw new NotImplementedException ();
			}
		}

		bool IBindingListView.SupportsAdvancedSorting {
			get {
				return true;
			}
		}

		bool IBindingListView.SupportsFiltering {
			get {
				return false;
			}
		}
		#endregion
		
		int Translate (int index)
		{
			if (view_indexes == null)
				return index;
			
			return view_indexes [index];
		}
		
		public System.Collections.IEnumerator GetViewEnumerator ()
		{
			foreach (var pair in view_indexes) {
				yield return base [pair.Value];
			}
		}
		
		public new T this[int index] {
			get {
				return base [Translate (index)];
			}
			set {
				base [Translate (index)] = value;
			}
		}
		
		public new System.Collections.IEnumerator GetEnumerator ()
		{
			return (view_indexes == null) ? base.GetEnumerator () : GetViewEnumerator ();
			
		}
		
		protected override void ApplySortCore (PropertyDescriptor prop, ListSortDirection direction)
		{
			if (Count == 0)
				return;
			
			var sorts = new ListSortDescriptionCollection (new ListSortDescription[] {
				new ListSortDescription (prop, direction) });
			(this as IBindingListView).ApplySort (sorts);
		}
		
		protected override void RemoveSortCore ()
		{
			view_indexes = null;
		}
		
		protected override bool SupportsSortingCore {
			get {
				return true;
			}
		}
}
}

