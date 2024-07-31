using TallyLibrary.DataAccess;
using TallyLibrary.DataAccess.SQL;
using TallyLibrary.DataAccess.TextFile;

namespace TallyLibrary.Data;

public static class DatabaseSetup
{
	public static async Task CreateDatabase(string companyName)
	{
		if (DataLocation.IsDatabase())
		{
			await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Database.CreateDatabase", companyName), "master");
			await CreateTables(companyName);
			await FillData(companyName);
		}

		Directory.CreateDirectory(DataLocation.GetDataPath() + companyName);
		await CopyOriginalFiles(companyName);
	}

	private static async Task CreateTables(string companyName) =>
			await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Database.CreateTables"), $"{companyName}Tally");

	private static async Task FillData(string companyName) =>
			await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Database.FillData"), $"{companyName}Tally");

	private static async Task CopyOriginalFiles(string companyName)
	{
		var tables = (await TextFileDataAccess.GetFileContentsTextDataAccess("TableNames")).ToString().Split("\r\n");

		for (int i = 0; i < tables.Length; i++)
			File.WriteAllText(DataLocation.GetDataPath() + companyName + $@"\{tables[i]}.txt", (await TextFileDataAccess.GetFileContentsTextDataAccess($"OriginalFiles.{tables[i]}")).ToString());
	}
}
