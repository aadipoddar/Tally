using Tally.Company;
using Tally.Gateway;

using TallyLibrary.Data;
using TallyLibrary.Models;

namespace Tally;

public partial class Dashboard : Form
{
	public Dashboard()
	{
		InitializeComponent();

		Task task = RefreshCompanyList();
	}

	public async Task RefreshCompanyList()
	{
		listOfCompaniesListBox.DataSource = null;
		listOfCompaniesListBox.Items.Clear();

		var companies = (await CompanyData.GetAllCompanies()).ToList();

		for (int i = 0; i < companies.Count; i++)
			companies[i] = companies[i].Substring(0, companies[i].Length - 5);

		listOfCompaniesListBox.DataSource = companies;
	}

	private void ShowAlterForm(CompanyModel companyModel)
	{
		CreateCompanyForm createCompanyForm = new(this);

		createCompanyForm.createCompanyButton.Text = "Alter Company";
		createCompanyForm.oldCompanyName = createCompanyForm.companyNameTextBox.Text = companyModel.Name;
		createCompanyForm.mailingNameTextBox.Text = companyModel.MailingName == "NULL" ? "" : companyModel.MailingName;
		createCompanyForm.addressTextBox.Text = companyModel.Address == "NULL" ? "" : companyModel.Address;
		createCompanyForm.stateTextBox.Text = companyModel.State == "NULL" ? "" : companyModel.State;
		createCompanyForm.pinCodeTextBox.Text = companyModel.PinCode == 0 ? "" : companyModel.PinCode.ToString();
		createCompanyForm.telephoneNumberTextBox.Text = companyModel.TelephoneNumber == "NULL" ? "" : companyModel.TelephoneNumber;
		createCompanyForm.emailTextBox.Text = companyModel.EMail == "NULL" ? "" : companyModel.EMail;
		createCompanyForm.financialYearFromDateTimePicker.Text = companyModel.FinancialYearFrom.ToString();
		createCompanyForm.booksBeginFromDateTimePicker.Text = companyModel.BooksBeginFrom.ToString();
		createCompanyForm.passwordTextBox.Text = companyModel.Password == "NULL" ? "" : companyModel.Password;

		createCompanyForm.ShowDialog();
	}

	private void listOfCompaniesListBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		selectCompanyButton.Enabled = true;
		shutCompanyButton.Enabled = true;
		alterComapnyButton.Enabled = true;
		deleteCompanyButton.Enabled = true;
	}

	private async void createCompanyButton_ClickAsync(object sender, EventArgs e)
	{
		CreateCompanyForm createCompany = new(this);
		createCompany.createCompanyButton.Text = "Create Company";
		createCompany.ShowDialog();
		await RefreshCompanyList();
	}

	private async void alterComapnyButton_ClickAsync(object sender, EventArgs e)
	{
		if (listOfCompaniesListBox.SelectedItems.Count != 1)
			MessageBox.Show("Please Select/Create a Company");

		if (listOfCompaniesListBox.SelectedItems.Count == 1)
		{
			CompanyModel companyModel = new();
			companyModel = await CompanyData.LoadCompanyDetails(listOfCompaniesListBox.SelectedItem?.ToString());

			if (companyModel.Password != "NULL")
			{
				PasswordForm passwordForm = new(companyModel.Password);
				if (passwordForm.ShowDialog() == DialogResult.OK)
					if (passwordForm.correctPassword)
						ShowAlterForm(companyModel);

				await RefreshCompanyList();
				return;
			}

			ShowAlterForm(companyModel);
			await RefreshCompanyList();
		}
	}

	private async void deleteCompanyButton_ClickAsync(object sender, EventArgs e)
	{
		if (listOfCompaniesListBox.SelectedItems.Count != 1)
			MessageBox.Show("Please Select/Create a Company");

		if (listOfCompaniesListBox.SelectedItems.Count == 1)
		{
			CompanyModel companyModel = new();
			companyModel = await CompanyData.LoadCompanyDetails(listOfCompaniesListBox.SelectedItem?.ToString());

			if (companyModel == null)
			{
				await CompanyData.DeleteDatabase(listOfCompaniesListBox.SelectedItem?.ToString());
				await RefreshCompanyList();
				return;
			}

			if (companyModel.Password != "NULL")
			{
				PasswordForm passwordForm = new(companyModel.Password);
				if (passwordForm.ShowDialog() == DialogResult.OK)
					if (passwordForm.correctPassword)
						await CompanyData.DeleteDatabase(listOfCompaniesListBox.SelectedItem?.ToString());

				await RefreshCompanyList();
				return;
			}

			await CompanyData.DeleteDatabase(listOfCompaniesListBox.SelectedItem?.ToString());
			await RefreshCompanyList();
		}
	}

	private async void selectCompanyButton_ClickAsync(object sender, EventArgs e)
	{
		if (listOfCompaniesListBox.SelectedItems.Count != 1)
			MessageBox.Show("Please Select/Create a Company");

		if (listOfCompaniesListBox.SelectedItems.Count == 1)
		{
			CompanyModel companyModel = new();
			companyModel = await CompanyData.LoadCompanyDetails(listOfCompaniesListBox.SelectedItem?.ToString());
			GatewayDashboard gatewayDashboard = new(companyModel);

			if (companyModel.Password != "NULL")
			{
				PasswordForm passwordForm = new(companyModel.Password);
				if (passwordForm.ShowDialog() == DialogResult.OK)
					if (passwordForm.correctPassword)
					{
						gatewayDashboard.Show();
						Hide();
					}

				return;
			}

			gatewayDashboard.Show();
			Hide();
		}
	}
}
