using Microsoft.Win32;
using NDesk.Options;
using System;
using System.Diagnostics;
using System.IO;

using Install.Functions;

namespace Install // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool show_help = false;
            bool install_mod = false;
            bool run_mod = false;
            bool update_mod = false;
            List<string> names = new List<string>();
            int repeat = 1;

            Console.WriteLine("Welcome to PenCollective SourceMods Installer");
            Console.WriteLine("Try `install --help' for more information.");

            var p = new OptionSet()
            {
                { "h|help",  "show this message and exit",
                    v => show_help = v != null },
                { "i|install",  "Install a sourcemod",
                    v => install_mod = v != null },
                { "u|update",  "Update your sourcemod's client",
                    v => update_mod = v != null },
                { "r|run", "Run the sourcemod",
                    v => run_mod = v != null },
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

            if (install_mod)
            {
                InstallMod(p);
                return;
            }

            if (update_mod)
            {
                UpdateMod(p);
                return;
            }

            if(run_mod)
            {
                RunMod(p);
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
                Console.WriteLine("Installing Mod...");
                string sourcemod_path = "";
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam");
                sourcemod_path = key.GetValue("SourceModInstallPath").ToString();
                string mod_path = sourcemod_path + "\\fc";
                if(Directory.Exists(mod_path))
                {
                    Console.WriteLine("Error!");
                    Console.WriteLine("Fortress Connected is already installed in your computer.");
                    Console.WriteLine("Press enter to exit...");
                    Console.ReadLine();
                }
                else
                {
                    Download.Downloader_Install();
                    Console.WriteLine();
                    Console.WriteLine("This utility is paused unless any keys are pressed. This is to catch errors during installation.");
                    Console.WriteLine("Press enter to continue when the process is done.");
                    Console.ReadLine();
                }
                
            }

            static void RunMod(OptionSet p)
            {
                Console.WriteLine("Opening Steam and launching Mod");
                string sourcemod_path = "";
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam");
                sourcemod_path = key.GetValue("SourceModInstallPath").ToString();
                string mod_path = sourcemod_path + "\\fc";

                if (Directory.Exists(mod_path))
                {
                    Download.Downloader_Run();
                }
                else
                {
                    Console.WriteLine("Error!");
                    Console.WriteLine("Bro, the mod isnt installed. How am I going to run this sourcemod?");
                    Console.WriteLine("Press Enter to exit");
                    Console.ReadLine();
                }
            }

            static void UpdateMod(OptionSet p)
            {
                Console.WriteLine("Updating FC...");
                Download.Downloader_Update();
                Console.WriteLine();
                Console.WriteLine("This utility is paused unless any keys are pressed. This is to catch errors during installation.");
                Console.WriteLine("Press enter to continue when the process is done");
                Console.ReadLine();
            }
        }
    }
}
