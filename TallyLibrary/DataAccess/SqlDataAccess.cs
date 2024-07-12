using System.Data;
using System.Data.SqlClient;

using Dapper;

namespace TallyLibrary.DataAccess;

static class SqlDataAccess
{
	public static string GetConnectionstring(string databaseName) =>
		$"Server=AADIKIITLAPI\\SQLEXPRESS;Integrated security=SSPI;database={databaseName}";

	public static async Task RunSQL(string sql, string databaseName)
	{
		using IDbConnection connection = new SqlConnection(GetConnectionstring(databaseName));

		await connection.ExecuteAsync(sql);
	}

	public static async Task<IEnumerable<T>> LoadDataSQL<T>(string sql, string databaseName)
	{
		using IDbConnection connection = new SqlConnection(GetConnectionstring(databaseName));

		return await connection.QueryAsync<T>(sql);
	}

	public static async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string databaseName)
	{
		using IDbConnection connection = new SqlConnection(GetConnectionstring(databaseName));

		return await connection.QueryAsync<T>(storedProcedure,
											  parameters,
											  commandType: CommandType.StoredProcedure);
	}

	public static async Task SaveData<T>(string storedProcedure, T parameters, string databaseName)
	{
		using IDbConnection connection = new SqlConnection(GetConnectionstring(databaseName));

		await connection.ExecuteAsync(storedProcedure,
									  parameters,
									  commandType: CommandType.StoredProcedure);
	}
}
