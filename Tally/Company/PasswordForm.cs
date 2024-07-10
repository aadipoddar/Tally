namespace Tally.Company;

public partial class PasswordForm : Form
{
	String password;
	public bool correctPassword;

	public PasswordForm(string password)
	{
		InitializeComponent();

		this.password = password;
	}

	private void okButton_Click(object sender, EventArgs e)
	{
		if (passwordTextBox.Text == password)
			correctPassword = true;

		else
			MessageBox.Show("Please Retry Password", "Incorrect Password", MessageBoxButtons.OK);
	}
}
