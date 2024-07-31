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
		alterComapnyButton = new Button();
		deleteCompanyButton = new Button();
		SuspendLayout();
		// 
		// listOfCompaniesListBox
		// 
		listOfCompaniesListBox.FormattingEnabled = true;
		listOfCompaniesListBox.ItemHeight = 15;
		listOfCompaniesListBox.Location = new Point(12, 44);
		listOfCompaniesListBox.Name = "listOfCompaniesListBox";
		listOfCompaniesListBox.Size = new Size(856, 754);
		listOfCompaniesListBox.Sorted = true;
		listOfCompaniesListBox.TabIndex = 0;
		listOfCompaniesListBox.SelectedIndexChanged += listOfCompaniesListBox_SelectedIndexChanged;
		// 
		// listOfCompaniesLabel
		// 
		listOfCompaniesLabel.AutoSize = true;
		listOfCompaniesLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
		listOfCompaniesLabel.Location = new Point(200, 9);
		listOfCompaniesLabel.Name = "listOfCompaniesLabel";
		listOfCompaniesLabel.Size = new Size(204, 32);
		listOfCompaniesLabel.TabIndex = 1;
		listOfCompaniesLabel.Text = "List of Companies";
		// 
		// selectCompanyButton
		// 
		selectCompanyButton.Enabled = false;
		selectCompanyButton.Location = new Point(1040, 44);
		selectCompanyButton.Name = "selectCompanyButton";
		selectCompanyButton.Size = new Size(163, 23);
		selectCompanyButton.TabIndex = 2;
		selectCompanyButton.Text = "Select Company";
		selectCompanyButton.UseVisualStyleBackColor = true;
		selectCompanyButton.Click += selectCompanyButton_ClickAsync;
		// 
		// changeDataLocationButton
		// 
		changeDataLocationButton.Location = new Point(1040, 160);
		changeDataLocationButton.Name = "changeDataLocationButton";
		changeDataLocationButton.Size = new Size(163, 23);
		changeDataLocationButton.TabIndex = 3;
		changeDataLocationButton.Text = "Change Data Location";
		changeDataLocationButton.UseVisualStyleBackColor = true;
		changeDataLocationButton.Click += changeDataLocationButton_Click;
		// 
		// createCompanyButton
		// 
		createCompanyButton.Location = new Point(1040, 73);
		createCompanyButton.Name = "createCompanyButton";
		createCompanyButton.Size = new Size(163, 23);
		createCompanyButton.TabIndex = 4;
		createCompanyButton.Text = "Create Company";
		createCompanyButton.UseVisualStyleBackColor = true;
		createCompanyButton.Click += createCompanyButton_ClickAsync;
		// 
		// alterComapnyButton
		// 
		alterComapnyButton.Enabled = false;
		alterComapnyButton.Location = new Point(1040, 102);
		alterComapnyButton.Name = "alterComapnyButton";
		alterComapnyButton.Size = new Size(163, 23);
		alterComapnyButton.TabIndex = 5;
		alterComapnyButton.Text = "Alter Company";
		alterComapnyButton.UseVisualStyleBackColor = true;
		alterComapnyButton.Click += alterComapnyButton_ClickAsync;
		// 
		// deleteCompanyButton
		// 
		deleteCompanyButton.Enabled = false;
		deleteCompanyButton.Location = new Point(1040, 131);
		deleteCompanyButton.Name = "deleteCompanyButton";
		deleteCompanyButton.Size = new Size(163, 23);
		deleteCompanyButton.TabIndex = 7;
		deleteCompanyButton.Text = "Delete Company";
		deleteCompanyButton.UseVisualStyleBackColor = true;
		deleteCompanyButton.Click += deleteCompanyButton_ClickAsync;
		// 
		// Dashboard
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(1333, 834);
		Controls.Add(deleteCompanyButton);
		Controls.Add(alterComapnyButton);
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
        private Button alterComapnyButton;
	public ListBox listOfCompaniesListBox;
	private Button deleteCompanyButton;
}
