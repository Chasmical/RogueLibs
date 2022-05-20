using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Net;
using BepInEx;

namespace RogueLibsCore
{
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
        private static LanguageVersions? Versions;
        private static bool DownloadIndex()
        {
            const string url = "https://raw.githubusercontent.com/SugarBarrel/RogueLibs/main/RogueLibsCore/Resources/locale.index.xml";
            string downloadPath = Path.Combine(localePath, ".vanilla.index.xml");
            try
            {
                WebClient web = new WebClient();
                web.DownloadFile(url, downloadPath);

                using (FileStream stream = new FileStream(downloadPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (XmlReader reader = XmlReader.Create(stream))
                {
                    Versions = new LanguageVersions();
                    Versions.ReadXml(reader);
                }

                string lastAccessFile = Path.Combine(localePath, ".lastaccess");
                File.WriteAllText(lastAccessFile, DateTime.Now.ToString(CultureInfo.InvariantCulture));

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

            if (Versions is null) return;
            foreach (KeyValuePair<string, int> entry in Versions.Entries.ToList())
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
            string? versionAttr = reader.GetAttribute("Version");
            return versionAttr != null && int.TryParse(versionAttr, out int version) ? version : -1;
        }
        private static void UpdateLanguage(string language, string filePath, int newVersion)
        {
            if (RogueFramework.IsDebugEnabled(DebugFlags.Names)) RogueFramework.LogDebug($"Updating ${language} to version ${newVersion}");
            string url = $"https://raw.githubusercontent.com/SugarBarrel/RogueLibs/main/RogueLibsCore/Resources/locale.{language}.xml";
            string downloadPath = filePath + ".download";
            WebClient web = new WebClient();
            try
            {
                web.DownloadFile(url, downloadPath);
                File.Delete(filePath);
                File.Move(downloadPath, filePath);

                Versions!.Entries[language] = newVersion;
            }
            finally
            {
                File.Delete(downloadPath);
            }
        }

        private static string localePath = null!; // initialized in Init()

        private static void InitializeLanguages()
        {
            ReInitializeLanguages();
            LanguageService.OnCurrentChanged += static e => Current = ReloadLanguage(CurrentWatcher = SetupWatcher(e.Value));
            LanguageService.OnFallBackChanged += static e => FallBack = ReloadLanguage(FallBackWatcher = SetupWatcher(e.Value));
        }
        public static void ReInitializeLanguages()
        {
            CurrentWatcher = SetupWatcher(LanguageService.Current);
            FallBackWatcher = SetupWatcher(LanguageService.FallBack);

            ReloadCurrent(null, null);
            ReloadFallBack(null, null);
        }
        private static FileSystemWatcher? SetupWatcher(LanguageCode code)
        {
            string? name = LanguageService.GetLanguageName(code);
            string path = localePath;

            if (!File.Exists(Path.Combine(path, name + ".xml"))
                && LanguageService.Current is >= LanguageCode.English and <= LanguageCode.Korean)
            {
                path = Path.Combine(localePath, "vanilla");
                if (!File.Exists(Path.Combine(path, name + ".xml")))
                {
                    RogueFramework.LogError("Could not find the vanilla language file.");
                    return null;
                }
            }
            return new FileSystemWatcher(path)
            {
                Filter = name + ".xml",
                EnableRaisingEvents = true,
            };
        }

        private static LocaleLanguage? ReloadLanguage(FileSystemWatcher? watcher)
        {
            if (watcher is null) return null;
            return ReloadLanguage(watcher.Path, watcher.Filter);
        }
        private static LocaleLanguage? ReloadLanguage(string directory, string name)
        {
            if (RogueFramework.IsDebugEnabled(DebugFlags.Names)) RogueFramework.LogDebug($"Live-reloading {name}");
            string path = Path.Combine(directory, name);
            if (!File.Exists(path)) return null;
            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (XmlReader reader = XmlReader.Create(stream))
                {
                    LocaleLanguage language = new LocaleLanguage();
                    language.ReadXml(reader);
                    return language;
                }
            }
            catch
            {
                RogueFramework.LogError($"Error reading from {path}.");
                return null;
            }
        }

        private static FileSystemWatcher? currentWatcher;
        public static FileSystemWatcher? CurrentWatcher
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
        private static void ReloadCurrent(object? _, object? __) => Current = ReloadLanguage(CurrentWatcher);

        private static FileSystemWatcher? fallBackWatcher;
        public static FileSystemWatcher? FallBackWatcher
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
        private static void ReloadFallBack(object? _, object? __) => FallBack = ReloadLanguage(FallBackWatcher);

        public static LocaleLanguage? Current { get; private set; }
        public static LocaleLanguage? FallBack { get; private set; }

        public static string? GetName(string? name, string type)
        {
            if (name is null) return null;
            return Current?[type, name] ?? FallBack?[type, name];
        }
    }
}
