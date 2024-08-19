using TallyLibrary.DataAccess;
using TallyLibrary.Models;

namespace TallyLibrary.Data;

public static class GroupData
{
	public static async Task<GroupModel> GetGroupById(string companyName, int id)
	{
		if (DataLocation.IsDatabase())
			return await SQL.GroupData.GetGroupById(companyName, id);

		return default;
	}

	public static async Task<IEnumerable<T>> LoadTableData<T>(string tableName, string companyName) where T : new()
	{
		if (DataLocation.IsDatabase())
			return await SQL.GroupData.LoadTableData<T>(tableName, companyName);

		if (DataLocation.IsTextFile())
			return await TextFile.GroupData.LoadTableData<T>(tableName, companyName);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			return await MongoDB.GroupData.LoadTableData<T>(tableName, companyName);

		return default;
	}

	public static async Task InsertIntoGroupTable(GroupModel groupModel, string companyName)
	{
		if (DataLocation.IsDatabase())
			await SQL.GroupData.InsertIntoGroupTable(groupModel, companyName);

		if (DataLocation.IsTextFile())
			await TextFile.GroupData.InsertIntoGroupTable(groupModel, companyName);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			await MongoDB.GroupData.InsertIntoGroupTable(groupModel, companyName);
	}

	public static async Task UpdateGroupTable(GroupModel groupModel, string companyName)
	{
		if (DataLocation.IsDatabase())
			await SQL.GroupData.UpdateGroupTable(groupModel, companyName);

		if (DataLocation.IsTextFile())
			await TextFile.GroupData.UpdateGroupTable(groupModel, companyName);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			await MongoDB.GroupData.UpdateGroupTable(groupModel, companyName);
	}

	public static async Task DeleteGroupById(int id, string companyName)
	{
		if (DataLocation.IsDatabase())
			await SQL.GroupData.DeleteGroupById(id, companyName);

		if (DataLocation.IsTextFile())
			await TextFile.GroupData.DeleteGroupById(id, companyName);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			await MongoDB.GroupData.DeleteGroupById(id, companyName);
	}
}
