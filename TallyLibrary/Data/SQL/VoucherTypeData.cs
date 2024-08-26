using TallyLibrary.DataAccess.SQL;
using TallyLibrary.Models;

namespace TallyLibrary.Data.SQL;

internal static class VoucherTypeData
{
	public static async Task<IEnumerable<T>> LoadTableData<T>(string tableName, string companyName) where T : new() =>
			await SqlDataAccess.LoadDataSQL<T>(await GetSQL.GetSQLContent("Common.LoadTableData", tableName), $"{companyName}Tally");

	public static async Task InsertIntoVoucherTypeTable(VoucherTypeModel voucherTypeModel, string companyName) =>
			await SqlDataAccess.RunSQL(GetSQL.GetSQLContent(SQLCommands.INSERT, voucherTypeModel, "VoucherTypes"), $"{companyName}Tally");

	public static async Task UpdateVoucherTypeTable(VoucherTypeModel voucherTypeModel, string companyName) =>
			await SqlDataAccess.RunSQL(GetSQL.GetSQLContent(SQLCommands.UPDATE, voucherTypeModel, "VoucherTypes", "Id", voucherTypeModel.Id.ToString()), $"{companyName}Tally");

	public static async Task DeleteVoucherTypeById(int id, string companyName) =>
			await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Common.DeleteById", "VoucherTypes", id.ToString()), $"{companyName}Tally");
}
