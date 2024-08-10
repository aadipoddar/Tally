namespace Tally.Company;

public partial class PasswordForm : Form
{
	public string password;
	public bool correctPassword;

	public PasswordForm(string password = null)
	{
		InitializeComponent();

		this.password = password;
	}

	private void okButton_Click(object sender, EventArgs e)
	{
		if (password == null)
			password = passwordTextBox.Text;

		if (passwordTextBox.Text == password)
			correctPassword = true;

		else
			MessageBox.Show("Please Retry Password", "Incorrect Password", MessageBoxButtons.OK);
	}
}
