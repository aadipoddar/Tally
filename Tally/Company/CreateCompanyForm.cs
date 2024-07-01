using TallyLibrary.Data;
using TallyLibrary.Models;

namespace Tally;

public partial class CreateCompanyForm : Form
{
	CompanyModel companyModel = new();
	CompanyData companyData = new();

	public CreateCompanyForm()
	{
		InitializeComponent();
	}

	public bool ValidateAndAssign()
	{
		if (companyNameTextBox.Text != string.Empty)
			companyModel.Name = companyNameTextBox.Text;
		else
			return false;

		if (mailingNameTextBox.Text != string.Empty)
			companyModel.MailingName = mailingNameTextBox.Text;

		if (addressTextBox.Text != string.Empty)
			companyModel.Address = addressTextBox.Text;

		if (stateTextBox.Text != string.Empty)
			companyModel.State = stateTextBox.Text;

		if (pinCodeTextBox.Text != string.Empty)
			companyModel.PinCode = int.Parse(pinCodeTextBox.Text);

		if (telephoneNumberTextBox.Text != string.Empty)
			companyModel.TelephoneNumber = long.Parse(telephoneNumberTextBox.Text);

		if (emailTextBox.Text != string.Empty)
			companyModel.EMail = emailTextBox.Text;

		if (financialYearFromDateTimePicker.Text != string.Empty)
			companyModel.FinancialYearFrom = DateOnly.Parse(financialYearFromDateTimePicker.Text);

		if (booksBeginFromDateTimePicker.Text != string.Empty)
			companyModel.BooksBeginFrom = DateOnly.Parse(booksBeginFromDateTimePicker.Text);

		if (passwordTextBox.Text != string.Empty)
			companyModel.Password = passwordTextBox.Text;

		return true;
	}

	private async void createCompanyButton_ClickAsync(object sender, EventArgs e)
	{
		if (!ValidateAndAssign())
		{
			MessageBox.Show("Company Must have a Name", "Company Name Not Found", MessageBoxButtons.OK);
			return;
		}

		await companyData.CreateDatabase(companyModel.Name);

		Dashboard dashboard = new();
		dashboard.listOfCompaniesListBox.Items.Clear();
		await dashboard.RefreshCompanyList();
		Close();
	}
}
