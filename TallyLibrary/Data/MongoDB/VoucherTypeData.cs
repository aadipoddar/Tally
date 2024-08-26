using MongoDB.Driver;

using TallyLibrary.DataAccess.MongoDB;
using TallyLibrary.Models;

namespace TallyLibrary.Data.MongoDB;

internal static class VoucherTypeData
{
	public static async Task<IEnumerable<T>> LoadTableData<T>(string tableName, string companyName) =>
			await MongoDBDataAccess.GetCollection<T>(companyName, tableName)
									.Find(_ => true)
									.ToListAsync();

	public static async Task InsertIntoVoucherTypeTable(VoucherTypeModel voucherTypeModel, string companyName)
	{
		var ledgers = await MongoDBDataAccess.GetCollection<VoucherTypeModel>(companyName, "VoucherTypes")
										.Find(_ => true)
										.ToListAsync();

		voucherTypeModel.Id = ledgers.LastOrDefault().Id + 1;
		await MongoDBDataAccess.GetCollection<VoucherTypeModel>(companyName, "VoucherTypes").InsertOneAsync(voucherTypeModel);
	}

	public static async Task UpdateVoucherTypeTable(VoucherTypeModel voucherTypeModel, string companyName) =>
			await MongoDBDataAccess.GetCollection<VoucherTypeModel>(companyName, "VoucherTypes")
								.ReplaceOneAsync(voucherType => voucherType.Id == voucherTypeModel.Id, voucherTypeModel);

	public static async Task DeleteVoucherTypeById(int id, string companyName) =>
			await MongoDBDataAccess.GetCollection<VoucherTypeModel>(companyName, "VoucherTypes")
								.DeleteOneAsync(voucherType => voucherType.Id == id);
}
