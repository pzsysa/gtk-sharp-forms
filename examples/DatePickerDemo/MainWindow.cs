// 
//  MainWindow.cs
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
using Gtk;
using GtkForms;

namespace DatePickerDemo
{
	public partial class MainWindow : FormsWindow
	{
		public MainWindow () : base(Gtk.WindowType.Toplevel)
		{
			Build ();
		}
	
		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}
		
		protected override void OnShown ()
		{
			base.OnShown ();
			
			BindingContext = new BindingContext ();
			Order order = new Order ();
			
			datepicker.DataBindings.Add ("Date", order, "DeliveryDate", false, DataSourceUpdateMode.OnPropertyChanged);
			label.DataBindings.Add ("Text", order, "DeliveryDate");
			
			datepicker2.DataBindings.Add ("Date", order, "DeliveryDate", false, DataSourceUpdateMode.OnPropertyChanged);
			label2.DataBindings.Add ("Text", order, "DeliveryDate");
		}
	}
}
