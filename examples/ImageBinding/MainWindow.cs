// 
//  MainWindow.cs
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
using Gdk;
using GtkForms;
using ImageBinding;

public partial class MainWindow: FormsWindow
{	
	ImageData imagedata;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected override void OnShown ()
	{
		base.OnShown ();
		
		imagedata = new ImageData ();
		formsimage1.DataBindings.Add ("ImageData", imagedata, "Pixdata",
			false, DataSourceUpdateMode.OnPropertyChanged);
		Pixbuf pixbuf = new Pixbuf ("logo.png");
		Pixdata pixdata = new Pixdata ();
		pixdata.FromPixbuf (pixbuf, false);
		imagedata.Pixdata = pixdata.Serialize();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
