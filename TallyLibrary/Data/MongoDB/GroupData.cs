using MongoDB.Driver;

using TallyLibrary.DataAccess.MongoDB;
using TallyLibrary.Models;

namespace TallyLibrary.Data.MongoDB;

internal static class GroupData
{
	public static async Task<IEnumerable<T>> LoadTableData<T>(string tableName, string companyName) =>
			await MongoDBDataAccess.GetCollection<T>(companyName, tableName)
									.Find(_ => true)
									.ToListAsync();

	public static async Task InsertIntoTable(GroupModel groupModel, string companyName)
	{
		var groups = await MongoDBDataAccess.GetCollection<GroupModel>(companyName, "Groups")
										.Find(_ => true)
										.ToListAsync();

		groupModel.Id = groups.LastOrDefault().Id + 1;
		await MongoDBDataAccess.GetCollection<GroupModel>(companyName, "Groups").InsertOneAsync(groupModel);
	}

	public static async Task UpdateTable(GroupModel groupModel, string companyName) =>
			await MongoDBDataAccess.GetCollection<GroupModel>(companyName, "Groups")
								.ReplaceOneAsync(group => group.Id == groupModel.Id, groupModel);

	public static async Task DeleteById(int id, string companyName) =>
			await MongoDBDataAccess.GetCollection<GroupModel>(companyName, "Groups")
								.DeleteOneAsync(group => group.Id == id);
}
