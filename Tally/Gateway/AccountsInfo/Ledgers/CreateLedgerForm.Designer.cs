namespace TallyWinForms.Gateway.AccountsInfo.Ledgers;

partial class CreateLedgerForm
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
		underComboBox = new ComboBox();
		underLabel = new Label();
		nameTextBox = new TextBox();
		nameLabel = new Label();
		inventoryAffectedComboBox = new ComboBox();
		inventoryAffectedLabel = new Label();
		dateReconciliationLabel = new Label();
		dateReconciliationDateTimePicker = new DateTimePicker();
		maintainBalancesComboBox = new ComboBox();
		maintainBalancesLabel = new Label();
		defaultCreditPeriodLabel = new Label();
		defaultCreditPeriodTextBox = new TextBox();
		createLedgerButton = new Button();
		percentageOfCalculationLabel = new Label();
		percentageOfCalculationTextBox = new TextBox();
		methodOfCalculationLabel = new Label();
		methodOfCalculationComboBox = new ComboBox();
		SuspendLayout();
		// 
		// underComboBox
		// 
		underComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
		underComboBox.Font = new Font("Segoe UI", 12F);
		underComboBox.FormattingEnabled = true;
		underComboBox.Location = new Point(331, 95);
		underComboBox.Name = "underComboBox";
		underComboBox.Size = new Size(151, 29);
		underComboBox.TabIndex = 21;
		underComboBox.SelectedValueChanged += underComboBox_SelectedValueChanged;
		// 
		// underLabel
		// 
		underLabel.AutoSize = true;
		underLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
		underLabel.Location = new Point(27, 98);
		underLabel.Name = "underLabel";
		underLabel.Size = new Size(53, 21);
		underLabel.TabIndex = 20;
		underLabel.Text = "Under";
		// 
		// nameTextBox
		// 
		nameTextBox.Font = new Font("Segoe UI", 12F);
		nameTextBox.Location = new Point(195, 33);
		nameTextBox.Name = "nameTextBox";
		nameTextBox.Size = new Size(287, 29);
		nameTextBox.TabIndex = 19;
		// 
		// nameLabel
		// 
		nameLabel.AutoSize = true;
		nameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
		nameLabel.Location = new Point(27, 36);
		nameLabel.Name = "nameLabel";
		nameLabel.Size = new Size(52, 21);
		nameLabel.TabIndex = 18;
		nameLabel.Text = "Name";
		// 
		// inventoryAffectedComboBox
		// 
		inventoryAffectedComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
		inventoryAffectedComboBox.Font = new Font("Segoe UI", 12F);
		inventoryAffectedComboBox.FormattingEnabled = true;
		inventoryAffectedComboBox.Location = new Point(331, 145);
		inventoryAffectedComboBox.Name = "inventoryAffectedComboBox";
		inventoryAffectedComboBox.Size = new Size(151, 29);
		inventoryAffectedComboBox.TabIndex = 23;
		// 
		// inventoryAffectedLabel
		// 
		inventoryAffectedLabel.AutoSize = true;
		inventoryAffectedLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
		inventoryAffectedLabel.Location = new Point(27, 148);
		inventoryAffectedLabel.Name = "inventoryAffectedLabel";
		inventoryAffectedLabel.Size = new Size(205, 21);
		inventoryAffectedLabel.TabIndex = 22;
		inventoryAffectedLabel.Text = "Inventory Value are Affected";
		// 
		// dateReconciliationLabel
		// 
		dateReconciliationLabel.AutoSize = true;
		dateReconciliationLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
		dateReconciliationLabel.Location = new Point(27, 195);
		dateReconciliationLabel.Name = "dateReconciliationLabel";
		dateReconciliationLabel.Size = new Size(229, 21);
		dateReconciliationLabel.TabIndex = 24;
		dateReconciliationLabel.Text = "Effective Date for Reconciliation";
		// 
		// dateReconciliationDateTimePicker
		// 
		dateReconciliationDateTimePicker.Location = new Point(282, 194);
		dateReconciliationDateTimePicker.Name = "dateReconciliationDateTimePicker";
		dateReconciliationDateTimePicker.Size = new Size(200, 23);
		dateReconciliationDateTimePicker.TabIndex = 25;
		// 
		// maintainBalancesLabelComboBox
		// 
		maintainBalancesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
		maintainBalancesComboBox.Font = new Font("Segoe UI", 12F);
		maintainBalancesComboBox.FormattingEnabled = true;
		maintainBalancesComboBox.Location = new Point(331, 236);
		maintainBalancesComboBox.Name = "maintainBalancesLabelComboBox";
		maintainBalancesComboBox.Size = new Size(151, 29);
		maintainBalancesComboBox.TabIndex = 27;
		maintainBalancesComboBox.SelectedValueChanged += maintainBalancesComboBox_SelectedValueChanged;
		// 
		// maintainBalancesLabel
		// 
		maintainBalancesLabel.AutoSize = true;
		maintainBalancesLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
		maintainBalancesLabel.Location = new Point(27, 239);
		maintainBalancesLabel.Name = "maintainBalancesLabel";
		maintainBalancesLabel.Size = new Size(206, 21);
		maintainBalancesLabel.TabIndex = 26;
		maintainBalancesLabel.Text = "Maintain Balances Bill by Bill";
		// 
		// defaultCreditPeriodLabel
		// 
		defaultCreditPeriodLabel.AutoSize = true;
		defaultCreditPeriodLabel.Font = new Font("Segoe UI", 10F);
		defaultCreditPeriodLabel.Location = new Point(55, 274);
		defaultCreditPeriodLabel.Name = "defaultCreditPeriodLabel";
		defaultCreditPeriodLabel.Size = new Size(136, 19);
		defaultCreditPeriodLabel.TabIndex = 28;
		defaultCreditPeriodLabel.Text = "Default Credit Period";
		// 
		// defaultCreditPeriodTextBox
		// 
		defaultCreditPeriodTextBox.Font = new Font("Segoe UI", 10F);
		defaultCreditPeriodTextBox.Location = new Point(429, 270);
		defaultCreditPeriodTextBox.Name = "defaultCreditPeriodTextBox";
		defaultCreditPeriodTextBox.Size = new Size(53, 25);
		defaultCreditPeriodTextBox.TabIndex = 30;
		// 
		// createLedgerButton
		// 
		createLedgerButton.Location = new Point(148, 407);
		createLedgerButton.Name = "createLedgerButton";
		createLedgerButton.Size = new Size(165, 52);
		createLedgerButton.TabIndex = 31;
		createLedgerButton.Text = "Create Ledger";
		createLedgerButton.UseVisualStyleBackColor = true;
		createLedgerButton.Click += createLedgerButton_Click;
		// 
		// percentageOfCalculationLabel
		// 
		percentageOfCalculationLabel.AutoSize = true;
		percentageOfCalculationLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
		percentageOfCalculationLabel.Location = new Point(27, 316);
		percentageOfCalculationLabel.Name = "percentageOfCalculationLabel";
		percentageOfCalculationLabel.Size = new Size(185, 21);
		percentageOfCalculationLabel.TabIndex = 32;
		percentageOfCalculationLabel.Text = "Percentage of Calculation";
		// 
		// percentageOfCalculationTextBox
		// 
		percentageOfCalculationTextBox.Font = new Font("Segoe UI", 12F);
		percentageOfCalculationTextBox.Location = new Point(429, 313);
		percentageOfCalculationTextBox.Name = "percentageOfCalculationTextBox";
		percentageOfCalculationTextBox.Size = new Size(53, 29);
		percentageOfCalculationTextBox.TabIndex = 33;
		percentageOfCalculationTextBox.TextChanged += percentageOfCalculationTextBox_TextChanged;
		// 
		// methodOfCalculationLabel
		// 
		methodOfCalculationLabel.AutoSize = true;
		methodOfCalculationLabel.Font = new Font("Segoe UI", 10F);
		methodOfCalculationLabel.Location = new Point(55, 351);
		methodOfCalculationLabel.Name = "methodOfCalculationLabel";
		methodOfCalculationLabel.Size = new Size(139, 19);
		methodOfCalculationLabel.TabIndex = 34;
		methodOfCalculationLabel.Text = "Method of Calulation";
		// 
		// methodOfCalculationComboBox
		// 
		methodOfCalculationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
		methodOfCalculationComboBox.Font = new Font("Segoe UI", 10F);
		methodOfCalculationComboBox.FormattingEnabled = true;
		methodOfCalculationComboBox.Location = new Point(331, 348);
		methodOfCalculationComboBox.Name = "methodOfCalculationComboBox";
		methodOfCalculationComboBox.Size = new Size(151, 25);
		methodOfCalculationComboBox.TabIndex = 35;
		// 
		// CreateLedgerForm
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(494, 471);
		Controls.Add(methodOfCalculationComboBox);
		Controls.Add(methodOfCalculationLabel);
		Controls.Add(percentageOfCalculationTextBox);
		Controls.Add(percentageOfCalculationLabel);
		Controls.Add(createLedgerButton);
		Controls.Add(defaultCreditPeriodTextBox);
		Controls.Add(defaultCreditPeriodLabel);
		Controls.Add(maintainBalancesComboBox);
		Controls.Add(maintainBalancesLabel);
		Controls.Add(dateReconciliationDateTimePicker);
		Controls.Add(dateReconciliationLabel);
		Controls.Add(inventoryAffectedComboBox);
		Controls.Add(inventoryAffectedLabel);
		Controls.Add(underComboBox);
		Controls.Add(underLabel);
		Controls.Add(nameTextBox);
		Controls.Add(nameLabel);
		Name = "CreateLedgerForm";
		StartPosition = FormStartPosition.CenterScreen;
		Text = "CreateLedgerForm";
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	public ComboBox underComboBox;
	private Label underLabel;
	public TextBox nameTextBox;
	private Label nameLabel;
	public ComboBox inventoryAffectedComboBox;
	public DateTimePicker dateReconciliationDateTimePicker;
	public ComboBox maintainBalancesComboBox;
	public TextBox defaultCreditPeriodTextBox;
	public Button createLedgerButton;
	public Label inventoryAffectedLabel;
	public Label dateReconciliationLabel;
	public Label maintainBalancesLabel;
	public Label defaultCreditPeriodLabel;
	public Label percentageOfCalculationLabel;
	public TextBox percentageOfCalculationTextBox;
	public Label methodOfCalculationLabel;
	public ComboBox methodOfCalculationComboBox;
}