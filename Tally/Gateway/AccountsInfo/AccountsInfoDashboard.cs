using Tally.Gateway.AccountsInfo.Groups;

using TallyLibrary.Models;

using TallyWinForms.Gateway.AccountsInfo.Ledgers;

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

	private void ledgersButton_Click(object sender, EventArgs e)
	{
		LedgersDashboard ledgersDashboard = new(companyModel);
		ledgersDashboard.Show();
		Hide();
	}
}
