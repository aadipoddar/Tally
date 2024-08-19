using System.Reflection;

namespace TallyLibrary.DataAccess.SQL;

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

	public static string GetSQLContent<TModel>(SQLCommands sQLCommands, TModel model, string tableName, params string[] additionalParameters)
	{
		if (sQLCommands == SQLCommands.INSERT)
		{
			string s = $"INSERT INTO [dbo].[{tableName}](";

			var propertyValues = GetProperties(model);

			for (int i = 0; i < propertyValues.Count; i++)
			{
				if (propertyValues.ElementAt(i).Key == "Id")
					continue;
				s = s + $"[{propertyValues.ElementAt(i).Key}],";
			}

			s = s.Remove(s.Length - 1);
			s = s + ") VALUES (";

			for (int i = 0; i < propertyValues.Count; i++)
			{
				if (propertyValues.ElementAt(i).Key == "Id")
					continue;
				if (propertyValues.ElementAt(i).Value == null)
					s = s + "null,";
				else s = s + $"'{propertyValues.ElementAt(i).Value}',";
			}

			s = s.Remove(s.Length - 1);

			s = s + ")";

			return s;
		}

		if (sQLCommands == SQLCommands.UPDATE)
		{
			string s = $"UPDATE [dbo].[{tableName}] SET ";

			var propertyValues = GetProperties(model);

			for (int i = 0; i < propertyValues.Count; i++)
			{
				if (propertyValues.ElementAt(i).Key == "Id")
					continue;
				if (propertyValues.ElementAt(i).Value == null)
					s = s + $"[{propertyValues.ElementAt(i).Key}] = null,";
				else
					s = s + $"[{propertyValues.ElementAt(i).Key}] = '{propertyValues.ElementAt(i).Value}',";
			}

			s = s.Remove(s.Length - 1);

			s = s + $" WHERE [{additionalParameters[0]}] = '{additionalParameters[1]}'";

			return s;
		}

		return "";
	}

	private static Dictionary<string, string> GetProperties<TModel>(TModel model)
	{
		var properties = typeof(TModel).GetProperties();
		var propertyValues = new Dictionary<string, string>();
		foreach (var property in properties)
		{
			if (!property.GetGetMethod().IsPublic) continue;

			var value = property.GetValue(model);

			string stringValue = value == null ? null : value.ToString();

			propertyValues.Add(property.Name, stringValue);
		}

		return propertyValues;
	}
}