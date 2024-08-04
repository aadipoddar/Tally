namespace TallyLibrary.DataAccess;

public static class DataLocation
{
	public static bool IsDatabase() =>
		Environment.GetEnvironmentVariable("TallyAadi", EnvironmentVariableTarget.User) == "Database";

	public static bool IsTextFile() =>
		IsDatabase() ? false : true;

	public static string GetDataPath() =>
		$@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\TallyAadi\";
}
