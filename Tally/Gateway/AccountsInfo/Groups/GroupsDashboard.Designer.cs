namespace Tally.Gateway.AccountsInfo.Groups;

partial class GroupsDashboard
{
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
		createGroupButton = new Button();
		deleteGroupButton = new Button();
		alterGroupButton = new Button();
		groupsListBox = new ListBox();
		SuspendLayout();
		// 
		// createGroupButton
		// 
		createGroupButton.Location = new Point(319, 12);
		createGroupButton.Name = "createGroupButton";
		createGroupButton.Size = new Size(200, 75);
		createGroupButton.TabIndex = 0;
		createGroupButton.Text = "Create";
		createGroupButton.UseVisualStyleBackColor = true;
		createGroupButton.Click += createGroupButton_Click;
		// 
		// deleteGroupButton
		// 
		deleteGroupButton.Location = new Point(319, 174);
		deleteGroupButton.Name = "deleteGroupButton";
		deleteGroupButton.Size = new Size(200, 75);
		deleteGroupButton.TabIndex = 1;
		deleteGroupButton.Text = "Delete";
		deleteGroupButton.UseVisualStyleBackColor = true;
		deleteGroupButton.Click += deleteGroupButton_Click;
		// 
		// alterGroupButton
		// 
		alterGroupButton.Location = new Point(319, 93);
		alterGroupButton.Name = "alterGroupButton";
		alterGroupButton.Size = new Size(200, 75);
		alterGroupButton.TabIndex = 2;
		alterGroupButton.Text = "Alter";
		alterGroupButton.UseVisualStyleBackColor = true;
		alterGroupButton.Click += alterGroupButton_Click;
		// 
		// groupsListBox
		// 
		groupsListBox.FormattingEnabled = true;
		groupsListBox.ItemHeight = 15;
		groupsListBox.Location = new Point(12, 12);
		groupsListBox.Name = "groupsListBox";
		groupsListBox.Size = new Size(282, 649);
		groupsListBox.TabIndex = 3;
		// 
		// GroupsDashboard
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(534, 681);
		Controls.Add(groupsListBox);
		Controls.Add(alterGroupButton);
		Controls.Add(deleteGroupButton);
		Controls.Add(createGroupButton);
		Name = "GroupsDashboard";
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Groups";
		FormClosed += GroupsDashboard_FormClosed;
		ResumeLayout(false);
	}

	#endregion

	private Button createGroupButton;
	private Button deleteGroupButton;
	private Button alterGroupButton;
	public ListBox groupsListBox;
}