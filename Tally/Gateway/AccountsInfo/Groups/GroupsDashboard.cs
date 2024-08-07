using TallyLibrary.Data;
using TallyLibrary.Models;

namespace Tally.Gateway.AccountsInfo.Groups;

public partial class GroupsDashboard : Form
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
		groupsListBox.DataSource = null;
		groupsListBox.Items.Clear();

		var groups = (await GroupData.LoadTableData<GroupModel>("Groups", companyModel.Name)).ToList();

		groups.RemoveAt(0);

		groupsListBox.DataSource = groups;
		groupsListBox.DisplayMember = "Name";
	}

	private void GroupsDashboard_FormClosed(object sender, FormClosedEventArgs e)
	{
		AccountsInfoDashboard accountsInfoDashboard = new(companyModel);
		accountsInfoDashboard.Show();
		Hide();
	}

	private async void alterGroupButton_Click(object sender, EventArgs e)
	{
		if (groupsListBox.SelectedItems.Count != 1 || groupsListBox.SelectedItem == null)
		{
			MessageBox.Show("Please Select a Group", "Select Group", MessageBoxButtons.OK);
			return;
		}

		GroupModel group = (GroupModel)groupsListBox.SelectedItem;

		CreateGroupForm createGroupForm = new(companyModel, this);
		await createGroupForm.LoadComboBoxes();
		createGroupForm.Text = createGroupForm.createGroupButton.Text = "Alter Group";
		createGroupForm.id = group.Id;
		createGroupForm.nameTextBox.Text = group.Name.ToString();
		createGroupForm.underComboBox.SelectedValue = group.Under;
		createGroupForm.natureOfGroupComboBox.SelectedValue = group.NatureOfGroup == null ? createGroupForm.natureOfGroupComboBox.Visible = createGroupForm.natureOfGroupLabel.Visible = false : group.NatureOfGroup;
		createGroupForm.affectGrossProfitComboBox.SelectedValue = group.AffectGrossProfit == null ? createGroupForm.affectGrossProfitComboBox.Visible = false : group.AffectGrossProfit;
		createGroupForm.behavesSubLedgerComboBox.SelectedValue = group.BehavesSubLedger;
		createGroupForm.netBalancesComboBox.SelectedValue = group.NetBalances;
		createGroupForm.usedForCalculationComboBox.SelectedValue = group.UsedForCalculation;
		createGroupForm.methodToAllocateComboBox.SelectedValue = group.MethodToAllocate;

		createGroupForm.ShowDialog();
	}

	private void createGroupButton_Click(object sender, EventArgs e)
	{
		CreateGroupForm createGroupForm = new(companyModel, this);
		createGroupForm.ShowDialog();
	}

	private async void deleteGroupButton_Click(object sender, EventArgs e)
	{
		if (groupsListBox.SelectedItems.Count != 1 || groupsListBox.SelectedItem == null)
		{
			MessageBox.Show("Please Select a Group", "Select Group", MessageBoxButtons.OK);
			return;
		}

		await GroupData.DeleteGroupById(((GroupModel)groupsListBox.SelectedItem).Id, companyModel.Name);
		await RefreshGroupList();
	}
}
