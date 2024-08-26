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

	public static async Task InsertIntoVoucherTypeTable(VoucherTypeModel voucherTypeModel, string companyName)
	{
		if (DataLocation.IsDatabase())
			await SQL.VoucherTypeData.InsertIntoVoucherTypeTable(voucherTypeModel, companyName);

		if (DataLocation.IsTextFile())
			await TextFile.VoucherTypeData.InsertIntoVoucherTypeTable(voucherTypeModel, companyName);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			await MongoDB.VoucherTypeData.InsertIntoVoucherTypeTable(voucherTypeModel, companyName);
	}

	public static async Task UpdateVoucherTypeTable(VoucherTypeModel voucherTypeModel, string companyName)
	{
		if (DataLocation.IsDatabase())
			await SQL.VoucherTypeData.UpdateVoucherTypeTable(voucherTypeModel, companyName);

		if (DataLocation.IsTextFile())
			await TextFile.VoucherTypeData.UpdateVoucherTypeTable(voucherTypeModel, companyName);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			await MongoDB.VoucherTypeData.UpdateVoucherTypeTable(voucherTypeModel, companyName);
	}

	public static async Task DeleteVoucherTypeById(int id, string companyName)
	{
		if (DataLocation.IsDatabase())
			await SQL.VoucherTypeData.DeleteVoucherTypeById(id, companyName);

		if (DataLocation.IsTextFile())
			await TextFile.VoucherTypeData.DeleteVoucherTypeById(id, companyName);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			await MongoDB.VoucherTypeData.DeleteVoucherTypeById(id, companyName);
	}
}
