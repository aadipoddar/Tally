namespace Tally.Gateway.AccountsInfo.Groups;

partial class CreateGroupForm
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
		nameTextBox = new TextBox();
		nameLabel = new Label();
		underLabel = new Label();
		natureOfGroupLabel = new Label();
		affectGrossProfitLabel = new Label();
		behavesSubLedgerLabel = new Label();
		netBalanceLabel = new Label();
		usedForCalculationLabel = new Label();
		methodToAllocateLabel = new Label();
		underComboBox = new ComboBox();
		natureOfGroupComboBox = new ComboBox();
		affectGrossProfitComboBox = new ComboBox();
		behavesSubLedgerComboBox = new ComboBox();
		netBalancesComboBox = new ComboBox();
		usedForCalculationComboBox = new ComboBox();
		methodToAllocateComboBox = new ComboBox();
		createGroupButton = new Button();
		SuspendLayout();
		// 
		// nameTextBox
		// 
		nameTextBox.Font = new Font("Segoe UI", 12F);
		nameTextBox.Location = new Point(197, 38);
		nameTextBox.Name = "nameTextBox";
		nameTextBox.Size = new Size(287, 29);
		nameTextBox.TabIndex = 3;
		// 
		// nameLabel
		// 
		nameLabel.AutoSize = true;
		nameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
		nameLabel.Location = new Point(29, 41);
		nameLabel.Name = "nameLabel";
		nameLabel.Size = new Size(52, 21);
		nameLabel.TabIndex = 2;
		nameLabel.Text = "Name";
		// 
		// underLabel
		// 
		underLabel.AutoSize = true;
		underLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
		underLabel.Location = new Point(29, 103);
		underLabel.Name = "underLabel";
		underLabel.Size = new Size(53, 21);
		underLabel.TabIndex = 4;
		underLabel.Text = "Under";
		// 
		// natureOfGroupLabel
		// 
		natureOfGroupLabel.AutoSize = true;
		natureOfGroupLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
		natureOfGroupLabel.Location = new Point(29, 150);
		natureOfGroupLabel.Name = "natureOfGroupLabel";
		natureOfGroupLabel.Size = new Size(127, 21);
		natureOfGroupLabel.TabIndex = 6;
		natureOfGroupLabel.Text = "Nature Of Group";
		// 
		// affectGrossProfitLabel
		// 
		affectGrossProfitLabel.AutoSize = true;
		affectGrossProfitLabel.Font = new Font("Segoe UI", 10F);
		affectGrossProfitLabel.Location = new Point(37, 180);
		affectGrossProfitLabel.Name = "affectGrossProfitLabel";
		affectGrossProfitLabel.Size = new Size(167, 19);
		affectGrossProfitLabel.TabIndex = 8;
		affectGrossProfitLabel.Text = "Does it Affect Gross Profit";
		// 
		// behavesSubLedgerLabel
		// 
		behavesSubLedgerLabel.AutoSize = true;
		behavesSubLedgerLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
		behavesSubLedgerLabel.Location = new Point(29, 222);
		behavesSubLedgerLabel.Name = "behavesSubLedgerLabel";
		behavesSubLedgerLabel.Size = new Size(219, 21);
		behavesSubLedgerLabel.TabIndex = 10;
		behavesSubLedgerLabel.Text = "Group Behaves As Sub Ledger";
		// 
		// netBalanceLabel
		// 
		netBalanceLabel.AutoSize = true;
		netBalanceLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
		netBalanceLabel.Location = new Point(29, 257);
		netBalanceLabel.Name = "netBalanceLabel";
		netBalanceLabel.Size = new Size(188, 21);
		netBalanceLabel.TabIndex = 12;
		netBalanceLabel.Text = "Net Debit/Credit Balances";
		// 
		// usedForCalculationLabel
		// 
		usedForCalculationLabel.AutoSize = true;
		usedForCalculationLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
		usedForCalculationLabel.Location = new Point(29, 292);
		usedForCalculationLabel.Name = "usedForCalculationLabel";
		usedForCalculationLabel.Size = new Size(153, 21);
		usedForCalculationLabel.TabIndex = 14;
		usedForCalculationLabel.Text = "Used For Calculation";
		// 
		// methodToAllocateLabel
		// 
		methodToAllocateLabel.AutoSize = true;
		methodToAllocateLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
		methodToAllocateLabel.Location = new Point(29, 327);
		methodToAllocateLabel.Name = "methodToAllocateLabel";
		methodToAllocateLabel.Size = new Size(289, 21);
		methodToAllocateLabel.TabIndex = 16;
		methodToAllocateLabel.Text = "Method to Allocate in Purchased Income";
		// 
		// underComboBox
		// 
		underComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
		underComboBox.Font = new Font("Segoe UI", 12F);
		underComboBox.FormattingEnabled = true;
		underComboBox.Location = new Point(333, 100);
		underComboBox.Name = "underComboBox";
		underComboBox.Size = new Size(151, 29);
		underComboBox.TabIndex = 17;
		underComboBox.SelectedValueChanged += underComboBox_SelectedValueChanged;
		// 
		// natureOfGroupComboBox
		// 
		natureOfGroupComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
		natureOfGroupComboBox.Font = new Font("Segoe UI", 12F);
		natureOfGroupComboBox.FormattingEnabled = true;
		natureOfGroupComboBox.Location = new Point(333, 142);
		natureOfGroupComboBox.Name = "natureOfGroupComboBox";
		natureOfGroupComboBox.Size = new Size(151, 29);
		natureOfGroupComboBox.TabIndex = 18;
		natureOfGroupComboBox.SelectedValueChanged += natureOfGroupComboBox_SelectedValueChanged;
		natureOfGroupComboBox.VisibleChanged += natureOfGroupComboBox_VisibleChanged;
		// 
		// affectGrossProfitComboBox
		// 
		affectGrossProfitComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
		affectGrossProfitComboBox.Font = new Font("Segoe UI", 10F);
		affectGrossProfitComboBox.FormattingEnabled = true;
		affectGrossProfitComboBox.Items.AddRange(new object[] { "No", "Yes" });
		affectGrossProfitComboBox.Location = new Point(333, 177);
		affectGrossProfitComboBox.Name = "affectGrossProfitComboBox";
		affectGrossProfitComboBox.Size = new Size(151, 25);
		affectGrossProfitComboBox.TabIndex = 19;
		affectGrossProfitComboBox.VisibleChanged += affectGrossProfitComboBox_VisibleChanged;
		// 
		// behavesSubLedgerComboBox
		// 
		behavesSubLedgerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
		behavesSubLedgerComboBox.Font = new Font("Segoe UI", 12F);
		behavesSubLedgerComboBox.FormattingEnabled = true;
		behavesSubLedgerComboBox.Items.AddRange(new object[] { "No", "Yes" });
		behavesSubLedgerComboBox.Location = new Point(333, 219);
		behavesSubLedgerComboBox.Name = "behavesSubLedgerComboBox";
		behavesSubLedgerComboBox.Size = new Size(151, 29);
		behavesSubLedgerComboBox.TabIndex = 20;
		// 
		// netBalancesComboBox
		// 
		netBalancesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
		netBalancesComboBox.Font = new Font("Segoe UI", 12F);
		netBalancesComboBox.FormattingEnabled = true;
		netBalancesComboBox.Items.AddRange(new object[] { "No", "Yes" });
		netBalancesComboBox.Location = new Point(333, 254);
		netBalancesComboBox.Name = "netBalancesComboBox";
		netBalancesComboBox.Size = new Size(151, 29);
		netBalancesComboBox.TabIndex = 21;
		// 
		// usedForCalculationComboBox
		// 
		usedForCalculationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
		usedForCalculationComboBox.Font = new Font("Segoe UI", 12F);
		usedForCalculationComboBox.FormattingEnabled = true;
		usedForCalculationComboBox.Items.AddRange(new object[] { "No", "Yes" });
		usedForCalculationComboBox.Location = new Point(333, 289);
		usedForCalculationComboBox.Name = "usedForCalculationComboBox";
		usedForCalculationComboBox.Size = new Size(151, 29);
		usedForCalculationComboBox.TabIndex = 22;
		// 
		// methodToAllocateComboBox
		// 
		methodToAllocateComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
		methodToAllocateComboBox.Font = new Font("Segoe UI", 12F);
		methodToAllocateComboBox.FormattingEnabled = true;
		methodToAllocateComboBox.Location = new Point(333, 324);
		methodToAllocateComboBox.Name = "methodToAllocateComboBox";
		methodToAllocateComboBox.Size = new Size(151, 29);
		methodToAllocateComboBox.TabIndex = 23;
		// 
		// createGroupButton
		// 
		createGroupButton.Location = new Point(162, 373);
		createGroupButton.Name = "createGroupButton";
		createGroupButton.Size = new Size(165, 52);
		createGroupButton.TabIndex = 24;
		createGroupButton.Text = "Create Group";
		createGroupButton.UseVisualStyleBackColor = true;
		createGroupButton.Click += createGroupButton_Click;
		// 
		// CreateGroupForm
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(496, 450);
		Controls.Add(createGroupButton);
		Controls.Add(methodToAllocateComboBox);
		Controls.Add(usedForCalculationComboBox);
		Controls.Add(netBalancesComboBox);
		Controls.Add(behavesSubLedgerComboBox);
		Controls.Add(affectGrossProfitComboBox);
		Controls.Add(natureOfGroupComboBox);
		Controls.Add(underComboBox);
		Controls.Add(methodToAllocateLabel);
		Controls.Add(usedForCalculationLabel);
		Controls.Add(netBalanceLabel);
		Controls.Add(behavesSubLedgerLabel);
		Controls.Add(affectGrossProfitLabel);
		Controls.Add(natureOfGroupLabel);
		Controls.Add(underLabel);
		Controls.Add(nameTextBox);
		Controls.Add(nameLabel);
		Name = "CreateGroupForm";
		StartPosition = FormStartPosition.CenterScreen;
		Text = "CreateGroupForm";
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion
	private Label nameLabel;
	private Label underLabel;
	private Label affectGrossProfitLabel;
	private Label behavesSubLedgerLabel;
	private Label netBalanceLabel;
	private Label usedForCalculationLabel;
	private Label methodToAllocateLabel;
	public TextBox nameTextBox;
	public ComboBox underComboBox;
	public ComboBox natureOfGroupComboBox;
	public ComboBox affectGrossProfitComboBox;
	public ComboBox behavesSubLedgerComboBox;
	public ComboBox netBalancesComboBox;
	public ComboBox usedForCalculationComboBox;
	public ComboBox methodToAllocateComboBox;
	public Button createGroupButton;
	public Label natureOfGroupLabel;
}