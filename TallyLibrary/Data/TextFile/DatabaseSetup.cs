using TallyLibrary.DataAccess.TextFile;

namespace TallyLibrary.Data.TextFile;

internal static class DatabaseSetup
{
	public static async Task CreateDatabase(string companyName)
	{
		Directory.CreateDirectory(TextFileDataAccess.GetDataPath(companyName));
		await CopyOriginalFiles(companyName);
	}

	private static async Task CopyOriginalFiles(string companyName)
	{
		var tables = (await TextFileDataAccess.GetFileContentsTextDataAccess("TableNames")).ToString().Split("\r\n");

		for (int i = 0; i < tables.Length; i++)
			File.WriteAllText(TextFileDataAccess.GetDataPath(companyName, tables[i]), (await TextFileDataAccess.GetFileContentsTextDataAccess($"OriginalFiles.{tables[i]}")).ToString());
	}
}
