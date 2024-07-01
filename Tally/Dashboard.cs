using TallyLibrary.Data;
using TallyLibrary.Models;

namespace Tally;

public partial class Dashboard : Form
{
	public Dashboard()
	{
		InitializeComponent();

		listOfCompaniesListBox.Items.Clear();
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
		CreateCompanyForm createCompany = new();
		createCompany.ShowDialog();
	}

	private void alterComapnyButton_Click(object sender, EventArgs e)
	{
		CreateCompanyForm createCompany = new();
		createCompany.ShowDialog();
	}

	public async void refreshButton_Click(object sender, EventArgs e)
	{
		await RefreshCompanyList();
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
