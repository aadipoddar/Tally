using TallyLibrary.DataAccess.TextFile;
using TallyLibrary.DataAccess;
using TallyLibrary.Models;
using Microsoft.VisualBasic.FileIO;

namespace TallyLibrary.Data.TextFile;

public static class CompanyData
{
	public static IEnumerable<string> GetAllCompanies()
	{
		var applicationDataPath = Environment.GetEnvironmentVariable("TallyAadi", EnvironmentVariableTarget.User);
		var directories = Directory.GetDirectories(applicationDataPath).ToList();
		for (int i = 0; i < directories.Count; i++)
			directories[i] = directories[i].Substring(applicationDataPath.Length);

		return directories;
	}

	public static async Task<CompanyModel> LoadCompanyDetails(string companyName) =>
		(await TextFileDataAccess.ConvertFileContentToModel<CompanyModel>(companyName, "CompanyDetails")).FirstOrDefault();

	public static async Task InsertIntoCompanyTablesAsync(CompanyModel company) =>
		await TextFileDataAccess.WriteToFile(company.Name, "CompanyDetails", company);

	private static void ChangeDatabaseName(string newCompanyName, string oldCompanyName) =>
		FileSystem.RenameDirectory(DataLocation.GetDataPath() + oldCompanyName, newCompanyName);

	public static async Task UpdateCompanyDetails(CompanyModel company, string oldCompanyName, bool companyNameChanged = false)
	{
		if (companyNameChanged)
			ChangeDatabaseName(company.Name, oldCompanyName);

		await TextFileDataAccess.UpdateFileEntry(company.Name, "CompanyDetails", company, oldCompanyName);
	}

	public static async Task DeleteDatabase(string companyName) =>
		Directory.Delete(DataLocation.GetDataPath() + companyName, true);
}
