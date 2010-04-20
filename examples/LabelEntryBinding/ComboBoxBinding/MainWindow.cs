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
using System.Collections.Generic;
using System.ComponentModel;
using Gtk;
using Gtk.Forms;

public partial class MainWindow : FormsWindow
{
	List<Customer> customers;
    NotifiedBindingList<Customer> customers2;
	BindingSource bsrcCustomers;
    NotifiedBindingList<Customer> customers3;
	
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
		
		customers = new List<Customer>() { new Customer() { CompanyID = 1, CompanyName = "Acme Workshop" },
                                                    new Customer() { CompanyID = 2, CompanyName = "Sirius Tech"} };
        formscombobox1.DataSource = customers;
        formscombobox1.DisplayMember = "CompanyName";

        formslabel1.DataBindings.Add("Text", customers, "CompanyId");

        customers2 = new NotifiedBindingList<Customer>() { new Customer() { CompanyID = 1, CompanyName = "Acme Workshop" },
                                                new Customer() { CompanyID = 2, CompanyName = "Sirius Tech"} };
        bsrcCustomers = new BindingSource() { DataSource = customers2 }; 
       
        formscombobox2.DataSource = bsrcCustomers;
        formscombobox2.DisplayMember = "CompanyName";

        formslabel2.DataBindings.Add("Text", bsrcCustomers, "CompanyId");

        customers3 = new NotifiedBindingList<Customer>() { new Customer() { CompanyID = 1, CompanyName = "Acme Workshop" },
                                                   new Customer() { CompanyID = 2, CompanyName = "Sirius Tech"} };

        formscombobox3.DataSource = customers3;
        formscombobox3.DisplayMember = "CompanyName";

        formslabel3.DataBindings.Add("Text", customers3, "CompanyId");
	}
	
	protected virtual void OnButton1Clicked (object sender, System.EventArgs e)
	{
		 customers[0].CompanyID = 10;
         customers[0].CompanyName = "Neo Acme Workshop";
	}
	
	protected virtual void OnButton2Clicked (object sender, System.EventArgs e)
	{
		customers2[0].CompanyID = 10;
        customers2[0].CompanyName = "Neo Acme Workshop";
	}
	
	protected virtual void OnButton3Clicked (object sender, System.EventArgs e)
	{
		customers3[0].CompanyID = 10;
        customers3[0].CompanyName = "Neo Acme Workshop";
	}
	
	protected virtual void OnButton4Clicked (object sender, System.EventArgs e)
	{
		customers3.Clear ();
	}
	
	protected virtual void OnButton5Clicked (object sender, System.EventArgs e)
	{
		bsrcCustomers.Position = 1;
	}
	
	
	
	
	
	
	

}
