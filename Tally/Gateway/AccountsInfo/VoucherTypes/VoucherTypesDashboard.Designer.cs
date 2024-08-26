namespace TallyWinForms.Gateway.AccountsInfo.VoucherTypes;

partial class VoucherTypesDashboard
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
		alterVoucherTypeButton = new Button();
		deleteVoucherTypeButton = new Button();
		createVoucherTypeButton = new Button();
		voucherTypesListBox = new ListBox();
		SuspendLayout();
		// 
		// alterVoucherTypeButton
		// 
		alterVoucherTypeButton.Location = new Point(322, 104);
		alterVoucherTypeButton.Name = "alterVoucherTypeButton";
		alterVoucherTypeButton.Size = new Size(200, 75);
		alterVoucherTypeButton.TabIndex = 11;
		alterVoucherTypeButton.Text = "Alter";
		alterVoucherTypeButton.UseVisualStyleBackColor = true;
		alterVoucherTypeButton.Click += alterVoucherTypeButton_Click;
		// 
		// deleteVoucherTypeButton
		// 
		deleteVoucherTypeButton.Location = new Point(322, 185);
		deleteVoucherTypeButton.Name = "deleteVoucherTypeButton";
		deleteVoucherTypeButton.Size = new Size(200, 75);
		deleteVoucherTypeButton.TabIndex = 10;
		deleteVoucherTypeButton.Text = "Delete";
		deleteVoucherTypeButton.UseVisualStyleBackColor = true;
		deleteVoucherTypeButton.Click += deleteVoucherTypeButton_Click;
		// 
		// createVoucherTypeButton
		// 
		createVoucherTypeButton.Location = new Point(322, 23);
		createVoucherTypeButton.Name = "createVoucherTypeButton";
		createVoucherTypeButton.Size = new Size(200, 75);
		createVoucherTypeButton.TabIndex = 9;
		createVoucherTypeButton.Text = "Create";
		createVoucherTypeButton.UseVisualStyleBackColor = true;
		createVoucherTypeButton.Click += createVoucherTypeButton_Click;
		// 
		// voucherTypesListBox
		// 
		voucherTypesListBox.FormattingEnabled = true;
		voucherTypesListBox.ItemHeight = 15;
		voucherTypesListBox.Location = new Point(12, 23);
		voucherTypesListBox.Name = "voucherTypesListBox";
		voucherTypesListBox.Size = new Size(282, 634);
		voucherTypesListBox.TabIndex = 8;
		// 
		// VoucherTypesDashboard
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(534, 681);
		Controls.Add(alterVoucherTypeButton);
		Controls.Add(deleteVoucherTypeButton);
		Controls.Add(createVoucherTypeButton);
		Controls.Add(voucherTypesListBox);
		Name = "VoucherTypesDashboard";
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Voucher Types";
		FormClosed += VoucherTypesDashboard_FormClosed;
		ResumeLayout(false);
	}

	#endregion

	private Button alterVoucherTypeButton;
	private Button deleteVoucherTypeButton;
	private Button createVoucherTypeButton;
	public ListBox voucherTypesListBox;
}