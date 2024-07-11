using TallyLibrary.DataAccess;
using TallyLibrary.Models;

namespace TallyLibrary.Data;

public class CompanyData
{
	SqlDataAccess sqlDataAccess = new();

	public async Task<IEnumerable<string>> GetAllCompanies() =>
		await sqlDataAccess.LoadDataSQL<string>($"SELECT name FROM sys.databases WHERE name LIKE '%Tally'", "master");

	public async Task InsertIntoTablesAsync(CompanyModel company)
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

	public async Task DeleteDatabase(string companyName)
	{
		String sql = $"USE [master] DECLARE @kill varchar(8000) = ''; SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';' FROM sys.dm_exec_sessions WHERE database_id  = db_id('{companyName}Tally') EXEC(@kill);";
		await sqlDataAccess.RunSQL(sql, "master");
		await sqlDataAccess.RunSQL($"DROP DATABASE {companyName}Tally", "master");
	}
}
