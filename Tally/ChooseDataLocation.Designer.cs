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
		mongoDBLocal = new Button();
		mongoDBCloudButton = new Button();
		SuspendLayout();
		// 
		// textFileButton
		// 
		textFileButton.Location = new Point(12, 7);
		textFileButton.Name = "textFileButton";
		textFileButton.Size = new Size(150, 65);
		textFileButton.TabIndex = 0;
		textFileButton.Text = "Text File";
		textFileButton.UseVisualStyleBackColor = true;
		textFileButton.Click += textFileButton_Click;
		// 
		// databaseButton
		// 
		databaseButton.Location = new Point(168, 7);
		databaseButton.Name = "databaseButton";
		databaseButton.Size = new Size(150, 65);
		databaseButton.TabIndex = 1;
		databaseButton.Text = "Database";
		databaseButton.UseVisualStyleBackColor = true;
		databaseButton.Click += databaseButton_Click;
		// 
		// mongoDBLocal
		// 
		mongoDBLocal.Location = new Point(168, 78);
		mongoDBLocal.Name = "mongoDBLocal";
		mongoDBLocal.Size = new Size(150, 65);
		mongoDBLocal.TabIndex = 3;
		mongoDBLocal.Text = "MongoDB Local";
		mongoDBLocal.UseVisualStyleBackColor = true;
		mongoDBLocal.Click += mongoDBLocal_Click;
		// 
		// mongoDBCloudButton
		// 
		mongoDBCloudButton.Location = new Point(12, 78);
		mongoDBCloudButton.Name = "mongoDBCloudButton";
		mongoDBCloudButton.Size = new Size(150, 65);
		mongoDBCloudButton.TabIndex = 2;
		mongoDBCloudButton.Text = "MongoDB Cloud";
		mongoDBCloudButton.UseVisualStyleBackColor = true;
		mongoDBCloudButton.Click += mongoDBCloudButton_Click;
		// 
		// ChooseDataLocation
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(340, 154);
		Controls.Add(mongoDBLocal);
		Controls.Add(mongoDBCloudButton);
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
	private Button mongoDBLocal;
	private Button mongoDBCloudButton;
}