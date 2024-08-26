using TallyLibrary.Data;
using TallyLibrary.Models;

namespace TallyWPF.Gateway.AccountsInfo.Ledgers;

/// <summary>
/// Interaction logic for LedgersDashboard.xaml
/// </summary>
public partial class LedgersDashboard : Window
{
	CompanyModel companyModel = new();

	public LedgersDashboard(CompanyModel companyModel)
	{
		InitializeComponent();

		this.companyModel = companyModel;

		Task task = RefreshLedgerList();
	}

	public async Task RefreshLedgerList()
	{
		ledgersListBox.ItemsSource = null;
		ledgersListBox.Items.Clear();

		var ledgers = (await LedgerData.LoadTableData<LedgerModel>("Ledgers", companyModel.Name)).ToList();

		ledgersListBox.ItemsSource = ledgers;
		ledgersListBox.DisplayMemberPath = "Name";
	}

	private void Window_Closed(object sender, EventArgs e)
	{
		AccountsInfoDashboard accountsInfoDashboard = new(companyModel);
		accountsInfoDashboard.Show();
		Hide();
	}

	private void createLedgerButton_Click(object sender, RoutedEventArgs e)
	{
		CreateLedgerForm createLedgerForm = new(companyModel, this);
		createLedgerForm.ShowDialog();
	}

	private async void alterLedgerButton_Click(object sender, RoutedEventArgs e)
	{
		if (ledgersListBox.SelectedItems.Count != 1 || ledgersListBox.SelectedItem == null)
		{
			MessageBox.Show("Please Select a Ledger", "Select Ledger", MessageBoxButton.OK);
			return;
		}

		LedgerModel ledger = (LedgerModel)ledgersListBox.SelectedItem;

		CreateLedgerForm createLedgerForm = new(companyModel, this);
		await createLedgerForm.LoadComboBoxes();
		createLedgerForm.Title = "Alter Ledger";
		createLedgerForm.createLedgerButton.Content = "Alter Ledger";
		createLedgerForm.id = ledger.Id;
		createLedgerForm.nameTextBox.Text = ledger.Name.ToString();
		createLedgerForm.underComboBox.SelectedValue = ledger.Under;
		createLedgerForm.inventoryAffectedComboBox.SelectedValue = ledger.InventoryAffected == null ? createLedgerForm.inventoryAffectedComboBox.Visibility = createLedgerForm.inventoryAffectedLabel.Visibility = Visibility.Hidden : ledger.InventoryAffected;

		if (ledger.DateReconciliation == null)
		{
			createLedgerForm.dateReconciliationDateTimePicker.Visibility = Visibility.Hidden;
			createLedgerForm.dateReconciliationLabel.Visibility = Visibility.Hidden;
		}
		else
			createLedgerForm.dateReconciliationDateTimePicker.Text = ledger.DateReconciliation.ToString();


		createLedgerForm.maintainBalancesComboBox.SelectedValue = ledger.MaintainBalances == null ? createLedgerForm.maintainBalancesComboBox.Visibility = createLedgerForm.maintainBalancesLabel.Visibility = Visibility.Hidden : ledger.MaintainBalances;

		if (ledger.MaintainBalances == null || ledger.MaintainBalances == 0)
		{
			createLedgerForm.defaultCreditPeriodLabel.Visibility = Visibility.Hidden;
			createLedgerForm.defaultCreditPeriodTextBox.Visibility = Visibility.Hidden;
		}
		else
			createLedgerForm.defaultCreditPeriodTextBox.Text = ledger.MaintainBalances.ToString();

		if (ledger.PercentageCalculation == null)
		{
			createLedgerForm.percentageOfCalculationLabel.Visibility = Visibility.Hidden;
			createLedgerForm.percentageOfCalculationTextBox.Visibility = Visibility.Hidden;

			createLedgerForm.methodOfCalculationLabel.Visibility = Visibility.Hidden;
			createLedgerForm.methodOfCalculationComboBox.Visibility = Visibility.Hidden;
		}
		else
			createLedgerForm.percentageOfCalculationTextBox.Text = ledger.PercentageCalculation.ToString();

		if (ledger.PercentageCalculation == 0)
		{
			createLedgerForm.methodOfCalculationLabel.Visibility = Visibility.Hidden;
			createLedgerForm.methodOfCalculationComboBox.Visibility = Visibility.Hidden;
		}
		else if (ledger.PercentageCalculation > 0)
		{
			createLedgerForm.methodOfCalculationLabel.Visibility = Visibility.Visible;
			createLedgerForm.methodOfCalculationComboBox.Visibility = Visibility.Visible;

			createLedgerForm.methodOfCalculationComboBox.SelectedValue = ledger.MethodOfCalculation;
		}

		createLedgerForm.ShowDialog();
	}

	private async void deleteLedgerButton_Click(object sender, RoutedEventArgs e)
	{
		if (ledgersListBox.SelectedItems.Count != 1 || ledgersListBox.SelectedItem == null)
		{
			MessageBox.Show("Please Select a Ledgers", "Select Ledger", MessageBoxButton.OK);
			return;
		}

		await LedgerData.DeleteLedgerById(((LedgerModel)ledgersListBox.SelectedItem).Id, companyModel.Name);
		await RefreshLedgerList();
	}
}
