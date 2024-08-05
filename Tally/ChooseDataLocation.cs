using TallyLibrary.DataAccess;

namespace Tally;

public partial class ChooseDataLocation : Form
{
	private static readonly string _applicationDataPath = DataLocation.GetTextFileDataPath();

	public ChooseDataLocation()
	{
		InitializeComponent();
	}

	private void textFileButton_Click(object sender, EventArgs e)
	{
		if (!Directory.Exists(_applicationDataPath)) Directory.CreateDirectory(_applicationDataPath);
		Environment.SetEnvironmentVariable("TallyAadi", $"TF-{_applicationDataPath}", EnvironmentVariableTarget.User);
		Dashboard dashboard = new();
		dashboard.Show();
		Hide();
	}

	private void databaseButton_Click(object sender, EventArgs e)
	{
		Environment.SetEnvironmentVariable("TallyAadi", $"DB-{DataLocation.GetSQLServerName()}", EnvironmentVariableTarget.User);
		Dashboard dashboard = new();
		dashboard.Show();
		Hide();
	}

	private void ChooseDataLocation_FormClosed(object sender, FormClosedEventArgs e)
	{
		Application.Exit();
	}
}
