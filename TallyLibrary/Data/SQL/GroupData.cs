using TallyLibrary.DataAccess.SQL;
using TallyLibrary.Models;

namespace TallyLibrary.Data.SQL;

internal static class GroupData
{
	public static async Task<GroupModel> GetGroupById(string companyName, int id) =>
		(GroupModel)await SqlDataAccess.LoadDataSQL<GroupModel>(await GetSQL.GetSQLContent("Common.GetById", "Groups", id.ToString()), $"{companyName}Tally");

	public static async Task<IEnumerable<T>> LoadTableData<T>(string tableName, string companyName) where T : new() =>
			await SqlDataAccess.LoadDataSQL<T>(await GetSQL.GetSQLContent("Common.LoadTableData", tableName), $"{companyName}Tally");

	public static async Task InsertIntoTable(GroupModel groupModel, string companyName) =>
			await SqlDataAccess.RunSQL(GetSQL.GetSQLContent(SQLCommands.INSERT, groupModel, "Groups"), $"{companyName}Tally");

	public static async Task UpdateTable(GroupModel groupModel, string companyName) =>
			await SqlDataAccess.RunSQL(GetSQL.GetSQLContent(SQLCommands.UPDATE, groupModel, "Groups", "Id", groupModel.Id.ToString()), $"{companyName}Tally");

	public static async Task DeleteById(int id, string companyName) =>
			await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Common.DeleteById", "Groups", id.ToString()), $"{companyName}Tally");
}
