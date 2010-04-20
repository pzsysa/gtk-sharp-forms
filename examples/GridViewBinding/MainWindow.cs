using System;
using Gtk;
using Gtk.Forms;

public partial class MainWindow : FormsWindow
{
	NotifiedBindingList<Product> products;
	BindingSource bsrcProducts;
	
	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();	
	}
	
	protected override void OnShown ()
	{
		base.OnShown ();
		
		BindingContext = new BindingContext ();
		
		products = new NotifiedBindingList<Product> () {
						new Product(){ProductID=1, ProductName="computer", Price=49m, Favourite=false},
						new Product(){ProductID=2, ProductName="mouse", Price=10.5m, Favourite=false},
						new Product(){ProductID=3, ProductName="monitor", Price=200m, Favourite=true},
						new Product(){ProductID=4, ProductName="keyboard", Price=21m, Favourite=true}};
		
		bsrcProducts = new BindingSource (){DataSource = products};
		gridview.DataSource = bsrcProducts;		
		
		entryID.DataBindings.Add (new Binding ("Text", bsrcProducts, "ProductID"));
		entryName.DataBindings.Add (new Binding ("Text", bsrcProducts, "ProductName"));
		spinPrice.DataBindings.Add (new Binding ("Value", bsrcProducts, "Price"));
		checkFavourite.DataBindings.Add (new Binding("Active", bsrcProducts, "Favourite"));
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
