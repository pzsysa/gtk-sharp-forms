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
		
		labelError.ModifyFg (StateType.Normal, new Gdk.Color(255, 0, 0));
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
		
		entryID.DataBindings.Add (new Binding ("Text", bsrcProducts, "ProductID", true, DataSourceUpdateMode.OnPropertyChanged));
		entryName.DataBindings.Add (new Binding ("Text", bsrcProducts, "ProductName", true, DataSourceUpdateMode.OnValidation));
		spinPrice.DataBindings.Add (new Binding ("Value", bsrcProducts, "Price", true, DataSourceUpdateMode.OnPropertyChanged));
		checkFavourite.DataBindings.Add (new Binding("Active", bsrcProducts, "Favourite", true, DataSourceUpdateMode.OnPropertyChanged));
	
		gridview.DataSource = bsrcProducts;		
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	
	protected virtual void OnEntryNameValidating (object sender, System.ComponentModel.CancelEventArgs e)
	{
		if (entryName.Text == "") {
			e.Cancel = true;
			labelError.Text = "Please fill company name";
			labelError.Visible = true;
		} else {
			labelError.Visible = false;
		}
	}
}
