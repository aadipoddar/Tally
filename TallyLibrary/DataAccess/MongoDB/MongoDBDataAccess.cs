using MongoDB.Driver;

namespace TallyLibrary.DataAccess.MongoDB;

public static class MongoDBDataAccess
{
	public static string GetConnectionstring() =>
		Environment.GetEnvironmentVariable("TallyAadi", EnvironmentVariableTarget.User).Substring(3);

	public static IMongoClient GetMongoDBClient() =>
		new MongoClient(GetConnectionstring());

	public static IMongoCollection<T> GetCollection<T>(string companyName, string collectionName) =>
		GetMongoDBClient().GetDatabase(companyName).GetCollection<T>(collectionName);
}
