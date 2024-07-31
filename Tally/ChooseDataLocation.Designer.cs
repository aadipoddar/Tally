namespace Tally;

partial class ChooseDataLocation
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
		textFileButton = new Button();
		databaseButton = new Button();
		SuspendLayout();
		// 
		// textFileButton
		// 
		textFileButton.Location = new Point(12, 46);
		textFileButton.Name = "textFileButton";
		textFileButton.Size = new Size(109, 45);
		textFileButton.TabIndex = 0;
		textFileButton.Text = "Text File";
		textFileButton.UseVisualStyleBackColor = true;
		textFileButton.Click += textFileButton_Click;
		// 
		// databaseButton
		// 
		databaseButton.Location = new Point(127, 46);
		databaseButton.Name = "databaseButton";
		databaseButton.Size = new Size(117, 45);
		databaseButton.TabIndex = 1;
		databaseButton.Text = "Database";
		databaseButton.UseVisualStyleBackColor = true;
		databaseButton.Click += databaseButton_Click;
		// 
		// ChooseDataLocation
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(256, 150);
		Controls.Add(databaseButton);
		Controls.Add(textFileButton);
		Name = "ChooseDataLocation";
		StartPosition = FormStartPosition.CenterScreen;
		Text = "ChooseDataLocation";
		FormClosed += ChooseDataLocation_FormClosed;
		ResumeLayout(false);
	}

	#endregion

	private Button textFileButton;
	private Button databaseButton;
}