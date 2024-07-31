using Microsoft.VisualBasic.FileIO;

using TallyLibrary.DataAccess;
using TallyLibrary.DataAccess.SQL;
using TallyLibrary.DataAccess.TextFile;
using TallyLibrary.Models;

namespace TallyLibrary.Data;

public static class CompanyData
{
	public static async Task<IEnumerable<string>> GetAllCompanies()
	{
		if (DataLocation.IsDatabase())
		{
			var companies = (await SqlDataAccess.LoadDataSQL<string>(await GetSQL.GetSQLContent("Company.GetAllCompanies"), "master")).ToList();
			for (int i = 0; i < companies.Count; i++)
				companies[i] = companies[i].Substring(0, companies[i].Length - 5);
			return companies;
		}

		var applicationDataPath = Environment.GetEnvironmentVariable("TallyAadi", EnvironmentVariableTarget.User);
		var directories = Directory.GetDirectories(applicationDataPath).ToList();
		for (int i = 0; i < directories.Count; i++)
			directories[i] = directories[i].Substring(applicationDataPath.Length);

		return directories;
	}

	public static async Task<CompanyModel> LoadCompanyDetails(string companyName)
	{
		if (DataLocation.IsDatabase())
			return (await SqlDataAccess.LoadDataSQL<CompanyModel>(await GetSQL.GetSQLContent("Common.LoadTableData", "CompanyDetails"), $"{companyName}Tally")).FirstOrDefault();

		return (await TextFileDataAccess.ConvertFileContentToModel<CompanyModel>(companyName, "CompanyDetails")).FirstOrDefault();
	}

	public static async Task InsertIntoCompanyTablesAsync(CompanyModel company)
	{
		if (DataLocation.IsDatabase())
			await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Company.InsertCompanyDetails", company), $"{company.Name}Tally");

		await TextFileDataAccess.WriteToFile(company.Name, "CompanyDetails", company);
	}

	private static async Task ChangeDatabaseName(string newCompanyName, string oldCompanyName)
	{
		if (DataLocation.IsDatabase())
			await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Company.ChangeDatabaseName", oldCompanyName, newCompanyName), "master");

		FileSystem.RenameDirectory(DataLocation.GetDataPath() + oldCompanyName, newCompanyName);
	}

	public static async Task UpdateCompanyDetails(CompanyModel company, string oldCompanyName, bool companyNameChanged = false)
	{
		if (companyNameChanged)
			await ChangeDatabaseName(company.Name, oldCompanyName);

		if (DataLocation.IsDatabase())
			await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Company.UpdateCompanyDetails", company, oldCompanyName), $"{company.Name}Tally");

		await TextFileDataAccess.UpdateFileEntry(company.Name, "CompanyDetails", company, oldCompanyName);
	}

	public static async Task DeleteDatabase(string companyName)
	{
		if (DataLocation.IsDatabase())
			await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Company.DeleteDatabase", companyName), "master");

		Directory.Delete(DataLocation.GetDataPath() + companyName, true);
	}
}
