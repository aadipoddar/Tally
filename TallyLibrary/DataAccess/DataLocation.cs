using System.Runtime.InteropServices;

namespace TallyLibrary.DataAccess;

public static class DataLocation
{
	public static bool IsDatabase() =>
		Environment.GetEnvironmentVariable("TallyAadi", EnvironmentVariableTarget.User).Substring(0,2) == "DB";

	public static bool IsTextFile() =>
		Environment.GetEnvironmentVariable("TallyAadi", EnvironmentVariableTarget.User).Substring(0,2) == "TF";

	public static bool IsMongoDBCloud() =>
		Environment.GetEnvironmentVariable("TallyAadi", EnvironmentVariableTarget.User).Substring(0,2) == "MC";

	public static bool IsMongoDBLocal() =>
		Environment.GetEnvironmentVariable("TallyAadi", EnvironmentVariableTarget.User).Substring(0, 2) == "ML";

	public static string GetTextFileDataPath() =>
		$@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\TallyAadi\";

	public static string GetSQLServerName()
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

		return $"Server={cmbServerName.FirstOrDefault()};Integrated security=SSPI;database=";
	}
}
