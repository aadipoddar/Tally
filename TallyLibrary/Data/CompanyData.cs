using TallyLibrary.DataAccess;
using TallyLibrary.Models;

namespace TallyLibrary.Data;

public static class CompanyData
{
	public static async Task<IEnumerable<string>> GetAllCompanies() =>
		await SqlDataAccess.LoadDataSQL<string>(await GetSQL.GetSQLContent("Company.GetAllCompanies"), "master");

	private static async Task ChangeDatabaseName(string newCompanyName, string oldCompanyName) =>
		await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Company.ChangeDatabaseName", oldCompanyName, newCompanyName), "master");

	public static async Task<CompanyModel> LoadCompanyDetails(string companyName) =>
		(await SqlDataAccess.LoadDataSQL<CompanyModel>(await GetSQL.GetSQLContent("Common.LoadTableData", "CompanyDetails"), $"{companyName}Tally")).FirstOrDefault();

	public static async Task InsertIntoCompanyTablesAsync(CompanyModel company) =>
		await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Company.InsertCompanyDetails", company), $"{company.Name}Tally");

	public static async Task UpdateCompanyDetails(CompanyModel company, string oldCompanyName, bool companyNameChanged = false)
	{
		if (companyNameChanged)
			await ChangeDatabaseName(company.Name, oldCompanyName);

		await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Company.UpdateCompanyDetails", company, oldCompanyName), $"{company.Name}Tally");
	}

	public static async Task DeleteDatabase(string companyName) =>
		await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Company.DeleteDatabase", companyName), "master");
}
