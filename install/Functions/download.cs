using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Install.Functions
{
    internal class Download
    {
        public static void Downloader_Install()
        {
            string sourcemod_path = "";
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam");
            sourcemod_path = key.GetValue("SourceModInstallPath").ToString();
            string mod_path = sourcemod_path + "\\mod";

            Process.Start(".\\bin\\bin\\git", "config --global http.postBuffer 524288000");
            Process.Start(".\\bin\\bin\\git", "config --global http.maxRequestBuffer 524288000");
            Process.Start(".\\bin\\bin\\git", "config --global core.compression 9");
            Process.Start(".\\bin\\bin\\git", "config --system credential.helper manager-core");
            Process.Start(".\\bin\\bin\\git", "clone --depth 1 https://github.com/Daisreich/tf2i " + mod_path + "\\tf2i");
        }

        public static void Downloader_Update()
        {
            string mod_path = "";
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam");
            mod_path = key.GetValue("SourceModInstallPath").ToString();
            Process.Start(".\\bin\\bin\\git", "config --global http.postBuffer 524288000");
            Process.Start(".\\bin\\bin\\git", "config --global http.maxRequestBuffer 524288000");
            Process.Start(".\\bin\\bin\\git", "config --global core.compression 9");
            Process.Start(".\\bin\\bin\\git", "config --system credential.helper manager-core");

            // PracticeMedicine; We used "+" instead of a comma (",") because we need to prevent the overload arguments error.
            Process.Start(".\\bin\\bin\\git", "-C " + mod_path + "\\mod " + "fetch --depth 1");
            Process.Start(".\\bin\\bin\\git", "-C " + mod_path + "\\mod " + "reset --hard origin/HEAD");
        }
        public static void Downloader_Run()
        {
            string sourcemod_path = "";
            string steam_path = "";
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam");
            sourcemod_path = key.GetValue("SourceModInstallPath").ToString();
            steam_path = key.GetValue("SteamPath").ToString();
            string mod_path = sourcemod_path + "\\mod";

            Process.Start(@"steam.exe" + "-applaunch 243750" + "-game " + mod_path + "-windowed -noborder" + "-w 1920 -h 1080");
        }
    }
}
