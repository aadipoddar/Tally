using TallyLibrary.DataAccess.TextFile;
using TallyLibrary.Models;
using Microsoft.VisualBasic.FileIO;

namespace TallyLibrary.Data.TextFile;

internal static class CompanyData
{
	public static IEnumerable<string> GetAllCompanies() =>
		TextFileDataAccess.GetAllDirectories();

	public static async Task<CompanyModel> LoadCompanyDetails(string companyName) =>
		(await TextFileDataAccess.ConvertFileContentToModel<CompanyModel>(companyName, "CompanyDetails")).FirstOrDefault();

	public static async Task InsertIntoTable(CompanyModel company) =>
		await TextFileDataAccess.WriteToFile(company.Name, "CompanyDetails", company);

	private static void ChangeDatabaseName(string newCompanyName, string oldCompanyName) =>
		FileSystem.RenameDirectory(TextFileDataAccess.GetDataPath(oldCompanyName), newCompanyName);

	public static async Task UpdateCompanyDetails(CompanyModel company, string oldCompanyName, bool companyNameChanged = false)
	{
		if (companyNameChanged)
			ChangeDatabaseName(company.Name, oldCompanyName);

		await TextFileDataAccess.UpdateFileEntry(company.Name, "CompanyDetails", company, oldCompanyName);
	}

	public static void DeleteDatabase(string companyName) =>
		Directory.Delete(TextFileDataAccess.GetDataPath(companyName), true);
}
