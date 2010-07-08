// 
//  ListWidgetDecorator.cs
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

namespace GtkForms
{
	public class ListWidgetDecorator<T> : BaseListWidgetDecorator<T>
		where T : Widget, IDecoratedListWidget
	{
		T list_widget;
		
		public ListWidgetDecorator (T widget)
			: base (widget)
		{
			list_widget = widget;
		}
		
		protected override ListStore CreateStore ()
		{
			return new ListStore (typeof(string));
		}
		
		protected override void SetCellRenderers ()
		{
            Gtk.CellRendererText ct = new Gtk.CellRendererText ();
			ct.Editable = true;
            list_widget.PackStart (ct, false);
            list_widget.AddAttribute (ct, "text", 0);	
		}
		
		protected override object[] GetItemValues (object item)
		{
			object o = FilterItemOnProperty (item, DisplayMember);
			
			if (o == null)
				o = item;
			
			return new object[] {o.ToString ()};
		}
		
		private object FilterItemOnProperty (object item, string field)
		{
			if (item == null)
				return null;

			if (field == null || field == string.Empty)
				return item;

			PropertyDescriptor prop = null;

			if (DataManager != null) {
				PropertyDescriptorCollection col = DataManager.GetItemProperties ();
				prop = col.Find (field, true);
			} else {
				PropertyDescriptorCollection properties = TypeDescriptor.GetProperties (item);
				prop = properties.Find (field, true);
			}
			
			if (prop == null)
				return item;
			
			return prop.GetValue (item);
		}
	}
}
