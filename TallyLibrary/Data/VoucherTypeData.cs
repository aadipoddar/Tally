using TallyLibrary.DataAccess;
using TallyLibrary.Models;

namespace TallyLibrary.Data;

public class VoucherTypeData
{
	public static async Task<IEnumerable<T>> LoadTableData<T>(string tableName, string companyName) where T : new()
	{
		if (DataLocation.IsDatabase())
			return await SQL.VoucherTypeData.LoadTableData<T>(tableName, companyName);

		if (DataLocation.IsTextFile())
			return await TextFile.VoucherTypeData.LoadTableData<T>(tableName, companyName);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			return await MongoDB.VoucherTypeData.LoadTableData<T>(tableName, companyName);

		return default;
	}

	public static async Task InsertIntoTable(VoucherTypeModel voucherTypeModel, string companyName)
	{
		if (DataLocation.IsDatabase())
			await SQL.VoucherTypeData.InsertIntoTable(voucherTypeModel, companyName);

		if (DataLocation.IsTextFile())
			await TextFile.VoucherTypeData.InsertIntoTable(voucherTypeModel, companyName);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			await MongoDB.VoucherTypeData.InsertIntoTable(voucherTypeModel, companyName);
	}

	public static async Task UpdateTable(VoucherTypeModel voucherTypeModel, string companyName)
	{
		if (DataLocation.IsDatabase())
			await SQL.VoucherTypeData.UpdateTable(voucherTypeModel, companyName);

		if (DataLocation.IsTextFile())
			await TextFile.VoucherTypeData.UpdateTable(voucherTypeModel, companyName);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			await MongoDB.VoucherTypeData.UpdateTable(voucherTypeModel, companyName);
	}

	public static async Task DeleteById(int id, string companyName)
	{
		if (DataLocation.IsDatabase())
			await SQL.VoucherTypeData.DeleteById(id, companyName);

		if (DataLocation.IsTextFile())
			await TextFile.VoucherTypeData.DeleteById(id, companyName);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			await MongoDB.VoucherTypeData.DeleteById(id, companyName);
	}
}
