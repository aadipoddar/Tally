using TallyLibrary.DataAccess;
using TallyLibrary.Models;

namespace TallyLibrary.Data;

public static class GroupData
{
	public static async Task<IEnumerable<T>> LoadTableData<T>(string tableName, string companyName) =>
		await SqlDataAccess.LoadDataSQL<T>(await GetSQL.GetSQLContent("Common.LoadTableData", tableName), $"{companyName}Tally");

	public static async Task InsertIntoGroupTable(GroupModel groupModel, string companyName) =>
		await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Groups.InsertIntoGroups", groupModel), $"{companyName}Tally");

	public static async Task UpdateGroupTable(GroupModel groupModel, int id, string companyName) =>
		await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Groups.UpdateGroups", groupModel, id.ToString()), $"{companyName}Tally");

	public static async Task DeleteGroupById(int id, string companyName) =>
		await SqlDataAccess.RunSQL(await GetSQL.GetSQLContent("Common.DeleteById", "Groups", id.ToString()), $"{companyName}Tally");
}
