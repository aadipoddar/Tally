using TallyLibrary.DataAccess;

namespace TallyLibrary.Data;

public static class DatabaseSetup
{
	public static async Task CreateDatabase(string companyName)
	{
		await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Database.CreateDatabase", companyName), "master");
		await CreateTables(companyName);
		await FillData(companyName);
	}

	private static async Task CreateTables(string companyName) =>
		await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Database.CreateTables"), $"{companyName}Tally");

	private static async Task FillData(string companyName) =>
		await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Database.FillData"), $"{companyName}Tally");
}
