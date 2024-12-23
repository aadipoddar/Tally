namespace TallyWinForms.Gateway.Vouchers
{
	partial class SelectVoucherType
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
			voucherTypeComboBox = new ComboBox();
			okButton = new Button();
			SuspendLayout();
			// 
			// voucherTypeComboBox
			// 
			voucherTypeComboBox.Font = new Font("Segoe UI", 12F);
			voucherTypeComboBox.FormattingEnabled = true;
			voucherTypeComboBox.Location = new Point(30, 35);
			voucherTypeComboBox.Name = "voucherTypeComboBox";
			voucherTypeComboBox.Size = new Size(187, 29);
			voucherTypeComboBox.TabIndex = 0;
			// 
			// okButton
			// 
			okButton.Font = new Font("Segoe UI", 12F);
			okButton.ForeColor = SystemColors.ControlText;
			okButton.Location = new Point(64, 81);
			okButton.Name = "okButton";
			okButton.Size = new Size(118, 44);
			okButton.TabIndex = 1;
			okButton.Text = "OK";
			okButton.UseVisualStyleBackColor = true;
			okButton.Click += okButton_Click;
			// 
			// SelectVoucherType
			// 
			AcceptButton = okButton;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(254, 161);
			Controls.Add(okButton);
			Controls.Add(voucherTypeComboBox);
			Name = "SelectVoucherType";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "SelectVoucherType";
			FormClosed += SelectVoucherType_FormClosed;
			ResumeLayout(false);
		}

		#endregion

		private ComboBox voucherTypeComboBox;
		private Button okButton;
	}
}