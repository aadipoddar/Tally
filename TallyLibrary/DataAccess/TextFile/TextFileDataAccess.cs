using System.IO;
using System.Reflection;

namespace TallyLibrary.DataAccess.TextFile;

public static class TextFileDataAccess
{
	public static string GetDataPath(string companyName = null, string fileName = null) =>
		fileName == null ?
			  Environment.GetEnvironmentVariable("TallyAadi", EnvironmentVariableTarget.User).Substring(3) + companyName
			: Environment.GetEnvironmentVariable("TallyAadi", EnvironmentVariableTarget.User).Substring(3) + companyName + @$"\{fileName}.txt";

	public async static Task<string> GetFileContentsTextDataAccess(string fileName)
	{
		Assembly assembly = Assembly.GetExecutingAssembly();

		StreamReader stream = new StreamReader(assembly.GetManifestResourceStream($"TallyLibrary.TextFileScripts.{fileName}.txt"));

		return await stream.ReadToEndAsync();
	}

	private static async Task RemoveEmptyLinesFromFile(string companyName, string fileName)
	{
		var path = GetDataPath(companyName, fileName);
		List<string> lines = (await File.ReadAllLinesAsync(path)).ToList();

		for (int i = 0; i < lines.Count; i++)
		{
			lines[i] = lines[i].Trim();
			if (lines[i] == "")
				lines.RemoveAt(i);
		}

		await File.WriteAllTextAsync(path, String.Empty);
		await File.WriteAllLinesAsync(path, lines);
	}

	public static IEnumerable<string> GetAllDirectories(string companyName = null)
	{
		var applicationDataPath = GetDataPath(companyName);
		var directories = Directory.GetDirectories(applicationDataPath).ToList();
		for (int i = 0; i < directories.Count; i++)
			directories[i] = directories[i].Substring(applicationDataPath.Length);

		return directories;
	}

	private static string WriteModelToLine<TModel>(TModel model)
	{
		string line = "";
		var properties = typeof(TModel).GetProperties();
		var propertyValues = new Dictionary<string, string>();

		foreach (var property in properties)
		{
			if (!property.GetGetMethod().IsPublic) continue;
			var value = property.GetValue(model);
			string stringValue = value == null ? "NULL" : value.ToString();
			propertyValues.Add(property.Name, stringValue);
		}

		for (int i = 0; i < propertyValues.Count; i++)
			line += propertyValues.ElementAt(i).Value + ",";
		return line;
	}

	public static async Task WriteToFile<TModel>(string companyName, string fileName, TModel model, params string[] additionalParameters)
	{
		string line = WriteModelToLine(model);

		for (int i = 0; i < additionalParameters.Length; i++)
			line += additionalParameters[i] + ",";

		line = line.Remove(line.Length - 1);

		if ((await File.ReadAllLinesAsync(GetDataPath(companyName, fileName))).Length == 0)
			await File.AppendAllTextAsync(GetDataPath(companyName, fileName), line);
		else
			await File.AppendAllTextAsync(GetDataPath(companyName, fileName), Environment.NewLine + line);
	}

	public static async Task<IEnumerable<TModel>> ConvertFileContentToModel<TModel>(string companyName, string fileName) where TModel : new()
	{
		await RemoveEmptyLinesFromFile(companyName, fileName);
		var lines = await File.ReadAllLinesAsync(GetDataPath(companyName, fileName));

		List<TModel> output = new();

		foreach (string line in lines)
			output.Add(ConvertLineToModel<TModel>(line));

		return output;
	}

	private static TModel ConvertLineToModel<TModel>(string line) where TModel : new()
	{
		string[] cols = line.Split(',');
		TModel model = new();

		for (int i = 0; i < cols.Length; i++)
		{
			var property = typeof(TModel).GetProperties()[i];
			if (property.PropertyType == typeof(string))
				property.SetValue(model, cols[i]);
			else if (cols[i] == "NULL")
				property.SetValue(model, null);
			else if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
				property.SetValue(model, int.Parse(cols[i]));
			else if (property.PropertyType == typeof(decimal))
				property.SetValue(model, decimal.Parse(cols[i]));
			else if (property.PropertyType == typeof(double))
				property.SetValue(model, double.Parse(cols[i]));
			else if (property.PropertyType == typeof(DateTime))
				property.SetValue(model, DateTime.Parse(cols[i]));
		}

		return model;
	}

	public static async Task UpdateFileEntry<TModel>(string companyName, string fileName, TModel model, object variable)
	{
		await RemoveEmptyLinesFromFile(companyName, fileName);
		var path = GetDataPath(companyName, fileName);
		var lines = await File.ReadAllLinesAsync(path);

		for (int i = 0; i < lines.Length; i++)
		{
			string[] cols = lines[i].Split(',');
			if (cols[0] == variable.ToString())
			{
				lines[i] = WriteModelToLine(model);
				lines[i] = lines[i].Remove(lines[i].Length - 1);
			}
			continue;
		}

		File.WriteAllText(path, String.Empty);
		File.WriteAllLines(path, lines);
	}

	public static async Task DeleteFileEntry(string companyName, string fileName, object variable)
	{
		await RemoveEmptyLinesFromFile(companyName, fileName);
		var path = GetDataPath(companyName, fileName);
		List<string> lines = (await File.ReadAllLinesAsync(path)).ToList();

		for (int i = 0; i < lines.Count; i++)
		{
			string[] cols = lines[i].Split(',');
			if (cols[0] == variable.ToString())
				lines.RemoveAt(i);
			continue;
		}

		File.WriteAllText(path, String.Empty);
		File.WriteAllLines(path, lines);
	}
}