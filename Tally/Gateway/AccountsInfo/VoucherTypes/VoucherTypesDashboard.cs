using Tally.Gateway.AccountsInfo;

using TallyLibrary.Data;
using TallyLibrary.Models;

namespace TallyWinForms.Gateway.AccountsInfo.VoucherTypes;

public partial class VoucherTypesDashboard : Form
{
	CompanyModel companyModel = new();

	public VoucherTypesDashboard(CompanyModel companyModel)
	{
		InitializeComponent();

		this.companyModel = companyModel;

		Task task = RefreshVoucherTypesList();
	}

	public async Task RefreshVoucherTypesList()
	{
		voucherTypesListBox.DataSource = null;
		voucherTypesListBox.Items.Clear();

		var voucherTypes = (await VoucherTypeData.LoadTableData<VoucherTypeModel>("VoucherTypes", companyModel.Name)).ToList();

		voucherTypesListBox.DataSource = voucherTypes;
		voucherTypesListBox.DisplayMember = "Name";
	}

	private void VoucherTypesDashboard_FormClosed(object sender, FormClosedEventArgs e)
	{
		AccountsInfoDashboard accountsInfoDashboard = new(companyModel);
		accountsInfoDashboard.Show();
		Hide();
	}

	private async void deleteVoucherTypeButton_Click(object sender, EventArgs e)
	{
		if (voucherTypesListBox.SelectedItems.Count != 1 || voucherTypesListBox.SelectedItem == null)
		{
			MessageBox.Show("Please Select a Voucher Type", "Select Voucher Type", MessageBoxButtons.OK);
			return;
		}

		await VoucherTypeData.DeleteById(((VoucherTypeModel)voucherTypesListBox.SelectedItem).Id, companyModel.Name);
		await RefreshVoucherTypesList();
	}

	private void createVoucherTypeButton_Click(object sender, EventArgs e)
	{
		CreateVoucherTypeForm createVoucherTypeForm = new(companyModel, this);
		createVoucherTypeForm.ShowDialog();
	}

	private async void alterVoucherTypeButton_Click(object sender, EventArgs e)
	{
		if (voucherTypesListBox.SelectedItems.Count != 1 || voucherTypesListBox.SelectedItem == null)
		{
			MessageBox.Show("Please Select a Voucher Type", "Select Voucher Type", MessageBoxButtons.OK);
			return;
		}

		VoucherTypeModel voucherTypeModel = (VoucherTypeModel)voucherTypesListBox.SelectedItem;

		CreateVoucherTypeForm createVoucherTypeForm = new(companyModel, this);
		await createVoucherTypeForm.LoadComboBoxes();
		createVoucherTypeForm.Text = createVoucherTypeForm.createVoucherTypeButton.Text = "Alter Voucher Type";
		createVoucherTypeForm.id = voucherTypeModel.Id;
		createVoucherTypeForm.nameTextBox.Text = voucherTypeModel.Name.ToString();
		createVoucherTypeForm.typeOfVoucherComboBox.SelectedValue = voucherTypeModel.TypeOfVoucher;
		createVoucherTypeForm.methodOfNumberingComboBox.SelectedValue = voucherTypeModel.MethodOfNumbering == null ? 2 : voucherTypeModel.MethodOfNumbering;
		createVoucherTypeForm.preventDuplicatesComboBox.SelectedValue = voucherTypeModel.PreventDuplicates == null ? createVoucherTypeForm.preventDuplicatesComboBox.Visible = createVoucherTypeForm.preventDuplicatesLabel.Visible = false : voucherTypeModel.PreventDuplicates;
		createVoucherTypeForm.useEffectiveDatesComboBox.SelectedValue = voucherTypeModel.UseEffectiveDates;
		createVoucherTypeForm.defaultOptionalComboBox.SelectedValue = voucherTypeModel.DefaultOptional;
		createVoucherTypeForm.commonNarrationComboBox.SelectedValue = voucherTypeModel.CommonNarration;
		createVoucherTypeForm.narrationEachEntryComboBox.SelectedValue = voucherTypeModel.NarrationEachEntry;

		createVoucherTypeForm.ShowDialog();
	}
}
