using MongoDB.Bson;
using MongoDB.Driver;

using TallyLibrary.DataAccess.MongoDB;
using TallyLibrary.Models;

namespace TallyLibrary.Data.MongoDB;

internal static class CompanyData
{
	public static async Task<IEnumerable<string>> GetAllCompanies()
	{
		var allCompanies = (await MongoDBDataAccess.GetMongoDBClient().ListDatabaseNamesAsync()).ToList();

		if (DataAccess.DataLocation.IsMongoDBLocal())
			allCompanies.RemoveRange(0,3);

		return allCompanies;
	}

	public static async Task<CompanyModel> LoadCompanyDetails(string companyName) =>
		await MongoDBDataAccess.GetCollection<CompanyModel>(companyName, "CompanyDetails")
				.Find(Builders<CompanyModel>.Filter.Empty)
				.Project<CompanyModel>(Builders<CompanyModel>
				.Projection.Exclude("_id"))
				.FirstOrDefaultAsync();

	public static async Task InsertIntoCompanyTablesAsync(CompanyModel company) =>
		await MongoDBDataAccess.GetCollection<CompanyModel>(company.Name, "CompanyDetails").InsertOneAsync(company);

	private static void ChangeDatabaseName(CompanyModel company, string oldCompanyName)
	{
		MongoDBDataAccess.GetMongoDBClient().DropDatabase(company.Name); //we drop the new database in case it exists

		var newDb = MongoDBDataAccess.GetMongoDBClient().GetDatabase(company.Name); //get an instance of the new db

		var CurrentDb = MongoDBDataAccess.GetMongoDBClient().GetDatabase(oldCompanyName); //get an instance of the current db

		foreach (BsonDocument Col in CurrentDb.ListCollections().ToList()) //work thru all collections in the current db
		{
			string name = Col["name"].AsString; //getting collection name

			//collection of items to copy from source collection
			dynamic collectionItems = CurrentDb.GetCollection<dynamic>(name).Find(Builders<dynamic>.Filter.Empty).ToList();

			//getting instance of new collection to store the current db collection items
			dynamic destinationCollection = newDb.GetCollection<dynamic>(name);

			//insert the source items into the new destination database collection
			destinationCollection.InsertMany(collectionItems);
		}

		//removing the old datbase
		MongoDBDataAccess.GetMongoDBClient().DropDatabase(oldCompanyName);
	}

	public static async Task UpdateCompanyDetails(CompanyModel company, string oldCompanyName, bool companyNameChanged = false)
	{
		if (companyNameChanged)
			ChangeDatabaseName(company, oldCompanyName);

		await MongoDBDataAccess.GetCollection<CompanyModel>(company.Name, "CompanyDetails")
								.ReplaceOneAsync(company => company.Name == oldCompanyName, company);
	}

	public static async Task DeleteDatabase(string companyName) =>
		await MongoDBDataAccess.GetMongoDBClient().DropDatabaseAsync(companyName);
}
