using Tally.Gateway.AccountsInfo.Groups;

using TallyLibrary.Models;

namespace Tally.Gateway.AccountsInfo;

public partial class AccountsInfoDashboard : Form
{
	CompanyModel companyModel;

	public AccountsInfoDashboard(CompanyModel companyModel)
	{
		InitializeComponent();

		this.companyModel = companyModel;
	}

	private void AccountsInfoDashboard_FormClosed(object sender, FormClosedEventArgs e)
	{
		GatewayDashboard gatewayDashboard = new(companyModel);
		gatewayDashboard.Show();
		Hide();
	}

	private void groupsButton_Click(object sender, EventArgs e)
	{
		GroupsDashboard groupsDashboard = new(companyModel);
		groupsDashboard.Show();
		Hide();
	}
}
