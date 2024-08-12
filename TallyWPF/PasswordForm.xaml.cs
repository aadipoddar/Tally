namespace TallyWPF;

/// <summary>
/// Interaction logic for PasswordForm.xaml
/// </summary>
public partial class PasswordForm : Window
{
	public string password;
	public bool correctPassword;

	public PasswordForm(string password = null)
	{
		InitializeComponent();

		this.password = password;
	}

	private void okButton_Click(object sender, RoutedEventArgs e)
	{
		if (password == null)
			password = passwordTextBox.Password;

		if (passwordTextBox.Password == password)
			correctPassword = true;

		else
			MessageBox.Show("Please Retry Password", "Incorrect Password", MessageBoxButton.OK);

		Close();
	}

	private void Window_Loaded(object sender, RoutedEventArgs e)
	{
		passwordTextBox.Focus();
	}
}