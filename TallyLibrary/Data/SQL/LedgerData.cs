
using TallyLibrary.DataAccess.SQL;
using TallyLibrary.Models;

namespace TallyLibrary.Data.SQL;

internal static class LedgerData
{
	public static async Task<IEnumerable<T>> LoadTableData<T>(string tableName, string companyName) where T : new() =>
			await SqlDataAccess.LoadDataSQL<T>(await GetSQL.GetSQLContent("Common.LoadTableData", tableName), $"{companyName}Tally");

	public static async Task InsertIntoLedgerTable(LedgerModel ledgerModel, string companyName) =>
			await SqlDataAccess.RunSQL(GetSQL.GetSQLContent(SQLCommands.INSERT, ledgerModel, "Ledgers"), $"{companyName}Tally");

	public static async Task UpdateLedgerTable(LedgerModel ledgerModel, string companyName) =>
			await SqlDataAccess.RunSQL(GetSQL.GetSQLContent(SQLCommands.UPDATE, ledgerModel, "Ledgers", "Id", ledgerModel.Id.ToString()), $"{companyName}Tally");

	public static async Task DeleteLedgerById(int id, string companyName) =>
			await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Common.DeleteById", "Ledgers", id.ToString()), $"{companyName}Tally");
}
