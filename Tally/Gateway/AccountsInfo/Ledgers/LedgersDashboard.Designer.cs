namespace TallyWinForms.Gateway.AccountsInfo.Ledgers;

partial class LedgersDashboard
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
		ledgersListBox = new ListBox();
		alterLedgerButton = new Button();
		deleteLedgerButton = new Button();
		createLedgerButton = new Button();
		SuspendLayout();
		// 
		// ledgersListBox
		// 
		ledgersListBox.FormattingEnabled = true;
		ledgersListBox.ItemHeight = 15;
		ledgersListBox.Location = new Point(12, 22);
		ledgersListBox.Name = "ledgersListBox";
		ledgersListBox.Size = new Size(282, 634);
		ledgersListBox.TabIndex = 4;
		// 
		// alterLedgerButton
		// 
		alterLedgerButton.Location = new Point(322, 103);
		alterLedgerButton.Name = "alterLedgerButton";
		alterLedgerButton.Size = new Size(200, 75);
		alterLedgerButton.TabIndex = 7;
		alterLedgerButton.Text = "Alter";
		alterLedgerButton.UseVisualStyleBackColor = true;
		alterLedgerButton.Click += alterLedgerButton_Click;
		// 
		// deleteLedgerButton
		// 
		deleteLedgerButton.Location = new Point(322, 184);
		deleteLedgerButton.Name = "deleteLedgerButton";
		deleteLedgerButton.Size = new Size(200, 75);
		deleteLedgerButton.TabIndex = 6;
		deleteLedgerButton.Text = "Delete";
		deleteLedgerButton.UseVisualStyleBackColor = true;
		deleteLedgerButton.Click += deleteLedgerButton_Click;
		// 
		// createLedgerButton
		// 
		createLedgerButton.Location = new Point(322, 22);
		createLedgerButton.Name = "createLedgerButton";
		createLedgerButton.Size = new Size(200, 75);
		createLedgerButton.TabIndex = 5;
		createLedgerButton.Text = "Create";
		createLedgerButton.UseVisualStyleBackColor = true;
		createLedgerButton.Click += createLedgerButton_Click;
		// 
		// LedgersDashboard
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(534, 681);
		Controls.Add(alterLedgerButton);
		Controls.Add(deleteLedgerButton);
		Controls.Add(createLedgerButton);
		Controls.Add(ledgersListBox);
		Name = "LedgersDashboard";
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Ledgers";
		FormClosed += LedgersDashboard_FormClosed;
		ResumeLayout(false);
	}

	#endregion

	public ListBox ledgersListBox;
	private Button alterLedgerButton;
	private Button deleteLedgerButton;
	private Button createLedgerButton;
}