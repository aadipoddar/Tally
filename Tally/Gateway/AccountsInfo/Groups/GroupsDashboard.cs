using TallyLibrary.Models;

namespace Tally.Gateway.AccountsInfo.Groups;

public partial class GroupsDashboard : Form
{
	CompanyModel companyModel = new();

	public GroupsDashboard(CompanyModel companyModel)
	{
		InitializeComponent();

		this.companyModel = companyModel;
	}

	private void GroupsDashboard_FormClosed(object sender, FormClosedEventArgs e)
	{
		AccountsInfoDashboard accountsInfoDashboard = new(companyModel);
		accountsInfoDashboard.Show();
		Hide();
	}
}
