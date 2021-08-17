using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Provides static methods and properties for localization and translation.</para>
	/// </summary>
	public static class LanguageService
	{
		/// <summary>
		///   <para>Gets the currently used instance of <see cref="global::NameDB"/>.</para>
		/// </summary>
		public static NameDB NameDB { get; internal set; }
		internal static LanguageCode current;
		/// <summary>
		///   <para>Gets the currently selected language.</para>
		/// </summary>
		public static LanguageCode Current
		{
			get => current;
			set
			{
				if (current == value) return;
				LanguageCode prev = current;
				current = value;
				OnCurrentChanged?.Invoke(new OnLanguageChangedArgs(prev, value));
			}
		}
		internal static LanguageCode fallBack;
		/// <summary>
		///   <para>Gets or sets the fall-back language that will be used, when the current language's localization string is not found. Default: <see cref="LanguageCode.English"/>.</para>
		/// </summary>
		public static LanguageCode FallBack
		{
			get => fallBack;
			set
			{
				if (fallBack == value) return;
				LanguageCode prev = current;
				fallBack = value;
				OnFallBackChanged?.Invoke(new OnLanguageChangedArgs(prev, value));
			}
		}
		public static event Action<OnLanguageChangedArgs> OnCurrentChanged;
		public static event Action<OnLanguageChangedArgs> OnFallBackChanged;

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
		private static readonly Dictionary<LanguageCode, string> languageNames = languages.ToDictionary(p => p.Value, p => p.Key);
		/// <summary>
		///   <para>Returns a read-only dictionary of languages currently existing in the game.</para>
		/// </summary>
		public static ReadOnlyDictionary<string, LanguageCode> Languages { get; } = new ReadOnlyDictionary<string, LanguageCode>(languages);

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
}
