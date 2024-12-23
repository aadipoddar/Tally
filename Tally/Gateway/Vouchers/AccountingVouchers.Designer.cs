namespace TallyWinForms.Gateway.Vouchers;

partial class AccountingVouchers
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
		itemsDataGridView = new DataGridView();
		typeColumn = new DataGridViewComboBoxColumn();
		particularsColumn = new DataGridViewComboBoxColumn();
		debitColumn = new DataGridViewTextBoxColumn();
		creditColumn = new DataGridViewTextBoxColumn();
		voucherTypeLabel = new Label();
		numberLabel = new Label();
		voucherNumberLabel = new Label();
		dateTimePicker1 = new DateTimePicker();
		totalDebitAmountLabel = new Label();
		totalDebitLabel = new Label();
		totalCreditLabel = new Label();
		totalCreditAmountLabel = new Label();
		textBox1 = new TextBox();
		narrationTextBox = new Label();
		((System.ComponentModel.ISupportInitialize)itemsDataGridView).BeginInit();
		SuspendLayout();
		// 
		// itemsDataGridView
		// 
		itemsDataGridView.AllowUserToOrderColumns = true;
		itemsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		itemsDataGridView.Columns.AddRange(new DataGridViewColumn[] { typeColumn, particularsColumn, debitColumn, creditColumn });
		itemsDataGridView.Location = new Point(12, 72);
		itemsDataGridView.Name = "itemsDataGridView";
		itemsDataGridView.Size = new Size(1560, 652);
		itemsDataGridView.TabIndex = 4;
		itemsDataGridView.CellBeginEdit += itemsDataGridView_CellBeginEdit;
		itemsDataGridView.CellClick += itemsDataGridView_CellClick;
		itemsDataGridView.CellEndEdit += itemsDataGridView_CellEndEdit;
		itemsDataGridView.CellLeave += itemsDataGridView_CellLeave;
		itemsDataGridView.RowsAdded += itemsDataGridView_RowsAdded;
		// 
		// typeColumn
		// 
		typeColumn.HeaderText = "Type";
		typeColumn.Name = "typeColumn";
		// 
		// particularsColumn
		// 
		particularsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		particularsColumn.HeaderText = "Particulars";
		particularsColumn.Name = "particularsColumn";
		// 
		// debitColumn
		// 
		debitColumn.HeaderText = "Debit";
		debitColumn.Name = "debitColumn";
		// 
		// creditColumn
		// 
		creditColumn.HeaderText = "Credit";
		creditColumn.Name = "creditColumn";
		// 
		// voucherTypeLabel
		// 
		voucherTypeLabel.AutoSize = true;
		voucherTypeLabel.BackColor = Color.IndianRed;
		voucherTypeLabel.FlatStyle = FlatStyle.Flat;
		voucherTypeLabel.Font = new Font("Segoe UI", 16F);
		voucherTypeLabel.Location = new Point(12, 9);
		voucherTypeLabel.Name = "voucherTypeLabel";
		voucherTypeLabel.Size = new Size(146, 30);
		voucherTypeLabel.TabIndex = 0;
		voucherTypeLabel.Text = "Voucher Type";
		// 
		// numberLabel
		// 
		numberLabel.AutoSize = true;
		numberLabel.Font = new Font("Segoe UI", 14F);
		numberLabel.Location = new Point(164, 12);
		numberLabel.Name = "numberLabel";
		numberLabel.Size = new Size(41, 25);
		numberLabel.TabIndex = 1;
		numberLabel.Text = "No:";
		// 
		// voucherNumberLabel
		// 
		voucherNumberLabel.AutoSize = true;
		voucherNumberLabel.Font = new Font("Segoe UI", 14F);
		voucherNumberLabel.Location = new Point(201, 12);
		voucherNumberLabel.Name = "voucherNumberLabel";
		voucherNumberLabel.Size = new Size(22, 25);
		voucherNumberLabel.TabIndex = 2;
		voucherNumberLabel.Text = "0";
		// 
		// dateTimePicker1
		// 
		dateTimePicker1.Location = new Point(1365, 16);
		dateTimePicker1.Name = "dateTimePicker1";
		dateTimePicker1.Size = new Size(207, 23);
		dateTimePicker1.TabIndex = 3;
		// 
		// totalDebitAmountLabel
		// 
		totalDebitAmountLabel.AutoSize = true;
		totalDebitAmountLabel.Font = new Font("Segoe UI", 14F);
		totalDebitAmountLabel.Location = new Point(1062, 736);
		totalDebitAmountLabel.Name = "totalDebitAmountLabel";
		totalDebitAmountLabel.Size = new Size(42, 25);
		totalDebitAmountLabel.TabIndex = 6;
		totalDebitAmountLabel.Text = "000";
		// 
		// totalDebitLabel
		// 
		totalDebitLabel.AutoSize = true;
		totalDebitLabel.Font = new Font("Segoe UI", 14F);
		totalDebitLabel.Location = new Point(954, 736);
		totalDebitLabel.Name = "totalDebitLabel";
		totalDebitLabel.Size = new Size(102, 25);
		totalDebitLabel.TabIndex = 7;
		totalDebitLabel.Text = "Total Debit";
		// 
		// totalCreditLabel
		// 
		totalCreditLabel.AutoSize = true;
		totalCreditLabel.Font = new Font("Segoe UI", 14F);
		totalCreditLabel.Location = new Point(954, 761);
		totalCreditLabel.Name = "totalCreditLabel";
		totalCreditLabel.Size = new Size(108, 25);
		totalCreditLabel.TabIndex = 9;
		totalCreditLabel.Text = "Total Credit";
		// 
		// totalCreditAmountLabel
		// 
		totalCreditAmountLabel.AutoSize = true;
		totalCreditAmountLabel.Font = new Font("Segoe UI", 14F);
		totalCreditAmountLabel.Location = new Point(1062, 761);
		totalCreditAmountLabel.Name = "totalCreditAmountLabel";
		totalCreditAmountLabel.Size = new Size(42, 25);
		totalCreditAmountLabel.TabIndex = 8;
		totalCreditAmountLabel.Text = "000";
		// 
		// textBox1
		// 
		textBox1.Location = new Point(12, 761);
		textBox1.Multiline = true;
		textBox1.Name = "textBox1";
		textBox1.Size = new Size(875, 88);
		textBox1.TabIndex = 10;
		// 
		// narrationTextBox
		// 
		narrationTextBox.AutoSize = true;
		narrationTextBox.Location = new Point(12, 736);
		narrationTextBox.Name = "narrationTextBox";
		narrationTextBox.Size = new Size(57, 15);
		narrationTextBox.TabIndex = 11;
		narrationTextBox.Text = "Narration";
		// 
		// AccountingVouchers
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(1584, 861);
		Controls.Add(narrationTextBox);
		Controls.Add(textBox1);
		Controls.Add(totalCreditLabel);
		Controls.Add(totalCreditAmountLabel);
		Controls.Add(totalDebitLabel);
		Controls.Add(totalDebitAmountLabel);
		Controls.Add(itemsDataGridView);
		Controls.Add(dateTimePicker1);
		Controls.Add(voucherNumberLabel);
		Controls.Add(numberLabel);
		Controls.Add(voucherTypeLabel);
		Name = "AccountingVouchers";
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Accounting Vouchers";
		FormClosed += AccountingVouchers_FormClosed;
		((System.ComponentModel.ISupportInitialize)itemsDataGridView).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private Label voucherTypeLabel;
	private Label numberLabel;
	private Label voucherNumberLabel;
	private DateTimePicker dateTimePicker1;
	private DataGridView itemsDataGridView;
	private DataGridViewComboBoxColumn typeColumn;
	private DataGridViewComboBoxColumn particularsColumn;
	private DataGridViewTextBoxColumn debitColumn;
	private DataGridViewTextBoxColumn creditColumn;
	private Label totalDebitAmountLabel;
	private Label totalDebitLabel;
	private Label totalCreditLabel;
	private Label totalCreditAmountLabel;
	private TextBox textBox1;
	private Label narrationTextBox;
}