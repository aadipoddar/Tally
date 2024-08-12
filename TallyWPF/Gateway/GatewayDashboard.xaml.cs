using TallyLibrary.Models;

using TallyWPF.Gateway.AccountsInfo;

namespace TallyWPF.Gateway;

/// <summary>
/// Interaction logic for GatewayDashboard.xaml
/// </summary>
public partial class GatewayDashboard : Window
{
	CompanyModel companyModel = new();
	public GatewayDashboard(CompanyModel companyModel)
	{
		InitializeComponent();

		this.companyModel = companyModel;
		Title = companyModel.Name == null ? "Gateway" : companyModel.Name;
	}

	private void accountsInfoButton_Click(object sender, RoutedEventArgs e)
	{
		AccountsInfoDashboard accountsInfoDashboard = new(companyModel);
		accountsInfoDashboard.Show();
		Hide();
	}

	private void Window_Closed(object sender, EventArgs e)
	{
		Application.Current.Shutdown();
	}
}
