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

	public static async Task InsertIntoTable(LedgerModel ledgerModel, string companyName)
	{
		if (DataLocation.IsDatabase())
			await SQL.LedgerData.InsertIntoTable(ledgerModel, companyName);

		if (DataLocation.IsTextFile())
			await TextFile.LedgerData.InsertIntoTable(ledgerModel, companyName);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			await MongoDB.LedgerData.InsertIntoTable(ledgerModel, companyName);
	}

	public static async Task UpdateTable(LedgerModel ledgerModel, string companyName)
	{
		if (DataLocation.IsDatabase())
			await SQL.LedgerData.UpdateTable(ledgerModel, companyName);

		if (DataLocation.IsTextFile())
			await TextFile.LedgerData.UpdateTable(ledgerModel, companyName);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			await MongoDB.LedgerData.UpdateTable(ledgerModel, companyName);
	}

	public static async Task DeleteById(int id, string companyName)
	{
		if (DataLocation.IsDatabase())
			await SQL.LedgerData.DeleteById(id, companyName);

		if (DataLocation.IsTextFile())
			await TextFile.LedgerData.DeleteById(id, companyName);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			await MongoDB.LedgerData.DeleteById(id, companyName);
	}
}
