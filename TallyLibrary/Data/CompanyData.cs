using TallyLibrary.DataAccess;
using TallyLibrary.Models;

namespace TallyLibrary.Data;

public static class CompanyData
{
	public static async Task<IEnumerable<string>> GetAllCompanies()
	{
		if (DataLocation.IsDatabase())
			return await SQL.CompanyData.GetAllCompanies();

		if (DataLocation.IsTextFile())
			return TextFile.CompanyData.GetAllCompanies();

		return default;
	}

	public static async Task<CompanyModel> LoadCompanyDetails(string companyName)
	{
		if (DataLocation.IsDatabase())
			return await SQL.CompanyData.LoadCompanyDetails(companyName);

		if (DataLocation.IsTextFile())
			return await TextFile.CompanyData.LoadCompanyDetails(companyName);

		return default;
	}

	public static async Task InsertIntoCompanyTablesAsync(CompanyModel company)
	{
		if (DataLocation.IsDatabase())
			await SQL.CompanyData.InsertIntoCompanyTablesAsync(company);

		if (DataLocation.IsTextFile())
			await TextFile.CompanyData.InsertIntoCompanyTablesAsync(company);
	}

	public static async Task UpdateCompanyDetails(CompanyModel company, string oldCompanyName, bool companyNameChanged = false)
	{
		if (DataLocation.IsDatabase())
			await SQL.CompanyData.UpdateCompanyDetails(company, oldCompanyName, companyNameChanged);

		if (DataLocation.IsTextFile())
			await TextFile.CompanyData.UpdateCompanyDetails(company, oldCompanyName, companyNameChanged);
	}

	public static async Task DeleteDatabase(string companyName)
	{
		if (DataLocation.IsDatabase())
			await SQL.CompanyData.DeleteDatabase(companyName);

		if (DataLocation.IsTextFile())
			TextFile.CompanyData.DeleteDatabase(companyName);
	}
}
