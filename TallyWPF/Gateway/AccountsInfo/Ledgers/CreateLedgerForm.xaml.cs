using System.Windows.Controls;

using TallyLibrary.Data;
using TallyLibrary.Models;

namespace TallyWPF.Gateway.AccountsInfo.Ledgers;

/// <summary>
/// Interaction logic for CreateLedgerForm.xaml
/// </summary>
public partial class CreateLedgerForm : Window
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
		groups.RemoveAt(0);
		SetBoolComboBoxes(underComboBox, groups, "Name", "Id");
		SetBoolComboBoxes(inventoryAffectedComboBox, new List<BoolBit>() { new(0), new(1) }, "Value", "Bit");
		SetBoolComboBoxes(maintainBalancesComboBox, new List<BoolBit>() { new(0), new(1) }, "Value", "Bit");
		SetBoolComboBoxes(methodOfCalculationComboBox, (await LedgerData.LoadTableData<MethodOfCalculationModel>("MethodOfCalculation", companyModel.Name)).ToList(), "Name", "Id");

		void SetBoolComboBoxes(ComboBox comboBox, object itemsSource, string displayMember, string valueMember)
		{
			comboBox.ItemsSource = (System.Collections.IEnumerable)itemsSource;
			comboBox.DisplayMemberPath = displayMember;
			comboBox.SelectedValuePath = valueMember;
			comboBox.SelectedIndex = 0;
		}
	}

	private void underComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (((GroupModel)underComboBox.SelectedItem) == null) return;

		if (((GroupModel)underComboBox.SelectedItem).Id == 2 || ((GroupModel)underComboBox.SelectedItem).Id == 3 || ((GroupModel)underComboBox.SelectedItem).Under == 2 || ((GroupModel)underComboBox.SelectedItem).Under == 3)
		{
			dateReconciliationLabel.Visibility = Visibility.Visible;
			dateReconciliationDateTimePicker.Visibility = Visibility.Visible;

			inventoryAffectedLabel.Visibility = Visibility.Hidden;
			inventoryAffectedComboBox.Visibility = Visibility.Hidden;

			maintainBalancesLabel.Visibility = Visibility.Hidden;
			maintainBalancesComboBox.Visibility = Visibility.Hidden;

			defaultCreditPeriodLabel.Visibility = Visibility.Hidden;
			defaultCreditPeriodTextBox.Visibility = Visibility.Hidden;

			percentageOfCalculationLabel.Visibility = Visibility.Hidden;
			percentageOfCalculationTextBox.Visibility = Visibility.Hidden;

			methodOfCalculationLabel.Visibility = Visibility.Hidden;
			methodOfCalculationComboBox.Visibility = Visibility.Hidden;
		}

		else if (((GroupModel)underComboBox.SelectedItem).Id == 26 || ((GroupModel)underComboBox.SelectedItem).Id == 27 || ((GroupModel)underComboBox.SelectedItem).Under == 26 || ((GroupModel)underComboBox.SelectedItem).Under == 27)
		{
			maintainBalancesLabel.Visibility = Visibility.Visible;
			maintainBalancesComboBox.Visibility = Visibility.Visible;

			inventoryAffectedLabel.Visibility = Visibility.Visible;
			inventoryAffectedComboBox.Visibility = Visibility.Visible;

			defaultCreditPeriodLabel.Visibility = Visibility.Hidden;
			defaultCreditPeriodTextBox.Visibility = Visibility.Hidden;

			percentageOfCalculationLabel.Visibility = Visibility.Hidden;
			percentageOfCalculationTextBox.Visibility = Visibility.Hidden;

			methodOfCalculationLabel.Visibility = Visibility.Hidden;
			methodOfCalculationComboBox.Visibility = Visibility.Hidden;

			dateReconciliationLabel.Visibility = Visibility.Hidden;
			dateReconciliationDateTimePicker.Visibility = Visibility.Hidden;
		}

		else if (((GroupModel)underComboBox.SelectedItem).Id == 6 || ((GroupModel)underComboBox.SelectedItem).Id == 25 || ((GroupModel)underComboBox.SelectedItem).Under == 6 || ((GroupModel)underComboBox.SelectedItem).Under == 25)
		{
			maintainBalancesLabel.Visibility = Visibility.Hidden;
			maintainBalancesComboBox.Visibility = Visibility.Hidden;

			defaultCreditPeriodLabel.Visibility = Visibility.Hidden;
			defaultCreditPeriodTextBox.Visibility = Visibility.Hidden;

			inventoryAffectedLabel.Visibility = Visibility.Hidden;
			inventoryAffectedComboBox.Visibility = Visibility.Hidden;

			percentageOfCalculationLabel.Visibility = Visibility.Hidden;
			percentageOfCalculationTextBox.Visibility = Visibility.Hidden;

			methodOfCalculationLabel.Visibility = Visibility.Hidden;
			methodOfCalculationComboBox.Visibility = Visibility.Hidden;

			dateReconciliationLabel.Visibility = Visibility.Hidden;
			dateReconciliationDateTimePicker.Visibility = Visibility.Hidden;
		}

		else
		{
			inventoryAffectedLabel.Visibility = Visibility.Visible;
			inventoryAffectedComboBox.Visibility = Visibility.Visible;

			maintainBalancesLabel.Visibility = Visibility.Hidden;
			maintainBalancesComboBox.Visibility = Visibility.Hidden;

			defaultCreditPeriodLabel.Visibility = Visibility.Hidden;
			defaultCreditPeriodTextBox.Visibility = Visibility.Hidden;

			percentageOfCalculationLabel.Visibility = Visibility.Hidden;
			percentageOfCalculationTextBox.Visibility = Visibility.Hidden;

			methodOfCalculationLabel.Visibility = Visibility.Hidden;
			methodOfCalculationComboBox.Visibility = Visibility.Hidden;

			dateReconciliationLabel.Visibility = Visibility.Hidden;
			dateReconciliationDateTimePicker.Visibility = Visibility.Hidden;
		}

		if (((GroupModel)underComboBox.SelectedItem).UsedForCalculation == 1)
		{
			percentageOfCalculationLabel.Visibility = Visibility.Visible;
			percentageOfCalculationTextBox.Visibility = Visibility.Visible;
		}

		else
		{
			percentageOfCalculationLabel.Visibility = Visibility.Hidden;
			percentageOfCalculationTextBox.Visibility = Visibility.Hidden;
		}

		if (((GroupModel)underComboBox.SelectedItem).Id == 14 || ((GroupModel)underComboBox.SelectedItem).Under == 14)
		{
			percentageOfCalculationLabel.Visibility = Visibility.Visible;
			percentageOfCalculationTextBox.Visibility = Visibility.Visible;
		}
	}

	private void maintainBalancesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (maintainBalancesComboBox.SelectedItem == null) return;

		if (((BoolBit)maintainBalancesComboBox.SelectedItem).Bit == 0)
		{
			defaultCreditPeriodLabel.Visibility = Visibility.Hidden;
			defaultCreditPeriodTextBox.Visibility = Visibility.Hidden;
		}

		else
		{
			defaultCreditPeriodLabel.Visibility = Visibility.Visible;
			defaultCreditPeriodTextBox.Visibility = Visibility.Visible;
		}
	}

	private void percentageOfCalculationTextBox_TextChanged(object sender, TextChangedEventArgs e)
	{
		if (percentageOfCalculationTextBox.Text == "")
		{
			methodOfCalculationLabel.Visibility = Visibility.Hidden;
			methodOfCalculationComboBox.Visibility = Visibility.Hidden;
		}

		else if (Decimal.Parse(percentageOfCalculationTextBox.Text) > 0)
		{
			methodOfCalculationLabel.Visibility = Visibility.Visible;
			methodOfCalculationComboBox.Visibility = Visibility.Visible;
		}

		else
		{
			methodOfCalculationLabel.Visibility = Visibility.Hidden;
			methodOfCalculationComboBox.Visibility = Visibility.Hidden;
		}
	}

	private bool ValidateAndAssign()
	{
		if (createLedgerButton.Content.ToString() == "Alter Ledger")
			ledgerModel.Id = id;

		if (nameTextBox.Text != string.Empty)
			ledgerModel.Name = nameTextBox.Text;

		else
		{
			MessageBox.Show("Ledger Must have a Name", "Leger Name Not Found", MessageBoxButton.OK);
			return false;
		}

		if (createLedgerButton.Content.ToString() == "Create Ledger")
		{
			foreach (LedgerModel ledger in ledgersDashboard.ledgersListBox.Items)
			{
				if (nameTextBox.Text == ledger.Name)
				{
					MessageBox.Show("Ledger Name Already Exists", "Ledger Name Conflict", MessageBoxButton.OK);
					return false;
				}
			}
		}

		ledgerModel.Under = Convert.ToInt32(underComboBox.SelectedValue);

		if (inventoryAffectedComboBox.Visibility == Visibility.Visible)
			ledgerModel.InventoryAffected = Convert.ToInt32(inventoryAffectedComboBox.SelectedValue);

		if (dateReconciliationDateTimePicker.Visibility == Visibility.Visible)
			ledgerModel.DateReconciliation = DateTime.Parse(dateReconciliationDateTimePicker.Text);

		if (maintainBalancesComboBox.Visibility == Visibility.Visible)
			ledgerModel.MaintainBalances = Convert.ToInt32(maintainBalancesComboBox.SelectedValue);

		if (defaultCreditPeriodTextBox.Visibility == Visibility.Visible)
			ledgerModel.DefaultCreditPeriod = Convert.ToInt32(defaultCreditPeriodTextBox.Text);

		if (percentageOfCalculationTextBox.Visibility == Visibility.Visible)
			ledgerModel.PercentageCalculation = Convert.ToDouble(percentageOfCalculationTextBox.Text);

		if (methodOfCalculationComboBox.Visibility == Visibility.Visible)
			ledgerModel.MethodOfCalculation = Convert.ToInt32(methodOfCalculationComboBox.SelectedValue);

		return true;
	}

	private async void createLedgerButton_Click(object sender, RoutedEventArgs e)
	{
		if (!ValidateAndAssign()) return;

		if (createLedgerButton.Content.ToString() == "Alter Ledger")
			await LedgerData.UpdateLedgerTable(ledgerModel, companyModel.Name);

		else await LedgerData.InsertIntoLedgerTable(ledgerModel, companyModel.Name);
		await ledgersDashboard.RefreshLedgerList();
		Close();
	}
}
