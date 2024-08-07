using System.Data;
using System.Data.SqlClient;

using Dapper;

namespace TallyLibrary.DataAccess.SQL;

static class SqlDataAccess
{
	public static string GetConnectionstring(string databaseName = null) =>
		Environment.GetEnvironmentVariable("TallyAadi", EnvironmentVariableTarget.User).Substring(3) + databaseName;

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
}
