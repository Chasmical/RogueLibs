using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RogueLibsCore
{
	public interface IName : IEnumerable<KeyValuePair<LanguageCode, string>>
	{
		string this[LanguageCode language] { get; set; }
	}
	public class CustomName : IName
	{
		static CustomName() => Languages = new ReadOnlyDictionary<string, LanguageCode>(languages);
		internal CustomName(string name, string type, string english)
		{
			Name = name;
			Type = type;
			English = english;
			Translations = new ReadOnlyDictionary<LanguageCode, string>(translations);
		}
		internal CustomName(string name, string type, IEnumerable<KeyValuePair<LanguageCode, string>> dictionary)
		{
			Name = name;
			Type = type;
			foreach (KeyValuePair<LanguageCode, string> pair in dictionary)
				if (!(pair.Value is null))
					translations[pair.Key] = pair.Value;
			Translations = new ReadOnlyDictionary<LanguageCode, string>(translations);
		}

		public string Name { get; }
		public string Type { get; }

		public string English { get => this[LanguageCode.English]; set => this[LanguageCode.English] = value; }
		public string Spanish { get => this[LanguageCode.Spanish]; set => this[LanguageCode.Spanish] = value; }
		public string Chinese { get => this[LanguageCode.Chinese]; set => this[LanguageCode.Chinese] = value; }
		public string German { get => this[LanguageCode.German]; set => this[LanguageCode.German] = value; }
		public string Brazilian { get => this[LanguageCode.Brazilian]; set => this[LanguageCode.Brazilian] = value; }
		public string French { get => this[LanguageCode.French]; set => this[LanguageCode.French] = value; }
		public string Russian { get => this[LanguageCode.Russian]; set => this[LanguageCode.Russian] = value; }
		public string Korean { get => this[LanguageCode.Korean]; set => this[LanguageCode.Korean] = value; }

		private readonly Dictionary<LanguageCode, string> translations = new Dictionary<LanguageCode, string>(1);
		public ReadOnlyDictionary<LanguageCode, string> Translations { get; }
		public string this[LanguageCode language]
		{
			get => translations.TryGetValue(language, out string str) ? str : null;
			set
			{
				if (!(value is null)) translations[language] = value;
				else translations.Remove(language);
			}
		}

		public IEnumerator<KeyValuePair<LanguageCode, string>> GetEnumerator() => translations.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		private static readonly Dictionary<string, LanguageCode> languages = new Dictionary<string, LanguageCode>
		{
			["english"] = LanguageCode.English,
			["spanish"] = LanguageCode.Spanish,
			["schinese"] = LanguageCode.Chinese,
			["german"] = LanguageCode.German,
			["brazilian"] = LanguageCode.Brazilian,
			["french"] = LanguageCode.French,
			["russian"] = LanguageCode.Russian,
			["koreana"] = LanguageCode.Korean,
		};
		public static ReadOnlyDictionary<string, LanguageCode> Languages { get; }
		public static void RegisterLanguageCode(string languageId, LanguageCode code)
		{
			if (languageId is null) throw new ArgumentNullException(nameof(languageId));
			if (languages.ContainsKey(languageId))
				throw new ArgumentException($"The specified {nameof(languageId)} is already taken.", nameof(languageId));
			RogueFramework.Logger.LogDebug($"Registered \"{languageId}\" language id ({(int)code})");
			languages.Add(languageId, code);
		}
	}
	public struct CustomNameInfo : IName
	{
		public CustomNameInfo(string english)
		{
			if (english is null) throw new ArgumentNullException(nameof(english));
			translations = new Dictionary<LanguageCode, string>(1) { [LanguageCode.English] = english };
		}
		public CustomNameInfo(IEnumerable<KeyValuePair<LanguageCode, string>> dictionary)
		{
			if (dictionary is null) throw new ArgumentNullException(nameof(dictionary));
			translations = new Dictionary<LanguageCode, string>(dictionary.Count());
			foreach (KeyValuePair<LanguageCode, string> pair in dictionary)
				if (!(pair.Value is null))
					translations[pair.Key] = pair.Value;
		}

		public string English { get => this[LanguageCode.English]; set => this[LanguageCode.English] = value; }
		public string Spanish { get => this[LanguageCode.Spanish]; set => this[LanguageCode.Spanish] = value; }
		public string Chinese { get => this[LanguageCode.Chinese]; set => this[LanguageCode.Chinese] = value; }
		public string German { get => this[LanguageCode.German]; set => this[LanguageCode.German] = value; }
		public string Brazilian { get => this[LanguageCode.Brazilian]; set => this[LanguageCode.Brazilian] = value; }
		public string French { get => this[LanguageCode.French]; set => this[LanguageCode.French] = value; }
		public string Russian { get => this[LanguageCode.Russian]; set => this[LanguageCode.Russian] = value; }
		public string Korean { get => this[LanguageCode.Korean]; set => this[LanguageCode.Korean] = value; }

		private Dictionary<LanguageCode, string> translations;
		public Dictionary<LanguageCode, string> Translations => translations ?? (translations = new Dictionary<LanguageCode, string>(1));
		public string this[LanguageCode language]
		{
			get => translations.TryGetValue(language, out string str) ? str : null;
			set
			{
				if (value != null) Translations[language] = value;
				else translations?.Remove(language);
			}
		}

		public IEnumerator<KeyValuePair<LanguageCode, string>> GetEnumerator()
			=> (translations ?? Enumerable.Empty<KeyValuePair<LanguageCode, string>>()).GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
	public enum LanguageCode
	{
		English   = 0,
		Spanish   = 1,
		Chinese   = 2,
		German    = 3,
		Brazilian = 4,
		French    = 5,
		Russian   = 6,
		Korean    = 7,
	}
	public static class LanguageService
	{
		public static NameDB NameDB { get; internal set; }
		public static LanguageCode Current { get; internal set; }
		public static LanguageCode FallBack { get; internal set; }
	}
	public interface INameProvider
	{
		void GetName(string name, string type, ref string result);
	}
	public class CustomNameProvider : INameProvider
	{
		public readonly Dictionary<string, Dictionary<string, CustomName>> CustomNames = new Dictionary<string, Dictionary<string, CustomName>>();

		public void GetName(string name, string type, ref string result)
		{
			if (name != null && type != null
				&& CustomNames.TryGetValue(type, out Dictionary<string, CustomName> category)
				&& category.TryGetValue(name, out CustomName customName))
				result = customName[LanguageService.Current] ?? customName[LanguageService.FallBack];
		}
		public CustomName AddName(string name, string type, CustomNameInfo info)
		{
			CustomName customName = new CustomName(name, type, info);
			if (!CustomNames.TryGetValue(type, out Dictionary<string, CustomName> category))
				CustomNames.Add(type, category = new Dictionary<string, CustomName>());
			category.Add(name, customName);
			return customName;
		}
	}
	public class DialogueNameProvider : INameProvider
	{
		public void GetName(string name, string type, ref string result)
		{
			if (result is null && type == "Dialogue" && name.StartsWith("NA_"))
			{
				string sub = name.Substring("NA_".Length);
				string newResult = LanguageService.NameDB.GetName(sub, type);
				if (!newResult.StartsWith("E_")) result = newResult;
			}
		}
	}
}
