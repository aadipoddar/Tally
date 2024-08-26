using TallyLibrary.DataAccess.TextFile;
using TallyLibrary.Models;

namespace TallyLibrary.Data.TextFile;

internal static class LedgerData
{
	public static async Task<IEnumerable<T>> LoadTableData<T>(string tableName, string companyName) where T : new() =>
			await TextFileDataAccess.ConvertFileContentToModel<T>(companyName, tableName);

	public static async Task InsertIntoTable(LedgerModel ledgerModel, string companyName)
	{
		var ledgers = await TextFileDataAccess.ConvertFileContentToModel<LedgerModel>(companyName, "Ledgers");
		ledgerModel.Id = ledgers.Last().Id + 1;
		await TextFileDataAccess.WriteToFile(companyName, "Ledgers", ledgerModel);
	}

	public static async Task UpdateTable(LedgerModel ledgerModel, string companyName) =>
			await TextFileDataAccess.UpdateFileEntry(companyName, "Ledgers", ledgerModel, ledgerModel.Id);

	public static async Task DeleteById(int id, string companyName) =>
			await TextFileDataAccess.DeleteFileEntry(companyName, "Ledgers", id);
}
