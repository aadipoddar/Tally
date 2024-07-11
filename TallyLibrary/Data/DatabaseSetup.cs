using TallyLibrary.DataAccess;

namespace TallyLibrary.Data;

public class DatabaseSetup
{
	SqlDataAccess sqlDataAccess = new();

	public async Task CreateDatabase(String companyName)
	{
		await sqlDataAccess.RunSQL($"CREATE DATABASE {companyName}Tally", "master");

		await CreateTablesAsync(companyName);
	}

	private async Task CreateTablesAsync(string companyName)
	{
		await CompanyDetailsTable(companyName);
		await NatureOfGroupTable(companyName);
		await MethodToAllocateTable(companyName);
		await GroupsTable(companyName);
	}

	private async Task CompanyDetailsTable(string companyName)
	{
		String sql = "CREATE TABLE [dbo].[CompanyDetails] ([Name] VARCHAR(250) NOT NULL, [MailingName] VARCHAR(250) NULL, [Address] VARCHAR(250) NULL, [State] VARCHAR(250) NULL, [PinCode] INT NULL, [TelephoneNumber] VARCHAR(250) NULL, [EMail] VARCHAR(250) NULL, [FinancialYearFrom] DATE NOT NULL, [BooksBeginFrom] DATE NOT NULL, [Password] VARCHAR(250) NULL)";
		await sqlDataAccess.RunSQL(sql, $"{companyName}Tally");
	}

	private async Task NatureOfGroupTable(string companyName)
	{
		String sql = "CREATE TABLE [dbo].[NatureOfGroup] ([Id] INT NOT NULL PRIMARY KEY IDENTITY, [Name] VARCHAR(250) NOT NULL)";
		await sqlDataAccess.RunSQL(sql, $"{companyName}Tally");
	}

	private async Task MethodToAllocateTable(string companyName)
	{
		String sql = "CREATE TABLE [dbo].[MethodToAllocate] ( [Id] INT NOT NULL PRIMARY KEY IDENTITY, [Name] VARCHAR(250) NOT NULL)";
		await sqlDataAccess.RunSQL(sql, $"{companyName}Tally");
	}

	private async Task GroupsTable(string companyName)
	{
		String sql = "CREATE TABLE [dbo].[Groups] ( [Id] INT NOT NULL PRIMARY KEY IDENTITY, [Name] VARCHAR(250) NOT NULL, [Under] INT NOT NULL, [NatureOfGroup] INT NULL, [AffectGrossProfit] BIT NULL, [BehavesSubLedger] BIT NOT NULL, [NetBalances] BIT NOT NULL, [UsedForCalculation] BIT NOT NULL, [MethodToAllocate] INT NOT NULL, CONSTRAINT [FK_Groups_ToNature] FOREIGN KEY ([NatureOfGroup]) REFERENCES [NatureOfGroup]([Id]), CONSTRAINT [FK_Groups_ToMethodAllocate] FOREIGN KEY ([MethodToAllocate]) REFERENCES [MethodToAllocate]([Id]))";
		await sqlDataAccess.RunSQL(sql, $"{companyName}Tally");
	}
}
