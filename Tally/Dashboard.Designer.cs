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
		shutCompanyButton = new Button();
		createCompanyButton = new Button();
		alterComapnyButton = new Button();
		refreshButton = new Button();
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
		selectCompanyButton.Size = new Size(110, 23);
		selectCompanyButton.TabIndex = 2;
		selectCompanyButton.Text = "Select Company";
		selectCompanyButton.UseVisualStyleBackColor = true;
		// 
		// shutCompanyButton
		// 
		shutCompanyButton.Enabled = false;
		shutCompanyButton.Location = new Point(1040, 73);
		shutCompanyButton.Name = "shutCompanyButton";
		shutCompanyButton.Size = new Size(110, 23);
		shutCompanyButton.TabIndex = 3;
		shutCompanyButton.Text = "Shut Company";
		shutCompanyButton.UseVisualStyleBackColor = true;
		// 
		// createCompanyButton
		// 
		createCompanyButton.Location = new Point(1040, 102);
		createCompanyButton.Name = "createCompanyButton";
		createCompanyButton.Size = new Size(110, 23);
		createCompanyButton.TabIndex = 4;
		createCompanyButton.Text = "Create Company";
		createCompanyButton.UseVisualStyleBackColor = true;
		createCompanyButton.Click += createCompanyButton_Click;
		// 
		// alterComapnyButton
		// 
		alterComapnyButton.Enabled = false;
		alterComapnyButton.Location = new Point(1040, 131);
		alterComapnyButton.Name = "alterComapnyButton";
		alterComapnyButton.Size = new Size(110, 23);
		alterComapnyButton.TabIndex = 5;
		alterComapnyButton.Text = "Alter Company";
		alterComapnyButton.UseVisualStyleBackColor = true;
		alterComapnyButton.Click += alterComapnyButton_Click;
		// 
		// refreshButton
		// 
		refreshButton.Location = new Point(1040, 160);
		refreshButton.Name = "refreshButton";
		refreshButton.Size = new Size(110, 23);
		refreshButton.TabIndex = 6;
		refreshButton.Text = "Refresh";
		refreshButton.UseVisualStyleBackColor = true;
		refreshButton.Click += refreshButton_Click;
		// 
		// deleteCompanyButton
		// 
		deleteCompanyButton.Enabled = false;
		deleteCompanyButton.Location = new Point(1040, 189);
		deleteCompanyButton.Name = "deleteCompanyButton";
		deleteCompanyButton.Size = new Size(110, 23);
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
		Controls.Add(refreshButton);
		Controls.Add(alterComapnyButton);
		Controls.Add(createCompanyButton);
		Controls.Add(shutCompanyButton);
		Controls.Add(selectCompanyButton);
		Controls.Add(listOfCompaniesLabel);
		Controls.Add(listOfCompaniesListBox);
		Name = "Dashboard";
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Dashboard";
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion
	private Label listOfCompaniesLabel;
        private Button selectCompanyButton;
        private Button shutCompanyButton;
        private Button createCompanyButton;
        private Button alterComapnyButton;
	public ListBox listOfCompaniesListBox;
	private Button deleteCompanyButton;
	public Button refreshButton;
}
