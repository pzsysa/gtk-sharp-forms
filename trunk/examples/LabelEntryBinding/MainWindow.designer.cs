// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

// This file has been generated by the GUI designer. Do not modify.


public partial class MainWindow
{
	
	private global::Gtk.VBox vbox1;
	private global::Gtk.HBox hbox1;
	private global::GtkForms.FormsLabel label;
	private global::GtkForms.FormsEntry entry;
	private global::Gtk.HBox hbox2;
	private global::GtkForms.FormsLabel checkLabel;
	private global::GtkForms.FormsCheckButton check;
	private global::Gtk.HBox hbox3;
	private global::GtkForms.FormsLabel notifyLabel;
	private global::GtkForms.FormsEntry notifyEntry;
	private global::Gtk.HBox hbox4;
	private global::GtkForms.FormsLabel spinLabel;
	private global::GtkForms.FormsSpinButton spin;
	private global::GtkForms.FormsEntry spinEntry;
	private global::Gtk.HBox hbox7;
	private global::Gtk.Notebook notebook1;
	private global::Gtk.Frame frame1;
	private global::Gtk.Alignment GtkAlignment;
	private global::Gtk.HBox hbox8;
	private global::GtkForms.FormsLabel labelStreet;
	private global::GtkForms.FormsEntry entryAdressStreet;
	private global::Gtk.Label GtkLabel3;
	private global::Gtk.Label label1;
	private global::Gtk.HBox hbox6;
	private global::GtkForms.FormsLabel labelTextView;
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	private global::GtkForms.FormsTextView textView;
	private global::Gtk.HBox hbox5;
	private global::GtkForms.FormsRadioButton radioOn;
	private global::GtkForms.FormsRadioButton radioOff;
	private global::GtkForms.FormsLabel labelStatus;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("Label entry binding demo");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.label = new global::GtkForms.FormsLabel ();
		this.label.Name = "label";
		this.label.FontSize = 0;
		this.hbox1.Add (this.label);
		global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label]));
		w1.Position = 0;
		// Container child hbox1.Gtk.Box+BoxChild
		this.entry = new global::GtkForms.FormsEntry ();
		this.entry.CanFocus = true;
		this.entry.Name = "entry";
		this.entry.IsEditable = true;
		this.entry.InvisibleChar = '●';
		this.entry.FontSize = 0;
		this.hbox1.Add (this.entry);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.entry]));
		w2.Position = 1;
		w2.Expand = false;
		w2.Fill = false;
		this.vbox1.Add (this.hbox1);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
		w3.Position = 0;
		w3.Expand = false;
		w3.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox2 = new global::Gtk.HBox ();
		this.hbox2.Name = "hbox2";
		this.hbox2.Spacing = 6;
		// Container child hbox2.Gtk.Box+BoxChild
		this.checkLabel = new global::GtkForms.FormsLabel ();
		this.checkLabel.Name = "checkLabel";
		this.checkLabel.FontSize = 0;
		this.hbox2.Add (this.checkLabel);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.checkLabel]));
		w4.Position = 0;
		w4.Expand = false;
		w4.Fill = false;
		// Container child hbox2.Gtk.Box+BoxChild
		this.check = new global::GtkForms.FormsCheckButton ();
		this.check.CanFocus = true;
		this.check.Name = "check";
		this.check.DrawIndicator = true;
		this.check.FontSize = 0;
		this.hbox2.Add (this.check);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.check]));
		w5.Position = 1;
		this.vbox1.Add (this.hbox2);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox2]));
		w6.Position = 1;
		w6.Expand = false;
		w6.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox3 = new global::Gtk.HBox ();
		this.hbox3.Name = "hbox3";
		this.hbox3.Spacing = 6;
		// Container child hbox3.Gtk.Box+BoxChild
		this.notifyLabel = new global::GtkForms.FormsLabel ();
		this.notifyLabel.Name = "notifyLabel";
		this.notifyLabel.FontSize = 0;
		this.hbox3.Add (this.notifyLabel);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.notifyLabel]));
		w7.Position = 0;
		w7.Expand = false;
		w7.Fill = false;
		// Container child hbox3.Gtk.Box+BoxChild
		this.notifyEntry = new global::GtkForms.FormsEntry ();
		this.notifyEntry.CanFocus = true;
		this.notifyEntry.Name = "notifyEntry";
		this.notifyEntry.IsEditable = true;
		this.notifyEntry.InvisibleChar = '●';
		this.notifyEntry.FontSize = 0;
		this.hbox3.Add (this.notifyEntry);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.notifyEntry]));
		w8.Position = 1;
		w8.Expand = false;
		w8.Fill = false;
		this.vbox1.Add (this.hbox3);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox3]));
		w9.Position = 2;
		w9.Expand = false;
		w9.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox4 = new global::Gtk.HBox ();
		this.hbox4.Name = "hbox4";
		this.hbox4.Spacing = 6;
		// Container child hbox4.Gtk.Box+BoxChild
		this.spinLabel = new global::GtkForms.FormsLabel ();
		this.spinLabel.Name = "spinLabel";
		this.spinLabel.FontSize = 0;
		this.hbox4.Add (this.spinLabel);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.spinLabel]));
		w10.Position = 0;
		w10.Expand = false;
		w10.Fill = false;
		// Container child hbox4.Gtk.Box+BoxChild
		this.spin = new global::GtkForms.FormsSpinButton ();
		this.spin.CanFocus = true;
		this.spin.Name = "spin";
		this.hbox4.Add (this.spin);
		global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.spin]));
		w11.Position = 1;
		w11.Expand = false;
		w11.Fill = false;
		// Container child hbox4.Gtk.Box+BoxChild
		this.spinEntry = new global::GtkForms.FormsEntry ();
		this.spinEntry.CanFocus = true;
		this.spinEntry.Name = "spinEntry";
		this.spinEntry.IsEditable = true;
		this.spinEntry.InvisibleChar = '●';
		this.spinEntry.FontSize = 0;
		this.hbox4.Add (this.spinEntry);
		global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.spinEntry]));
		w12.Position = 2;
		w12.Expand = false;
		w12.Fill = false;
		this.vbox1.Add (this.hbox4);
		global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox4]));
		w13.Position = 3;
		w13.Expand = false;
		w13.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox7 = new global::Gtk.HBox ();
		this.hbox7.Name = "hbox7";
		this.hbox7.Spacing = 6;
		// Container child hbox7.Gtk.Box+BoxChild
		this.notebook1 = new global::Gtk.Notebook ();
		this.notebook1.CanFocus = true;
		this.notebook1.Name = "notebook1";
		this.notebook1.CurrentPage = 0;
		// Container child notebook1.Gtk.Notebook+NotebookChild
		this.frame1 = new global::Gtk.Frame ();
		this.frame1.Name = "frame1";
		this.frame1.ShadowType = ((global::Gtk.ShadowType)(0));
		// Container child frame1.Gtk.Container+ContainerChild
		this.GtkAlignment = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
		this.GtkAlignment.Name = "GtkAlignment";
		this.GtkAlignment.LeftPadding = ((uint)(12));
		// Container child GtkAlignment.Gtk.Container+ContainerChild
		this.hbox8 = new global::Gtk.HBox ();
		this.hbox8.Name = "hbox8";
		this.hbox8.Spacing = 6;
		// Container child hbox8.Gtk.Box+BoxChild
		this.labelStreet = new global::GtkForms.FormsLabel ();
		this.labelStreet.Name = "labelStreet";
		this.labelStreet.LabelProp = global::Mono.Unix.Catalog.GetString ("formslabel1");
		this.labelStreet.FontSize = 0;
		this.hbox8.Add (this.labelStreet);
		global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.labelStreet]));
		w14.Position = 0;
		w14.Expand = false;
		w14.Fill = false;
		// Container child hbox8.Gtk.Box+BoxChild
		this.entryAdressStreet = new global::GtkForms.FormsEntry ();
		this.entryAdressStreet.CanFocus = true;
		this.entryAdressStreet.Name = "entryAdressStreet";
		this.entryAdressStreet.IsEditable = true;
		this.entryAdressStreet.InvisibleChar = '●';
		this.entryAdressStreet.FontSize = 0;
		this.hbox8.Add (this.entryAdressStreet);
		global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.entryAdressStreet]));
		w15.Position = 1;
		w15.Expand = false;
		w15.Fill = false;
		this.GtkAlignment.Add (this.hbox8);
		this.frame1.Add (this.GtkAlignment);
		this.GtkLabel3 = new global::Gtk.Label ();
		this.GtkLabel3.Name = "GtkLabel3";
		this.GtkLabel3.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>GtkFrame</b>");
		this.GtkLabel3.UseMarkup = true;
		this.frame1.LabelWidget = this.GtkLabel3;
		this.notebook1.Add (this.frame1);
		// Notebook tab
		this.label1 = new global::Gtk.Label ();
		this.label1.Name = "label1";
		this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("page1");
		this.notebook1.SetTabLabel (this.frame1, this.label1);
		this.label1.ShowAll ();
		this.hbox7.Add (this.notebook1);
		global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.notebook1]));
		w19.Position = 0;
		this.vbox1.Add (this.hbox7);
		global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox7]));
		w20.PackType = ((global::Gtk.PackType)(1));
		w20.Position = 4;
		w20.Expand = false;
		w20.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox6 = new global::Gtk.HBox ();
		this.hbox6.Name = "hbox6";
		this.hbox6.Spacing = 6;
		// Container child hbox6.Gtk.Box+BoxChild
		this.labelTextView = new global::GtkForms.FormsLabel ();
		this.labelTextView.Name = "labelTextView";
		this.labelTextView.LabelProp = global::Mono.Unix.Catalog.GetString ("formslabel1");
		this.labelTextView.FontSize = 0;
		this.hbox6.Add (this.labelTextView);
		global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.labelTextView]));
		w21.Position = 0;
		w21.Expand = false;
		w21.Fill = false;
		// Container child hbox6.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.textView = new global::GtkForms.FormsTextView ();
		this.textView.CanFocus = true;
		this.textView.Name = "textView";
		this.textView.FontSize = 0;
		this.GtkScrolledWindow.Add (this.textView);
		this.hbox6.Add (this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.GtkScrolledWindow]));
		w23.Position = 1;
		this.vbox1.Add (this.hbox6);
		global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox6]));
		w24.PackType = ((global::Gtk.PackType)(1));
		w24.Position = 5;
		w24.Expand = false;
		w24.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox5 = new global::Gtk.HBox ();
		this.hbox5.Name = "hbox5";
		this.hbox5.Spacing = 6;
		// Container child hbox5.Gtk.Box+BoxChild
		this.radioOn = new global::GtkForms.FormsRadioButton ();
		this.radioOn.CanFocus = true;
		this.radioOn.Name = "radioOn";
		this.radioOn.Label = global::Mono.Unix.Catalog.GetString ("On");
		this.radioOn.DrawIndicator = true;
		this.radioOn.UseUnderline = true;
		this.radioOn.Group = new global::GLib.SList (global::System.IntPtr.Zero);
		this.hbox5.Add (this.radioOn);
		global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.radioOn]));
		w25.Position = 0;
		w25.Expand = false;
		w25.Fill = false;
		// Container child hbox5.Gtk.Box+BoxChild
		this.radioOff = new global::GtkForms.FormsRadioButton ();
		this.radioOff.CanFocus = true;
		this.radioOff.Name = "radioOff";
		this.radioOff.Label = global::Mono.Unix.Catalog.GetString ("Off");
		this.radioOff.DrawIndicator = true;
		this.radioOff.UseUnderline = true;
		this.radioOff.Group = this.radioOn.Group;
		this.hbox5.Add (this.radioOff);
		global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.radioOff]));
		w26.Position = 1;
		w26.Expand = false;
		w26.Fill = false;
		// Container child hbox5.Gtk.Box+BoxChild
		this.labelStatus = new global::GtkForms.FormsLabel ();
		this.labelStatus.Name = "labelStatus";
		this.labelStatus.LabelProp = global::Mono.Unix.Catalog.GetString ("formslabel1");
		this.labelStatus.FontSize = 0;
		this.hbox5.Add (this.labelStatus);
		global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.labelStatus]));
		w27.Position = 2;
		w27.Expand = false;
		w27.Fill = false;
		this.vbox1.Add (this.hbox5);
		global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox5]));
		w28.PackType = ((global::Gtk.PackType)(1));
		w28.Position = 6;
		w28.Expand = false;
		w28.Fill = false;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 423;
		this.DefaultHeight = 349;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
	}
}
