using Tally.Gateway;

using TallyLibrary.Data;
using TallyLibrary.Models;

namespace TallyWinForms.Gateway.Vouchers;

public partial class SelectVoucherType : Form
{
	CompanyModel companyModel;
	public SelectVoucherType(CompanyModel companyModel)
	{
		InitializeComponent();

		this.companyModel = companyModel;
		Task task = LoadComboBox();
	}

	private async Task LoadComboBox()
	{
		var voucherTypes = (await VoucherTypeData.LoadTableData<VoucherTypeModel>("VoucherTypes", companyModel.Name)).ToList();
		SetBoolComboBoxes(voucherTypeComboBox, voucherTypes, "Name", "Id");

		void SetBoolComboBoxes(ComboBox comboBox, object dataSource, string displayMember, string valueMember)
		{
			comboBox.DataSource = dataSource;
			comboBox.DisplayMember = displayMember;
			comboBox.ValueMember = valueMember;
		}
	}

	private void SelectVoucherType_FormClosed(object sender, FormClosedEventArgs e)
	{
		GatewayDashboard gatewayDashboard = new(companyModel);
		gatewayDashboard.Show();
		Hide();
	}

	private void okButton_Click(object sender, EventArgs e)
	{
		AccountingVouchers accountingVouchers = new(companyModel, (VoucherTypeModel)voucherTypeComboBox.SelectedItem);
		accountingVouchers.Show();
		Hide();
	}
}
