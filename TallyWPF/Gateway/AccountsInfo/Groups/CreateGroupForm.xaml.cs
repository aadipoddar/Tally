using System.Windows.Controls;

using MongoDB.Bson;

using TallyLibrary.Data;
using TallyLibrary.Models;

namespace TallyWPF.Gateway.AccountsInfo.Groups;

/// <summary>
/// Interaction logic for CreateGroupForm.xaml
/// </summary>
public partial class CreateGroupForm : Window
{
	static CompanyModel companyModel = new();
	GroupModel groupModel = new();
	GroupsDashboard groupsDashboard = new(companyModel);
	public int id;

	public CreateGroupForm(CompanyModel company, GroupsDashboard groupsDashboard)
	{
		InitializeComponent();

		companyModel = company;
		this.groupsDashboard = groupsDashboard;

		Task task = LoadComboBoxes();
	}

	public async Task LoadComboBoxes()
	{
		SetBoolComboBoxes(underComboBox, await GroupData.LoadTableData<GroupModel>("Groups", companyModel.Name), "Name", "Id");
		SetBoolComboBoxes(natureOfGroupComboBox, await GroupData.LoadTableData<NatureOfGroupModel>("NatureOfGroup", companyModel.Name), "Name", "Id");
		SetBoolComboBoxes(affectGrossProfitComboBox, new List<BoolBit>() { new(0), new(1) }, "Value", "Bit");
		SetBoolComboBoxes(behavesSubLedgerComboBox, new List<BoolBit>() { new(0), new(1) }, "Value", "Bit");
		SetBoolComboBoxes(netBalancesComboBox, new List<BoolBit>() { new(0), new(1) }, "Value", "Bit");
		SetBoolComboBoxes(usedForCalculationComboBox, new List<BoolBit>() { new(0), new(1) }, "Value", "Bit");
		SetBoolComboBoxes(methodToAllocateComboBox, await GroupData.LoadTableData<MethodToAllocateModel>("MethodToAllocate", companyModel.Name), "Name", "Id");

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
		if (underComboBox.SelectedIndex != 0)
		{
			natureOfGroupLabel.Visibility = Visibility.Hidden;
			natureOfGroupLabel.IsEnabled = false;

			natureOfGroupComboBox.Visibility = Visibility.Hidden;
			natureOfGroupComboBox.IsEnabled = false;

			affectGrossProfitLabel.Visibility = Visibility.Hidden;
			affectGrossProfitLabel.IsEnabled = false;

			affectGrossProfitComboBox.Visibility = Visibility.Hidden;
			affectGrossProfitComboBox.IsEnabled = false;
		}

		else if (underComboBox.SelectedIndex == 0)
		{
			natureOfGroupLabel.Visibility = Visibility.Visible;
			natureOfGroupLabel.IsEnabled = true;

			natureOfGroupComboBox.Visibility = Visibility.Visible;
			natureOfGroupComboBox.IsEnabled = true;
		}
	}

	private void natureOfGroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (natureOfGroupComboBox.SelectedItem == null)
		{
			natureOfGroupComboBox.SelectedValue = 1;

			affectGrossProfitLabel.Visibility = Visibility.Hidden;
			affectGrossProfitLabel.IsEnabled = false;

			affectGrossProfitComboBox.Visibility = Visibility.Hidden;
			affectGrossProfitComboBox.IsEnabled = false;
		}

		else if (natureOfGroupComboBox.SelectedIndex == 0 || natureOfGroupComboBox.SelectedIndex == 3)
		{
			affectGrossProfitLabel.Visibility = Visibility.Hidden;
			affectGrossProfitLabel.IsEnabled = false;

			affectGrossProfitComboBox.Visibility = Visibility.Hidden;
			affectGrossProfitComboBox.IsEnabled = false;
		}

		else if (natureOfGroupComboBox.SelectedIndex == 1 || natureOfGroupComboBox.SelectedIndex == 2)
		{
			affectGrossProfitLabel.Visibility = Visibility.Visible;
			affectGrossProfitLabel.IsEnabled = true;

			affectGrossProfitComboBox.Visibility = Visibility.Visible;
			affectGrossProfitComboBox.IsEnabled = true;
		}
	}

	private void natureOfGroupComboBox_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
	{
		if (natureOfGroupComboBox.Visibility == Visibility.Visible)
		{
			if (natureOfGroupComboBox.SelectedValue == null)
			{
				natureOfGroupComboBox.SelectedValue = 1;

				affectGrossProfitLabel.Visibility = Visibility.Hidden;
				affectGrossProfitLabel.IsEnabled = false;

				affectGrossProfitComboBox.Visibility = Visibility.Hidden;
				affectGrossProfitComboBox.IsEnabled = false;
			}

			else if (natureOfGroupComboBox.SelectedIndex == 1 || natureOfGroupComboBox.SelectedIndex == 2)
			{
				affectGrossProfitLabel.Visibility = Visibility.Visible;
				affectGrossProfitLabel.IsEnabled = true;

				affectGrossProfitComboBox.Visibility = Visibility.Visible;
				affectGrossProfitComboBox.IsEnabled = true;
			}
		}
	}

	private void affectGrossProfitComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (affectGrossProfitComboBox.Visibility == Visibility.Visible)
			if (affectGrossProfitComboBox.SelectedValue == null)
				affectGrossProfitComboBox.SelectedValue = 0;
	}

	private bool ValidateAndAssign()
	{
		if (createGroupButton.Content.ToString() == "Alter Group")
			groupModel.Id = id;

		if (nameTextBox.Text != string.Empty)
			groupModel.Name = nameTextBox.Text;

		else
		{
			MessageBox.Show("Group Must have a Name", "Group Name Not Found", MessageBoxButton.OK);
			return false;
		}

		if (createGroupButton.Content.ToString() == "Create Group")
		{
			foreach (GroupModel group in groupsDashboard.groupsListBox.Items)
			{
				if (nameTextBox.Text == group.Name)
				{
					MessageBox.Show("Group Name Already Exists", "Group Name Conflict", MessageBoxButton.OK);
					return false;
				}
			}
		}

		groupModel.Under = Convert.ToInt32(underComboBox.SelectedValue);

		if (underComboBox.SelectedIndex == 0)
		{
			groupModel.NatureOfGroup = Convert.ToInt32(natureOfGroupComboBox.SelectedValue);
			if (natureOfGroupComboBox.SelectedIndex == 0 || natureOfGroupComboBox.SelectedIndex == 3)
				groupModel.AffectGrossProfit = null;
			else
				groupModel.AffectGrossProfit = Convert.ToInt32(affectGrossProfitComboBox.SelectedValue);
		}

		else
		{
			groupModel.NatureOfGroup = null;
			groupModel.AffectGrossProfit = null;
		}

		groupModel.BehavesSubLedger = Convert.ToInt32(behavesSubLedgerComboBox.SelectedValue);
		groupModel.NetBalances = Convert.ToInt32(netBalancesComboBox.SelectedValue);
		groupModel.UsedForCalculation = Convert.ToInt32(usedForCalculationComboBox.SelectedValue);
		groupModel.MethodToAllocate = Convert.ToInt32(methodToAllocateComboBox.SelectedValue);

		return true;
	}

	private async void createGroupButton_Click(object sender, RoutedEventArgs e)
	{
		if (!ValidateAndAssign()) return;

		if (createGroupButton.Content.ToString() == "Alter Group")
			await GroupData.UpdateGroupTable(groupModel, companyModel.Name);

		else await GroupData.InsertIntoGroupTable(groupModel, companyModel.Name);

		await groupsDashboard.RefreshGroupList();
		Close();
	}
}