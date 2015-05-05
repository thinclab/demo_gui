using System;
using Gtk;
using System.Diagnostics;
using demo_gui;
using System.IO;
using System.Collections.Generic;


public struct PolicyNode {
	public uint nestingNum;
	public uint verticalNum;
	public Gtk.ComboBox action;
	public List<Gtk.Label> obsLabels;
	public List<PolicyNode> children;
	public PolicyTreeNode dataRef;
}

public partial class MainWindow: Gtk.Window
{
	protected string file_path;

	public string[] fugitive_actions = {"Move North", "Move South", "Move East", "Move West", "Stay"};
	public string[] anti_coord_actions = {"Move North", "Move South", "Move East", "Move West", "Land"};
	public string[] coord_actions = {"Move North", "Move South", "Move East", "Move West", "Land", "Stay"};

	public string[] fugitive_observations = {"Enemy North", "Enemy South", "Enemy East", "Enemy West"};
	public string[] anti_coord_observations = {"Other North", "Other South", "Other East", "Other West"};

	protected string editor_file;

	PolicyTree policyTree;

	PolicyNode visPolicyTree;

	int verticalSize = 40;
	int nestingSize = 100;

	Random rnd;

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		rnd = new Random ();
		file_path = Directory.GetCurrentDirectory () + "/../../../gatacdronecontrol/bin/";
		Build ();

		init_controls ();
		visPolicyTree = createRandomPolicyDisplay (uint.Parse(num_decisions.Text));
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

		coord_uav1_row.Text = "1";
		coord_uav1_col.Text = "0";

		coord_uav2_row.Text = "1";
		coord_uav2_col.Text = "2";

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

	protected void uav1_control_changed  (object sender, EventArgs e)
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

		if (cbo_scenario.Active == 0) {
			if (!check_fugitive ())
				return;
		} else {
			if (!check_coordination ())
				return;
		}

		launch_demo ();
	}

	protected bool check_fugitive() 
	{

		// Check all parameters here
		switch (cbo_fug_mode.Active) 
		{
		case 0:
			// policy file
			if (filechsr_fugitive.Filename == null) {
				show_error ("You must choose a policy file for the fugitive before launching");
				return false;
			}
			break;
		case 1:
			// editor policy
			if (editor_file == null) {
				show_error ("You must save the editor policy for the fugitive before launching");
				return false;
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
			return false;
			break;
		}
		if (int.Parse (fug_row.Text) < 0 || int.Parse (fug_row.Text) >= int.Parse (grid_size_rows.Text)) {
			show_error("Starting row position for the fugitive is invalid.");
			return false;
		}
		if (int.Parse (fug_col.Text) < 0 || int.Parse (fug_col.Text) >= int.Parse (grid_size_cols.Text)) {
			show_error("Starting column position for the fugitive is invalid.");
			return false;
		}

		switch (cbo_uav1_mode.Active) 
		{
		case 0:
			// policy file
			if (filechsr_uav1.Filename == null) {
				show_error ("You must choose a policy file for UAV1 before launching");
				return false;
			}
			break;
		case 1:
			// editor policy
			if (editor_file == null) {
				show_error ("You must save the editor policy for UAV1 before launching");
				return false;
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
			return false;
			break;
		}
		if (int.Parse (uav1_row.Text) < 0 || int.Parse (uav1_row.Text) >= int.Parse (grid_size_rows.Text)) {
			show_error("Starting row position for UAV1 is invalid.");
			return false;
		}
		if (int.Parse (uav1_col.Text) < 0 || int.Parse (uav1_col.Text) >= int.Parse (grid_size_cols.Text)) {
			show_error("Starting column position for UAV1 is invalid.");
			return false;
		}


		switch (cbo_uav2_mode.Active) 
		{
		case 0:
			// policy file
			if (filechsr_uav2.Filename == null) {
				show_error ("You must choose a policy file for UAV2 before launching");
				return false;
			}
			break;
		case 1:
			// editor policy
			if (editor_file == null) {
				show_error ("You must save the editor policy for UAV2 before launching");
				return false;
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
			return false;
			break;
		}
		if (int.Parse (uav2_row.Text) < 0 || int.Parse (uav2_row.Text) >= int.Parse (grid_size_rows.Text)) {
			show_error("Starting row position for UAV2 is invalid.");
			return false;
		}
		if (int.Parse (uav2_col.Text) < 0 || int.Parse (uav2_col.Text) >= int.Parse (grid_size_cols.Text)) {
			show_error("Starting column position for UAV2 is invalid.");
			return false;
		}

		return true;
	}

	protected bool check_coordination() 
	{
		// Check all parameters here

		switch (cbo_coord_uav1_mode.Active) 
		{
		case 0:
			// policy file
			if (filechsr_coord_uav1.Filename == null) {
				show_error ("You must choose a policy file for UAV1 before launching");
				return false;
			}
			break;
		case 1:
			// editor policy
			if (editor_file == null) {
				show_error ("You must save the editor policy for UAV1 before launching");
				return false;
			}
			break;
		case 2:
			// keyboard
			break;
		default:
			show_error ("You must select a control for UAV1.");
			return false;
			break;
		}
		if (int.Parse (coord_uav1_row.Text) < 0 || int.Parse (coord_uav1_row.Text) >= int.Parse (grid_size_rows.Text)) {
			show_error("Starting row position for UAV1 is invalid.");
			return false;
		}
		if (int.Parse (coord_uav1_col.Text) < 0 || int.Parse (coord_uav1_col.Text) >= int.Parse (grid_size_cols.Text)) {
			show_error("Starting column position for UAV1 is invalid.");
			return false;
		}


		switch (cbo_coord_uav2_mode.Active) 
		{
		case 0:
			// policy file
			if (filechsr_coord_uav2.Filename == null) {
				show_error ("You must choose a policy file for UAV2 before launching");
				return false;
			}
			break;
		case 1:
			// editor policy
			if (editor_file == null) {
				show_error ("You must save the editor policy for UAV2 before launching");
				return false;
			}
			break;
		case 2:
			// keyboard
			break;
		default:
			show_error ("You must select a control for UAV2.");
			return false;
			break;
		}
		if (int.Parse (coord_uav2_row.Text) < 0 || int.Parse (coord_uav2_row.Text) >= int.Parse (grid_size_rows.Text)) {
			show_error("Starting row position for UAV2 is invalid.");
			return false;
		}
		if (int.Parse (coord_uav2_col.Text) < 0 || int.Parse (coord_uav2_col.Text) >= int.Parse (grid_size_cols.Text)) {
			show_error("Starting column position for UAV2 is invalid.");
			return false;
		}

		return true;
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
		if (cbo_scenario.Active == 0)
			launch_fugitive_demo ();
		else
			launch_coordination_demo ();

	}


	public void launch_fugitive_demo() 
	{

		// start server
		string args = "-e \'/bin/bash -l -c \"" + file_path + "server s 3\"\'";
		if (rdo_phys_drones.Active)
			args = "-e \'/bin/bash -l -c \"" + file_path + "server r 3\"\'";
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
			args += "fugitiveClient f " + grid_size_rows.Text + " " + grid_size_cols.Text + " " + fug_row.Text + " " + fug_col.Text + " " + safe_house_row.Text + " " + safe_house_col.Text + " \"" + filechsr_fugitive.Filename + "\"";
			break;
		case 1:
			// editor policy
			if (editor_file == null) {
				show_error ("You must save the editor policy for the fugitive before launching");
				return;
			}
			args += "fugitiveClient f " + grid_size_rows.Text + " " + grid_size_cols.Text + " " + fug_row.Text + " " + fug_col.Text + " " + safe_house_row.Text + " " + safe_house_col.Text  + " \"" + editor_file + "\"";
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

		System.Threading.Thread.Sleep (750);

		// parameters for drone1
		args = "-e '" + file_path;

		switch (cbo_uav1_mode.Active) 
		{
		case 0:
			// policy file
			if (filechsr_uav1.Filename == null) {
				show_error ("You must choose a policy file for UAV1 before launching");
				return;
			}
			args += "fugitiveClient u " + grid_size_rows.Text + " " + grid_size_cols.Text + " " + uav1_row.Text + " " + uav1_col.Text + " " + safe_house_row.Text + " " + safe_house_col.Text + " \"" + filechsr_uav1.Filename + "\"";
			break;
		case 1:
			// editor policy
			if (editor_file == null) {
				show_error ("You must save the editor policy for UAV1 before launching");
				return;
			}
			args += "fugitiveClient u " + grid_size_rows.Text + " " + grid_size_cols.Text + " " + uav1_row.Text + " " + uav1_col.Text + " " + safe_house_row.Text + " " + safe_house_col.Text + " \"" + editor_file + "\"";
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

		System.Threading.Thread.Sleep (750);

		// parameters for drone2
		args = "-e '" + file_path;

		switch (cbo_uav2_mode.Active) 
		{
		case 0:
			// policy file
			if (filechsr_uav2.Filename == null) {
				show_error ("You must choose a policy file for UAV2 before launching");
				return;
			}
			args += "fugitiveClient u " + grid_size_rows.Text + " " + grid_size_cols.Text + " " + uav2_row.Text + " " + uav2_col.Text + " " + safe_house_row.Text + " " + safe_house_col.Text + " \"" + filechsr_uav2.Filename + "\"";
			break;
		case 1:
			// editor policy
			if (editor_file == null) {
				show_error ("You must save the editor policy for UAV2 before launching");
				return;
			}
			args += "fugitiveClient u " + grid_size_rows.Text + " " + grid_size_cols.Text + " " + uav2_row.Text + " " + uav2_col.Text + " " + safe_house_row.Text + " " + safe_house_col.Text + " \"" + editor_file + "\"";
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


	public void launch_coordination_demo() 
	{

		// start server
		string args = "-e \'/bin/bash -l -c \"" + file_path + "server s 2\"\'";
		if (rdo_phys_drones.Active)
			args = "-e \'/bin/bash -l -c \"" + file_path + "server r 2\"\'";
		System.Diagnostics.Process.Start ("/usr/bin/gnome-terminal", args);

		System.Threading.Thread.Sleep (1000);

		// parameters for drone1
		args = "-e '" + file_path;

		switch (cbo_coord_uav1_mode.Active) 
		{
		case 0:
			// policy file
			if (filechsr_coord_uav1.Filename == null) {
				show_error ("You must choose a policy file for UAV1 before launching");
				return;
			}
			args += "anticoordClient " + grid_size_rows.Text + " " + grid_size_cols.Text + " " + coord_uav1_row.Text + " " + coord_uav1_col.Text + " \"" + filechsr_coord_uav1.Filename + "\"";
			break;
		case 1:
			// editor policy
			if (editor_file == null) {
				show_error ("You must save the editor policy for UAV1 before launching");
				return;
			}
			args += "anticoordClient " + grid_size_rows.Text + " " + grid_size_cols.Text + " " + coord_uav1_row.Text + " " + coord_uav1_col.Text + " \"" + editor_file + "\"";
			break;
		case 2:
			// keyboard
			args += "keyboard " + grid_size_rows.Text + " " + grid_size_cols.Text + " " + coord_uav1_row.Text + " " + coord_uav1_col.Text;
			break;
		default:
			show_error ("You must select a control for UAV1.");
			return;
			break;
		}
		args += "\'";
		System.Diagnostics.Process.Start ("/usr/bin/gnome-terminal", args);

		System.Threading.Thread.Sleep (750);

		// parameters for drone2
		args = "-e '" + file_path;

		switch (cbo_coord_uav2_mode.Active) 
		{
		case 0:
			// policy file
			if (filechsr_coord_uav2.Filename == null) {
				show_error ("You must choose a policy file for UAV2 before launching");
				return;
			}
			args += "anticoordClient " + grid_size_rows.Text + " " + grid_size_cols.Text + " " + coord_uav2_row.Text + " " + coord_uav2_col.Text + " \"" + filechsr_coord_uav2.Filename + "\"";
			break;
		case 1:
			// editor policy
			if (editor_file == null) {
				show_error ("You must save the editor policy for UAV2 before launching");
				return;
			}
			args += "anticoordClient " + grid_size_rows.Text + " " + grid_size_cols.Text + " " + coord_uav2_row.Text + " " + coord_uav2_col.Text + " \"" + editor_file + "\"";
			break;
		case 2:
			// keyboard
			args += "keyboard " + grid_size_rows.Text + " " + grid_size_cols.Text + " " + coord_uav2_row.Text + " " + coord_uav2_col.Text;
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
		clearPolicyDisplay (visPolicyTree);
		policyTree = new PolicyTree ();
		policyTree.readPolicyTree (p);
		visPolicyTree = buildPolicyDisplay ();
	}

	public string save_policy_to_string()
	{
		updatePolicyFromDisplay ();
		return policyTree.printTree ();
	}


	public void clearPolicyDisplay(PolicyNode node) {
		PolicyArea.Remove (node.action);
		node.action.Dispose ();
		foreach(Gtk.Label l in node.obsLabels) {
			PolicyArea.Remove (l);
			l.Dispose ();
		}

		foreach (PolicyNode p in node.children) {
			clearPolicyDisplay (p);
		}

	}

	public PolicyNode buildPolicyDisplay() {
		uint vertical = 0;
		return _buildPolicyDisplay (policyTree.root, 0, ref vertical);
	}

	public PolicyNode _buildPolicyDisplay(PolicyTreeNode data, uint nesting, ref uint vertical) {


		PolicyNode returnval = new PolicyNode ();
		returnval.nestingNum = nesting;
		returnval.verticalNum = vertical;
		returnval.children = new List<PolicyNode> ();
		returnval.obsLabels = new List<Label> ();
		returnval.dataRef = data;

		returnval.action = new ComboBox ();
		returnval.action = global::Gtk.ComboBox.NewText ();
		foreach(string s in getActions())
			returnval.action.AppendText (s);

		returnval.action.Name = "cbo_action" + nesting.ToString() + ":" + vertical.ToString();
		returnval.action.Active = data.action;
		this.PolicyArea.Put(returnval.action, (int)nesting * nestingSize, (int)vertical * verticalSize);
		returnval.action.Show ();

		for (int i = 0; i < data.children.Count; i++) {
			// create and place label for observation
			vertical++;

			Label lbl = new Gtk.Label ();
			lbl.Text = getObservations() [i];
			lbl.Name = "lbl_obs" + nesting.ToString () + ":" + vertical.ToString ();
			this.PolicyArea.Put (lbl, (int)nesting * nestingSize, (int)vertical * verticalSize);
			lbl.Show();
			returnval.obsLabels.Add (lbl);
			// recurse

			returnval.children.Add(_buildPolicyDisplay (data.children [i], nesting + 1, ref vertical));

		}
		return returnval;
	}


	public void updatePolicyFromDisplay() {
		_updatePolicyFromDisplay (visPolicyTree);
	}

	public void _updatePolicyFromDisplay(PolicyNode p) {

		p.dataRef.action = p.action.Active;

		foreach (PolicyNode ptn in p.children) {
			_updatePolicyFromDisplay (ptn);

		}
	}

	public PolicyNode createRandomPolicyDisplay(uint nesting = 0) {
	
		policyTree = new PolicyTree ();
		policyTree.horizon = nesting;
		policyTree.numObservations = (uint)getObservations().Length;

		policyTree.root = createRandomPolicy ((int)nesting);

		return buildPolicyDisplay ();

	}

	public PolicyTreeNode createRandomPolicy(int horizon) {
		PolicyTreeNode returnval = new PolicyTreeNode ((uint)getObservations().Length);
		returnval.action = rnd.Next (getActions().Length);
		returnval.horizon = horizon;

		if (horizon > 1) {
			for( int i = 0; i < getObservations().Length; i ++ ) {
				returnval.children.Add (createRandomPolicy (horizon - 1));
			}

		}
		return returnval;
	}

	protected string[] getActions() {
		switch (cbo_scenario.Active) {
		case 0:
			return fugitive_actions;
			break;

		case 1:
			return anti_coord_actions;
			break;

		default:
			return coord_actions;
			break;
		}
	}

	protected string[] getObservations() {
		return (cbo_scenario.Active == 0 ? fugitive_observations : anti_coord_observations);
	}
	protected void changed_decisions (object sender, EventArgs e)
	{
		try {
			if (editor_file == null) {
				// build a new random policy
				clearPolicyDisplay (visPolicyTree);
				policyTree = new PolicyTree ();
				visPolicyTree = createRandomPolicyDisplay (uint.Parse(num_decisions.Text));

			} else {
				mnu_save(sender, e);
				editor_file = null;
				clearPolicyDisplay (visPolicyTree);
				policyTree = new PolicyTree ();
				visPolicyTree = createRandomPolicyDisplay (uint.Parse(num_decisions.Text));

			}
		} catch (FormatException fe) {

		}

	}


	protected void change_scenario (object sender, EventArgs e)
	{
		changed_decisions(sender, e);

		switch (cbo_scenario.Active) {
		case 0:
			frame_fugitive_settings.Visible = true;
			frame_coord_settings.Visible = false;
			break;

		case 1:
			frame_fugitive_settings.Visible = false;
			frame_coord_settings.Visible = true;
			break;

		default:
			frame_fugitive_settings.Visible = false;
			frame_coord_settings.Visible = true;
			break;
		}


	}


	protected void coord_uav1_control_changed (object sender, EventArgs e)
	{
		if (cbo_coord_uav1_mode.Active == 0) {
			filechsr_coord_uav1.Visible = true;
		} else {
			filechsr_coord_uav1.Visible = false;
		}
	}

	protected void coord_uav2_control_changed (object sender, EventArgs e)
	{
		if (cbo_coord_uav2_mode.Active == 0) {
			filechsr_coord_uav2.Visible = true;
		} else {
			filechsr_coord_uav2.Visible = false;
		}
	}

}
