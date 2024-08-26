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

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			return await MongoDB.CompanyData.GetAllCompanies();

		return default;
	}

	public static async Task<CompanyModel> LoadCompanyDetails(string companyName)
	{
		if (DataLocation.IsDatabase())
			return await SQL.CompanyData.LoadCompanyDetails(companyName);

		if (DataLocation.IsTextFile())
			return await TextFile.CompanyData.LoadCompanyDetails(companyName);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			return await MongoDB.CompanyData.LoadCompanyDetails(companyName);

		return default;
	}

	public static async Task InsertIntoTable(CompanyModel company)
	{
		if (DataLocation.IsDatabase())
			await SQL.CompanyData.InsertIntoTable(company);

		if (DataLocation.IsTextFile())
			await TextFile.CompanyData.InsertIntoTable(company);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			await MongoDB.CompanyData.InsertIntoTable(company);
	}

	public static async Task UpdateCompanyDetails(CompanyModel company, string oldCompanyName, bool companyNameChanged = false)
	{
		if (DataLocation.IsDatabase())
			await SQL.CompanyData.UpdateCompanyDetails(company, oldCompanyName, companyNameChanged);

		if (DataLocation.IsTextFile())
			await TextFile.CompanyData.UpdateCompanyDetails(company, oldCompanyName, companyNameChanged);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			await MongoDB.CompanyData.UpdateCompanyDetails(company, oldCompanyName, companyNameChanged);
	}

	public static async Task DeleteDatabase(string companyName)
	{
		if (DataLocation.IsDatabase())
			await SQL.CompanyData.DeleteDatabase(companyName);

		if (DataLocation.IsTextFile())
			TextFile.CompanyData.DeleteDatabase(companyName);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			await MongoDB.CompanyData.DeleteDatabase(companyName);
	}
}
