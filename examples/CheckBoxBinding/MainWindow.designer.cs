// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

// This file has been generated by the GUI designer. Do not modify.


public partial class MainWindow
{
    
	private global::Gtk.VBox vbox1;
	private global::GtkForms.FormsCheckButton check;
	private global::Gtk.HBox hbox1;
	private global::GtkForms.FormsLabel label;
	private global::GtkForms.FormsEntry entry;
    
	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.check = new global::GtkForms.FormsCheckButton ();
		this.check.CanFocus = true;
		this.check.Name = "check";
		this.check.Label = global::Mono.Unix.Catalog.GetString ("Visible");
		this.check.Active = true;
		this.check.DrawIndicator = true;
		this.check.UseUnderline = true;
		this.check.FontSize = 0;
		this.vbox1.Add (this.check);
		global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.check]));
		w1.Position = 0;
		w1.Expand = false;
		w1.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.label = new global::GtkForms.FormsLabel ();
		this.label.Name = "label";
		this.label.LabelProp = global::Mono.Unix.Catalog.GetString ("Text");
		this.label.FontSize = 12;
		this.hbox1.Add (this.label);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child hbox1.Gtk.Box+BoxChild
		this.entry = new global::GtkForms.FormsEntry ();
		this.entry.CanFocus = true;
		this.entry.Name = "entry";
		this.entry.IsEditable = true;
		this.entry.InvisibleChar = '•';
		this.entry.FontSize = 12;
		this.hbox1.Add (this.entry);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.entry]));
		w3.Position = 1;
		w3.Expand = false;
		w3.Fill = false;
		this.vbox1.Add (this.hbox1);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
		w4.Position = 1;
		w4.Expand = false;
		w4.Fill = false;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 400;
		this.DefaultHeight = 300;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
	}
}
