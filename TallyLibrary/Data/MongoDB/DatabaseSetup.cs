using TallyLibrary.DataAccess.MongoDB;
using TallyLibrary.DataAccess.TextFile;
using TallyLibrary.Models;

namespace TallyLibrary.Data.MongoDB;

internal static class DatabaseSetup
{
	public static async Task CreateDatabase(string companyName) =>
		await FillData(companyName, (await TextFileDataAccess.GetFileContentsTextDataAccess("TableNames")).ToString().Split("\r\n"));

	private static async Task FillData(string companyName, string[] tables)
	{
		for (int i = 0; i < tables.Length; i++)
		{
			var lines = (await TextFileDataAccess.GetFileContentsTextDataAccess($"OriginalFiles.{tables[i]}")).ToString().Split("\r\n");

			if (tables[i] == "Groups")
				foreach (var line in lines)
					await MongoDBDataAccess.GetCollection<GroupModel>(companyName, tables[i])
							.InsertOneAsync(TextFileDataAccess.ConvertLineToModel<GroupModel>(line));

			else if (tables[i] == "MethodToAllocate")
				foreach (var line in lines)
					await MongoDBDataAccess.GetCollection<MethodToAllocateModel>(companyName, tables[i])
							.InsertOneAsync(TextFileDataAccess.ConvertLineToModel<MethodToAllocateModel>(line));

			else if (tables[i] == "NatureOfGroup")
				foreach (var line in lines)
					await MongoDBDataAccess.GetCollection<NatureOfGroupModel>(companyName, tables[i])
							.InsertOneAsync(TextFileDataAccess.ConvertLineToModel<NatureOfGroupModel>(line));

			else if (tables[i] == "MethodOfCalculation")
				foreach (var line in lines)
					await MongoDBDataAccess.GetCollection<MethodOfCalculationModel>(companyName, tables[i])
							.InsertOneAsync(TextFileDataAccess.ConvertLineToModel<MethodOfCalculationModel>(line));

			else if (tables[i] == "Ledgers")
				foreach (var line in lines)
					await MongoDBDataAccess.GetCollection<LedgerModel>(companyName, tables[i])
							.InsertOneAsync(TextFileDataAccess.ConvertLineToModel<LedgerModel>(line));

			else if (tables[i] == "VoucherTypes")
				foreach (var line in lines)
					await MongoDBDataAccess.GetCollection<VoucherTypeModel>(companyName, tables[i])
							.InsertOneAsync(TextFileDataAccess.ConvertLineToModel<VoucherTypeModel>(line));
		}
	}
}
