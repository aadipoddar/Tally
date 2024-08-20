using TallyLibrary.Models;

using TallyWPF.Gateway.AccountsInfo.Groups;
using TallyWPF.Gateway.AccountsInfo.Ledgers;

namespace TallyWPF.Gateway.AccountsInfo;

/// <summary>
/// Interaction logic for AccountsInfoDashboard.xaml
/// </summary>
public partial class AccountsInfoDashboard : Window
{
	CompanyModel companyModel = new();
	public AccountsInfoDashboard(CompanyModel companyModel)
	{
		InitializeComponent();

		this.companyModel = companyModel;
	}

	private void groupsButton_Click(object sender, RoutedEventArgs e)
	{
		GroupsDashboard groupsDashboard = new(companyModel);
		groupsDashboard.Show();
		Hide();
	}

	private void Window_Closed(object sender, EventArgs e)
	{
		GatewayDashboard gatewayDashboard = new(companyModel);
		gatewayDashboard.Show();
		Hide();
	}

	private void ledgersButton_Click(object sender, RoutedEventArgs e)
	{
		LedgersDashboard ledgersDashboard = new(companyModel);
		ledgersDashboard.Show();
		Hide();
    }
}
