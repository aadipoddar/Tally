namespace Tally;

public partial class ChooseDataLocation : Form
{
	private static readonly string _applicationDataPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\TallyAadi\";

	public ChooseDataLocation()
	{
		InitializeComponent();
	}

	private void textFileButton_Click(object sender, EventArgs e)
	{
		if (!Directory.Exists(_applicationDataPath)) Directory.CreateDirectory(_applicationDataPath);
		Environment.SetEnvironmentVariable("TallyAadi", _applicationDataPath, EnvironmentVariableTarget.User);
		Dashboard dashboard = new();
		dashboard.Show();
		Hide();
	}

	private void databaseButton_Click(object sender, EventArgs e)
	{
		Environment.SetEnvironmentVariable("TallyAadi", "Database", EnvironmentVariableTarget.User);
		Dashboard dashboard = new();
		dashboard.Show();
		Hide();
	}

	private void ChooseDataLocation_FormClosed(object sender, FormClosedEventArgs e)
	{
		Application.Exit();
	}
}
