using TallyLibrary.Data;
using TallyLibrary.DataAccess;
using TallyLibrary.Models;

using TallyWPF.Company;
using TallyWPF.Gateway;

namespace TallyWPF;

/// <summary>
/// Interaction logic for Dashboard.xaml
/// </summary>
public partial class Dashboard : Window
{
	public Dashboard()
	{
		InitializeComponent();

		Task task = RefreshCompanyList();

		if (Environment.GetEnvironmentVariable("TallyAadi", EnvironmentVariableTarget.User) == null)
		{
			ChooseDataLocation chooseDataLocation = new();
			chooseDataLocation.Show();
		}

		dataLocationLabel.Content = DataLocation.GetDataLocation();
	}

	public async Task RefreshCompanyList()
	{
		listOfCompaniesListBox.ItemsSource = null;
		listOfCompaniesListBox.Items.Clear();

		var companies = (await CompanyData.GetAllCompanies()).ToList();

		listOfCompaniesListBox.ItemsSource = companies;
	}

	private void listOfCompaniesListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
	{
		selectCompanyButton.IsEnabled = true;
		alterCompanyButton.IsEnabled = true;
		deleteCompanyButton.IsEnabled = true;
	}

	private void Window_Closed(object sender, EventArgs e)
	{
		Application.Current.Shutdown();
	}

	private void changeDataLocationButton_Click(object sender, RoutedEventArgs e)
	{
		ChooseDataLocation chooseDataLocation = new();
		chooseDataLocation.Show();
		Hide();
	}

	private async void createCompanyButton_Click(object sender, RoutedEventArgs e)
	{
		CreateCompanyForm createCompany = new(this);
		createCompany.createCompanyButton.Content = "Create Company";
		createCompany.ShowDialog();
		await RefreshCompanyList();
	}

	private void ShowAlterForm(CompanyModel companyModel)
	{
		CreateCompanyForm createCompanyForm = new(this);

		createCompanyForm.createCompanyButton.Content = "Alter Company";
		createCompanyForm.oldCompanyName = createCompanyForm.companyNameTextBox.Text = companyModel.Name;
		createCompanyForm.mailingNameTextBox.Text = companyModel.MailingName == "NULL" ? "" : companyModel.MailingName;
		createCompanyForm.addressTextBox.Text = companyModel.Address == "NULL" ? "" : companyModel.Address;
		createCompanyForm.stateTextBox.Text = companyModel.State == "NULL" ? "" : companyModel.State;
		createCompanyForm.pinCodeTextBox.Text = companyModel.PinCode == 0 ? "" : companyModel.PinCode.ToString();
		createCompanyForm.telephoneNumberTextBox.Text = companyModel.TelephoneNumber == "NULL" ? "" : companyModel.TelephoneNumber;
		createCompanyForm.emailTextBox.Text = companyModel.EMail == "NULL" ? "" : companyModel.EMail;
		createCompanyForm.financialYearFromDatePicker.Text = companyModel.FinancialYearFrom.ToString();
		createCompanyForm.booksBeginFromDatePicker.Text = companyModel.BooksBeginFrom.ToString();
		createCompanyForm.passwordTextBox.Password = companyModel.Password == "NULL" ? "" : companyModel.Password;

		createCompanyForm.ShowDialog();
	}

	private async void alterCompanyButton_Click(object sender, RoutedEventArgs e)
	{
		if (listOfCompaniesListBox.SelectedItems.Count != 1)
			MessageBox.Show("Please Select/Create a Company");

		if (listOfCompaniesListBox.SelectedItems.Count == 1)
		{
			CompanyModel companyModel = new();
			companyModel = await CompanyData.LoadCompanyDetails(listOfCompaniesListBox.SelectedItem?.ToString());

			if (companyModel.Password != "NULL" && companyModel.Password != null)
			{
				PasswordForm passwordForm = new(companyModel.Password);
				passwordForm.ShowDialog();
				if (passwordForm.correctPassword)
					ShowAlterForm(companyModel);

				await RefreshCompanyList();
				return;
			}

			ShowAlterForm(companyModel);
			await RefreshCompanyList();
		}
	}

	private async void deleteCompanyButton_Click(object sender, RoutedEventArgs e)
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

			if (companyModel.Password != "NULL" && companyModel.Password != null)
			{
				PasswordForm passwordForm = new(companyModel.Password);
				passwordForm.ShowDialog();
				if (passwordForm.correctPassword)
					await CompanyData.DeleteDatabase(listOfCompaniesListBox.SelectedItem?.ToString());

				await RefreshCompanyList();
				return;
			}

			await CompanyData.DeleteDatabase(listOfCompaniesListBox.SelectedItem?.ToString());
			await RefreshCompanyList();
		}
	}

	private async void selectCompanyButton_Click(object sender, RoutedEventArgs e)
	{
		if (listOfCompaniesListBox.SelectedItems.Count != 1)
			MessageBox.Show("Please Select/Create a Company");

		if (listOfCompaniesListBox.SelectedItems.Count == 1)
		{
			CompanyModel companyModel = new();
			companyModel = await CompanyData.LoadCompanyDetails(listOfCompaniesListBox.SelectedItem?.ToString());
			GatewayDashboard gatewayDashboard = new(companyModel);

			if (companyModel.Password != "NULL" && companyModel.Password != null)
			{
				PasswordForm passwordForm = new(companyModel.Password);
				passwordForm.ShowDialog();
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
