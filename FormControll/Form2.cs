using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormControll
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            string filePath = @"C:\Users\ljl\source\repos\FormControll\FormControll\box.pdf";
            panelPDF.Controls.Clear();
            ChromiumWebBrowser browser = new ChromiumWebBrowser(filePath);
            browser.Dock = DockStyle.Fill;
            panelPDF.Controls.Add(browser);
        }
    }
}