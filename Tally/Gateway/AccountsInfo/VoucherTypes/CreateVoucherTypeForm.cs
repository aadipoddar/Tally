using TallyLibrary.Data;
using TallyLibrary.Models;

namespace TallyWinForms.Gateway.AccountsInfo.VoucherTypes;

public partial class CreateVoucherTypeForm : Form
{
	static CompanyModel companyModel = new();
	VoucherTypeModel voucherTypeModel = new();
	VoucherTypesDashboard voucherTypesDashboard = new(companyModel);
	public int id;

	public CreateVoucherTypeForm(CompanyModel company, VoucherTypesDashboard voucherTypesDashboard)
	{
		InitializeComponent();

		companyModel = company;
		this.voucherTypesDashboard = voucherTypesDashboard;

		Task task = LoadComboBoxes();
	}

	public async Task LoadComboBoxes()
	{
		var voucherTypes = (await VoucherTypeData.LoadTableData<VoucherTypeModel>("VoucherTypes", companyModel.Name)).ToList();
		SetBoolComboBoxes(typeOfVoucherComboBox, voucherTypes, "Name", "Id");
		SetBoolComboBoxes(methodOfNumberingComboBox, new List<MethodOfNumberingModel>() { new(0), new(1), new(2) }, "Value", "Bit");
		SetBoolComboBoxes(preventDuplicatesComboBox, new List<BoolBit>() { new(0), new(1) }, "Value", "Bit");
		SetBoolComboBoxes(useEffectiveDatesComboBox, new List<BoolBit>() { new(0), new(1) }, "Value", "Bit");
		SetBoolComboBoxes(defaultOptionalComboBox, new List<BoolBit>() { new(0), new(1) }, "Value", "Bit");
		SetBoolComboBoxes(commonNarrationComboBox, new List<BoolBit>() { new(0), new(1) }, "Value", "Bit");
		SetBoolComboBoxes(narrationEachEntryComboBox, new List<BoolBit>() { new(0), new(1) }, "Value", "Bit");

		void SetBoolComboBoxes(ComboBox comboBox, object dataSource, string displayMember, string valueMember)
		{
			comboBox.DataSource = dataSource;
			comboBox.DisplayMember = displayMember;
			comboBox.ValueMember = valueMember;
		}
	}

	private void methodOfNumberingComboBox_SelectedValueChanged(object sender, EventArgs e)
	{
		if (((MethodOfNumberingModel)methodOfNumberingComboBox.SelectedItem).Bit == 2 || ((MethodOfNumberingModel)methodOfNumberingComboBox.SelectedItem).Bit == 0)
		{
			preventDuplicatesLabel.Visible = false;
			preventDuplicatesComboBox.Visible = false;
		}

		if (((MethodOfNumberingModel)methodOfNumberingComboBox.SelectedItem).Bit == 1)
		{
			preventDuplicatesLabel.Visible = true;
			preventDuplicatesComboBox.Visible = true;
		}
	}

	private bool ValidateAndAssign()
	{
		if (createVoucherTypeButton.Text == "Alter Voucher Type")
			voucherTypeModel.Id = id;

		if (nameTextBox.Text != string.Empty)
			voucherTypeModel.Name = nameTextBox.Text;

		else
		{
			MessageBox.Show("Voucher Type Must have a Name", "Voucher Type Name Not Found", MessageBoxButtons.OK);
			return false;
		}

		if (createVoucherTypeButton.Text == "Create Ledger")
		{
			foreach (VoucherTypeModel voucher in voucherTypesDashboard.voucherTypesListBox.Items)
			{
				if (nameTextBox.Text == voucher.Name)
				{
					MessageBox.Show("Voucher Type Name Already Exists", "Voucher Type Name Conflict", MessageBoxButtons.OK);
					return false;
				}
			}
		}

		voucherTypeModel.TypeOfVoucher = Convert.ToInt32(typeOfVoucherComboBox.SelectedValue);

		if (Convert.ToInt32(methodOfNumberingComboBox.SelectedValue) == 2)
			voucherTypeModel.MethodOfNumbering = null;

		else voucherTypeModel.MethodOfNumbering = Convert.ToInt32(methodOfNumberingComboBox.SelectedValue);

		if (preventDuplicatesComboBox.Visible == true)
			voucherTypeModel.PreventDuplicates = Convert.ToInt32(preventDuplicatesComboBox.SelectedValue);

		voucherTypeModel.UseEffectiveDates = Convert.ToInt32(useEffectiveDatesComboBox.SelectedValue);
		voucherTypeModel.DefaultOptional = Convert.ToInt32(defaultOptionalComboBox.SelectedValue);
		voucherTypeModel.CommonNarration = Convert.ToInt32(commonNarrationComboBox.SelectedValue);
		voucherTypeModel.NarrationEachEntry = Convert.ToInt32(narrationEachEntryComboBox.SelectedValue);

		return true;
	}

	private async void createVoucherTypeButton_Click(object sender, EventArgs e)
	{
		if (!ValidateAndAssign()) return;

		if (createVoucherTypeButton.Text == "Alter Voucher Type")
			await VoucherTypeData.UpdateTable(voucherTypeModel, companyModel.Name);

		else await VoucherTypeData.InsertIntoTable(voucherTypeModel, companyModel.Name);
		await voucherTypesDashboard.RefreshVoucherTypesList();
		Close();
	}
}
