// 
//  TreeViewDecorator.cs
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
using Gtk;

namespace GtkForms
{
	public class TreeViewDecorator : WidgetDecorator
	{
		object data_source;
		
		public TreeViewDecorator (TreeView widget)
			: base (widget)
		{
		}
		
		
//		public object DataSource {
//			get { return data_source; }
//			set {
//				if (data_source == value)
//					return;
//
//				if (value == null)
//					display_member = String.Empty;
//				else if (!(value is IList || value is IListSource))
//					throw new Exception ("Complex DataBinding accepts as a data source " +
//						"either an IList or an IListSource");
//				
//				data_source = value;
//				ConnectToDataSource ();
////				OnDataSourceChanged (EventArgs.Empty);
//			}
//		}
	}
}

