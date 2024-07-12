using TallyLibrary.DataAccess;

namespace TallyLibrary.Data;

public static class DatabaseSetup
{
	public static async Task CreateDatabase(string companyName)
	{
		await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Database\\CreateDatabase", companyName), "master");
		await CreateTablesAsync(companyName);
	}

	private static async Task CreateTablesAsync(string companyName) =>
		await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Database\\CreateTables"), $"{companyName}Tally");
}
