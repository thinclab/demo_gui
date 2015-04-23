
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	
	private global::Gtk.Action FileAction;
	
	private global::Gtk.Action OpenPolicyAction;
	
	private global::Gtk.Action SavePolicyAction;
	
	private global::Gtk.Action QuitAction;
	
	private global::Gtk.VBox vbox0;
	
	private global::Gtk.MenuBar menubar1;
	
	private global::Gtk.HPaned hpaned1;
	
	private global::Gtk.VBox vbox;
	
	private global::Gtk.HBox hbox1;
	
	private global::Gtk.Label label1;
	
	private global::Gtk.Entry entry1;
	
	private global::Gtk.Label label2;
	
	private global::Gtk.Entry entry2;
	
	private global::Gtk.Alignment alignment3;
	
	private global::Gtk.HBox hbox8;
	
	private global::Gtk.RadioButton radiobutton1;
	
	private global::Gtk.RadioButton radiobutton2;
	
	private global::Gtk.Alignment alignment9;
	
	private global::Gtk.HBox hbox2;
	
	private global::Gtk.Label label3;
	
	private global::Gtk.ComboBox combobox1;
	
	private global::Gtk.Frame frame1;
	
	private global::Gtk.Alignment GtkAlignment;
	
	private global::Gtk.VBox vbox1;
	
	private global::Gtk.HBox hbox3;
	
	private global::Gtk.Label label4;
	
	private global::Gtk.Entry entry3;
	
	private global::Gtk.Label label5;
	
	private global::Gtk.Entry entry4;
	
	private global::Gtk.Alignment alignment4;
	
	private global::Gtk.HBox hbox9;
	
	private global::Gtk.Label label13;
	
	private global::Gtk.Entry entry11;
	
	private global::Gtk.Alignment alignment10;
	
	private global::Gtk.Frame frame2;
	
	private global::Gtk.Alignment GtkAlignment1;
	
	private global::Gtk.VBox vbox2;
	
	private global::Gtk.HBox hbox4;
	
	private global::Gtk.Label label8;
	
	private global::Gtk.ComboBox combobox5;
	
	private global::Gtk.Entry entry5;
	
	private global::Gtk.Label label7;
	
	private global::Gtk.Entry entry6;
	
	private global::Gtk.Alignment alignment5;
	
	private global::Gtk.HBox hbox5;
	
	private global::Gtk.Label label10;
	
	private global::Gtk.ComboBox combobox6;
	
	private global::Gtk.Entry entry7;
	
	private global::Gtk.Label label9;
	
	private global::Gtk.Entry entry8;
	
	private global::Gtk.Alignment alignment6;
	
	private global::Gtk.HBox hbox6;
	
	private global::Gtk.Label label12;
	
	private global::Gtk.ComboBox combobox7;
	
	private global::Gtk.Entry entry9;
	
	private global::Gtk.Label label11;
	
	private global::Gtk.Entry entry10;
	
	private global::Gtk.Alignment alignment7;
	
	private global::Gtk.Label GtkLabel3;
	
	private global::Gtk.Label GtkLabel4;
	
	private global::Gtk.Alignment alignment1;
	
	private global::Gtk.HBox hbox7;
	
	private global::Gtk.Alignment alignment2;
	
	private global::Gtk.Button button1;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.FileAction = new global::Gtk.Action ("FileAction", global::Mono.Unix.Catalog.GetString ("_File"), null, null);
		this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_File");
		w1.Add (this.FileAction, "<Alt><Mod2>o");
		this.OpenPolicyAction = new global::Gtk.Action ("OpenPolicyAction", global::Mono.Unix.Catalog.GetString ("_Open Policy"), null, null);
		this.OpenPolicyAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Open Policy");
		w1.Add (this.OpenPolicyAction, "<Alt><Mod2>o");
		this.SavePolicyAction = new global::Gtk.Action ("SavePolicyAction", global::Mono.Unix.Catalog.GetString ("_Save Policy"), null, null);
		this.SavePolicyAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Save Policy");
		w1.Add (this.SavePolicyAction, "<Alt><Mod2>q");
		this.QuitAction = new global::Gtk.Action ("QuitAction", global::Mono.Unix.Catalog.GetString ("_Quit"), null, null);
		this.QuitAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Quit");
		w1.Add (this.QuitAction, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox0 = new global::Gtk.VBox ();
		this.vbox0.Name = "vbox0";
		this.vbox0.Spacing = 6;
		// Container child vbox0.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><menubar name='menubar1'><menu name='FileAction' action='FileAction'><menuitem name='OpenPolicyAction' action='OpenPolicyAction'/><menuitem name='SavePolicyAction' action='SavePolicyAction'/><menuitem name='QuitAction' action='QuitAction'/></menu></menubar></ui>");
		this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar1")));
		this.menubar1.Name = "menubar1";
		this.vbox0.Add (this.menubar1);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox0 [this.menubar1]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox0.Gtk.Box+BoxChild
		this.hpaned1 = new global::Gtk.HPaned ();
		this.hpaned1.CanFocus = true;
		this.hpaned1.Name = "hpaned1";
		this.hpaned1.Position = 487;
		this.hpaned1.BorderWidth = ((uint)(3));
		// Container child hpaned1.Gtk.Paned+PanedChild
		this.vbox = new global::Gtk.VBox ();
		this.vbox.Name = "vbox";
		this.vbox.Spacing = 6;
		// Container child vbox.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.label1 = new global::Gtk.Label ();
		this.label1.Name = "label1";
		this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Grid Size");
		this.hbox1.Add (this.label1);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label1]));
		w3.Position = 0;
		w3.Expand = false;
		w3.Fill = false;
		// Container child hbox1.Gtk.Box+BoxChild
		this.entry1 = new global::Gtk.Entry ();
		this.entry1.CanFocus = true;
		this.entry1.Name = "entry1";
		this.entry1.IsEditable = true;
		this.entry1.WidthChars = 2;
		this.entry1.MaxLength = 2;
		this.entry1.InvisibleChar = '●';
		this.hbox1.Add (this.entry1);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.entry1]));
		w4.Position = 1;
		w4.Expand = false;
		// Container child hbox1.Gtk.Box+BoxChild
		this.label2 = new global::Gtk.Label ();
		this.label2.Name = "label2";
		this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("X");
		this.hbox1.Add (this.label2);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label2]));
		w5.Position = 2;
		w5.Expand = false;
		w5.Fill = false;
		// Container child hbox1.Gtk.Box+BoxChild
		this.entry2 = new global::Gtk.Entry ();
		this.entry2.CanFocus = true;
		this.entry2.Name = "entry2";
		this.entry2.IsEditable = true;
		this.entry2.WidthChars = 2;
		this.entry2.MaxLength = 2;
		this.entry2.InvisibleChar = '●';
		this.hbox1.Add (this.entry2);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.entry2]));
		w6.Position = 3;
		w6.Expand = false;
		// Container child hbox1.Gtk.Box+BoxChild
		this.alignment3 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
		this.alignment3.Name = "alignment3";
		this.hbox1.Add (this.alignment3);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.alignment3]));
		w7.Position = 4;
		this.vbox.Add (this.hbox1);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox [this.hbox1]));
		w8.Position = 0;
		w8.Expand = false;
		w8.Fill = false;
		// Container child vbox.Gtk.Box+BoxChild
		this.hbox8 = new global::Gtk.HBox ();
		this.hbox8.Name = "hbox8";
		this.hbox8.Spacing = 6;
		// Container child hbox8.Gtk.Box+BoxChild
		this.radiobutton1 = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Simulated Drones"));
		this.radiobutton1.CanFocus = true;
		this.radiobutton1.Name = "radiobutton1";
		this.radiobutton1.DrawIndicator = true;
		this.radiobutton1.UseUnderline = true;
		this.radiobutton1.Group = new global::GLib.SList (global::System.IntPtr.Zero);
		this.hbox8.Add (this.radiobutton1);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.radiobutton1]));
		w9.Position = 0;
		w9.Expand = false;
		// Container child hbox8.Gtk.Box+BoxChild
		this.radiobutton2 = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Physical Drones"));
		this.radiobutton2.CanFocus = true;
		this.radiobutton2.Name = "radiobutton2";
		this.radiobutton2.DrawIndicator = true;
		this.radiobutton2.UseUnderline = true;
		this.radiobutton2.Group = this.radiobutton1.Group;
		this.hbox8.Add (this.radiobutton2);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.radiobutton2]));
		w10.Position = 1;
		w10.Expand = false;
		// Container child hbox8.Gtk.Box+BoxChild
		this.alignment9 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
		this.alignment9.Name = "alignment9";
		this.hbox8.Add (this.alignment9);
		global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.alignment9]));
		w11.Position = 2;
		this.vbox.Add (this.hbox8);
		global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox [this.hbox8]));
		w12.Position = 1;
		w12.Expand = false;
		w12.Fill = false;
		// Container child vbox.Gtk.Box+BoxChild
		this.hbox2 = new global::Gtk.HBox ();
		this.hbox2.Name = "hbox2";
		this.hbox2.Spacing = 6;
		// Container child hbox2.Gtk.Box+BoxChild
		this.label3 = new global::Gtk.Label ();
		this.label3.Name = "label3";
		this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Scenario");
		this.hbox2.Add (this.label3);
		global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label3]));
		w13.Position = 0;
		w13.Expand = false;
		w13.Fill = false;
		// Container child hbox2.Gtk.Box+BoxChild
		this.combobox1 = global::Gtk.ComboBox.NewText ();
		this.combobox1.Name = "combobox1";
		this.hbox2.Add (this.combobox1);
		global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.combobox1]));
		w14.Position = 1;
		w14.Expand = false;
		w14.Fill = false;
		this.vbox.Add (this.hbox2);
		global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox [this.hbox2]));
		w15.Position = 2;
		w15.Expand = false;
		w15.Fill = false;
		// Container child vbox.Gtk.Box+BoxChild
		this.frame1 = new global::Gtk.Frame ();
		this.frame1.Name = "frame1";
		this.frame1.BorderWidth = ((uint)(1));
		// Container child frame1.Gtk.Container+ContainerChild
		this.GtkAlignment = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
		this.GtkAlignment.Name = "GtkAlignment";
		this.GtkAlignment.LeftPadding = ((uint)(12));
		// Container child GtkAlignment.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox3 = new global::Gtk.HBox ();
		this.hbox3.Name = "hbox3";
		this.hbox3.Spacing = 6;
		// Container child hbox3.Gtk.Box+BoxChild
		this.label4 = new global::Gtk.Label ();
		this.label4.Name = "label4";
		this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Safe House Pos");
		this.hbox3.Add (this.label4);
		global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.label4]));
		w16.Position = 0;
		w16.Expand = false;
		w16.Fill = false;
		// Container child hbox3.Gtk.Box+BoxChild
		this.entry3 = new global::Gtk.Entry ();
		this.entry3.CanFocus = true;
		this.entry3.Name = "entry3";
		this.entry3.IsEditable = true;
		this.entry3.WidthChars = 2;
		this.entry3.MaxLength = 2;
		this.entry3.InvisibleChar = '●';
		this.hbox3.Add (this.entry3);
		global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.entry3]));
		w17.Position = 1;
		w17.Expand = false;
		// Container child hbox3.Gtk.Box+BoxChild
		this.label5 = new global::Gtk.Label ();
		this.label5.Name = "label5";
		this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("X");
		this.hbox3.Add (this.label5);
		global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.label5]));
		w18.Position = 2;
		w18.Expand = false;
		w18.Fill = false;
		// Container child hbox3.Gtk.Box+BoxChild
		this.entry4 = new global::Gtk.Entry ();
		this.entry4.CanFocus = true;
		this.entry4.Name = "entry4";
		this.entry4.IsEditable = true;
		this.entry4.WidthChars = 2;
		this.entry4.MaxLength = 2;
		this.entry4.InvisibleChar = '●';
		this.hbox3.Add (this.entry4);
		global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.entry4]));
		w19.Position = 3;
		w19.Expand = false;
		// Container child hbox3.Gtk.Box+BoxChild
		this.alignment4 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
		this.alignment4.Name = "alignment4";
		this.hbox3.Add (this.alignment4);
		global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.alignment4]));
		w20.Position = 4;
		this.vbox1.Add (this.hbox3);
		global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox3]));
		w21.Position = 0;
		w21.Expand = false;
		w21.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox9 = new global::Gtk.HBox ();
		this.hbox9.Name = "hbox9";
		this.hbox9.Spacing = 6;
		// Container child hbox9.Gtk.Box+BoxChild
		this.label13 = new global::Gtk.Label ();
		this.label13.Name = "label13";
		this.label13.LabelProp = global::Mono.Unix.Catalog.GetString ("Max Moves");
		this.hbox9.Add (this.label13);
		global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox9 [this.label13]));
		w22.Position = 0;
		w22.Expand = false;
		w22.Fill = false;
		// Container child hbox9.Gtk.Box+BoxChild
		this.entry11 = new global::Gtk.Entry ();
		this.entry11.CanFocus = true;
		this.entry11.Name = "entry11";
		this.entry11.IsEditable = true;
		this.entry11.WidthChars = 3;
		this.entry11.MaxLength = 3;
		this.entry11.InvisibleChar = '●';
		this.hbox9.Add (this.entry11);
		global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.hbox9 [this.entry11]));
		w23.Position = 1;
		w23.Expand = false;
		// Container child hbox9.Gtk.Box+BoxChild
		this.alignment10 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
		this.alignment10.Name = "alignment10";
		this.hbox9.Add (this.alignment10);
		global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.hbox9 [this.alignment10]));
		w24.Position = 2;
		this.vbox1.Add (this.hbox9);
		global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox9]));
		w25.Position = 1;
		w25.Expand = false;
		w25.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.frame2 = new global::Gtk.Frame ();
		this.frame2.Name = "frame2";
		this.frame2.BorderWidth = ((uint)(1));
		// Container child frame2.Gtk.Container+ContainerChild
		this.GtkAlignment1 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
		this.GtkAlignment1.Name = "GtkAlignment1";
		this.GtkAlignment1.LeftPadding = ((uint)(12));
		// Container child GtkAlignment1.Gtk.Container+ContainerChild
		this.vbox2 = new global::Gtk.VBox ();
		this.vbox2.Name = "vbox2";
		this.vbox2.Spacing = 6;
		// Container child vbox2.Gtk.Box+BoxChild
		this.hbox4 = new global::Gtk.HBox ();
		this.hbox4.Name = "hbox4";
		this.hbox4.Spacing = 6;
		// Container child hbox4.Gtk.Box+BoxChild
		this.label8 = new global::Gtk.Label ();
		this.label8.Name = "label8";
		this.label8.LabelProp = global::Mono.Unix.Catalog.GetString ("Fugitive");
		this.hbox4.Add (this.label8);
		global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.label8]));
		w26.Position = 0;
		w26.Expand = false;
		w26.Fill = false;
		// Container child hbox4.Gtk.Box+BoxChild
		this.combobox5 = global::Gtk.ComboBox.NewText ();
		this.combobox5.Name = "combobox5";
		this.hbox4.Add (this.combobox5);
		global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.combobox5]));
		w27.Position = 1;
		w27.Expand = false;
		w27.Fill = false;
		// Container child hbox4.Gtk.Box+BoxChild
		this.entry5 = new global::Gtk.Entry ();
		this.entry5.CanFocus = true;
		this.entry5.Name = "entry5";
		this.entry5.IsEditable = true;
		this.entry5.WidthChars = 2;
		this.entry5.MaxLength = 2;
		this.entry5.InvisibleChar = '●';
		this.hbox4.Add (this.entry5);
		global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.entry5]));
		w28.Position = 2;
		w28.Expand = false;
		// Container child hbox4.Gtk.Box+BoxChild
		this.label7 = new global::Gtk.Label ();
		this.label7.Name = "label7";
		this.label7.LabelProp = global::Mono.Unix.Catalog.GetString ("X");
		this.hbox4.Add (this.label7);
		global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.label7]));
		w29.Position = 3;
		w29.Expand = false;
		w29.Fill = false;
		// Container child hbox4.Gtk.Box+BoxChild
		this.entry6 = new global::Gtk.Entry ();
		this.entry6.CanFocus = true;
		this.entry6.Name = "entry6";
		this.entry6.IsEditable = true;
		this.entry6.WidthChars = 2;
		this.entry6.MaxLength = 2;
		this.entry6.InvisibleChar = '●';
		this.hbox4.Add (this.entry6);
		global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.entry6]));
		w30.Position = 4;
		w30.Expand = false;
		// Container child hbox4.Gtk.Box+BoxChild
		this.alignment5 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
		this.alignment5.Name = "alignment5";
		this.hbox4.Add (this.alignment5);
		global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.alignment5]));
		w31.Position = 5;
		this.vbox2.Add (this.hbox4);
		global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox4]));
		w32.Position = 0;
		w32.Expand = false;
		w32.Fill = false;
		// Container child vbox2.Gtk.Box+BoxChild
		this.hbox5 = new global::Gtk.HBox ();
		this.hbox5.Name = "hbox5";
		this.hbox5.Spacing = 6;
		// Container child hbox5.Gtk.Box+BoxChild
		this.label10 = new global::Gtk.Label ();
		this.label10.Name = "label10";
		this.label10.LabelProp = global::Mono.Unix.Catalog.GetString ("UAV 1");
		this.hbox5.Add (this.label10);
		global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.label10]));
		w33.Position = 0;
		w33.Expand = false;
		w33.Fill = false;
		// Container child hbox5.Gtk.Box+BoxChild
		this.combobox6 = global::Gtk.ComboBox.NewText ();
		this.combobox6.Name = "combobox6";
		this.hbox5.Add (this.combobox6);
		global::Gtk.Box.BoxChild w34 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.combobox6]));
		w34.Position = 1;
		w34.Expand = false;
		w34.Fill = false;
		// Container child hbox5.Gtk.Box+BoxChild
		this.entry7 = new global::Gtk.Entry ();
		this.entry7.CanFocus = true;
		this.entry7.Name = "entry7";
		this.entry7.IsEditable = true;
		this.entry7.WidthChars = 2;
		this.entry7.MaxLength = 2;
		this.entry7.InvisibleChar = '●';
		this.hbox5.Add (this.entry7);
		global::Gtk.Box.BoxChild w35 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.entry7]));
		w35.Position = 2;
		w35.Expand = false;
		// Container child hbox5.Gtk.Box+BoxChild
		this.label9 = new global::Gtk.Label ();
		this.label9.Name = "label9";
		this.label9.LabelProp = global::Mono.Unix.Catalog.GetString ("X");
		this.hbox5.Add (this.label9);
		global::Gtk.Box.BoxChild w36 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.label9]));
		w36.Position = 3;
		w36.Expand = false;
		w36.Fill = false;
		// Container child hbox5.Gtk.Box+BoxChild
		this.entry8 = new global::Gtk.Entry ();
		this.entry8.CanFocus = true;
		this.entry8.Name = "entry8";
		this.entry8.IsEditable = true;
		this.entry8.WidthChars = 2;
		this.entry8.MaxLength = 2;
		this.entry8.InvisibleChar = '●';
		this.hbox5.Add (this.entry8);
		global::Gtk.Box.BoxChild w37 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.entry8]));
		w37.Position = 4;
		w37.Expand = false;
		// Container child hbox5.Gtk.Box+BoxChild
		this.alignment6 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
		this.alignment6.Name = "alignment6";
		this.hbox5.Add (this.alignment6);
		global::Gtk.Box.BoxChild w38 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.alignment6]));
		w38.Position = 5;
		this.vbox2.Add (this.hbox5);
		global::Gtk.Box.BoxChild w39 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox5]));
		w39.Position = 1;
		w39.Expand = false;
		w39.Fill = false;
		// Container child vbox2.Gtk.Box+BoxChild
		this.hbox6 = new global::Gtk.HBox ();
		this.hbox6.Name = "hbox6";
		this.hbox6.Spacing = 6;
		// Container child hbox6.Gtk.Box+BoxChild
		this.label12 = new global::Gtk.Label ();
		this.label12.Name = "label12";
		this.label12.LabelProp = global::Mono.Unix.Catalog.GetString ("UAV 2");
		this.hbox6.Add (this.label12);
		global::Gtk.Box.BoxChild w40 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.label12]));
		w40.Position = 0;
		w40.Expand = false;
		w40.Fill = false;
		// Container child hbox6.Gtk.Box+BoxChild
		this.combobox7 = global::Gtk.ComboBox.NewText ();
		this.combobox7.Name = "combobox7";
		this.hbox6.Add (this.combobox7);
		global::Gtk.Box.BoxChild w41 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.combobox7]));
		w41.Position = 1;
		w41.Expand = false;
		w41.Fill = false;
		// Container child hbox6.Gtk.Box+BoxChild
		this.entry9 = new global::Gtk.Entry ();
		this.entry9.CanFocus = true;
		this.entry9.Name = "entry9";
		this.entry9.IsEditable = true;
		this.entry9.WidthChars = 2;
		this.entry9.MaxLength = 2;
		this.entry9.InvisibleChar = '●';
		this.hbox6.Add (this.entry9);
		global::Gtk.Box.BoxChild w42 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.entry9]));
		w42.Position = 2;
		w42.Expand = false;
		// Container child hbox6.Gtk.Box+BoxChild
		this.label11 = new global::Gtk.Label ();
		this.label11.Name = "label11";
		this.label11.LabelProp = global::Mono.Unix.Catalog.GetString ("X");
		this.hbox6.Add (this.label11);
		global::Gtk.Box.BoxChild w43 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.label11]));
		w43.Position = 3;
		w43.Expand = false;
		w43.Fill = false;
		// Container child hbox6.Gtk.Box+BoxChild
		this.entry10 = new global::Gtk.Entry ();
		this.entry10.CanFocus = true;
		this.entry10.Name = "entry10";
		this.entry10.IsEditable = true;
		this.entry10.WidthChars = 2;
		this.entry10.MaxLength = 2;
		this.entry10.InvisibleChar = '●';
		this.hbox6.Add (this.entry10);
		global::Gtk.Box.BoxChild w44 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.entry10]));
		w44.Position = 4;
		w44.Expand = false;
		// Container child hbox6.Gtk.Box+BoxChild
		this.alignment7 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
		this.alignment7.Name = "alignment7";
		this.hbox6.Add (this.alignment7);
		global::Gtk.Box.BoxChild w45 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.alignment7]));
		w45.Position = 5;
		this.vbox2.Add (this.hbox6);
		global::Gtk.Box.BoxChild w46 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox6]));
		w46.Position = 2;
		w46.Expand = false;
		w46.Fill = false;
		this.GtkAlignment1.Add (this.vbox2);
		this.frame2.Add (this.GtkAlignment1);
		this.GtkLabel3 = new global::Gtk.Label ();
		this.GtkLabel3.Name = "GtkLabel3";
		this.GtkLabel3.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Start Positions</b>");
		this.GtkLabel3.UseMarkup = true;
		this.frame2.LabelWidget = this.GtkLabel3;
		this.vbox1.Add (this.frame2);
		global::Gtk.Box.BoxChild w49 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.frame2]));
		w49.Position = 2;
		w49.Expand = false;
		w49.Fill = false;
		this.GtkAlignment.Add (this.vbox1);
		this.frame1.Add (this.GtkAlignment);
		this.GtkLabel4 = new global::Gtk.Label ();
		this.GtkLabel4.Name = "GtkLabel4";
		this.GtkLabel4.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Scenario Settings</b>");
		this.GtkLabel4.UseMarkup = true;
		this.frame1.LabelWidget = this.GtkLabel4;
		this.vbox.Add (this.frame1);
		global::Gtk.Box.BoxChild w52 = ((global::Gtk.Box.BoxChild)(this.vbox [this.frame1]));
		w52.Position = 3;
		w52.Expand = false;
		w52.Fill = false;
		// Container child vbox.Gtk.Box+BoxChild
		this.alignment1 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
		this.alignment1.Name = "alignment1";
		this.vbox.Add (this.alignment1);
		global::Gtk.Box.BoxChild w53 = ((global::Gtk.Box.BoxChild)(this.vbox [this.alignment1]));
		w53.Position = 4;
		// Container child vbox.Gtk.Box+BoxChild
		this.hbox7 = new global::Gtk.HBox ();
		this.hbox7.Name = "hbox7";
		this.hbox7.Spacing = 6;
		// Container child hbox7.Gtk.Box+BoxChild
		this.alignment2 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
		this.alignment2.Name = "alignment2";
		this.hbox7.Add (this.alignment2);
		global::Gtk.Box.BoxChild w54 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.alignment2]));
		w54.Position = 0;
		// Container child hbox7.Gtk.Box+BoxChild
		this.button1 = new global::Gtk.Button ();
		this.button1.CanFocus = true;
		this.button1.Name = "button1";
		this.button1.UseUnderline = true;
		this.button1.Label = global::Mono.Unix.Catalog.GetString ("Launch");
		this.hbox7.Add (this.button1);
		global::Gtk.Box.BoxChild w55 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.button1]));
		w55.Position = 1;
		w55.Expand = false;
		w55.Fill = false;
		this.vbox.Add (this.hbox7);
		global::Gtk.Box.BoxChild w56 = ((global::Gtk.Box.BoxChild)(this.vbox [this.hbox7]));
		w56.PackType = ((global::Gtk.PackType)(1));
		w56.Position = 5;
		w56.Expand = false;
		w56.Fill = false;
		this.hpaned1.Add (this.vbox);
		global::Gtk.Paned.PanedChild w57 = ((global::Gtk.Paned.PanedChild)(this.hpaned1 [this.vbox]));
		w57.Resize = false;
		this.vbox0.Add (this.hpaned1);
		global::Gtk.Box.BoxChild w58 = ((global::Gtk.Box.BoxChild)(this.vbox0 [this.hpaned1]));
		w58.Position = 1;
		this.Add (this.vbox0);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 1162;
		this.DefaultHeight = 744;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
	}
}
