using TallyLibrary.DataAccess.TextFile;
using TallyLibrary.Models;

namespace TallyLibrary.Data.TextFile;

internal static class GroupData
{
	public static async Task<IEnumerable<T>> LoadTableData<T>(string tableName, string companyName) where T : new() =>
			await TextFileDataAccess.ConvertFileContentToModel<T>(companyName, tableName);

	public static async Task InsertIntoGroupTable(GroupModel groupModel, string companyName)
	{
		var groups = await TextFileDataAccess.ConvertFileContentToModel<GroupModel>(companyName, "Groups");
		groupModel.Id = groups.Last().Id + 1;
		await TextFileDataAccess.WriteToFile(companyName, "Groups", groupModel);
	}

	public static async Task UpdateGroupTable(GroupModel groupModel, string companyName) =>
			await TextFileDataAccess.UpdateFileEntry<GroupModel>(companyName, "Groups", groupModel, groupModel.Id);

	public static async Task DeleteGroupById(int id, string companyName) =>
			await TextFileDataAccess.DeleteFileEntry(companyName, "Groups", id);
}
