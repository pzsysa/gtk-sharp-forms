using System;
using Gtk;
using GtkForms;

public partial class MainWindow : FormsWindow
{
	LinqNotifiedBindingList<Product> products;
	BindingSource bsrcProducts;
	
	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();	
		
		labelError.ModifyFg (StateType.Normal, new Gdk.Color(255, 0, 0));
		gridview.AutoGenerateColumns = false;
		gridview.HeadersClickable = true;
		gridview.Columns.Add (new GridViewColumn () {
			DataPropertyName = "ProductID", HeaderText = "ID" });
		gridview.Columns.Add (new GridViewColumn () {
			DataPropertyName = "ProductName", HeaderText = "Name", Width = 160 });
		var colPrice = new GridViewColumn () {
			DataPropertyName = "Price", HeaderText = "Price", Width = 60};
		colPrice.DefaultCellStyle.Format = "C2";
		gridview.Columns.Add (colPrice);
		gridview.Columns.Add (new GridViewColumn () {
			DataPropertyName = "Favourite", HeaderText = "Favourite"}); 
		
		products = new LinqNotifiedBindingList<Product>() {};
		bsrcProducts = new BindingSource (){DataSource = products};
		gridview.DataSource = bsrcProducts;
		
		entryID.DataBindings.Add (new Binding ("Text", bsrcProducts, "ProductID", true, DataSourceUpdateMode.OnPropertyChanged));
		entryName.DataBindings.Add (new Binding ("Text", bsrcProducts, "ProductName", true, DataSourceUpdateMode.OnPropertyChanged));
		spinPrice.DataBindings.Add (new Binding ("Value", bsrcProducts, "Price", true, DataSourceUpdateMode.OnPropertyChanged));
		checkFavourite.DataBindings.Add (new Binding ("Active", bsrcProducts, "Favourite", true, DataSourceUpdateMode.OnPropertyChanged));
		gridview.HeadersClickable = true;
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
	
	protected virtual void ButtonLoad_Clicked (object sender, System.EventArgs e)
	{
		products = new LinqNotifiedBindingList<Product> () {
						new Product(){ProductID=1, ProductName="computer", Price=49m, Favourite=false},
						new Product(){ProductID=2, ProductName="mouse", Price=10.5m, Favourite=false},
						new Product(){ProductID=3, ProductName="monitor", Price=80m, Favourite=true},
						new Product(){ProductID=4, ProductName="keyboard", Price=21m, Favourite=true},
						new Product(){ProductID=5, ProductName="monitor", Price=30m, Favourite=true},
						new Product(){ProductID=6, ProductName="monitor", Price=30m, Favourite=false}};
		
		bsrcProducts.DataSource = products;
		gridview.DataSource = bsrcProducts;
	}
}
