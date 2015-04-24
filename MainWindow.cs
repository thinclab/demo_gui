using System;
using Gtk;
using System.Diagnostics;
using demo_gui;
using System.IO;

public partial class MainWindow: Gtk.Window
{
	protected string file_path = "/home/kbogert/gatac_workspace/src/gatacdronecontrol/bin/";

	public string[] actions = {"Move North", "Move South", "Move East", "Move West", "Stay"};

	protected string editor_file;

	PolicyTree policyTree;


	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();

		policyTree = new PolicyTree ();
		init_controls ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected void on_quit (object sender, EventArgs e) {
		OnDeleteEvent (sender, null);
	}

	protected void init_controls() {

		grid_size_rows.Text = "5";
		grid_size_cols.Text = "5";

		safe_house_row.Text = "3";
		safe_house_col.Text = "2";

		fug_row.Text = "1";
		fug_col.Text = "2";

		uav1_row.Text = "2";
		uav1_col.Text = "1";

		uav2_row.Text = "1";
		uav2_col.Text = "4";

		max_moves.Text = "4";

	}

	protected void fugitive_control_changed (object sender, EventArgs e)
	{
		if (cbo_fug_mode.Active == 0) {
			filechsr_fugitive.Visible = true;
		} else {
			filechsr_fugitive.Visible = false;
		}
	}

	protected void uav1_control_changed (object sender, EventArgs e)
	{
		if (cbo_uav1_mode.Active == 0) {
			filechsr_uav1.Visible = true;
		} else {
			filechsr_uav1.Visible = false;
		}
	}

	protected void uav2_control_changed (object sender, EventArgs e)
	{
		if (cbo_uav2_mode.Active == 0) {
			filechsr_uav2.Visible = true;
		} else {
			filechsr_uav2.Visible = false;
		}
	}
	protected void mnu_open (object sender, EventArgs e)
	{
		Gtk.FileChooserDialog fc=
			new Gtk.FileChooserDialog("Choose the file to open",
				this,
				FileChooserAction.Open,
				"Cancel",ResponseType.Cancel,
				"Open",ResponseType.Accept);

		if (fc.Run() == (int)ResponseType.Accept) 
		{
			System.IO.StreamReader file = new System.IO.StreamReader(fc.Filename);
			load_policy_from_File (file);
			file.Close();

			editor_file = fc.Filename;
		}
		fc.Destroy();
	}

	protected void mnu_save (object sender, EventArgs e)
	{
		if (editor_file != null) {
			string policy_string = save_policy_to_string ();

			System.IO.StreamWriter file = new System.IO.StreamWriter (editor_file);
			file.Write (policy_string);
			file.Close ();

			return;
		}


		Gtk.FileChooserDialog fc=
			new Gtk.FileChooserDialog("Choose the file to save",
				this,
				FileChooserAction.Save,
				"Cancel",ResponseType.Cancel,
				"Save",ResponseType.Accept);

		if (fc.Run () == (int)ResponseType.Accept) {
			string policy_string = save_policy_to_string ();

			System.IO.StreamWriter file = new System.IO.StreamWriter (fc.Filename);
			file.Write (policy_string);
			file.Close ();

			editor_file = fc.Filename;
		}
		fc.Destroy ();

	}

	protected void launch_button (object sender, EventArgs e)
	{

		// Check all parameters here
		switch (cbo_fug_mode.Active) 
		{
		case 0:
			// policy file
			if (filechsr_fugitive.Filename == null) {
				show_error ("You must choose a policy file for the fugitive before launching");
				return;
			}
			break;
		case 1:
			// editor policy
			if (editor_file == null) {
				show_error ("You must save the editor policy for the fugitive before launching");
				return;
			}
			break;
		case 2:
			// random
			break;
		case 3:
			// keyboard
			break;
		default:
			show_error ("You must select a control for the fugitive.");
			return;
			break;
		}
		if (int.Parse (fug_row.Text) < 0 || int.Parse (fug_row.Text) >= int.Parse (grid_size_rows.Text)) {
			show_error("Starting row position for the fugitive is invalid.");
			return;
		}
		if (int.Parse (fug_col.Text) < 0 || int.Parse (fug_col.Text) >= int.Parse (grid_size_cols.Text)) {
			show_error("Starting column position for the fugitive is invalid.");
			return;
		}

		switch (cbo_uav1_mode.Active) 
		{
		case 0:
			// policy file
			if (filechsr_uav1.Filename == null) {
				show_error ("You must choose a policy file for UAV1 before launching");
				return;
			}
			break;
		case 1:
			// editor policy
			if (editor_file == null) {
				show_error ("You must save the editor policy for UAV1 before launching");
				return;
			}
			break;
		case 2:
			// random
			break;
		case 3:
			// keyboard
			break;
		default:
			show_error ("You must select a control for UAV1.");
			return;
			break;
		}
		if (int.Parse (uav1_row.Text) < 0 || int.Parse (uav1_row.Text) >= int.Parse (grid_size_rows.Text)) {
			show_error("Starting row position for UAV1 is invalid.");
			return;
		}
		if (int.Parse (uav1_col.Text) < 0 || int.Parse (uav1_col.Text) >= int.Parse (grid_size_cols.Text)) {
			show_error("Starting column position for UAV1 is invalid.");
			return;
		}


		switch (cbo_uav2_mode.Active) 
		{
		case 0:
			// policy file
			if (filechsr_uav2.Filename == null) {
				show_error ("You must choose a policy file for UAV2 before launching");
				return;
			}
			break;
		case 1:
			// editor policy
			if (editor_file == null) {
				show_error ("You must save the editor policy for UAV2 before launching");
				return;
			}
			break;
		case 2:
			// random
			break;
		case 3:
			// keyboard
			break;
		default:
			show_error ("You must select a control for UAV2.");
			return;
			break;
		}
		if (int.Parse (uav2_row.Text) < 0 || int.Parse (uav2_row.Text) >= int.Parse (grid_size_rows.Text)) {
			show_error("Starting row position for UAV2 is invalid.");
			return;
		}
		if (int.Parse (uav2_col.Text) < 0 || int.Parse (uav2_col.Text) >= int.Parse (grid_size_cols.Text)) {
			show_error("Starting column position for UAV2 is invalid.");
			return;
		}

		launch_demo ();
	}

	public void show_error(string errormsg)
	{
		MessageDialog md = new MessageDialog (this, 
			DialogFlags.DestroyWithParent, MessageType.Error, 
			ButtonsType.Close, errormsg);
		md.Run();
		md.Destroy();
	}

	public void launch_demo() 
	{


		// start server
//		string args = "-e \'/bin/bash -c \"export BASH_POST_RC=\\\"" + file_path + "simServerThree\\\"; exec bash\"\'";
		string args = "-e \'/bin/bash -l -c \"" + file_path + "simServerThree\"\'";
		System.Diagnostics.Process.Start ("/usr/bin/gnome-terminal", args);

		System.Threading.Thread.Sleep (1000);

		// parameters for fugitive
		args = "-e '" + file_path;

		switch (cbo_fug_mode.Active) 
		{
		case 0:
			// policy file
			if (filechsr_fugitive.Filename == null) {
				show_error ("You must choose a policy file for the fugitive before launching");
				return;
			}
			args += "policyClient f " + grid_size_rows.Text + " " + grid_size_cols.Text + " " + fug_row.Text + " " + fug_col.Text + " " + max_moves.Text + " \"" + filechsr_fugitive.Filename + "\"";
			break;
		case 1:
			// editor policy
			if (editor_file == null) {
				show_error ("You must save the editor policy for the fugitive before launching");
				return;
			}
			args += "policyClient f " + grid_size_rows.Text + " " + grid_size_cols.Text + " " + fug_row.Text + " " + fug_col.Text + " " + max_moves.Text + " \"" + editor_file + "\"";
			break;
		case 2:
			// random
			args += "random " + grid_size_rows.Text + " " + grid_size_cols.Text + " " + fug_row.Text + " " + fug_col.Text + " " + max_moves.Text;
			break;
		case 3:
			// keyboard
			args += "keyboard " + grid_size_rows.Text + " " + grid_size_cols.Text + " " + fug_row.Text + " " + fug_col.Text;
			break;
		default:
			show_error ("You must select a control for the fugitive.");
			return;
			break;
		}
		args += "\'";
		System.Diagnostics.Process.Start ("/usr/bin/gnome-terminal", args);


		// parameters for drone1
		args = "-e '" + file_path;

		switch (cbo_uav1_mode.Active) 
		{
		case 0:
			// policy file
			if (filechsr_fugitive.Filename == null) {
				show_error ("You must choose a policy file for UAV1 before launching");
				return;
			}
			args += "policyClient u " + grid_size_rows.Text + " " + grid_size_cols.Text + " " + uav1_row.Text + " " + uav1_col.Text + " " + max_moves.Text + " \"" + filechsr_uav1.Filename + "\"";
			break;
		case 1:
			// editor policy
			if (editor_file == null) {
				show_error ("You must save the editor policy for UAV1 before launching");
				return;
			}
			args += "policyClient u " + grid_size_rows.Text + " " + grid_size_cols.Text + " " + uav1_row.Text + " " + uav1_col.Text + " " + max_moves.Text + " \"" + editor_file + "\"";
			break;
		case 2:
			// random
			args += "random " + grid_size_rows.Text + " " + grid_size_cols.Text + " " + uav1_row.Text + " " + uav1_col.Text + " " + max_moves.Text;
			break;
		case 3:
			// keyboard
			args += "keyboard " + grid_size_rows.Text + " " + grid_size_cols.Text + " " + uav1_row.Text + " " + uav1_col.Text;
			break;
		default:
			show_error ("You must select a control for UAV1.");
			return;
			break;
		}
		args += "\'";
		System.Diagnostics.Process.Start ("/usr/bin/gnome-terminal", args);


		// parameters for drone2
		args = "-e '" + file_path;

		switch (cbo_uav2_mode.Active) 
		{
		case 0:
			// policy file
			if (filechsr_fugitive.Filename == null) {
				show_error ("You must choose a policy file for UAV2 before launching");
				return;
			}
			args += "policyClient u " + grid_size_rows.Text + " " + grid_size_cols.Text + " " + uav2_row.Text + " " + uav2_col.Text + " " + max_moves.Text + " \"" + filechsr_uav1.Filename + "\"";
			break;
		case 1:
			// editor policy
			if (editor_file == null) {
				show_error ("You must save the editor policy for UAV2 before launching");
				return;
			}
			args += "policyClient u " + grid_size_rows.Text + " " + grid_size_cols.Text + " " + uav2_row.Text + " " + uav2_col.Text + " " + max_moves.Text + " \"" + editor_file + "\"";
			break;
		case 2:
			// random
			args += "random " + grid_size_rows.Text + " " + grid_size_cols.Text + " " + uav2_row.Text + " " + uav2_col.Text + " " + max_moves.Text;
			break;
		case 3:
			// keyboard
			args += "keyboard " + grid_size_rows.Text + " " + grid_size_cols.Text + " " + uav2_row.Text + " " + uav2_col.Text;
			break;
		default:
			show_error ("You must select a control for UAV2.");
			return;
			break;
		}
		args += "\'";
		System.Diagnostics.Process.Start ("/usr/bin/gnome-terminal", args);
	}

	public void load_policy_from_File(StreamReader p)
	{
		policyTree.readPolicyTree (p);

	}

	public string save_policy_to_string()
	{
		return policyTree.printTree ();
	}
}
