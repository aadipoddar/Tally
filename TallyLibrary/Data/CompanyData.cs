using TallyLibrary.DataAccess;

namespace TallyLibrary.Data;

public class CompanyData
{
	SqlDataAccess sqlDataAccess = new();

	public async Task<IEnumerable<string>> GetAllCompanies() =>
		await sqlDataAccess.LoadDataSQL<string>($"SELECT name FROM sys.databases WHERE name LIKE '%Tally'", "master");
		
	public async Task CreateDatabase(string companyName) =>
		await sqlDataAccess.RunSQL($"CREATE DATABASE {companyName}Tally", "master");

	public async Task DeleteDatabase(string companyName) =>
		await sqlDataAccess.RunSQL($"DROP DATABASE {companyName}Tally", "master");

}
