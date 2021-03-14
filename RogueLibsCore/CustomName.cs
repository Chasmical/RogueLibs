using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Base interface for a custom name entry.</para>
	/// </summary>
	public interface ICustomName
	{
		/// <summary>
		///   <para>Gets/sets the specified <paramref name="language"/>'s translation of the entry.</para>
		/// </summary>
		/// <param name="language">Language, whose translation of the entry is to be get/set.</param>
		/// <returns><paramref name="language"/>'s translation of the entry, if found; otherwise, <see langword="null"/>.</returns>
		string this[LanguageCode language] { get; set; }
	}
	/// <summary>
	///   <para>Primary custom name entry class.</para>
	/// </summary>
	public class CustomName : ICustomName, IEnumerable<KeyValuePair<LanguageCode, string>>
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

		/// <summary>
		///   <para>Name/id of the entry.</para>
		/// </summary>
		public string Name { get; }
		/// <summary>
		///   <para>Type of the entry.</para>
		/// </summary>
		public string Type { get; }

		/// <summary>
		///   <para>Gets/sets the english translation of the entry.</para>
		/// </summary>
		public string English { get => this[LanguageCode.English]; set => this[LanguageCode.English] = value; }
		/// <summary>
		///   <para>Gets/sets the spanish translation of the entry.</para>
		/// </summary>
		public string Spanish { get => this[LanguageCode.Spanish]; set => this[LanguageCode.Spanish] = value; }
		/// <summary>
		///   <para>Gets/sets the chinese translation of the entry.</para>
		/// </summary>
		public string Chinese { get => this[LanguageCode.Chinese]; set => this[LanguageCode.Chinese] = value; }
		/// <summary>
		///   <para>Gets/sets the german translation of the entry.</para>
		/// </summary>
		public string German { get => this[LanguageCode.German]; set => this[LanguageCode.German] = value; }
		/// <summary>
		///   <para>Gets/sets the brazilian translation of the entry.</para>
		/// </summary>
		public string Brazilian { get => this[LanguageCode.Brazilian]; set => this[LanguageCode.Brazilian] = value; }
		/// <summary>
		///   <para>Gets/sets the french translation of the entry.</para>
		/// </summary>
		public string French { get => this[LanguageCode.French]; set => this[LanguageCode.French] = value; }
		/// <summary>
		///   <para>Gets/sets the russian translation of the entry.</para>
		/// </summary>
		public string Russian { get => this[LanguageCode.Russian]; set => this[LanguageCode.Russian] = value; }
		/// <summary>
		///   <para>Gets/sets the korean translation of the entry.</para>
		/// </summary>
		public string Korean { get => this[LanguageCode.Korean]; set => this[LanguageCode.Korean] = value; }

		private readonly Dictionary<LanguageCode, string> translations = new Dictionary<LanguageCode, string>(1);
		/// <summary>
		///   <para>Gets the internal translations dictionary.</para>
		/// </summary>
		public ReadOnlyDictionary<LanguageCode, string> Translations { get; }
		/// <summary>
		///   <para>Gets/sets the specified <paramref name="language"/>'s translation of the entry.</para>
		/// </summary>
		/// <param name="language">Language, whose translation is to be get/set.</param>
		/// <returns><paramref name="language"/>'s translation of the entry, if found; otherwise, <see langword="null"/>.</returns>
		public string this[LanguageCode language]
		{
			get => translations.TryGetValue(language, out string str) ? str : null;
			set
			{
				if (!(value is null)) translations[language] = value;
				else translations.Remove(language);
			}
		}

		/// <summary>
		///   <para>Gets the default enumerator for the current entry.</para>
		/// </summary>
		/// <returns>Enumerator that itereates through the entry.</returns>
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
			["koreana"] = LanguageCode.Korean
		};
		/// <summary>
		///   <para>Dictionary of registered <see cref="LanguageCode"/>s.</para>
		/// </summary>
		public static ReadOnlyDictionary<string, LanguageCode> Languages { get; }
		/// <summary>
		///   <para>Registers the specified <paramref name="languageId"/> with the specified <paramref name="code"/>.</para>
		/// </summary>
		/// <param name="languageId">Language string id, that is used by the game.</param>
		/// <param name="code"><see cref="LanguageCode"/> associated with the specified <paramref name="languageId"/> id.</param>
		/// <exception cref="ArgumentNullException"><paramref name="languageId"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="languageId"/> is already taken. See Debug-level logs for more info.</exception>
		public static void RegisterLanguageCode(string languageId, LanguageCode code)
		{
			if (languageId is null) throw new ArgumentNullException(nameof(languageId));
			if (languages.ContainsKey(languageId)) throw new ArgumentException($"The specified {nameof(languageId)} is already taken.", nameof(languageId));
			RogueLibsInternals.Logger.LogDebug($"Registered \"{languageId}\" language id ({(int)code})");
			languages.Add(languageId, code);
		}
	}
	/// <summary>
	///   <para>Secondary custom name entry class. Mostly used to transfer translations data between methods.</para>
	/// </summary>
	public struct CustomNameInfo : ICustomName, IEnumerable<KeyValuePair<LanguageCode, string>>
	{
		/// <summary>
		///   <para>Initializes a new instance of <see cref="CustomNameInfo"/> with the specified <paramref name="english"/> translation.</para>
		/// </summary>
		/// <param name="english">English translation of the entry.</param>
		/// <exception cref="ArgumentNullException"><paramref name="english"/> is <see langword="null"/>.</exception>
		public CustomNameInfo(string english)
		{
			if (english is null) throw new ArgumentNullException(nameof(english));
			translations = new Dictionary<LanguageCode, string>(1) { [LanguageCode.English] = english };
		}
		/// <summary>
		///   <para>Initializes a new instance of <see cref="CustomNameInfo"/> with translations from the specified <paramref name="dictionary"/>.</para>
		/// </summary>
		/// <param name="dictionary">Collection of language and translation pairs.</param>
		public CustomNameInfo(IEnumerable<KeyValuePair<LanguageCode, string>> dictionary)
		{
			if (dictionary is null) throw new ArgumentNullException(nameof(dictionary));
			translations = new Dictionary<LanguageCode, string>(dictionary.Count());
			foreach (KeyValuePair<LanguageCode, string> pair in dictionary)
				if (!(pair.Value is null))
					translations[pair.Key] = pair.Value;
		}

		/// <summary>
		///   <para>Gets/sets the english translation of the entry.</para>
		/// </summary>
		public string English { get => this[LanguageCode.English]; set => this[LanguageCode.English] = value; }
		/// <summary>
		///   <para>Gets/sets the spanish translation of the entry.</para>
		/// </summary>
		public string Spanish { get => this[LanguageCode.Spanish]; set => this[LanguageCode.Spanish] = value; }
		/// <summary>
		///   <para>Gets/sets the chinese translation of the entry.</para>
		/// </summary>
		public string Chinese { get => this[LanguageCode.Chinese]; set => this[LanguageCode.Chinese] = value; }
		/// <summary>
		///   <para>Gets/sets the german translation of the entry.</para>
		/// </summary>
		public string German { get => this[LanguageCode.German]; set => this[LanguageCode.German] = value; }
		/// <summary>
		///   <para>Gets/sets the brazilian translation of the entry.</para>
		/// </summary>
		public string Brazilian { get => this[LanguageCode.Brazilian]; set => this[LanguageCode.Brazilian] = value; }
		/// <summary>
		///   <para>Gets/sets the french translation of the entry.</para>
		/// </summary>
		public string French { get => this[LanguageCode.French]; set => this[LanguageCode.French] = value; }
		/// <summary>
		///   <para>Gets/sets the russian translation of the entry.</para>
		/// </summary>
		public string Russian { get => this[LanguageCode.Russian]; set => this[LanguageCode.Russian] = value; }
		/// <summary>
		///   <para>Gets/sets the korean translation of the entry.</para>
		/// </summary>
		public string Korean { get => this[LanguageCode.Korean]; set => this[LanguageCode.Korean] = value; }

		private Dictionary<LanguageCode, string> translations;
		/// <summary>
		///   <para>Gets the internal translations dictionary.</para>
		/// </summary>
		public Dictionary<LanguageCode, string> Translations => translations ?? (translations = new Dictionary<LanguageCode, string>(1));
		/// <summary>
		///   <para>Gets/sets the specified <paramref name="language"/>'s translation of the entry.</para>
		/// </summary>
		/// <param name="language">Language, whose translation is to be get/set.</param>
		/// <returns><paramref name="language"/>'s translation of the entry, if found; otherwise, <see langword="null"/>.</returns>
		public string this[LanguageCode language]
		{
			get => translations.TryGetValue(language, out string str) ? str : null;
			set
			{
				if (value != null) Translations[language] = value;
				else translations?.Remove(language);
			}
		}

		/// <summary>
		///   <para>Gets the default enumerator for the entry.</para>
		/// </summary>
		/// <returns>Enumerator that itereates through the entry.</returns>
		public IEnumerator<KeyValuePair<LanguageCode, string>> GetEnumerator()
			=> (translations ?? Enumerable.Empty<KeyValuePair<LanguageCode, string>>()).GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
	/// <summary>
	///   <para>Represents a language.</para>
	/// </summary>
	public enum LanguageCode
	{
		/// <summary>
		///   <para>English <see cref="LanguageCode"/>.</para>
		/// </summary>
		English   = 0,
		/// <summary>
		///   <para>Spanish <see cref="LanguageCode"/>.</para>
		/// </summary>
		Spanish   = 1,
		/// <summary>
		///   <para>Chinese <see cref="LanguageCode"/>.</para>
		/// </summary>
		Chinese   = 2,
		/// <summary>
		///   <para>German <see cref="LanguageCode"/>.</para>
		/// </summary>
		German    = 3,
		/// <summary>
		///   <para>Brazilian <see cref="LanguageCode"/>.</para>
		/// </summary>
		Brazilian = 4,
		/// <summary>
		///   <para>French <see cref="LanguageCode"/>.</para>
		/// </summary>
		French    = 5,
		/// <summary>
		///   <para>Russian <see cref="LanguageCode"/>.</para>
		/// </summary>
		Russian   = 6,
		/// <summary>
		///   <para>Korean <see cref="LanguageCode"/>.</para>
		/// </summary>
		Korean    = 7
	}
}
