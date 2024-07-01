using System.Data;
using System.Data.SqlClient;

using Dapper;

namespace TallyLibrary.DataAccess;

class SqlDataAccess
{
	public string GetConnectionString(string companyName) =>
		$"Server=AADIKIITLAPI\\SQLEXPRESS;Integrated security=SSPI;database={companyName}";

	public async Task RunSQL(string sql, string companyName)
	{
		using IDbConnection connection = new SqlConnection(GetConnectionString(companyName));

		await connection.ExecuteAsync(sql);
	}

	public async Task<IEnumerable<T>> LoadDataSQL<T>(string sql, string companyName)
	{
		using IDbConnection connection = new SqlConnection(GetConnectionString(companyName));

		return await connection.QueryAsync<T>(sql);
	}

	public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string companyName)
	{
		using IDbConnection connection = new SqlConnection(GetConnectionString(companyName));

		return await connection.QueryAsync<T>(storedProcedure,
											  parameters,
											  commandType: CommandType.StoredProcedure);
	}

	public async Task SaveData<T>(string storedProcedure, T parameters, string companyName)
	{
		using IDbConnection connection = new SqlConnection(GetConnectionString(companyName));

		await connection.ExecuteAsync(storedProcedure,
									  parameters,
									  commandType: CommandType.StoredProcedure);
	}
}
