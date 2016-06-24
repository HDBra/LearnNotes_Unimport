

namespace DemoBrowser
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainBrowser = new EO.WebBrowser.WinForm.WebControl();
            this.webView1 = new EO.WebBrowser.WebView();
            this.MainBrowser2 = new EO.WebBrowser.WinForm.WebControl();
            this.webView2 = new EO.WebBrowser.WebView();
            this.SuspendLayout();
            // 
            // MainBrowser
            // 
            this.MainBrowser.BackColor = System.Drawing.Color.White;
            this.MainBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainBrowser.Location = new System.Drawing.Point(0, 0);
            this.MainBrowser.Name = "MainBrowser";
            this.MainBrowser.Size = new System.Drawing.Size(784, 562);
            this.MainBrowser.TabIndex = 0;
            this.MainBrowser.WebView = this.webView1;
            // 
            // webView1
            // 
            this.webView1.KeyUp += new EO.WebBrowser.WndMsgEventHandler(this.webView1_KeyUp);
            // 
            // MainBrowser2
            // 
            this.MainBrowser2.BackColor = System.Drawing.Color.White;
            this.MainBrowser2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainBrowser2.Location = new System.Drawing.Point(0, 0);
            this.MainBrowser2.Name = "MainBrowser2";
            this.MainBrowser2.Size = new System.Drawing.Size(784, 562);
            this.MainBrowser2.TabIndex = 1;
            this.MainBrowser2.Text = "webControl1";
            this.MainBrowser2.WebView = this.webView2;
            // 
            // webView2
            // 
            this.webView2.KeyUp += new EO.WebBrowser.WndMsgEventHandler(this.webView2_KeyUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.MainBrowser2);
            this.Controls.Add(this.MainBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private EO.WebBrowser.WinForm.WebControl MainBrowser;
        private EO.WebBrowser.WebView webView1;
        private EO.WebBrowser.WinForm.WebControl MainBrowser2;
        private EO.WebBrowser.WebView webView2;



    }
}

