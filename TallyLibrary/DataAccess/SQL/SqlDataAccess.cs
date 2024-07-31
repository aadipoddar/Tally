using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

using Dapper;

namespace TallyLibrary.DataAccess.SQL;

static class SqlDataAccess
{
    public static string GetConnectionstring(string databaseName)
    {
        List<string> cmbServerName = new();

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Microsoft.Win32.RegistryView registryView = Environment.Is64BitOperatingSystem ? Microsoft.Win32.RegistryView.Registry64 : Microsoft.Win32.RegistryView.Registry32;
            using Microsoft.Win32.RegistryKey hklm = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, registryView);
            Microsoft.Win32.RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
            if (instanceKey != null)
                foreach (var instanceName in instanceKey.GetValueNames())
                    cmbServerName.Add(Environment.MachineName + "\\" + instanceName);
        }

        return $"Server={cmbServerName.FirstOrDefault()};Integrated security=SSPI;database={databaseName}";
    }

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
