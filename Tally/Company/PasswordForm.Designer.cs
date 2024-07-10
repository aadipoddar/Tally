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
		okButton = new Button();
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
		// okButton
		// 
		okButton.DialogResult = DialogResult.OK;
		okButton.Location = new Point(272, 114);
		okButton.Name = "okButton";
		okButton.Size = new Size(100, 35);
		okButton.TabIndex = 2;
		okButton.Text = "OK";
		okButton.UseVisualStyleBackColor = true;
		okButton.Click += okButton_Click;
		// 
		// PasswordForm
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(384, 161);
		Controls.Add(okButton);
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
	private Button okButton;
}