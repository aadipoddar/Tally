using TallyLibrary.DataAccess.TextFile;
using TallyLibrary.Models;

namespace TallyLibrary.Data.TextFile;

internal static class VoucherTypeData
{
	public static async Task<IEnumerable<T>> LoadTableData<T>(string tableName, string companyName) where T : new() =>
		await TextFileDataAccess.ConvertFileContentToModel<T>(companyName, tableName);

	public static async Task InsertIntoVoucherTypeTable(VoucherTypeModel voucherTypeModel, string companyName)
	{
		var vouchers = await TextFileDataAccess.ConvertFileContentToModel<VoucherTypeModel>(companyName, "VoucherTypes");
		voucherTypeModel.Id = vouchers.Last().Id + 1;
		await TextFileDataAccess.WriteToFile(companyName, "VoucherTypes", voucherTypeModel);
	}

	public static async Task UpdateVoucherTypeTable(VoucherTypeModel voucherTypeModel, string companyName) =>
			await TextFileDataAccess.UpdateFileEntry(companyName, "VoucherTypes", voucherTypeModel, voucherTypeModel.Id);

	public static async Task DeleteVoucherTypeById(int id, string companyName) =>
			await TextFileDataAccess.DeleteFileEntry(companyName, "VoucherTypes", id);
}
