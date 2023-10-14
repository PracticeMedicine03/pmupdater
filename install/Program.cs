using Microsoft.Win32;
using NDesk.Options;
using System;
using System.Diagnostics;
using System.IO;


namespace Install // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool show_help = false;
            bool install_ef2 = false;
            bool update_ef2 = false;
            List<string> names = new List<string>();
            int repeat = 1;

            Console.WriteLine("Welcome to PenCollective SourceMods Installer");
            Console.WriteLine("Try `install --help' for more information.");

            var p = new OptionSet()
            {          
                { "h|help",  "show this message and exit",
                    v => show_help = v != null },
                { "i|install",  "Install a sourcemod (Only EF2 as of this edition)",
                    v => install_ef2 = v != null },
                { "u|update",  "Update your sourcemod's client",
                    v => update_ef2 = v != null },
            };

            List<string> extra;
            try
            {
                extra = p.Parse(args);
            }
            catch (OptionException e)
            {
                Console.WriteLine("Welcome to PenCollective SourceMods Installer");
                //Console.Write("greet: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `install --help' for more information.");
                return;
            }

            if (show_help)
            {
                ShowHelp(p);
                return;
            }

            if (install_ef2)
            {
                InstallMod(p);
                return;
            }

            if (update_ef2)
            {
                UpdateMod(p);
                return;
            }

            static void ShowHelp(OptionSet p)
            {
                Console.WriteLine("Usage: install [OPTIONS]");
                Console.WriteLine("Install EF2 or other mods applied to this executable.");
                Console.WriteLine("Example: install.exe -install");
                Console.WriteLine();
                Console.WriteLine("Options:");
                p.WriteOptionDescriptions(Console.Out);
            }

            static void InstallMod(OptionSet p)
            {
                Console.WriteLine("Installing EF2...");
                string mod_path = "";
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam");
                mod_path = key.GetValue("SourceModInstallPath").ToString();
                if(Directory.Exists(mod_path))
                {
                    Console.WriteLine("Error!");
                    Console.WriteLine("EF2 is already installed in your computer.");
                    Console.WriteLine("Press enter to exit...");
                    Console.ReadLine();
                }
                else
                {
                    Process.Start(".\\bin\\bin\\git", "config --global http.postBuffer 524288000");
                    Process.Start(".\\bin\\bin\\git", "config --global http.maxRequestBuffer 524288000");
                    Process.Start(".\\bin\\bin\\git", "config --global core.compression 9");
                    Process.Start(".\\bin\\bin\\git", "config --system credential.helper manager-core");
                    Process.Start(".\\bin\\bin\\git", "clone --depth 1 https://github.com/Daisreich/tf2i " + mod_path + "\\tf2i");
                    Console.WriteLine();
                    Console.WriteLine("This utility is paused unless any keys are pressed. This is to catch errors during installation.");
                    Console.WriteLine("Press enter to continue when the process is done.");
                    Console.ReadLine();
                }
                
            }

            static void UpdateMod(OptionSet p)
            {
                Console.WriteLine("Updating EF2...");
                string mod_path = "";
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam");
                mod_path = key.GetValue("SourceModInstallPath").ToString();
                Process.Start(".\\bin\\bin\\git", "config --global http.postBuffer 524288000");
                Process.Start(".\\bin\\bin\\git", "config --global http.maxRequestBuffer 524288000");
                Process.Start(".\\bin\\bin\\git", "config --global core.compression 9");
                Process.Start(".\\bin\\bin\\git", "config --system credential.helper manager-core");

                // PracticeMedicine; We used "+" instead of a comma (",") because we need to prevent the overload arguments error.
                Process.Start(".\\bin\\bin\\git", "-C " + mod_path + "\\tf2i " + "fetch --depth 1");
                Process.Start(".\\bin\\bin\\git", "-C " + mod_path + "\\tf2i " + "reset --hard origin/HEAD");
                Console.WriteLine();
                Console.WriteLine("This utility is paused unless any keys are pressed. This is to catch errors during installation.");
                Console.WriteLine("Press enter to continue when the process is done");
                Console.ReadLine();
            }
        }
    }
}