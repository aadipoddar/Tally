using TallyLibrary.DataAccess;

namespace TallyLibrary.Data;

public static class DatabaseSetup
{
	public static async Task CreateDatabase(string companyName)
	{
		if (DataLocation.IsDatabase())
			await SQL.DatabaseSetup.CreateDatabase(companyName);

		if (DataLocation.IsTextFile())
			await TextFile.DatabaseSetup.CreateDatabase(companyName);
	}
}
