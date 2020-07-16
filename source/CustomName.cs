
namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom in-game string with localizations.</para>
	/// </summary>
	public class CustomName
	{
		/// <summary>
		///   <para>Id of this <see cref="CustomName"/>.</para>
		/// </summary>
		public string Id { get; }
		/// <summary>
		///   <para>Type of this <see cref="CustomName"/>. Use <see langword="null"/>, if you don't know which one you need.</para>
		///   <para>Default types are: Agent, Item, Object, StatusEffect, Interface, Dialogue, Description, Unlock.</para>
		/// </summary>
		public string Type { get; }
		/// <summary>
		///   <para>An array of translation strings for this <see cref="CustomName"/>.</para>
		/// </summary>
		public string[] Translations { get; set; }

		internal CustomName(string id, string type)
		{
			Id = id;
			Type = type;
			Translations = new string[8];
		}

		/// <summary>
		///   <para>Uses the given <paramref name="customNameInfo"/> to get localization strings.</para>
		/// </summary>
		public void SetTranslations(CustomNameInfo customNameInfo)
		{
			Translations[0] = customNameInfo.English;
			Translations[1] = customNameInfo.SChinese;
			Translations[2] = customNameInfo.German;
			Translations[3] = customNameInfo.Spanish;
			Translations[4] = customNameInfo.Brazilian;
			Translations[5] = customNameInfo.Russian;
			Translations[6] = customNameInfo.French;
			Translations[7] = customNameInfo.KoreanA;
		}

		/// <summary>
		///   <para>Gets and sets the English string. If the <see langword="value"/> is <see langword="null"/>, doesn't change it.</para>
		/// </summary>
		public string English { get => Translations[0]; set => Translations[0] = value ?? Translations[0]; }
		/// <summary>
		///   <para>Gets and sets the Simplified Chinese string. If the <see langword="value"/> is <see langword="null"/>, doesn't change it.</para>
		/// </summary>
		public string SChinese { get => Translations[1]; set => Translations[1] = value ?? Translations[1]; }
		/// <summary>
		///   <para>Gets and sets the German string. If the <see langword="value"/> is <see langword="null"/>, doesn't change it.</para>
		/// </summary>
		public string German { get => Translations[2]; set => Translations[2] = value ?? Translations[2]; }
		/// <summary>
		///   <para>Gets and sets the Spanish string. If the <see langword="value"/> is <see langword="null"/>, doesn't change it.</para>
		/// </summary>
		public string Spanish { get => Translations[3]; set => Translations[3] = value ?? Translations[3]; }
		/// <summary>
		///   <para>Gets and sets the Brazilian string. If the <see langword="value"/> is <see langword="null"/>, doesn't change it.</para>
		/// </summary>
		public string Brazilian { get => Translations[4]; set => Translations[4] = value ?? Translations[4]; }
		/// <summary>
		///   <para>Gets and sets the Russian string. If the <see langword="value"/> is <see langword="null"/>, doesn't change it.</para>
		/// </summary>
		public string Russian { get => Translations[5]; set => Translations[5] = value ?? Translations[5]; }
		/// <summary>
		///   <para>Gets and sets the French string. If the <see langword="value"/> is <see langword="null"/>, doesn't change it.</para>
		/// </summary>
		public string French { get => Translations[6]; set => Translations[6] = value ?? Translations[6]; }
		/// <summary>
		///   <para>Gets and sets the Korean (A?) string. If the <see langword="value"/> is <see langword="null"/>, doesn't change it.</para>
		/// </summary>
		public string KoreanA { get => Translations[7]; set => Translations[7] = value ?? Translations[7]; }
	}

	/// <summary>
	///   <para>Helper struct for creating <see cref="CustomName"/>.</para>
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
	}
}
