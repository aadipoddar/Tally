using TallyLibrary.Data;
using TallyLibrary.Models;

namespace TallyWPF.Gateway.AccountsInfo.Groups;

/// <summary>
/// Interaction logic for GroupsDashboard.xaml
/// </summary>
public partial class GroupsDashboard : Window
{
	CompanyModel companyModel = new();

	public GroupsDashboard(CompanyModel companyModel)
	{
		InitializeComponent();

		this.companyModel = companyModel;

		Task task = RefreshGroupList();
	}

	public async Task RefreshGroupList()
	{
		groupsListBox.ItemsSource = null;
		groupsListBox.Items.Clear();

		var groups = (await GroupData.LoadTableData<GroupModel>("Groups", companyModel.Name)).ToList();

		groups.RemoveAt(0);

		groupsListBox.ItemsSource = groups;
		groupsListBox.DisplayMemberPath = "Name";
	}

	private void Window_Closed(object sender, EventArgs e)
	{
		AccountsInfoDashboard accountsInfoDashboard = new(companyModel);
		accountsInfoDashboard.Show();
		Hide();
	}

	private void createGroupButton_Click(object sender, RoutedEventArgs e)
	{
		CreateGroupForm createGroupForm = new(companyModel, this);
		createGroupForm.ShowDialog();
	}

	private async void alterGroupButton_Click(object sender, RoutedEventArgs e)
	{
		if (groupsListBox.SelectedItems.Count != 1 || groupsListBox.SelectedItem == null)
		{
			MessageBox.Show("Please Select a Group", "Select Group", MessageBoxButton.OK);
			return;
		}

		GroupModel group = (GroupModel)groupsListBox.SelectedItem;

		CreateGroupForm createGroupForm = new(companyModel, this);
		await createGroupForm.LoadComboBoxes();
		createGroupForm.Title = "Alter Group" ;
		createGroupForm.createGroupButton.Content = "Alter Group";
		createGroupForm.id = group.Id;
		createGroupForm.nameTextBox.Text = group.Name.ToString();
		createGroupForm.underComboBox.SelectedValue = group.Under;
		createGroupForm.natureOfGroupComboBox.SelectedValue = group.NatureOfGroup == null ? createGroupForm.natureOfGroupComboBox.Visibility = createGroupForm.natureOfGroupLabel.Visibility = Visibility.Hidden : group.NatureOfGroup;
		createGroupForm.affectGrossProfitComboBox.SelectedValue = group.AffectGrossProfit == null ? createGroupForm.affectGrossProfitComboBox.Visibility = Visibility.Hidden : group.AffectGrossProfit;
		createGroupForm.behavesSubLedgerComboBox.SelectedValue = group.BehavesSubLedger;
		createGroupForm.netBalancesComboBox.SelectedValue = group.NetBalances;
		createGroupForm.usedForCalculationComboBox.SelectedValue = group.UsedForCalculation;
		createGroupForm.methodToAllocateComboBox.SelectedValue = group.MethodToAllocate;

		createGroupForm.ShowDialog();
	}

	private async void deleteGroupButton_Click(object sender, RoutedEventArgs e)
	{
		if (groupsListBox.SelectedItems.Count != 1 || groupsListBox.SelectedItem == null)
		{
			MessageBox.Show("Please Select a Group", "Select Group", MessageBoxButton.OK);
			return;
		}

		await GroupData.DeleteById(((GroupModel)groupsListBox.SelectedItem).Id, companyModel.Name);
		await RefreshGroupList();
	}
}
