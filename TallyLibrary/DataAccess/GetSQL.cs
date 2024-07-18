using System.Reflection;

namespace TallyLibrary.DataAccess;

static class GetSQL
{
	private static async Task<string> GetSQLContent(string fileName)
	{
		Assembly assembly = Assembly.GetExecutingAssembly();

		StreamReader stream = new StreamReader(assembly.GetManifestResourceStream($"TallyLibrary.SQLScripts.{fileName}.txt"));

		return await stream.ReadToEndAsync();
	}

	public static async Task<string> GetSQLContent(string fileName, params string[] parameters)
	{
		string sqlTemplate = await GetSQLContent(fileName);
		for (int i = 0; i < parameters.Length; i++)
			sqlTemplate = sqlTemplate.Replace($"@param{i}@", parameters[i]);

		return sqlTemplate;
	}

	public static async Task<string> GetSQLContent<TModel>(string fileName, TModel model, params string[] additionalParameters)
	{
		string sqlTemplate = await GetSQLContent(fileName);

		if (model != null)
		{
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
				sqlTemplate = sqlTemplate.Replace("@" + propertyValues.ElementAt(i).Key + "@", propertyValues.ElementAt(i).Value);
		}

		for (int i = 0; i < additionalParameters.Length; i++)
			sqlTemplate = sqlTemplate.Replace($"@param{i}@", additionalParameters[i]);

		return sqlTemplate;
	}
}