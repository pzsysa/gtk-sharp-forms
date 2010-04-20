// 
//  BaseListWidgetDecorator.cs
//  
//  Author:
//		 Jordi Mas i Hernandez, <jordi@ximian.com>
//       Krzysztof Marecki <marecki.krzysztof@gmail.com>
// 
//  Copyright (c) 2004-2005 Novell, Inc.
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
using System.Collections;
using System.ComponentModel;
using Gtk;

namespace Gtk.Forms
{
	public abstract class BaseListWidgetDecorator<T> : WidgetDecorator
		where T : Widget, IDecoratedBaseListWidget
	{
		private T list_widget;
		private ListStore store;
		
		private object data_source;
		private BindingMemberInfo value_member;
		private string display_member;
		private CurrencyManager DataManager;
		
		public BaseListWidgetDecorator (T widget)
			: base (widget)
		{
			list_widget = widget;
		}
		
		public object DataSource {
			get { return data_source; }
			set {
				if (data_source == value)
					return;

				if (value == null)
					display_member = String.Empty;
				else if (!(value is IList || value is IListSource))
					throw new Exception ("Complex DataBinding accepts as a data source " +
						"either an IList or an IListSource");

				data_source = value;
				ConnectToDataSource ();
//				OnDataSourceChanged (EventArgs.Empty);
			}
		}
		
		public string DisplayMember {
			get { 
				return display_member;
			}
			set {
				if (value == null)
					value = String.Empty;

				if (display_member == value) {
					return;
				}

				display_member = value;
				ConnectToDataSource ();
//				OnDisplayMemberChanged (EventArgs.Empty);
			}
		}
		
		public string ValueMember {
			get { return value_member.BindingMember; }
			set {
				BindingMemberInfo new_value = new BindingMemberInfo (value);
				
				if (value_member.Equals (new_value))
					return;
				
				value_member = new_value;
				
				if (display_member == string.Empty)
					DisplayMember = value_member.BindingMember;

				ConnectToDataSource ();
//				OnValueMemberChanged (EventArgs.Empty);
			}
		}
		
		
		public void SetPositionFromIter (TreeIter iter)
		{
			TreePath path = list_widget.Model.GetPath (iter);
			int position = path.Indices [0];
			
			if (DataManager == null)
				return;
			if (DataManager.Position == position)
				return;
			DataManager.Position = position;
		}
		
		private void ConnectToDataSource ()
		{
			if (BindingContext == null)
				return;

			CurrencyManager newDataMgr = null;
			if (data_source != null)
				newDataMgr = (CurrencyManager) BindingContext [data_source];
			if (newDataMgr != DataManager) {
				if (DataManager != null) {
					// Disconnect handlers from previous manager
					DataManager.PositionChanged -= new EventHandler (OnPositionChanged);
					DataManager.ItemChanged -= new ItemChangedEventHandler (OnItemChanged);
				}
				if (newDataMgr != null) {
					newDataMgr.PositionChanged += new EventHandler (OnPositionChanged);
					newDataMgr.ItemChanged += new ItemChangedEventHandler (OnItemChanged);
					
				}
				DataManager = newDataMgr;
				SetModel ();
			}
			SetItems ();
			//list_widget.SetItemsCore (data_manager.List);
		}
			
		private void SetModel ()
		{
			store = CreateStore ();
			
			SetCellRenderers ();
                
            list_widget.Model = store;
		}
		
		protected abstract ListStore CreateStore ();
		
		protected abstract void SetCellRenderers ();
		
		private void SetItems ()
		{
			store.Clear ();
			
			foreach (object item in DataManager.List) {
				
				object[] items = GetItemValues (item);
				store.AppendValues (items);
			}
			
			UpdatePosition ();
		}
		
		protected abstract object[] GetItemValues (object item);
		
		private void UpdatePosition ()
		{
			TreeIter iter;
			int position = DataManager.Position;
			
			if (position >= 0)
				if (store.GetIterFromString (out iter, position.ToString ()))
					list_widget.SetActiveIter (iter);
		}
		
		private void RefreshItem (int index)
		{
			object item = DataManager.List [index];
			TreeIter iter;
			
			if (store.GetIterFromString (out iter, index.ToString ())) {
				object[] items = GetItemValues (item);
				store.SetValues (iter, items);
			}
		}	
		
		private void OnItemChanged (object sender, ItemChangedEventArgs e)
		{
			/* if the list has changed, tell our subclass to re-bind */
			if (e.Index == -1)
				SetItems ();
			else
				RefreshItem (e.Index);

			/* For the first added item, ItemChanged is fired _after_ PositionChanged,
			 * so we need to set Index _only_ for that case - normally we would do that
			 * in PositionChanged handler */
//			if (AllowSelection && SelectedIndex == -1 && data_manager.Count == 1)
//				SelectedIndex = data_manager.Position;
		}

		private void OnPositionChanged (object sender, EventArgs e)
		{
			UpdatePosition ();
			/* For the first added item, PositionChanged is fired
			 * _before_ ItemChanged (items not yet added), which leave us in a temporary
			 * invalid state */
//			if (AllowSelection && data_manager.Count > 1)
//				SelectedIndex = data_manager.Position;
		}
	}
}
