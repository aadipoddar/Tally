using MongoDB.Driver;

using TallyLibrary.DataAccess.MongoDB;
using TallyLibrary.Models;

namespace TallyLibrary.Data.MongoDB;

internal static class LedgerData
{
	public static async Task<IEnumerable<T>> LoadTableData<T>(string tableName, string companyName) =>
			await MongoDBDataAccess.GetCollection<T>(companyName, tableName)
									.Find(_ => true)
									.ToListAsync();

	public static async Task InsertIntoTable(LedgerModel ledgerModel, string companyName)
	{
		var ledgers = await MongoDBDataAccess.GetCollection<LedgerModel>(companyName, "Ledgers")
										.Find(_ => true)
										.ToListAsync();

		ledgerModel.Id = ledgers.LastOrDefault().Id + 1;
		await MongoDBDataAccess.GetCollection<LedgerModel>(companyName, "Ledgers").InsertOneAsync(ledgerModel);
	}

	public static async Task UpdateTable(LedgerModel ledgerModel, string companyName) =>
			await MongoDBDataAccess.GetCollection<LedgerModel>(companyName, "Ledgers")
								.ReplaceOneAsync(ledger => ledger.Id == ledgerModel.Id, ledgerModel);

	public static async Task DeleteById(int id, string companyName) =>
			await MongoDBDataAccess.GetCollection<LedgerModel>(companyName, "Ledgers")
								.DeleteOneAsync(ledger => ledger.Id == id);
}
