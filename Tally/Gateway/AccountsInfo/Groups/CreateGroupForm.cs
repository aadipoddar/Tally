using TallyLibrary.Data;
using TallyLibrary.Models;

namespace Tally.Gateway.AccountsInfo.Groups;

public partial class CreateGroupForm : Form
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

		void SetBoolComboBoxes(ComboBox comboBox, object dataSource, string displayMember, string valueMember)
		{
			comboBox.DataSource = dataSource;
			comboBox.DisplayMember = displayMember;
			comboBox.ValueMember = valueMember;
		}
	}

	private void underComboBox_SelectedValueChanged(object sender, EventArgs e)
	{
		if (underComboBox.SelectedIndex != 0)
		{
			natureOfGroupLabel.Visible = false;
			natureOfGroupLabel.Enabled = false;

			natureOfGroupComboBox.Visible = false;
			natureOfGroupComboBox.Enabled = false;

			affectGrossProfitLabel.Visible = false;
			affectGrossProfitLabel.Enabled = false;

			affectGrossProfitComboBox.Visible = false;
			affectGrossProfitComboBox.Enabled = false;
		}

		else if (underComboBox.SelectedIndex == 0)
		{
			natureOfGroupLabel.Visible = true;
			natureOfGroupLabel.Enabled = true;

			natureOfGroupComboBox.Visible = true;
			natureOfGroupComboBox.Enabled = true;
		}
	}

	private void natureOfGroupComboBox_SelectedValueChanged(object sender, EventArgs e)
	{
		if (natureOfGroupComboBox.SelectedItem == null)
		{
			natureOfGroupComboBox.SelectedValue = 1;

			affectGrossProfitLabel.Visible = false;
			affectGrossProfitLabel.Enabled = false;

			affectGrossProfitComboBox.Visible = false;
			affectGrossProfitComboBox.Enabled = false;
		}

		else if (natureOfGroupComboBox.SelectedIndex == 0 || natureOfGroupComboBox.SelectedIndex == 3)
		{
			affectGrossProfitLabel.Visible = false;
			affectGrossProfitLabel.Enabled = false;

			affectGrossProfitComboBox.Visible = false;
			affectGrossProfitComboBox.Enabled = false;
		}

		else if (natureOfGroupComboBox.SelectedIndex == 1 || natureOfGroupComboBox.SelectedIndex == 2)
		{
			affectGrossProfitLabel.Visible = true;
			affectGrossProfitLabel.Enabled = true;

			affectGrossProfitComboBox.Visible = true;
			affectGrossProfitComboBox.Enabled = true;
		}
	}

	private void natureOfGroupComboBox_VisibleChanged(object sender, EventArgs e)
	{
		if (natureOfGroupComboBox.Visible == true)
		{
			if (natureOfGroupComboBox.SelectedValue == null)
			{
				natureOfGroupComboBox.SelectedValue = 1;

				affectGrossProfitLabel.Visible = false;
				affectGrossProfitLabel.Enabled = false;

				affectGrossProfitComboBox.Visible = false;
				affectGrossProfitComboBox.Enabled = false;
			}

			else if (natureOfGroupComboBox.SelectedIndex == 1 || natureOfGroupComboBox.SelectedIndex == 2)
			{
				affectGrossProfitLabel.Visible = true;
				affectGrossProfitLabel.Enabled = true;

				affectGrossProfitComboBox.Visible = true;
				affectGrossProfitComboBox.Enabled = true;
			}
		}
	}

	private void affectGrossProfitComboBox_VisibleChanged(object sender, EventArgs e)
	{
		if (affectGrossProfitComboBox.Visible == true)
			if (affectGrossProfitComboBox.SelectedValue == null)
				affectGrossProfitComboBox.SelectedValue = 0;
	}

	private bool ValidateAndAssign()
	{
		groupModel.Id = id;

		if (nameTextBox.Text != string.Empty)
			groupModel.Name = nameTextBox.Text;

		else
		{
			MessageBox.Show("Group Must have a Name", "Group Name Not Found", MessageBoxButtons.OK);
			return false;
		}

		if (createGroupButton.Text == "Create Group")
		{
			foreach (GroupModel group in groupsDashboard.groupsListBox.Items)
			{
				if (nameTextBox.Text == group.Name)
				{
					MessageBox.Show("Group Name Already Exists", "Group Name Conflict", MessageBoxButtons.OK);
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

	private async void createGroupButton_Click(object sender, EventArgs e)
	{
		if (!ValidateAndAssign()) return;

		if (createGroupButton.Text == "Alter Group") await GroupData.UpdateGroupTable(groupModel, companyModel.Name);

		else await GroupData.InsertIntoGroupTable(groupModel, companyModel.Name);

		await groupsDashboard.RefreshGroupList();
		Close();
	}
}
