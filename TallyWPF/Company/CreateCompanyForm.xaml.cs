using System.Text.RegularExpressions;
using System.Windows.Input;

using TallyLibrary.Data;
using TallyLibrary.Models;

namespace TallyWPF.Company;

/// <summary>
/// Interaction logic for CreateCompanyForm.xaml
/// </summary>
public partial class CreateCompanyForm : Window
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

		if (financialYearFromDatePicker.Text != string.Empty)
			companyModel.FinancialYearFrom = DateTime.Parse(financialYearFromDatePicker.Text);

		if (booksBeginFromDatePicker.Text != string.Empty)
			companyModel.BooksBeginFrom = DateTime.Parse(booksBeginFromDatePicker.Text);

		if (passwordTextBox.Password != string.Empty)
			companyModel.Password = passwordTextBox.Password;

		return true;
	}

	private async void createCompanyButton_Click(object sender, RoutedEventArgs e)
	{
		if (!ValidateAndAssign())
		{
			MessageBox.Show("Company Must have a Name", "Company Name Not Found", MessageBoxButton.OK);
			return;
		}

		if (createCompanyButton.Content.ToString() == "Create Company")
		{
			await DatabaseSetup.CreateDatabase(companyModel.Name);
			await CompanyData.InsertIntoTable(companyModel);
		}

		if (createCompanyButton.Content.ToString() == "Alter Company")
		{
			if (oldCompanyName != companyNameTextBox.Text)
				await CompanyData.UpdateCompanyDetails(companyModel, oldCompanyName, true);
			else
				await CompanyData.UpdateCompanyDetails(companyModel, oldCompanyName);
		}

		Close();
	}

	private void pinCodeTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
	{
		e.Handled = !IsTextAllowed(e.Text);
	}

	private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
	private static bool IsTextAllowed(string text)
	{
		return !_regex.IsMatch(text);
	}
}
