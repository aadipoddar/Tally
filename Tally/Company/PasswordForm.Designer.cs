namespace Tally.Company;

partial class PasswordForm
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
		passwordTextBox = new TextBox();
		enterPasswordLabel = new Label();
		goButton = new Button();
		SuspendLayout();
		// 
		// passwordTextBox
		// 
		passwordTextBox.Location = new Point(54, 80);
		passwordTextBox.Name = "passwordTextBox";
		passwordTextBox.PasswordChar = '*';
		passwordTextBox.Size = new Size(212, 23);
		passwordTextBox.TabIndex = 0;
		// 
		// enterPasswordLabel
		// 
		enterPasswordLabel.AutoSize = true;
		enterPasswordLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
		enterPasswordLabel.Location = new Point(54, 27);
		enterPasswordLabel.Name = "enterPasswordLabel";
		enterPasswordLabel.Size = new Size(173, 32);
		enterPasswordLabel.TabIndex = 1;
		enterPasswordLabel.Text = "Enter Password";
		// 
		// goButton
		// 
		goButton.Location = new Point(272, 114);
		goButton.Name = "goButton";
		goButton.Size = new Size(100, 35);
		goButton.TabIndex = 2;
		goButton.Text = "GO";
		goButton.UseVisualStyleBackColor = true;
		goButton.Click += goButton_ClickAsync;
		// 
		// PasswordForm
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(384, 161);
		Controls.Add(goButton);
		Controls.Add(enterPasswordLabel);
		Controls.Add(passwordTextBox);
		Name = "PasswordForm";
		StartPosition = FormStartPosition.CenterScreen;
		Text = "PasswordForm";
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private TextBox passwordTextBox;
	private Label enterPasswordLabel;
	private Button goButton;
}