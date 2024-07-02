using TallyLibrary.Data;
using TallyLibrary.Models;

namespace Tally.Company;

public partial class PasswordForm : Form
{
	String password;
	Dashboard dashboard;

	public PasswordForm(string password, Dashboard dashboard)
	{
		InitializeComponent();

		this.password = password;
		this.dashboard = dashboard;
	}

	private async void goButton_ClickAsync(object sender, EventArgs e)
	{
		CompanyData companyData = new();
		CompanyModel companyModel = new();
		companyModel = await companyData.LoadCompanyDetails(dashboard.listOfCompaniesListBox.SelectedItem?.ToString());

		if (passwordTextBox.Text == companyModel.Password)
		{
			CreateCompanyForm createCompanyForm = new(dashboard);

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

		else
		{
			MessageBox.Show("Please Retry Password", "Incorrect Password", MessageBoxButtons.OK);
		}
	}
}
