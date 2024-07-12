using TallyLibrary.Data;
using TallyLibrary.Models;

namespace Tally.Company;

public partial class CreateCompanyForm : Form
{
	CompanyModel companyModel = new();
	public string oldCompanyName;

	public CreateCompanyForm(Dashboard dashboard)
	{
		InitializeComponent();

		oldCompanyName = companyNameTextBox.Text;
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
			companyModel.TelephoneNumber = telephoneNumberTextBox.Text;

		if (emailTextBox.Text != string.Empty)
			companyModel.EMail = emailTextBox.Text;

		if (financialYearFromDateTimePicker.Text != string.Empty)
			companyModel.FinancialYearFrom = DateTime.Parse(financialYearFromDateTimePicker.Text);

		if (booksBeginFromDateTimePicker.Text != string.Empty)
			companyModel.BooksBeginFrom = DateTime.Parse(booksBeginFromDateTimePicker.Text);

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

		if (createCompanyButton.Text == "Create Company")
		{
			await DatabaseSetup.CreateDatabase(companyModel.Name);
			await CompanyData.InsertIntoTablesAsync(companyModel);
		}

		if (createCompanyButton.Text == "Alter Company")
		{
			if (oldCompanyName != companyNameTextBox.Text)
				await CompanyData.UpdateCompanyDetails(companyModel, oldCompanyName, true);
			else
				await CompanyData.UpdateCompanyDetails(companyModel, oldCompanyName);
		}

		Close();
	}
}