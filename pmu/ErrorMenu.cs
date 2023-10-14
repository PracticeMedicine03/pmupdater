using System;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace ef2_updater
{
    public partial class ErrorMenu : Form
    {
        public ErrorMenu()
        {
            InitializeComponent();
        }

       // /*
        private void InitializeComponent()
        {
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(40, 12);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(192, 15);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "Whoops! You\'ve encountered an <strong>error</strong>!";
            this.guna2HtmlLabel1.Click += new System.EventHandler(this.guna2HtmlLabel1_Click);
            // 
            // ErrorMenu
            // 
            this.ClientSize = new System.Drawing.Size(281, 139);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Name = "ErrorMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }//*/

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
    