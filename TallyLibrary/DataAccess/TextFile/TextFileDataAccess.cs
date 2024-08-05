using System.Reflection;

namespace TallyLibrary.DataAccess.TextFile;

public static class TextFileDataAccess
{
	public static string GetDataPath() =>
		Environment.GetEnvironmentVariable("TallyAadi", EnvironmentVariableTarget.User).Substring(3);

	public async static Task<string> GetFileContentsTextDataAccess(string fileName)
	{
		Assembly assembly = Assembly.GetExecutingAssembly();

		StreamReader stream = new StreamReader(assembly.GetManifestResourceStream($"TallyLibrary.TextFileScripts.{fileName}.txt"));

		return await stream.ReadToEndAsync();
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

		await File.AppendAllTextAsync(GetDataPath() + companyName + @$"\{fileName}.txt", line);
	}

	public static async Task<IEnumerable<TModel>> ConvertFileContentToModel<TModel>(string companyName, string fileName) where TModel : new()
	{
		var lines = await File.ReadAllLinesAsync(GetDataPath() + companyName + @$"\{fileName}.txt");

		List<TModel> output = new();

		foreach (string line in lines)
			output.Add(ConvertLineToModel<TModel>(line));

		return output;
	}

	private static async Task<TModel> LookupBy<TModel>(string companyName, string fileName, object variable) where TModel : new()
	{
		var lines = await File.ReadAllLinesAsync(GetDataPath() + companyName + @$"\{fileName}.txt");

		foreach (string line in lines)
		{
			string[] cols = line.Split(',');
			if (cols[0] == variable.ToString())
				return ConvertLineToModel<TModel>(line);
		}

		return default;
	}

	public static TModel ConvertLineToModel<TModel>(string line) where TModel : new()
	{
		string[] cols = line.Split(',');
		TModel model = new();

		for (int i = 0; i < cols.Length; i++)
		{
			var property = typeof(TModel).GetProperties()[i];
			if (property.PropertyType == typeof(string))
				property.SetValue(model, cols[i]);
			else if (property.PropertyType == typeof(int))
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
		var path = GetDataPath() + companyName + @$"\{fileName}.txt";
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
}