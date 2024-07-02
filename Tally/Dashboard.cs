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

		CompanyData companyData = new();
		List<string> companies = (await companyData.GetAllCompanies()).ToList();

		for (int i = 0; i < companies.Count; i++)
			companies[i] = companies[i].Substring(0, companies[i].Length - 5);

		listOfCompaniesListBox.DataSource = companies;
	}

	private void createCompanyButton_Click(object sender, EventArgs e)
	{
		CreateCompanyForm createCompany = new(this);
		createCompany.createCompanyButton.Text = "Create Company";
		createCompany.ShowDialog();
	}

	private async void alterComapnyButton_ClickAsync(object sender, EventArgs e)
	{
		CompanyData companyData = new();
		CompanyModel companyModel = new();
		companyModel =  await companyData.LoadCompanyDetails(listOfCompaniesListBox.SelectedItem?.ToString());

		CreateCompanyForm createCompanyForm = new(this);

		createCompanyForm.createCompanyButton.Text = "Alter Company";
		createCompanyForm.oldCompanyName = createCompanyForm.companyNameTextBox.Text = companyModel.Name;
		createCompanyForm.mailingNameTextBox.Text = companyModel.MailingName;
		createCompanyForm.addressTextBox.Text = companyModel.Address;
		createCompanyForm.stateTextBox.Text = companyModel.State;
		createCompanyForm.pinCodeTextBox.Text = companyModel.PinCode.ToString();
		createCompanyForm.telephoneNumberTextBox.Text = companyModel.TelephoneNumber;
		createCompanyForm.emailTextBox.Text = companyModel.EMail;
		createCompanyForm.financialYearFromDateTimePicker.Text = companyModel.FinancialYearFrom.ToString();
		createCompanyForm.booksBeginFromDateTimePicker.Text = companyModel.BooksBeginFrom.ToString();
		createCompanyForm.passwordTextBox.Text = companyModel.Password;

		createCompanyForm.ShowDialog();
	}

	private async void deleteCompanyButton_ClickAsync(object sender, EventArgs e)
	{
		CompanyData companyData = new();

		if (listOfCompaniesListBox.SelectedItems.Count == 1)
			await companyData.DeleteDatabase(listOfCompaniesListBox.SelectedItem?.ToString());

		await RefreshCompanyList();
	}

	private void listOfCompaniesListBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		selectCompanyButton.Enabled = true;
		shutCompanyButton.Enabled = true;
		alterComapnyButton.Enabled = true;
		deleteCompanyButton.Enabled = true;
	}
}
