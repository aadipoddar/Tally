using System.IO;

using TallyLibrary.DataAccess;

namespace TallyWPF;

/// <summary>
/// Interaction logic for ChooseDataLocation.xaml
/// </summary>
public partial class ChooseDataLocation : Window
{
	private static readonly string _applicationDataPath = DataLocation.GetTextFileDataPath();

	public ChooseDataLocation()
	{
		InitializeComponent();
	}

	private void textFileButton_Click(object sender, RoutedEventArgs e)
	{
		if (!Directory.Exists(_applicationDataPath)) Directory.CreateDirectory(_applicationDataPath);
		Environment.SetEnvironmentVariable("TallyAadi", $"TF-{_applicationDataPath}", EnvironmentVariableTarget.User);
		Dashboard dashboard = new();
		dashboard.Show();
		Hide();
	}

	private void databaseButton_Click(object sender, RoutedEventArgs e)
	{
		Environment.SetEnvironmentVariable("TallyAadi", $"DB-{DataLocation.GetSQLServerName()}", EnvironmentVariableTarget.User);
		Dashboard dashboard = new();
		dashboard.Show();
		Hide();
	}

	private void mongoDBCloudButton_Click(object sender, RoutedEventArgs e)
	{
		PasswordForm passwordForm = new();
		if (passwordForm.ShowDialog() == DialogResult.GetValueOrDefault())
			Environment.SetEnvironmentVariable("TallyAadi", $"MC-mongodb+srv://aadi:{passwordForm.password}@tally.tgm1qxl.mongodb.net/?retryWrites=true&w=majority&appName=Tally", EnvironmentVariableTarget.User);

		else return;
		Dashboard dashboard = new();
		dashboard.Show();
		Hide();
	}

	private void mongoDBLocalButton_Click(object sender, RoutedEventArgs e)
	{
		Environment.SetEnvironmentVariable("TallyAadi", $"ML-mongodb://localhost:27017/", EnvironmentVariableTarget.User);
		Dashboard dashboard = new();
		dashboard.Show();
		Hide();
	}

	private void Window_Closed(object sender, EventArgs e)
	{
		Application.Current.Shutdown();
	}
}
