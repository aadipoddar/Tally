using TallyLibrary.Data;
using TallyLibrary.Models;

namespace TallyWinForms.Gateway.AccountsInfo.Ledgers;

public partial class CreateLedgerForm : Form
{
	static CompanyModel companyModel = new();
	LedgerModel ledgerModel = new();
	LedgersDashboard ledgersDashboard = new(companyModel);
	public int id;

	public CreateLedgerForm(CompanyModel company, LedgersDashboard ledgersDashboard)
	{
		InitializeComponent();

		companyModel = company;
		this.ledgersDashboard = ledgersDashboard;

		Task task = LoadComboBoxes();
	}

	public async Task LoadComboBoxes()
	{
		var groups = (await GroupData.LoadTableData<GroupModel>("Groups", companyModel.Name)).ToList();
		SetBoolComboBoxes(underComboBox, groups, "Name", "Id");
		SetBoolComboBoxes(inventoryAffectedComboBox, new List<BoolBit>() { new(0), new(1) }, "Value", "Bit");
		SetBoolComboBoxes(maintainBalancesComboBox, new List<BoolBit>() { new(0), new(1) }, "Value", "Bit");
		SetBoolComboBoxes(methodOfCalculationComboBox, (await LedgerData.LoadTableData<MethodOfCalculationModel>("MethodOfCalculation", companyModel.Name)).ToList(), "Name", "Id");

		void SetBoolComboBoxes(ComboBox comboBox, object dataSource, string displayMember, string valueMember)
		{
			comboBox.DataSource = dataSource;
			comboBox.DisplayMember = displayMember;
			comboBox.ValueMember = valueMember;
		}
	}

	private void underComboBox_SelectedValueChanged(object sender, EventArgs e)
	{
		if ((GroupModel)underComboBox.SelectedItem is null)
			return;

		if (((GroupModel)underComboBox.SelectedItem).Id == 2 || ((GroupModel)underComboBox.SelectedItem).Id == 3 || ((GroupModel)underComboBox.SelectedItem).Under == 2 || ((GroupModel)underComboBox.SelectedItem).Under == 3)
		{
			dateReconciliationLabel.Visible = true;
			dateReconciliationDateTimePicker.Visible = true;

			inventoryAffectedLabel.Visible = false;
			inventoryAffectedComboBox.Visible = false;

			maintainBalancesLabel.Visible = false;
			maintainBalancesComboBox.Visible = false;

			defaultCreditPeriodLabel.Visible = false;
			defaultCreditPeriodTextBox.Visible = false;

			percentageOfCalculationLabel.Visible = false;
			percentageOfCalculationTextBox.Visible = false;

			methodOfCalculationLabel.Visible = false;
			methodOfCalculationComboBox.Visible = false;
		}

		else if (((GroupModel)underComboBox.SelectedItem).Id == 26 || ((GroupModel)underComboBox.SelectedItem).Id == 27 || ((GroupModel)underComboBox.SelectedItem).Under == 26 || ((GroupModel)underComboBox.SelectedItem).Under == 27)
		{
			maintainBalancesLabel.Visible = true;
			maintainBalancesComboBox.Visible = true;

			inventoryAffectedLabel.Visible = true;
			inventoryAffectedComboBox.Visible = true;

			defaultCreditPeriodLabel.Visible = false;
			defaultCreditPeriodTextBox.Visible = false;

			percentageOfCalculationLabel.Visible = false;
			percentageOfCalculationTextBox.Visible = false;

			methodOfCalculationLabel.Visible = false;
			methodOfCalculationComboBox.Visible = false;

			dateReconciliationLabel.Visible = false;
			dateReconciliationDateTimePicker.Visible = false;
		}

		else if (((GroupModel)underComboBox.SelectedItem).Id == 6 || ((GroupModel)underComboBox.SelectedItem).Id == 25 || ((GroupModel)underComboBox.SelectedItem).Under == 6 || ((GroupModel)underComboBox.SelectedItem).Under == 25)
		{
			maintainBalancesLabel.Visible = false;
			maintainBalancesComboBox.Visible = false;

			defaultCreditPeriodLabel.Visible = false;
			defaultCreditPeriodTextBox.Visible = false;

			inventoryAffectedLabel.Visible = false;
			inventoryAffectedComboBox.Visible = false;

			percentageOfCalculationLabel.Visible = false;
			percentageOfCalculationTextBox.Visible = false;

			methodOfCalculationLabel.Visible = false;
			methodOfCalculationComboBox.Visible = false;

			dateReconciliationLabel.Visible = false;
			dateReconciliationDateTimePicker.Visible = false;
		}

		else
		{
			inventoryAffectedLabel.Visible = true;
			inventoryAffectedComboBox.Visible = true;

			maintainBalancesLabel.Visible = false;
			maintainBalancesComboBox.Visible = false;

			defaultCreditPeriodLabel.Visible = false;
			defaultCreditPeriodTextBox.Visible = false;

			percentageOfCalculationLabel.Visible = false;
			percentageOfCalculationTextBox.Visible = false;

			methodOfCalculationLabel.Visible = false;
			methodOfCalculationComboBox.Visible = false;

			dateReconciliationLabel.Visible = false;
			dateReconciliationDateTimePicker.Visible = false;
		}

		if (((GroupModel)underComboBox.SelectedItem).UsedForCalculation == 1)
		{
			percentageOfCalculationLabel.Visible = true;
			percentageOfCalculationTextBox.Visible = true;
		}

		else
		{
			percentageOfCalculationLabel.Visible = false;
			percentageOfCalculationTextBox.Visible = false;
		}

		if (((GroupModel)underComboBox.SelectedItem).Id == 14 || ((GroupModel)underComboBox.SelectedItem).Under == 14)
		{
			percentageOfCalculationLabel.Visible = true;
			percentageOfCalculationTextBox.Visible = true;
		}
	}

	private void percentageOfCalculationTextBox_TextChanged(object sender, EventArgs e)
	{
		if (percentageOfCalculationTextBox.Text == "")
		{
			methodOfCalculationLabel.Visible = false;
			methodOfCalculationComboBox.Visible = false;
		}

		else if (Decimal.Parse(percentageOfCalculationTextBox.Text) > 0)
		{
			methodOfCalculationLabel.Visible = true;
			methodOfCalculationComboBox.Visible = true;
		}

		else
		{
			methodOfCalculationLabel.Visible = false;
			methodOfCalculationComboBox.Visible = false;
		}
	}

	private void maintainBalancesComboBox_SelectedValueChanged(object sender, EventArgs e)
	{
		if (maintainBalancesComboBox.SelectedItem == null) return;

		if (((BoolBit)maintainBalancesComboBox.SelectedItem).Bit == 0)
		{
			defaultCreditPeriodLabel.Visible = false;
			defaultCreditPeriodTextBox.Visible = false;
		}

		else
		{
			defaultCreditPeriodLabel.Visible = true;
			defaultCreditPeriodTextBox.Visible = true;
		}
	}

	private bool ValidateAndAssign()
	{
		if (createLedgerButton.Text == "Alter Ledger")
			ledgerModel.Id = id;

		if (nameTextBox.Text != string.Empty)
			ledgerModel.Name = nameTextBox.Text;

		else
		{
			MessageBox.Show("Ledger Must have a Name", "Leger Name Not Found", MessageBoxButtons.OK);
			return false;
		}

		if (createLedgerButton.Text == "Create Ledger")
		{
			foreach (LedgerModel ledger in ledgersDashboard.ledgersListBox.Items)
			{
				if (nameTextBox.Text == ledger.Name)
				{
					MessageBox.Show("Ledger Name Already Exists", "Ledger Name Conflict", MessageBoxButtons.OK);
					return false;
				}
			}
		}

		ledgerModel.Under = Convert.ToInt32(underComboBox.SelectedValue);

		if (inventoryAffectedComboBox.Visible == true)
			ledgerModel.InventoryAffected = Convert.ToInt32(inventoryAffectedComboBox.SelectedValue);

		if (dateReconciliationDateTimePicker.Visible == true)
			ledgerModel.DateReconciliation = DateTime.Parse(dateReconciliationDateTimePicker.Text);

		if (maintainBalancesComboBox.Visible == true)
			ledgerModel.MaintainBalances = Convert.ToInt32(maintainBalancesComboBox.SelectedValue);

		if (defaultCreditPeriodTextBox.Visible == true)
			ledgerModel.DefaultCreditPeriod = Convert.ToInt32(defaultCreditPeriodTextBox.Text);

		if (percentageOfCalculationTextBox.Visible == true)
			ledgerModel.PercentageCalculation = Convert.ToDouble(percentageOfCalculationTextBox.Text);

		if (methodOfCalculationComboBox.Visible == true)
			ledgerModel.MethodOfCalculation = Convert.ToInt32(methodOfCalculationComboBox.SelectedValue);

		return true;
	}

	private async void createLedgerButton_Click(object sender, EventArgs e)
	{
		if (!ValidateAndAssign()) return;

		if (createLedgerButton.Text == "Alter Ledger")
			await LedgerData.UpdateTable(ledgerModel, companyModel.Name);

		else await LedgerData.InsertIntoTable(ledgerModel, companyModel.Name);
		await ledgersDashboard.RefreshLedgerList();
		Close();
	}
}
