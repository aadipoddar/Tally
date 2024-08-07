using TallyLibrary.DataAccess.SQL;
using TallyLibrary.Models;

namespace TallyLibrary.Data.SQL;

internal static class GroupData
{
	public static async Task<IEnumerable<T>> LoadTableData<T>(string tableName, string companyName) where T : new() =>
			await SqlDataAccess.LoadDataSQL<T>(await GetSQL.GetSQLContent("Common.LoadTableData", tableName), $"{companyName}Tally");

	public static async Task InsertIntoGroupTable(GroupModel groupModel, string companyName) =>
			await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Groups.InsertIntoGroups", groupModel), $"{companyName}Tally");

	public static async Task UpdateGroupTable(GroupModel groupModel, string companyName) =>
			await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Groups.UpdateGroups", groupModel, groupModel.Id.ToString()), $"{companyName}Tally");

	public static async Task DeleteGroupById(int id, string companyName) =>
			await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Common.DeleteById", "Groups", id.ToString()), $"{companyName}Tally");
}
