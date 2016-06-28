using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace CefSharpDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Cef.Initialize();
            ChromiumWebBrowser browser = new ChromiumWebBrowser("http://ie.icoa.cn/");
            browser.Dock = DockStyle.Fill;
            //browser.SetZoomLevel(0.5);
            this.Controls.Add(browser);
        }
    }
}
