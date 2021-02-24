using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RogueLibsCore
{
	public interface ICustomName
	{
		string this[LanguageCode code] { get; set; }
	}
	public class CustomName : ICustomName
	{
		static CustomName() => Languages = new ReadOnlyDictionary<string, LanguageCode>(languages);
		internal CustomName(string name, string type, string english)
		{
			Name = name;
			Type = type;
			English = english;
		}
		internal CustomName(string name, string type, IEnumerable<KeyValuePair<LanguageCode, string>> dictionary)
		{
			Name = name;
			Type = type;
			foreach (KeyValuePair<LanguageCode, string> pair in dictionary)
				translations[pair.Key] = pair.Value;
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

		public readonly Dictionary<LanguageCode, string> translations = new Dictionary<LanguageCode, string>(1);
		public string this[LanguageCode code]
		{
			get => translations.TryGetValue(code, out string str) ? str : null;
			set
			{
				if (value != null) translations[code] = value;
				else translations.Remove(code);
			}
		}

		private static readonly Dictionary<string, LanguageCode> languages = new Dictionary<string, LanguageCode>();
		public static ReadOnlyDictionary<string, LanguageCode> Languages { get; }
		public static void RegisterLanguageCode(string language, LanguageCode code) => languages.Add(language, code);
	}
	public struct CustomNameInfo : IEnumerable<KeyValuePair<LanguageCode, string>>
	{
		public CustomNameInfo(string english)
		{
			translations = new Dictionary<LanguageCode, string>(1);
			English = english;
		}
		public CustomNameInfo(IEnumerable<KeyValuePair<LanguageCode, string>> dictionary)
		{
			translations = new Dictionary<LanguageCode, string>(dictionary.Count());
			foreach (KeyValuePair<LanguageCode, string> pair in dictionary)
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
		public string this[LanguageCode code]
		{
			get => translations.TryGetValue(code, out string str) ? str : null;
			set
			{
				if (value != null) Translations[code] = value;
				else translations?.Remove(code);
			}
		}

		public IEnumerator<KeyValuePair<LanguageCode, string>> GetEnumerator() => Translations.GetEnumerator();
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
		Korean    = 7
	}
}
