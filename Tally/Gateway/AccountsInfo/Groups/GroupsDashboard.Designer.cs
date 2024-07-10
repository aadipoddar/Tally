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
		displayGroupButton = new Button();
		alterGroupButton = new Button();
		SuspendLayout();
		// 
		// createGroupButton
		// 
		createGroupButton.Location = new Point(119, 32);
		createGroupButton.Name = "createGroupButton";
		createGroupButton.Size = new Size(75, 23);
		createGroupButton.TabIndex = 0;
		createGroupButton.Text = "Create";
		createGroupButton.UseVisualStyleBackColor = true;
		// 
		// displayGroupButton
		// 
		displayGroupButton.Location = new Point(119, 61);
		displayGroupButton.Name = "displayGroupButton";
		displayGroupButton.Size = new Size(75, 23);
		displayGroupButton.TabIndex = 1;
		displayGroupButton.Text = "Display";
		displayGroupButton.UseVisualStyleBackColor = true;
		// 
		// alterGroupButton
		// 
		alterGroupButton.Location = new Point(119, 90);
		alterGroupButton.Name = "alterGroupButton";
		alterGroupButton.Size = new Size(75, 23);
		alterGroupButton.TabIndex = 2;
		alterGroupButton.Text = "Alter";
		alterGroupButton.UseVisualStyleBackColor = true;
		// 
		// GroupsDashboard
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(346, 450);
		Controls.Add(alterGroupButton);
		Controls.Add(displayGroupButton);
		Controls.Add(createGroupButton);
		Name = "GroupsDashboard";
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Groups";
		FormClosed += GroupsDashboard_FormClosed;
		ResumeLayout(false);
	}

	#endregion

	private Button createGroupButton;
	private Button displayGroupButton;
	private Button alterGroupButton;
}