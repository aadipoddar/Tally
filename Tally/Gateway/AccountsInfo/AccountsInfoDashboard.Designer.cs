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
		ledgersButton = new Button();
		SuspendLayout();
		// 
		// groupsButton
		// 
		groupsButton.Location = new Point(12, 12);
		groupsButton.Name = "groupsButton";
		groupsButton.Size = new Size(200, 75);
		groupsButton.TabIndex = 0;
		groupsButton.Text = "Groups";
		groupsButton.UseVisualStyleBackColor = true;
		groupsButton.Click += groupsButton_Click;
		// 
		// ledgersButton
		// 
		ledgersButton.Location = new Point(12, 93);
		ledgersButton.Name = "ledgersButton";
		ledgersButton.Size = new Size(200, 75);
		ledgersButton.TabIndex = 1;
		ledgersButton.Text = "Ledgers";
		ledgersButton.UseVisualStyleBackColor = true;
		ledgersButton.Click += ledgersButton_Click;
		// 
		// AccountsInfoDashboard
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(234, 411);
		Controls.Add(ledgersButton);
		Controls.Add(groupsButton);
		Name = "AccountsInfoDashboard";
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Accounts Info";
		FormClosed += AccountsInfoDashboard_FormClosed;
		ResumeLayout(false);
	}

	#endregion

	private Button groupsButton;
	private Button ledgersButton;
}