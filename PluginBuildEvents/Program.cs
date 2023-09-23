using System;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace PluginBuildEvents
{
    public static class Program
    {
        private static string? GetSteamPath()
        {
            string myAppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AbbLab");
            string steamPathFile = Path.Combine(myAppData, "SteamPath");
            string? steamPath;
            if (File.Exists(steamPathFile))
            {
                steamPath = File.ReadAllText(steamPathFile);
                if (Directory.Exists(steamPath)) return steamPath;
            }
            steamPath = FindSteam();
            if (steamPath is not null)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(steamPathFile)!);
                File.WriteAllText(steamPathFile, steamPath);
            }
            return steamPath;
        }
        private static string? FindSteam()
        {
            if (OperatingSystem.IsWindows())
            {
                RegistryKey? steam = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Valve\Steam");
                return (string?)steam?.GetValue("SteamPath");
            }

            // ~/.local/share/Steam
            string path1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Steam");
            if (Directory.Exists(path1)) return path1;
            // ~/.steam
            string path2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".steam");
            if (Directory.Exists(path2)) return path2;
            // ~/Steam
            string path3 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Steam");
            if (Directory.Exists(path3)) return path3;
            return null;
        }
        public static void Main(string[] args)
        {
            try
            {
                Main2(args);
            }
            catch (Exception e)
            {
                string curDir = AppDomain.CurrentDomain.BaseDirectory;
                string path = Path.Combine(curDir, "error-log.txt");
                File.WriteAllText(path, e.ToString());
            }
        }
        private static void Main2(string[] args)
        {
            if (args.Length < 2)
                throw new InvalidOperationException("Usage:" +
                "\n./PluginBuildEvents.exe \"<plugin .dll>\" \"<game directory>\"" +
                "\nRemarks:" +
                "\nThe program also copies the .pdb and .dll.mdb files associated with your plugin." +
                "\nYou can specify the name of the game's directory in Steam instead of a full path. In that case, Steam's path will be detected automatically.");

            if (args[0].ToUpperInvariant() is "-L" or "--LAUNCH")
            {
                if (!long.TryParse(args[1], out long id))
                    throw new ArgumentException("The game id is in invalid format!");

                Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    Arguments = $"/c start steam://rungameid/{id}",
                });
                return;
            }

            string origDll = Path.GetFullPath(args[0]);
            if (!File.Exists(origDll)) throw new FileNotFoundException("The specified plugin .dll was not found!");

            string plugins;
            if (Directory.Exists(args[1]))
                plugins = Path.Combine(args[1], "BepInEx", "plugins");
            else if (!args[1].Contains('\\'))
            {
                string? steam = GetSteamPath();
                if (steam is null) throw new InvalidOperationException("Steam was not found on the computer! You'll have to specify the game's directory manually!");
                plugins = Path.GetFullPath(Path.Combine(steam, "SteamApps", "common", args[1], "BepInEx", "plugins"));
            }
            else throw new ArgumentException("The specified folder was not found!");

            string origPdb = Path.ChangeExtension(origDll, ".pdb");

            string newDll = Path.Combine(plugins, Path.GetFileName(origDll));
            string newPdb = Path.Combine(plugins, Path.GetFileName(origPdb));

            // ReSharper disable once InconsistentNaming
            string pdb2mdb = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pdb2mdb.exe");

            bool skipPdb = File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".no-pdb"));

            File.Copy(origDll, newDll, true);
            if (File.Exists(origPdb) && !skipPdb) File.Copy(origPdb, newPdb, true);

            if (File.Exists(pdb2mdb))
            {
                Process process = Process.Start(new ProcessStartInfo
                {
                    FileName = pdb2mdb,
                    Arguments = $"\"{origDll}\"",
                    UseShellExecute = false,
                })!;
                process.WaitForExit();

                string origMdb = origDll + ".mdb";
                string newMdb = Path.Combine(plugins, Path.GetFileName(origMdb));
                if (File.Exists(origMdb)) File.Copy(origMdb, newMdb, true);
            }

        }
    }
}
