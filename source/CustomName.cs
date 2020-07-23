using System;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom localizable in-game string.</para>
	/// </summary>
	public class CustomName
	{
		/// <summary>
		///   <para>Id of this <see cref="CustomName"/>.</para>
		/// </summary>
		public string Id { get; }
		/// <summary>
		///   <para>Type of this <see cref="CustomName"/>.</para>
		/// </summary>
		public string Type { get; }

		public bool OverrideOriginal { get; set; }

		/// <summary>
		///   <para>Array of localization strings.</para>
		/// </summary>
		public string[] Translations { get; set; }

		internal CustomName(string id, string type, CustomNameInfo info)
		{
			Id = id;
			Type = type;
			Translations = info.ToArray();
		}

		/// <summary>
		///   <para>Gets/sets the English localization string.</para>
		/// </summary>
		public string English { get => Translations[0]; set => Translations[0] = value; }
		/// <summary>
		///   <para>Gets/sets the Simplified Chinese localization string.</para>
		/// </summary>
		public string SChinese { get => Translations[1]; set => Translations[1] = value; }
		/// <summary>
		///   <para>Gets/sets the German localization string.</para>
		/// </summary>
		public string German { get => Translations[2]; set => Translations[2] = value; }
		/// <summary>
		///   <para>Gets/sets the Spanish localization string.</para>
		/// </summary>
		public string Spanish { get => Translations[3]; set => Translations[3] = value; }
		/// <summary>
		///   <para>Gets/sets the Brazilian localization string.</para>
		/// </summary>
		public string Brazilian { get => Translations[4]; set => Translations[4] = value; }
		/// <summary>
		///   <para>Gets/sets the Russian localization string.</para>
		/// </summary>
		public string Russian { get => Translations[5]; set => Translations[5] = value; }
		/// <summary>
		///   <para>Gets/sets the French localization string.</para>
		/// </summary>
		public string French { get => Translations[6]; set => Translations[6] = value; }
		/// <summary>
		///   <para>Gets/sets the Korean (A?) localization string.</para>
		/// </summary>
		public string KoreanA { get => Translations[7]; set => Translations[7] = value; }

	}

	/// <summary>
	///   <para>Helper struct for creating <see cref="CustomName"/>s.</para>
	/// </summary>
	public struct CustomNameInfo
	{
		/// <summary>
		///   <para>Localization string for this language.</para>
		/// </summary>
		public string English, SChinese, German, Spanish, Brazilian, Russian, French, KoreanA;

		/// <summary>
		///   <para>Initializes a new instance of <see cref="CustomNameInfo"/> with the specified <paramref name="english"/> string.</para>
		/// </summary>
		public CustomNameInfo(string english)
		{
			English = english;
			SChinese = German = Spanish = Brazilian = Russian = French = KoreanA = null;
		}
		/// <summary>
		///   <para>Initializes a new instance of <see cref="CustomNameInfo"/> with the specified language strings.</para>
		/// </summary>
		public CustomNameInfo(string english, string schinese = null, string german = null, string spanish = null, string brazilian = null, string russian = null, string french = null, string koreana = null)
		{
			English = english;
			SChinese = schinese;
			German = german;
			Spanish = spanish;
			Brazilian = brazilian;
			Russian = russian;
			French = french;
			KoreanA = koreana;
		}

		/// <summary>
		///   <para>Returns an array of localization strings from this <see cref="CustomNameInfo"/>.</para>
		/// </summary>
		public string[] ToArray() => new string[8] { English, SChinese, German, Spanish, Brazilian, Russian, French, KoreanA };

	}
}
