using Tally.Gateway.AccountsInfo;

using TallyLibrary.Models;

namespace Tally.Gateway;

public partial class GatewayDashboard : Form
{
	CompanyModel companyModel;

	public GatewayDashboard(CompanyModel companyModel)
	{
		InitializeComponent();

		this.companyModel = companyModel;
		Text = companyModel.Name;
	}

	private void GatewayDashboard_FormClosed(object sender, FormClosedEventArgs e)
	{
		Application.Exit();
	}

	private void accountsInfoButton_Click(object sender, EventArgs e)
	{
		AccountsInfoDashboard accountsInfoDashboard = new(companyModel);
		accountsInfoDashboard.Show();
		Hide();
	}
}
