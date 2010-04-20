// 
//  DataGridViewDecorator.cs
//  
//  Author:
//       Krzysztof Marecki <marecki.krzysztof@gmail.com>
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
using Gtk;

namespace Gtk.Forms
{

	public class GridViewDecorator <T> : BaseListWidgetDecorator<T>
		where T : Widget, IDecoratedGridView
	{
		private T grid_widget;
		
		private bool auto_generate_columns = true;
		public bool AutoGenerateColumns {
			get { return auto_generate_columns; }
			set { auto_generate_columns = value; }
		}

		public GridViewDecorator (T widget)
			: base (widget)
		{
			grid_widget = widget;
		}
		
		protected override ListStore CreateStore ()
		{
			return new ListStore (typeof(string));
		}
		
		protected override void SetCellRenderers ()
		{
			
		}
		
		protected override object[] GetItemValues (object item)
		{
			return new object[] {};
		}
	}
}
