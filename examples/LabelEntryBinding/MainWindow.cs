// 
//  MainWindow.cs
//  
//  Author:
//       Krzysztof Marecki <marecki.krzysztof@gmail.com>
//  
//  Copyright (c) 2010 Krzysztof Marecki
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Gtk;
using Gtk.Forms;

public partial class MainWindow : FormsWindow
{
	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();
		
		BindingContext = new BindingContext ();
		label.DataBindings.Add ("Text", entry, "Text");
		
		Binding binding = new Binding("Text", check, "Active");
		binding.Format += delegate(object sender, ConvertEventArgs e) {
			bool val = (bool)e.Value;
			e.Value = val ? "Enabled" : "Disabled";
		};
		
		checkLabel.DataBindings.Add (binding);
		
		Company company = new Company ();
		company.CompanyName = "Acme";
		BindingSource bsrc = new BindingSource ();
		var companies = new NotifiedBindingList<Company>{company};
		bsrc.DataSource = companies;
		
        Binding binding2 = new Binding("Text", bsrc, "CompanyName");
        binding2.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;

        this.notifyEntry.DataBindings.Add(binding2);

        Binding binding3 = new Binding("Text", bsrc, "CompanyName");
        binding3.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
        this.notifyLabel.DataBindings.Add(binding3);
		
		
		Binding binding4 = new Binding("Text", spin, "Value");
		Binding binding5 = new Binding("Text", spin, "Value");
		
		spinLabel.DataBindings.Add (binding4);
		spinEntry.DataBindings.Add (binding5);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

}
