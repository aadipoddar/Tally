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

	public static async Task InsertIntoTable(GroupModel groupModel, string companyName)
	{
		if (DataLocation.IsDatabase())
			await SQL.GroupData.InsertIntoTable(groupModel, companyName);

		if (DataLocation.IsTextFile())
			await TextFile.GroupData.InsertIntoTable(groupModel, companyName);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			await MongoDB.GroupData.InsertIntoTable(groupModel, companyName);
	}

	public static async Task UpdateTable(GroupModel groupModel, string companyName)
	{
		if (DataLocation.IsDatabase())
			await SQL.GroupData.UpdateTable(groupModel, companyName);

		if (DataLocation.IsTextFile())
			await TextFile.GroupData.UpdateTable(groupModel, companyName);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			await MongoDB.GroupData.UpdateTable(groupModel, companyName);
	}

	public static async Task DeleteById(int id, string companyName)
	{
		if (DataLocation.IsDatabase())
			await SQL.GroupData.DeleteById(id, companyName);

		if (DataLocation.IsTextFile())
			await TextFile.GroupData.DeleteById(id, companyName);

		if (DataLocation.IsMongoDBCloud() || DataLocation.IsMongoDBLocal())
			await MongoDB.GroupData.DeleteById(id, companyName);
	}
}
