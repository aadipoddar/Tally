using TallyLibrary.DataAccess;
using TallyLibrary.Models;

namespace TallyLibrary.Data;

public class CompanyData
{
	SqlDataAccess sqlDataAccess = new();

	public async Task<IEnumerable<string>> GetAllCompanies() =>
		await sqlDataAccess.LoadDataSQL<string>($"SELECT name FROM sys.databases WHERE name LIKE '%Tally'", "master");

	public async Task CreateDatabase(CompanyModel company)
	{
		await sqlDataAccess.RunSQL($"CREATE DATABASE {company.Name}Tally", "master");

		await CreateTablesAsync(company.Name);
		await InsertIntoTablesAsync(company);
	}

	private async Task CreateTablesAsync(string companyName)
	{
		String sql = "CREATE TABLE [dbo].[CompanyDetails] ([Name] VARCHAR(250) NOT NULL, [MailingName] VARCHAR(250) NULL, [Address] VARCHAR(250) NULL, [State] VARCHAR(250) NULL, [PinCode] INT NULL, [TelephoneNumber] VARCHAR(250) NULL, [EMail] VARCHAR(250) NULL, [FinancialYearFrom] DATE NOT NULL, [BooksBeginFrom] DATE NOT NULL, [Password] VARCHAR(250) NULL)";
		await sqlDataAccess.RunSQL(sql, $"{companyName}Tally");
	}

	private async Task InsertIntoTablesAsync(CompanyModel company)
	{
		String sql = $"INSERT INTO [dbo].[CompanyDetails]([Name], [MailingName], [Address], [State], [PinCode], [TelephoneNumber], [EMail], [FinancialYearFrom], [BooksBeginFrom], [Password]) VALUES('{company.Name}', '{company.MailingName}', '{company.Address}', '{company.State}', {company.PinCode}, '{company.TelephoneNumber}', '{company.EMail}', '{company.FinancialYearFrom}', '{company.BooksBeginFrom}', '{company.Password}')";
		await sqlDataAccess.RunSQL(sql, $"{company.Name}Tally");
	}

	public async Task UpdateCompanyDetails(CompanyModel company, string oldCompanyName, bool companyNameChanged = false)
	{
		if (companyNameChanged)
			await ChangeDatabaseName(company.Name, oldCompanyName);

		String sql = $"UPDATE [dbo].[CompanyDetails] SET [Name] = '{company.Name}', [MailingName] = '{company.MailingName}', [Address] = '{company.Address}', [State] = '{company.State}', [PinCode] = {company.PinCode}, [TelephoneNumber] = '{company.TelephoneNumber}', [EMail] = '{company.EMail}', [FinancialYearFrom] = '{company.FinancialYearFrom}', [BooksBeginFrom] = '{company.BooksBeginFrom}', [Password] = '{company.Password}' WHERE [Name] = '{oldCompanyName}'";
		await sqlDataAccess.RunSQL(sql, $"{company.Name}Tally");
	}

	private async Task ChangeDatabaseName(string newCompanyName, string oldCompanyName)
	{
		String sql = $"USE master; ALTER DATABASE {oldCompanyName}Tally SET SINGLE_USER WITH ROLLBACK IMMEDIATE; ALTER DATABASE {oldCompanyName}Tally MODIFY NAME = {newCompanyName}Tally; ALTER DATABASE {newCompanyName}Tally SET MULTI_USER;";
		await sqlDataAccess.RunSQL(sql, "master");
	}

	public async Task<CompanyModel> LoadCompanyDetails(string companyName) =>
		(await sqlDataAccess.LoadDataSQL<CompanyModel>($"SELECT * FROM [dbo].[CompanyDetails]", $"{companyName}Tally")).FirstOrDefault();

	public async Task DeleteDatabase(string companyName) =>
		await sqlDataAccess.RunSQL($"DROP DATABASE {companyName}Tally", "master");
}
