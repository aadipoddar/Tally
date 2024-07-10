namespace Tally.Gateway.AccountsInfo;

partial class AccountsInfoDashboard
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
		groupsButton = new Button();
		SuspendLayout();
		// 
		// groupsButton
		// 
		groupsButton.Location = new Point(100, 34);
		groupsButton.Name = "groupsButton";
		groupsButton.Size = new Size(75, 23);
		groupsButton.TabIndex = 0;
		groupsButton.Text = "Groups";
		groupsButton.UseVisualStyleBackColor = true;
		groupsButton.Click += groupsButton_Click;
		// 
		// AccountsInfoDashboard
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(297, 450);
		Controls.Add(groupsButton);
		Name = "AccountsInfoDashboard";
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Accounts Info";
		FormClosed += AccountsInfoDashboard_FormClosed;
		ResumeLayout(false);
	}

	#endregion

	private Button groupsButton;
}