using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a localizable string.</para>
	/// </summary>
	public interface IName : IEnumerable<KeyValuePair<LanguageCode, string>>
	{
		/// <summary>
		///   <para>Gets or sets the specified <paramref name="language"/>'s localization text.</para>
		/// </summary>
		/// <param name="language">The language to get or set the localization text for.</param>
		/// <returns>The specified <paramref name="language"/>'s localization text, if found; otherwise, <see langword="null"/>.</returns>
		string this[LanguageCode language] { get; set; }
	}
	/// <summary>
	///   <para>The implementation of the <see cref="IName"/> interface, used by the <see cref="CustomNameProvider"/>. Provides properties for getting and setting the 8 default languages' localization texts.</para>
	/// </summary>
	public class CustomName : IName
	{
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
				if (!(pair.Value is null))
					translations[pair.Key] = pair.Value;
		}

		/// <summary>
		///   <para>Gets the localizable string's name.</para>
		/// </summary>
		public string Name { get; }
		/// <summary>
		///   <para>Gets the localizable string's type.</para>
		/// </summary>
		public string Type { get; }

		/// <summary>
		///   <para>Gets or sets the English localization text.</para>
		/// </summary>
		public string English { get => this[LanguageCode.English]; set => this[LanguageCode.English] = value; }
		/// <summary>
		///   <para>Gets or sets the Spanish localization text.</para>
		/// </summary>
		public string Spanish { get => this[LanguageCode.Spanish]; set => this[LanguageCode.Spanish] = value; }
		/// <summary>
		///   <para>Gets or sets the Chinese localization text.</para>
		/// </summary>
		public string Chinese { get => this[LanguageCode.Chinese]; set => this[LanguageCode.Chinese] = value; }
		/// <summary>
		///   <para>Gets or sets the German localization text.</para>
		/// </summary>
		public string German { get => this[LanguageCode.German]; set => this[LanguageCode.German] = value; }
		/// <summary>
		///   <para>Gets or sets the Brazilian localization text.</para>
		/// </summary>
		public string Brazilian { get => this[LanguageCode.Brazilian]; set => this[LanguageCode.Brazilian] = value; }
		/// <summary>
		///   <para>Gets or sets the French localization text.</para>
		/// </summary>
		public string French { get => this[LanguageCode.French]; set => this[LanguageCode.French] = value; }
		/// <summary>
		///   <para>Gets or sets the Russian localization text.</para>
		/// </summary>
		public string Russian { get => this[LanguageCode.Russian]; set => this[LanguageCode.Russian] = value; }
		/// <summary>
		///   <para>Gets or sets the Korean localization text.</para>
		/// </summary>
		public string Korean { get => this[LanguageCode.Korean]; set => this[LanguageCode.Korean] = value; }

		private readonly Dictionary<LanguageCode, string> translations = new Dictionary<LanguageCode, string>(1);
		/// <inheritdoc/>
		public string this[LanguageCode language]
		{
			get => translations.TryGetValue(language, out string str) ? str : null;
			set
			{
				if (!(value is null)) translations[language] = value;
				else translations.Remove(language);
			}
		}

		/// <inheritdoc/>
		public IEnumerator<KeyValuePair<LanguageCode, string>> GetEnumerator() => translations.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
	/// <summary>
	///   <para>The <see langword="struct"/> implementation of the <see cref="IName"/> interface. Provides properties for getting and setting the 8 default languages' localization texts.</para>
	/// </summary>
	public struct CustomNameInfo : IName
	{
		/// <summary>
		///   <para>Initializes a new instance of <see cref="CustomNameInfo"/> structure with the specified <paramref name="english"/> localization text.</para>
		/// </summary>
		/// <param name="english">The English localization text.</param>
		public CustomNameInfo(string english)
		{
			if (english is null) throw new ArgumentNullException(nameof(english));
			_texts = new Dictionary<LanguageCode, string>(1) { [LanguageCode.English] = english };
		}
		/// <summary>
		///   <para>Initializes a new instance of <see cref="CustomNameInfo"/> structure with localization texts from the specified <paramref name="dictionary"/>.</para>
		/// </summary>
		/// <param name="dictionary">The dictionary with localization texts.</param>
		public CustomNameInfo(IEnumerable<KeyValuePair<LanguageCode, string>> dictionary)
		{
			if (dictionary is null) throw new ArgumentNullException(nameof(dictionary));
			_texts = new Dictionary<LanguageCode, string>(dictionary.Count());
			foreach (KeyValuePair<LanguageCode, string> pair in dictionary)
				if (pair.Value != null)
					_texts[pair.Key] = pair.Value;
		}

		/// <summary>
		///   <para>Gets or sets the English localization text.</para>
		/// </summary>
		public string English { get => this[LanguageCode.English]; set => this[LanguageCode.English] = value; }
		/// <summary>
		///   <para>Gets or sets the Spanish localization text.</para>
		/// </summary>
		public string Spanish { get => this[LanguageCode.Spanish]; set => this[LanguageCode.Spanish] = value; }
		/// <summary>
		///   <para>Gets or sets the Chinese localization text.</para>
		/// </summary>
		public string Chinese { get => this[LanguageCode.Chinese]; set => this[LanguageCode.Chinese] = value; }
		/// <summary>
		///   <para>Gets or sets the German localization text.</para>
		/// </summary>
		public string German { get => this[LanguageCode.German]; set => this[LanguageCode.German] = value; }
		/// <summary>
		///   <para>Gets or sets the Brazilian localization text.</para>
		/// </summary>
		public string Brazilian { get => this[LanguageCode.Brazilian]; set => this[LanguageCode.Brazilian] = value; }
		/// <summary>
		///   <para>Gets or sets the French localization text.</para>
		/// </summary>
		public string French { get => this[LanguageCode.French]; set => this[LanguageCode.French] = value; }
		/// <summary>
		///   <para>Gets or sets the Russian localization text.</para>
		/// </summary>
		public string Russian { get => this[LanguageCode.Russian]; set => this[LanguageCode.Russian] = value; }
		/// <summary>
		///   <para>Gets or sets the Korean localization text.</para>
		/// </summary>
		public string Korean { get => this[LanguageCode.Korean]; set => this[LanguageCode.Korean] = value; }

		private Dictionary<LanguageCode, string> _texts;
		private Dictionary<LanguageCode, string> Texts => _texts ?? (_texts = new Dictionary<LanguageCode, string>(1));
		/// <inheritdoc/>
		public string this[LanguageCode language]
		{
			get => _texts.TryGetValue(language, out string str) ? str : null;
			set
			{
				if (value != null) Texts[language] = value;
				else _texts?.Remove(language);
			}
		}

		/// <inheritdoc/>
		public IEnumerator<KeyValuePair<LanguageCode, string>> GetEnumerator()
			=> (_texts ?? Enumerable.Empty<KeyValuePair<LanguageCode, string>>()).GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
	/// <summary>
	///   <para>Represents a language in the game.</para>
	/// </summary>
	public enum LanguageCode
	{
		/// <summary>
		///   <para>The English language.</para>
		/// </summary>
		English   = 0,
		/// <summary>
		///   <para>The Spanish language.</para>
		/// </summary>
		Spanish   = 1,
		/// <summary>
		///   <para>The Chinese language.</para>
		/// </summary>
		Chinese   = 2,
		/// <summary>
		///   <para>The German language.</para>
		/// </summary>
		German    = 3,
		/// <summary>
		///   <para>The Brazilian language.</para>
		/// </summary>
		Brazilian = 4,
		/// <summary>
		///   <para>The French language.</para>
		/// </summary>
		French    = 5,
		/// <summary>
		///   <para>The Russian language.</para>
		/// </summary>
		Russian   = 6,
		/// <summary>
		///   <para>The Korean language.</para>
		/// </summary>
		Korean    = 7,
	}
	/// <summary>
	///   <para>Provides static methods and properties for localization and translation.</para>
	/// </summary>
	public static class LanguageService
	{
		static LanguageService()
		{
			Languages = new ReadOnlyDictionary<string, LanguageCode>(languages);
			languageNames = languages.ToDictionary(e => e.Value, e => e.Key);
		}
		/// <summary>
		///   <para>Gets the currently used instance of <see cref="global::NameDB"/>.</para>
		/// </summary>
		public static NameDB NameDB { get; internal set; }
		/// <summary>
		///   <para>Gets the currently selected language.</para>
		/// </summary>
		public static LanguageCode Current { get; internal set; }
		/// <summary>
		///   <para>Gets or sets the fall-back language that will be used, when the current language's localization string is not found. Default: <see cref="LanguageCode.English"/>.</para>
		/// </summary>
		public static LanguageCode FallBack { get; set; }

		private static readonly Dictionary<string, LanguageCode> languages = new Dictionary<string, LanguageCode>
		{
			["english"]   = LanguageCode.English,
			["spanish"]   = LanguageCode.Spanish,
			["schinese"]  = LanguageCode.Chinese,
			["german"]    = LanguageCode.German,
			["brazilian"] = LanguageCode.Brazilian,
			["french"]    = LanguageCode.French,
			["russian"]   = LanguageCode.Russian,
			["koreana"]   = LanguageCode.Korean,
		};
		private static readonly Dictionary<LanguageCode, string> languageNames;
		/// <summary>
		///   <para>Returns a read-only dictionary of languages currently existing in the game.</para>
		/// </summary>
		public static ReadOnlyDictionary<string, LanguageCode> Languages { get; }

		/// <summary>
		///   <para>Returns the language <paramref name="code"/>'s name.</para>
		/// </summary>
		/// <param name="code">The language code to get a name for.</param>
		/// <returns>The specified language <paramref name="code"/>'s name, if found; otherwise, <see langword="null"/>.</returns>
		public static string GetLanguageName(LanguageCode code)
			=> languageNames.TryGetValue(code, out string name) ? name : null;
		/// <summary>
		///   <para>Adds the specified <paramref name="languageName"/> to the game, and sets its language <paramref name="code"/>.</para>
		/// </summary>
		/// <param name="languageName">The language name to add into the game.</param>
		/// <param name="code">The language code that will be used to represent the language.</param>
		public static void RegisterLanguageCode(string languageName, LanguageCode code)
		{
			if (languageName is null) throw new ArgumentNullException(nameof(languageName));
			if (languages.ContainsKey(languageName))
				throw new ArgumentException($"The specified {nameof(languageName)} is already taken.", nameof(languageName));

			if (RogueFramework.IsDebugEnabled(DebugFlags.Names))
				RogueFramework.Logger.LogDebug($"Registered \"{languageName}\" language ({(int)code})");

			languages.Add(languageName, code);
			languageNames.Add(code, languageName);
		}

		/// <summary>
		///   <para>Gets the localization text for the current language.</para>
		/// </summary>
		/// <param name="name">The current localizable string instance.</param>
		/// <returns>The current language's localization string, if found; otherwise, <see langword="null"/>.</returns>
		public static string GetCurrent(this IName name) => name[Current];
		/// <summary>
		///   <para>Gets the localization text for the current language, or the fall-back language, if the current language's localization text is not found.</para>
		/// </summary>
		/// <param name="name">The current localizable string instance.</param>
		/// <returns>The current language's localization string, if found; otherwise, the fall-back language's localization string, if found; otherwise, <see langword="null"/>.</returns>
		public static string GetCurrentOrDefault(this IName name) => name[Current] ?? name[FallBack];
	}
	/// <summary>
	///   <para>Represents a localization text provider.</para>
	/// </summary>
	public interface INameProvider
	{
		/// <summary>
		///   <para>Tries to get the localization text for the specified <paramref name="name"/> and <paramref name="type"/>.</para>
		/// </summary>
		/// <param name="name">The name of the entry.</param>
		/// <param name="type">The type of the entry.</param>
		/// <param name="result">The localization text, or <see langword="null"/>, if a valid localization text could not be found.</param>
		void GetName(string name, string type, ref string result);
	}
	/// <summary>
	///   <para>The default implementation of the <see cref="INameProvider"/> interface that uses instances of the <see cref="CustomName"/> class.</para>
	/// </summary>
	public sealed class CustomNameProvider : INameProvider
	{
		/// <summary>
		///   <para>The <see cref="CustomName"/> dictionary used by the provider, organized by type and name.</para>
		/// </summary>
		public readonly Dictionary<string, Dictionary<string, CustomName>> CustomNames = new Dictionary<string, Dictionary<string, CustomName>>();

		/// <inheritdoc/>
		public void GetName(string name, string type, ref string result)
		{
			if (name != null && type != null
				&& CustomNames.TryGetValue(type, out Dictionary<string, CustomName> category)
				&& category.TryGetValue(name, out CustomName customName))
				result = customName.GetCurrentOrDefault();
		}
		/// <summary>
		///   <para>Adds a <see cref="CustomName"/> with the specified <paramref name="name"/>, <paramref name="type"/> and localization <paramref name="info"/>.</para>
		/// </summary>
		/// <param name="name">The name of the <see cref="CustomName"/> to create.</param>
		/// <param name="type">The type of the <see cref="CustomName"/> to create.</param>
		/// <param name="info">The localization data to initialize <see cref="CustomName"/> with.</param>
		/// <returns>The initialized <see cref="CustomName"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="type"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">A localizable string with the specified <paramref name="name"/> and <paramref name="type"/> already exists in the provider's dictionary.</exception>
		public CustomName AddName(string name, string type, CustomNameInfo info)
		{
			if (name is null || type is null)
				throw new ArgumentNullException(name is null ? nameof(name) : nameof(type));
			if (RogueFramework.IsDebugEnabled(DebugFlags.Names))
				RogueFramework.LogDebug($"Added \"{name}\" name ({type}): {info.GetCurrentOrDefault()}");

			CustomName customName = new CustomName(name, type, info);
			if (!CustomNames.TryGetValue(type, out Dictionary<string, CustomName> category))
				CustomNames.Add(type, category = new Dictionary<string, CustomName>());
			category.Add(name, customName);
			return customName;
		}
	}
	/// <summary>
	///   <para>The implementation of the <see cref="INameProvider"/> interface that resolves dialogue names with "NA_" prefix (No Agent).</para>
	/// </summary>
	public sealed class DialogueNameProvider : INameProvider
	{
		/// <inheritdoc/>
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
