using Tally.Gateway.AccountsInfo;

using TallyLibrary.Data;
using TallyLibrary.Models;

namespace TallyWinForms.Gateway.AccountsInfo.Ledgers;

public partial class LedgersDashboard : Form
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
		ledgersListBox.DataSource = null;
		ledgersListBox.Items.Clear();

		var ledgers = (await LedgerData.LoadTableData<LedgerModel>("Ledgers", companyModel.Name)).ToList();

		ledgersListBox.DataSource = ledgers;
		ledgersListBox.DisplayMember = "Name";
	}

	private void LedgersDashboard_FormClosed(object sender, FormClosedEventArgs e)
	{
		AccountsInfoDashboard accountsInfoDashboard = new(companyModel);
		accountsInfoDashboard.Show();
		Hide();
	}

	private async void deleteLedgerButton_Click(object sender, EventArgs e)
	{
		if (ledgersListBox.SelectedItems.Count != 1 || ledgersListBox.SelectedItem == null)
		{
			MessageBox.Show("Please Select a Ledger", "Select Ledger", MessageBoxButtons.OK);
			return;
		}

		await LedgerData.DeleteById(((LedgerModel)ledgersListBox.SelectedItem).Id, companyModel.Name);
		await RefreshLedgerList();
	}

	private void createLedgerButton_Click(object sender, EventArgs e)
	{
		CreateLedgerForm createLedgerForm = new(companyModel, this);
		createLedgerForm.ShowDialog();
	}

	private async void alterLedgerButton_Click(object sender, EventArgs e)
	{
		if (ledgersListBox.SelectedItems.Count != 1 || ledgersListBox.SelectedItem == null)
		{
			MessageBox.Show("Please Select a Ledger", "Select Ledger", MessageBoxButtons.OK);
			return;
		}

		LedgerModel ledger = (LedgerModel)ledgersListBox.SelectedItem;

		CreateLedgerForm createLedgerForm = new(companyModel, this);
		await createLedgerForm.LoadComboBoxes();
		createLedgerForm.Text = createLedgerForm.createLedgerButton.Text = "Alter Ledger";
		createLedgerForm.id = ledger.Id;
		createLedgerForm.nameTextBox.Text = ledger.Name.ToString();
		createLedgerForm.underComboBox.SelectedValue = ledger.Under;
		createLedgerForm.inventoryAffectedComboBox.SelectedValue = ledger.InventoryAffected == null ? createLedgerForm.inventoryAffectedComboBox.Visible = createLedgerForm.inventoryAffectedLabel.Visible = false : ledger.InventoryAffected;

		if (ledger.DateReconciliation == null)
		{
			createLedgerForm.dateReconciliationDateTimePicker.Visible = false;
			createLedgerForm.dateReconciliationLabel.Visible = false;
		}
		else
			createLedgerForm.dateReconciliationDateTimePicker.Text = ledger.DateReconciliation.ToString();


		createLedgerForm.maintainBalancesComboBox.SelectedValue = ledger.MaintainBalances == null ? createLedgerForm.maintainBalancesComboBox.Visible = createLedgerForm.maintainBalancesLabel.Visible = false : ledger.MaintainBalances;

		if (ledger.MaintainBalances == null || ledger.MaintainBalances == 0)
		{
			createLedgerForm.defaultCreditPeriodLabel.Visible = false;
			createLedgerForm.defaultCreditPeriodTextBox.Visible = false;
		}
		else
			createLedgerForm.defaultCreditPeriodTextBox.Text = ledger.MaintainBalances.ToString();

		if (ledger.PercentageCalculation == null)
		{
			createLedgerForm.percentageOfCalculationLabel.Visible = false;
			createLedgerForm.percentageOfCalculationTextBox.Visible = false;

			createLedgerForm.methodOfCalculationLabel.Visible = false;
			createLedgerForm.methodOfCalculationComboBox.Visible = false;
		}
		else
			createLedgerForm.percentageOfCalculationTextBox.Text = ledger.PercentageCalculation.ToString();

		if (ledger.PercentageCalculation == 0)
		{
			createLedgerForm.methodOfCalculationLabel.Visible = false;
			createLedgerForm.methodOfCalculationComboBox.Visible = false;
		}
		else if (ledger.PercentageCalculation > 0)
		{
			createLedgerForm.methodOfCalculationLabel.Visible = true;
			createLedgerForm.methodOfCalculationComboBox.Visible = true;

			createLedgerForm.methodOfCalculationComboBox.SelectedValue = ledger.MethodOfCalculation;
		}

		createLedgerForm.ShowDialog();
	}
}
