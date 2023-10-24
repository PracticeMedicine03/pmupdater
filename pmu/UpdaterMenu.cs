using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using Guna.UI2.WinForms;

using PMU.Functions;

namespace ef2_updater
{
    public partial class UpdaterMenu : Form
    {
        public UpdaterMenu()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(6000);
            string updater_binpath = "bin";
            if (Directory.Exists(updater_binpath))
            {
                InitializeComponent();
            }
            else
            {
                MessageBox.Show("Binaries folder were not found. Reinstall your client", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            t.Abort();
        }

        public void StartForm()
        {
            Application.Run(new Splash());
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string updater_binpath = "bin";
            Sound.UI.UI_OnPressed();
            //const string EF2_Path;
            if (Directory.Exists(updater_binpath))
            {
                Process.Start(updater_binpath + "\\install.exe", "-install");
            }
            else
            {
                MessageBox.Show("The bin folder (where the Git executable is) doesn't exist! Reinstall your updater.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string updater_binpath = "bin";
            Sound.UI.UI_OnPressed();
            if (Directory.Exists(updater_binpath))
            {
                Process.Start(updater_binpath + "\\install.exe", "-update");
            }
            else
            {
                MessageBox.Show("The bin folder (where the Git executable is) doesn't exist! Reinstall your updater.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            string updater_binpath = "bin";
            Sound.UI.UI_OnPressed();
            if (Directory.Exists(updater_binpath))
            {
                Process.Start(updater_binpath + "\\install.exe", "-update");
            }
            else
            {
                MessageBox.Show("The bin folder (where the Git executable is) doesn't exist! Reinstall your updater.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
    
