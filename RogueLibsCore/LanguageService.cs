using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Net;
using BepInEx;

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
		private static LanguageCode current;
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
		private static LanguageCode fallBack;
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
	public class OnLanguageChangedArgs : EventArgs
	{
		public OnLanguageChangedArgs(LanguageCode prev, LanguageCode value)
		{
			PreviousValue = prev;
			Value = value;
		}
		public LanguageCode PreviousValue { get; }
		public LanguageCode Value { get; }
	}
	public static class Localization
	{
		private static int init;
		public static void Init()
		{
			if (Interlocked.Exchange(ref init, 1) == 1) return;
			localePath = Path.Combine(Paths.BepInExRootPath, "locale");
			Directory.CreateDirectory(localePath);

			if (PermitDownload() && DownloadIndex())
				UpdateVanillaLanguages();

			InitializeLanguages();
		}

		private static bool PermitDownload()
		{
			string lastAccessFile = Path.Combine(localePath, ".lastaccess");
			if (!File.Exists(lastAccessFile)) return true;
			try
			{
				string text = File.ReadAllText(lastAccessFile);
				DateTime lastAccess = DateTime.Parse(text);
				return DateTime.Now - lastAccess > new TimeSpan(1, 0, 0);
			}
			catch
			{
				RogueFramework.LogError("Could not read the locale/.lastaccess file.");
				return true;
			}
		}
		private static LanguageVersions Versions;
		private static bool DownloadIndex()
		{
			const string url = "https://raw.githubusercontent.com/Abbysssal/RogueLibs/main/RogueLibsCore/Resources/locale.index.xml";
			string downloadPath = Path.Combine(localePath, ".vanilla.index.xml");
			try
			{
				WebClient web = new WebClient();
				web.DownloadFile(url, downloadPath);

				XmlSerializer ser = new XmlSerializer(typeof(LanguageVersions));
				using (FileStream stream = new FileStream(downloadPath, FileMode.Open, FileAccess.Read, FileShare.Read))
				using (XmlReader reader = XmlReader.Create(stream))
					Versions = (LanguageVersions)ser.Deserialize(reader);

				string lastAccessFile = Path.Combine(localePath, ".lastaccess");
				File.WriteAllText(lastAccessFile, DateTime.Now.ToString());

				return true;
			}
			catch (Exception e)
			{
				RogueFramework.LogError("Error in DownloadIndex!");
				RogueFramework.LogError(e.ToString());
				return false;
			}
			finally
			{
				File.Delete(downloadPath);
			}
		}

		private static void UpdateVanillaLanguages()
		{
			string vanillaLanguagesPath = Path.Combine(localePath, "vanilla");
			Directory.CreateDirectory(vanillaLanguagesPath);

			foreach (KeyValuePair<string, int> entry in Versions.Entries)
			{
				string id = entry.Key;
				int latest = entry.Value;

				string path = Path.Combine(vanillaLanguagesPath, $"{id}.xml");
				if (!File.Exists(path)) UpdateLanguage(id, path, latest);
				else
				{
					try
					{
						int current;
						using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
						using (XmlReader reader = XmlReader.Create(stream))
							current = ReadPrefix(reader);

						if (current < latest) UpdateLanguage(id, path, latest);
					}
					catch (Exception e)
					{
						RogueFramework.LogError($"Something's wrong with {id}.xml");
						RogueFramework.LogError(e.ToString());
					}
				}
			}
		}
		private static int ReadPrefix(XmlReader reader)
		{
			reader.MoveToContent();
			string versionAttr = reader.GetAttribute("Version");
			return versionAttr != null && int.TryParse(versionAttr, out int version) ? version : -1;
		}
		private static void UpdateLanguage(string language, string filePath, int newVersion)
		{
			string url = $"https://raw.githubusercontent.com/Abbysssal/RogueLibs/main/RogueLibsCore/Resources/locale.{language}.xml";
			string downloadPath = filePath + ".download";
			WebClient web = new WebClient();
			try
			{
				web.DownloadFile(url, downloadPath);
				File.Delete(filePath);
				File.Move(downloadPath, filePath);

				Versions.Entries[language] = newVersion;
			}
			finally
			{
				File.Delete(downloadPath);
			}
		}

		private static readonly XmlSerializer languageSer = new XmlSerializer(typeof(LocaleLanguage));
		private static string localePath;

		private static void InitializeLanguages()
		{
			CurrentWatcher = SetupWatcher(LanguageService.Current);
			FallBackWatcher = SetupWatcher(LanguageService.FallBack);

			LanguageService.OnCurrentChanged += _ => ReloadCurrent(null, null);
			LanguageService.OnFallBackChanged += _ => ReloadFallBack(null, null);

			ReloadCurrent(null, null);
			ReloadFallBack(null, null);
		}
		private static FileSystemWatcher SetupWatcher(LanguageCode code)
		{
			string name = LanguageService.GetLanguageName(code);
			string path = Path.Combine(localePath, name + ".xml");

			if (!File.Exists(path)
				&& LanguageService.Current >= LanguageCode.English
				&& LanguageService.Current <= LanguageCode.Korean)
			{
				path = Path.Combine(localePath, "vanilla", name + ".xml");
				if (!File.Exists(path))
				{
					RogueFramework.LogError("Could not find the current language file.");
					return null;
				}
			}
			return new FileSystemWatcher(localePath)
			{
				Filter = name + ".xml",
				NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.Size,
				EnableRaisingEvents = true,
			};
		}

		private static LocaleLanguage ReloadLanguage(FileSystemWatcher watcher)
		{
			if (watcher is null) return null;
			string path = Path.Combine(watcher.Path, watcher.Filter);
			if (!File.Exists(path)) return null;
			try
			{
				using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
				using (XmlReader reader = XmlReader.Create(stream))
					return (LocaleLanguage)languageSer.Deserialize(reader);
			}
			catch
			{
				RogueFramework.LogError($"Error reading from {path}.");
				return null;
			}
		}

		private static FileSystemWatcher currentWatcher;
		public static FileSystemWatcher CurrentWatcher
		{
			get => currentWatcher;
			set
			{
				if (currentWatcher == value) return;
				if (currentWatcher != null)
				{
					currentWatcher.Created -= ReloadCurrent;
					currentWatcher.Changed -= ReloadCurrent;
					currentWatcher.Renamed -= ReloadCurrent;
					currentWatcher.Deleted -= ReloadCurrent;
				}
				currentWatcher = value;
				if (value != null)
				{
					value.Created += ReloadCurrent;
					value.Changed += ReloadCurrent;
					value.Renamed += ReloadCurrent;
					value.Deleted += ReloadCurrent;
				}
			}
		}
		private static void ReloadCurrent(object _, object __) => Current = ReloadLanguage(CurrentWatcher);

		private static FileSystemWatcher fallBackWatcher;
		public static FileSystemWatcher FallBackWatcher
		{
			get => fallBackWatcher;
			set
			{
				if (fallBackWatcher == value) return;
				if (fallBackWatcher != null)
				{
					fallBackWatcher.Created -= ReloadFallBack;
					fallBackWatcher.Changed -= ReloadFallBack;
					fallBackWatcher.Renamed -= ReloadFallBack;
					fallBackWatcher.Deleted -= ReloadFallBack;
				}
				fallBackWatcher = value;
				if (value != null)
				{
					value.Created += ReloadFallBack;
					value.Changed += ReloadFallBack;
					value.Renamed += ReloadFallBack;
					value.Deleted += ReloadFallBack;
				}
			}
		}
		private static void ReloadFallBack(object _, object __) => FallBack = ReloadLanguage(FallBackWatcher);

		public static LocaleLanguage Current { get; private set; }
		public static LocaleLanguage FallBack { get; private set; }

		public static string GetName(string name, string type)
		{
			return Current?[type, name] ?? FallBack?[type, name];
		}
	}
	[XmlRoot("Language")]
	public class LocaleLanguage : IXmlSerializable
	{
		private LocaleLanguage() { }
		public string Id { get; private set; }
		public int Version { get; private set; }
		public LanguageCode Code { get; internal set; }
		private Dictionary<string, LocaleCategory> categories;
		public ReadOnlyDictionary<string, LocaleCategory> Categories { get; private set; }

		public void WriteXml(XmlWriter xml)
		{
			xml.WriteAttributeString("Id", Id);
			if (Version != 0) xml.WriteAttributeString("Version", Version.ToString());
			foreach (LocaleCategory category in categories.Values)
			{
				xml.WriteStartElement("Category");
				category.WriteXml(xml);
				xml.WriteEndElement();
			}
		}
		public void ReadXml(XmlReader xml)
		{
			Id = xml.GetAttribute("Id");
			string versionAttr = xml.GetAttribute("Version");
			if (!string.IsNullOrEmpty(versionAttr)) Version = int.Parse(versionAttr);
			bool nonEmpty = !xml.IsEmptyElement;
			xml.ReadStartElement();
			categories = new Dictionary<string, LocaleCategory>();
			Categories = new ReadOnlyDictionary<string, LocaleCategory>(categories);
			if (nonEmpty)
			{
				xml.MoveToContent();
				while (xml.NodeType != XmlNodeType.EndElement)
				{
					if (xml.NodeType == XmlNodeType.Element)
					{
						LocaleCategory category = new LocaleCategory();
						category.ReadXml(xml);
						categories.Add(category.Id, category);
					}
					else xml.Skip();
					xml.MoveToContent();
				}
				xml.ReadEndElement();
			}
		}
		public System.Xml.Schema.XmlSchema GetSchema() => null;

		public string this[string category, string name] => categories.TryGetValue(category, out LocaleCategory cat) ? cat[name] : null;
	}
	[XmlRoot("Category")]
	public class LocaleCategory : IXmlSerializable
	{
		internal LocaleCategory() { }
		public string Id { get; private set; }
		private Dictionary<string, string> entries;
		public ReadOnlyDictionary<string, string> Entries { get; private set; }

		public void WriteXml(XmlWriter xml)
		{
			xml.WriteAttributeString("Id", Id);
			foreach (KeyValuePair<string, string> entry in entries)
			{
				xml.WriteStartElement("Entry");
				xml.WriteAttributeString("Id", entry.Key);
				xml.WriteString(entry.Value);
				xml.WriteEndElement();
			}
		}
		public void ReadXml(XmlReader xml)
		{
			Id = xml.GetAttribute("Id");
			bool nonEmpty = !xml.IsEmptyElement;
			xml.ReadStartElement();
			entries = new Dictionary<string, string>();
			Entries = new ReadOnlyDictionary<string, string>(entries);
			if (nonEmpty)
			{
				xml.MoveToContent();
				while (xml.NodeType != XmlNodeType.EndElement)
				{
					if (xml.NodeType == XmlNodeType.Element)
					{
						string id = xml.GetAttribute("Id");
						string content = xml.ReadElementContentAsString();
						entries.Add(id, content);
					}
					else xml.Skip();
					xml.MoveToContent();
				}
				xml.ReadEndElement();
			}
		}
		public System.Xml.Schema.XmlSchema GetSchema() => null;

		public string this[string name] => entries.TryGetValue(name, out string text) ? text : null;
	}
	internal class LanguageVersions : IXmlSerializable
	{
		private LanguageVersions() { }
		public Dictionary<string, int> Entries { get; private set; }

		public void WriteXml(XmlWriter xml)
		{
			if (Entries != null)
				foreach (KeyValuePair<string, int> entry in Entries)
				{
					xml.WriteStartElement("Language");
					xml.WriteAttributeString("Id", entry.Key);
					xml.WriteAttributeString("Version", entry.Value.ToString());
					xml.WriteEndAttribute();
				}
		}
		public void ReadXml(XmlReader xml)
		{
			bool nonEmpty = !xml.IsEmptyElement;
			xml.ReadStartElement();
			Entries = new Dictionary<string, int>();
			if (nonEmpty)
			{
				xml.MoveToContent();
				while (xml.NodeType != XmlNodeType.EndElement)
				{
					if (xml.NodeType == XmlNodeType.Element)
					{
						string id = xml.GetAttribute("Id");
						string versionAttr = xml.GetAttribute("Version");
						Entries.Add(id, int.Parse(versionAttr));
					}
					else xml.Skip();
					xml.MoveToContent();
				}
			}

		}
		public System.Xml.Schema.XmlSchema GetSchema() => null;
	}
}
