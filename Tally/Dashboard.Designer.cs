namespace Tally;

    partial class Dashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
	///  Required method for Designer support - do not modify
	///  the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
		listOfCompaniesListBox = new ListBox();
		listOfCompaniesLabel = new Label();
		selectCompanyButton = new Button();
		changeDataLocationButton = new Button();
		createCompanyButton = new Button();
		alterComapanyButton = new Button();
		deleteCompanyButton = new Button();
		dataLocationLabel = new Label();
		SuspendLayout();
		// 
		// listOfCompaniesListBox
		// 
		listOfCompaniesListBox.FormattingEnabled = true;
		listOfCompaniesListBox.ItemHeight = 15;
		listOfCompaniesListBox.Location = new Point(12, 44);
		listOfCompaniesListBox.Name = "listOfCompaniesListBox";
		listOfCompaniesListBox.Size = new Size(685, 754);
		listOfCompaniesListBox.Sorted = true;
		listOfCompaniesListBox.TabIndex = 0;
		listOfCompaniesListBox.SelectedIndexChanged += listOfCompaniesListBox_SelectedIndexChanged;
		// 
		// listOfCompaniesLabel
		// 
		listOfCompaniesLabel.AutoSize = true;
		listOfCompaniesLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
		listOfCompaniesLabel.Location = new Point(196, 9);
		listOfCompaniesLabel.Name = "listOfCompaniesLabel";
		listOfCompaniesLabel.Size = new Size(204, 32);
		listOfCompaniesLabel.TabIndex = 1;
		listOfCompaniesLabel.Text = "List of Companies";
		// 
		// selectCompanyButton
		// 
		selectCompanyButton.Enabled = false;
		selectCompanyButton.Location = new Point(729, 44);
		selectCompanyButton.Name = "selectCompanyButton";
		selectCompanyButton.Size = new Size(200, 75);
		selectCompanyButton.TabIndex = 2;
		selectCompanyButton.Text = "Select Company";
		selectCompanyButton.UseVisualStyleBackColor = true;
		selectCompanyButton.Click += selectCompanyButton_ClickAsync;
		// 
		// changeDataLocationButton
		// 
		changeDataLocationButton.Location = new Point(729, 368);
		changeDataLocationButton.Name = "changeDataLocationButton";
		changeDataLocationButton.Size = new Size(200, 75);
		changeDataLocationButton.TabIndex = 3;
		changeDataLocationButton.Text = "Change Data Location";
		changeDataLocationButton.UseVisualStyleBackColor = true;
		changeDataLocationButton.Click += changeDataLocationButton_Click;
		// 
		// createCompanyButton
		// 
		createCompanyButton.Location = new Point(729, 125);
		createCompanyButton.Name = "createCompanyButton";
		createCompanyButton.Size = new Size(200, 75);
		createCompanyButton.TabIndex = 4;
		createCompanyButton.Text = "Create Company";
		createCompanyButton.UseVisualStyleBackColor = true;
		createCompanyButton.Click += createCompanyButton_ClickAsync;
		// 
		// alterComapnyButton
		// 
		alterComapanyButton.Enabled = false;
		alterComapanyButton.Location = new Point(729, 206);
		alterComapanyButton.Name = "alterComapnyButton";
		alterComapanyButton.Size = new Size(200, 75);
		alterComapanyButton.TabIndex = 5;
		alterComapanyButton.Text = "Alter Company";
		alterComapanyButton.UseVisualStyleBackColor = true;
		alterComapanyButton.Click += alterComapnyButton_ClickAsync;
		// 
		// deleteCompanyButton
		// 
		deleteCompanyButton.Enabled = false;
		deleteCompanyButton.Location = new Point(729, 287);
		deleteCompanyButton.Name = "deleteCompanyButton";
		deleteCompanyButton.Size = new Size(200, 75);
		deleteCompanyButton.TabIndex = 7;
		deleteCompanyButton.Text = "Delete Company";
		deleteCompanyButton.UseVisualStyleBackColor = true;
		deleteCompanyButton.Click += deleteCompanyButton_ClickAsync;
		// 
		// dataLocationLabel
		// 
		dataLocationLabel.AutoSize = true;
		dataLocationLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataLocationLabel.Location = new Point(729, 456);
		dataLocationLabel.Name = "dataLocationLabel";
		dataLocationLabel.Size = new Size(160, 32);
		dataLocationLabel.TabIndex = 8;
		dataLocationLabel.Text = "Data Location";
		// 
		// Dashboard
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(971, 834);
		Controls.Add(dataLocationLabel);
		Controls.Add(deleteCompanyButton);
		Controls.Add(alterComapanyButton);
		Controls.Add(createCompanyButton);
		Controls.Add(changeDataLocationButton);
		Controls.Add(selectCompanyButton);
		Controls.Add(listOfCompaniesLabel);
		Controls.Add(listOfCompaniesListBox);
		Name = "Dashboard";
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Dashboard";
		FormClosed += Dashboard_FormClosed;
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion
	private Label listOfCompaniesLabel;
        private Button selectCompanyButton;
        private Button changeDataLocationButton;
        private Button createCompanyButton;
        private Button alterComapanyButton;
	public ListBox listOfCompaniesListBox;
	private Button deleteCompanyButton;
	private Label dataLocationLabel;
}
