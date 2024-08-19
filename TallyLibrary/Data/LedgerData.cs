using TallyLibrary.DataAccess;
using TallyLibrary.Models;

namespace TallyLibrary.Data;

public static class LedgerData
{
	public static async Task<IEnumerable<T>> LoadTableData<T>(string tableName, string companyName) where T : new()
	{
		if (DataLocation.IsDatabase())
			return await SQL.LedgerData.LoadTableData<T>(tableName, companyName);

		if (DataLocation.IsTextFile())
			return await TextFile.LedgerData.LoadTableData<T>(tableName, companyName);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			return await MongoDB.LedgerData.LoadTableData<T>(tableName, companyName);

		return default;
	}

	public static async Task InsertIntoLedgerTable(LedgerModel ledgerModel, string companyName)
	{
		if (DataLocation.IsDatabase())
			await SQL.LedgerData.InsertIntoLedgerTable(ledgerModel, companyName);

		if (DataLocation.IsTextFile())
			await TextFile.LedgerData.InsertIntoLedgerTable(ledgerModel, companyName);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			await MongoDB.LedgerData.InsertIntoLedgerTable(ledgerModel, companyName);
	}

	public static async Task UpdateLedgerTable(LedgerModel ledgerModel, string companyName)
	{
		if (DataLocation.IsDatabase())
			await SQL.LedgerData.UpdateLedgerTable(ledgerModel, companyName);

		if (DataLocation.IsTextFile())
			await TextFile.LedgerData.UpdateLedgerTable(ledgerModel, companyName);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			await MongoDB.LedgerData.UpdateLedgerTable(ledgerModel, companyName);
	}

	public static async Task DeleteLedgerById(int id, string companyName)
	{
		if (DataLocation.IsDatabase())
			await SQL.LedgerData.DeleteLedgerById(id, companyName);

		if (DataLocation.IsTextFile())
			await TextFile.LedgerData.DeleteLedgerById(id, companyName);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			await MongoDB.LedgerData.DeleteLedgerById(id, companyName);
	}
}
