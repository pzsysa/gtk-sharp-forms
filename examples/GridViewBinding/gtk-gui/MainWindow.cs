//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



public partial class MainWindow {
    
    private Gtk.HBox hbox1;
    
    private Gtk.ScrolledWindow GtkScrolledWindow;
    
    private Gtk.Forms.FormsGridView gridview;
    
    private Gtk.Table table1;
    
    private Gtk.Alignment alignmentFavourite;
    
    private Gtk.Forms.FormsCheckButton checkFavourite;
    
    private Gtk.Alignment alignmentPrice;
    
    private Gtk.Forms.FormsSpinButton spinPrice;
    
    private Gtk.Forms.FormsEntry entryID;
    
    private Gtk.Forms.FormsEntry entryName;
    
    private Gtk.Forms.FormsLabel labelFavourite;
    
    private Gtk.Forms.FormsLabel labelID;
    
    private Gtk.Forms.FormsLabel labelName;
    
    private Gtk.Forms.FormsLabel labelPrice;
    
    protected virtual void Build() {
        Stetic.Gui.Initialize(this);
        // Widget MainWindow
        this.Name = "MainWindow";
        this.Title = Mono.Unix.Catalog.GetString("MainWindow");
        this.WindowPosition = ((Gtk.WindowPosition)(4));
        // Container child MainWindow.Gtk.Container+ContainerChild
        this.hbox1 = new Gtk.HBox();
        this.hbox1.Name = "hbox1";
        this.hbox1.Spacing = 6;
        // Container child hbox1.Gtk.Box+BoxChild
        this.GtkScrolledWindow = new Gtk.ScrolledWindow();
        this.GtkScrolledWindow.Name = "GtkScrolledWindow";
        this.GtkScrolledWindow.ShadowType = ((Gtk.ShadowType)(1));
        // Container child GtkScrolledWindow.Gtk.Container+ContainerChild
        this.gridview = new Gtk.Forms.FormsGridView();
        this.gridview.CanFocus = true;
        this.gridview.Name = "gridview";
        this.GtkScrolledWindow.Add(this.gridview);
        this.hbox1.Add(this.GtkScrolledWindow);
        Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.hbox1[this.GtkScrolledWindow]));
        w2.Position = 0;
        // Container child hbox1.Gtk.Box+BoxChild
        this.table1 = new Gtk.Table(((uint)(4)), ((uint)(3)), false);
        this.table1.Name = "table1";
        this.table1.RowSpacing = ((uint)(6));
        this.table1.ColumnSpacing = ((uint)(6));
        this.table1.BorderWidth = ((uint)(4));
        // Container child table1.Gtk.Table+TableChild
        this.alignmentFavourite = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
        this.alignmentFavourite.Name = "alignmentFavourite";
        // Container child alignmentFavourite.Gtk.Container+ContainerChild
        this.checkFavourite = new Gtk.Forms.FormsCheckButton();
        this.checkFavourite.CanFocus = true;
        this.checkFavourite.Name = "checkFavourite";
        this.checkFavourite.Label = "";
        this.checkFavourite.DrawIndicator = true;
        this.alignmentFavourite.Add(this.checkFavourite);
        this.table1.Add(this.alignmentFavourite);
        Gtk.Table.TableChild w4 = ((Gtk.Table.TableChild)(this.table1[this.alignmentFavourite]));
        w4.TopAttach = ((uint)(3));
        w4.BottomAttach = ((uint)(4));
        w4.LeftAttach = ((uint)(1));
        w4.RightAttach = ((uint)(2));
        w4.XOptions = ((Gtk.AttachOptions)(4));
        w4.YOptions = ((Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.alignmentPrice = new Gtk.Alignment(0.01F, 0.5F, 0F, 1F);
        this.alignmentPrice.Name = "alignmentPrice";
        // Container child alignmentPrice.Gtk.Container+ContainerChild
        this.spinPrice = new Gtk.Forms.FormsSpinButton();
        this.spinPrice.WidthRequest = 60;
        this.spinPrice.CanFocus = true;
        this.spinPrice.Name = "spinPrice";
        this.alignmentPrice.Add(this.spinPrice);
        this.table1.Add(this.alignmentPrice);
        Gtk.Table.TableChild w6 = ((Gtk.Table.TableChild)(this.table1[this.alignmentPrice]));
        w6.TopAttach = ((uint)(2));
        w6.BottomAttach = ((uint)(3));
        w6.LeftAttach = ((uint)(1));
        w6.RightAttach = ((uint)(2));
        w6.XOptions = ((Gtk.AttachOptions)(4));
        w6.YOptions = ((Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.entryID = new Gtk.Forms.FormsEntry();
        this.entryID.CanFocus = true;
        this.entryID.Name = "entryID";
        this.entryID.IsEditable = true;
        this.table1.Add(this.entryID);
        Gtk.Table.TableChild w7 = ((Gtk.Table.TableChild)(this.table1[this.entryID]));
        w7.LeftAttach = ((uint)(1));
        w7.RightAttach = ((uint)(2));
        w7.XOptions = ((Gtk.AttachOptions)(4));
        w7.YOptions = ((Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.entryName = new Gtk.Forms.FormsEntry();
        this.entryName.CanFocus = true;
        this.entryName.Name = "entryName";
        this.entryName.IsEditable = true;
        this.table1.Add(this.entryName);
        Gtk.Table.TableChild w8 = ((Gtk.Table.TableChild)(this.table1[this.entryName]));
        w8.TopAttach = ((uint)(1));
        w8.BottomAttach = ((uint)(2));
        w8.LeftAttach = ((uint)(1));
        w8.RightAttach = ((uint)(2));
        w8.XOptions = ((Gtk.AttachOptions)(4));
        w8.YOptions = ((Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.labelFavourite = new Gtk.Forms.FormsLabel();
        this.labelFavourite.Name = "labelFavourite";
        this.labelFavourite.Xalign = 1F;
        this.labelFavourite.Yalign = 0F;
        this.labelFavourite.LabelProp = Mono.Unix.Catalog.GetString("Favourite");
        this.table1.Add(this.labelFavourite);
        Gtk.Table.TableChild w9 = ((Gtk.Table.TableChild)(this.table1[this.labelFavourite]));
        w9.TopAttach = ((uint)(3));
        w9.BottomAttach = ((uint)(4));
        w9.XOptions = ((Gtk.AttachOptions)(4));
        w9.YOptions = ((Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.labelID = new Gtk.Forms.FormsLabel();
        this.labelID.Name = "labelID";
        this.labelID.Xalign = 1F;
        this.labelID.Yalign = 0F;
        this.labelID.LabelProp = Mono.Unix.Catalog.GetString("ID");
        this.table1.Add(this.labelID);
        Gtk.Table.TableChild w10 = ((Gtk.Table.TableChild)(this.table1[this.labelID]));
        w10.XOptions = ((Gtk.AttachOptions)(4));
        w10.YOptions = ((Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.labelName = new Gtk.Forms.FormsLabel();
        this.labelName.Name = "labelName";
        this.labelName.Xalign = 1F;
        this.labelName.Yalign = 0F;
        this.labelName.LabelProp = Mono.Unix.Catalog.GetString("Company name\n");
        this.table1.Add(this.labelName);
        Gtk.Table.TableChild w11 = ((Gtk.Table.TableChild)(this.table1[this.labelName]));
        w11.TopAttach = ((uint)(1));
        w11.BottomAttach = ((uint)(2));
        w11.XOptions = ((Gtk.AttachOptions)(4));
        w11.YOptions = ((Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.labelPrice = new Gtk.Forms.FormsLabel();
        this.labelPrice.Name = "labelPrice";
        this.labelPrice.Xalign = 1F;
        this.labelPrice.Yalign = 0F;
        this.labelPrice.LabelProp = Mono.Unix.Catalog.GetString("Price");
        this.table1.Add(this.labelPrice);
        Gtk.Table.TableChild w12 = ((Gtk.Table.TableChild)(this.table1[this.labelPrice]));
        w12.TopAttach = ((uint)(2));
        w12.BottomAttach = ((uint)(3));
        w12.XOptions = ((Gtk.AttachOptions)(4));
        w12.YOptions = ((Gtk.AttachOptions)(4));
        this.hbox1.Add(this.table1);
        Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.hbox1[this.table1]));
        w13.Position = 1;
        w13.Expand = false;
        w13.Fill = false;
        this.Add(this.hbox1);
        if ((this.Child != null)) {
            this.Child.ShowAll();
        }
        this.DefaultWidth = 452;
        this.DefaultHeight = 300;
        this.Show();
        this.DeleteEvent += new Gtk.DeleteEventHandler(this.OnDeleteEvent);
    }
}