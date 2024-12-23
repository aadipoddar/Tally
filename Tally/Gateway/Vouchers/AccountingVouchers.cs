using Tally.Gateway;

using TallyLibrary.Data;
using TallyLibrary.Models;

namespace TallyWinForms.Gateway.Vouchers;

public partial class AccountingVouchers : Form
{
	CompanyModel companyModel = new();
	VoucherTypeModel voucherTypeModel = new();

	public AccountingVouchers(CompanyModel companyModel, VoucherTypeModel voucherTypeModel)
	{
		InitializeComponent();

		this.companyModel = companyModel;
		this.voucherTypeModel = voucherTypeModel;

		Task task = LoadComboBox();
		CalculateAmounts();

		voucherTypeLabel.Text = voucherTypeModel.Name;
	}

	private async Task LoadComboBox()
	{
		var cell = (DataGridViewComboBoxCell)itemsDataGridView.Rows[itemsDataGridView.Rows.Count - 1].Cells[0];
		SetBoolComboBoxes(cell, new List<DebitCreditModel>() { new(1), new(2) }, "Value", "Bit");

		cell = (DataGridViewComboBoxCell)itemsDataGridView.Rows[itemsDataGridView.Rows.Count - 1].Cells[1];
		var ledgers = (await LedgerData.LoadTableData<LedgerModel>("Ledgers", companyModel.Name)).ToList();
		SetBoolComboBoxes(cell, ledgers, "Name", "Id");

		void SetBoolComboBoxes(DataGridViewComboBoxCell comboBox, object dataSource, string displayMember, string valueMember)
		{
			comboBox.DataSource = dataSource;
			comboBox.DisplayMember = displayMember;
			comboBox.ValueMember = valueMember;
			comboBox.AutoComplete = true;
			comboBox.Value = 1;
		}

		CalculateAmounts();
	}

	private void CalculateAmounts()
	{
		int totalDebitAmount = 0;
		int totalCreditAmount = 0;
		for (int i = 0; i < itemsDataGridView.RowCount; i++)
		{
			totalDebitAmount += Convert.ToInt32(itemsDataGridView.Rows[i].Cells[2].Value);
			totalCreditAmount += Convert.ToInt32(itemsDataGridView.Rows[i].Cells[3].Value);
		}

		totalCreditAmountLabel.Text = totalCreditAmount.ToString();
		totalDebitAmountLabel.Text = totalDebitAmount.ToString();
	}

	private async void itemsDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) =>
		await LoadComboBox();

	private void itemsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (itemsDataGridView.CurrentCell.ColumnIndex == 0)
		{
			if (itemsDataGridView.CurrentCell.Value.ToString() == "1")
			{
				itemsDataGridView.CurrentRow.Cells[2].ReadOnly = false;
				itemsDataGridView.CurrentRow.Cells[3].ReadOnly = true;
			}
			if (itemsDataGridView.CurrentCell.Value.ToString() == "2")
			{
				itemsDataGridView.CurrentRow.Cells[2].ReadOnly = true;
				itemsDataGridView.CurrentRow.Cells[3].ReadOnly = false;
			}
		}

		CalculateAmounts();
	}

	private void itemsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
	{
		itemsDataGridView_CellClick(sender, e);

		CalculateAmounts();
	}

	private void itemsDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
	{
		itemsDataGridView_CellClick(sender, e);

		CalculateAmounts();
	}

	private void itemsDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
	{
		if (itemsDataGridView.CurrentCell.ColumnIndex == 0)
		{
			if (itemsDataGridView.CurrentCell.Value.ToString() == "1")
			{
				itemsDataGridView.CurrentRow.Cells[2].ReadOnly = false;
				itemsDataGridView.CurrentRow.Cells[3].ReadOnly = true;
			}
			if (itemsDataGridView.CurrentCell.Value.ToString() == "2")
			{
				itemsDataGridView.CurrentRow.Cells[2].ReadOnly = true;
				itemsDataGridView.CurrentRow.Cells[3].ReadOnly = false;
			}
		}

		CalculateAmounts();
	}

	private void AccountingVouchers_FormClosed(object sender, FormClosedEventArgs e)
	{
		GatewayDashboard gatewayDashboard = new(companyModel);
		gatewayDashboard.Show();
		Hide();
	}
}
