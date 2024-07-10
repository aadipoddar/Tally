namespace Tally.Gateway;

partial class GatewayDashboard
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
		accountsInfoButton = new Button();
		SuspendLayout();
		// 
		// accountsInfoButton
		// 
		accountsInfoButton.Location = new Point(90, 29);
		accountsInfoButton.Name = "accountsInfoButton";
		accountsInfoButton.Size = new Size(120, 23);
		accountsInfoButton.TabIndex = 0;
		accountsInfoButton.Text = "Accounts Info";
		accountsInfoButton.UseVisualStyleBackColor = true;
		accountsInfoButton.Click += accountsInfoButton_Click;
		// 
		// GatewayDashboard
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(339, 450);
		Controls.Add(accountsInfoButton);
		Name = "GatewayDashboard";
		StartPosition = FormStartPosition.CenterScreen;
		Text = "GatewayDashboard";
		FormClosed += GatewayDashboard_FormClosed;
		ResumeLayout(false);
	}

	#endregion

	private Button accountsInfoButton;
}