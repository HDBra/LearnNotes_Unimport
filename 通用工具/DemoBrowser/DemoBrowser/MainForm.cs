using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoBrowser.Utils;

namespace DemoBrowser
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 窗体的初始大小
        /// </summary>
        private int mInitWidth = 800;
        /// <summary>
        /// 窗体的初始高度
        /// </summary>
        private int mInitHeight = 600;

        /// <summary>
        /// 屏幕宽度
        /// </summary>
        private int mFullWidth = 800;

        /// <summary>
        /// 屏幕高度
        /// </summary>
        private int mFullHeight = 600;

        /// <summary>
        /// 消息url对应列表
        /// </summary>
        public static readonly List<Tuple<string, string>> MessageUrlList = new List<Tuple<string, string>>(); 

        /// <summary>
        /// 消息队列
        /// </summary>
        private static BlockingCollection<string>  MessageQueue = new BlockingCollection<string>(100);

        /// <summary>
        /// 底层线程
        /// </summary>
        private Thread _thread = null;

        /// <summary>
        /// 线程是否运行
        /// </summary>
        private static volatile bool isThreadRunning = false;

        /// <summary>
        /// 构造函数
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// form加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //加载消息url列表
            MessageUrlList.Clear();
            string messageUrlPairStr = ConfigUtils.GetString(Constants.MessageUrlPair);
            if (!string.IsNullOrWhiteSpace(messageUrlPairStr))
            {
                string[] arr = messageUrlPairStr.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var arrItem in arr)
                {
                    string[] msgUrlPairs = arrItem.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    if (msgUrlPairs.Length >= 2)
                    {
                        MessageUrlList.Add(new Tuple<string, string>(msgUrlPairs[0].Trim(), msgUrlPairs[1].Trim()));
                    }
                }
            }

            //开启线程
            isThreadRunning = true;
            _thread = new Thread(new ThreadStart(ThreadCallBack));
            _thread.IsBackground = true;
            _thread.Start();
            
            mInitWidth = this.Width;
            mInitHeight = this.Height;
            //获取屏幕的大小
            mFullWidth = Screen.PrimaryScreen.Bounds.Width;
            mFullHeight = Screen.PrimaryScreen.Bounds.Height;
            String mainTitle = ConfigUtils.GetString(Constants.MainTitle);
            this.Text = mainTitle;
            string defaultUrl = ConfigUtils.GetString(Constants.DefaultUrl);
            if (!string.IsNullOrWhiteSpace(defaultUrl))
            {
                MainBrowser.Navigate(defaultUrl);
            }

        }

        /// <summary>
        /// 捕获对话框键
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                FullScreen();
            }
            else if (keyData == Keys.Escape)
            {
                NormalScreen();
            }

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// 窗体关闭前消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("确定关闭吗？", "提示", MessageBoxButtons.OKCancel);

            if (dialogResult == DialogResult.OK || dialogResult == DialogResult.Yes)
            {
                NLogHelper.Warn("用户手动关闭窗体");
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 大小改变后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                this.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }

            Zoom();
        }

        /// <summary>
        /// 全屏化
        /// </summary>
        public void FullScreen()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

        }

        /// <summary>
        /// 正常屏幕大小
        /// </summary>
        public void NormalScreen()
        {
            WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            isThreadRunning = false;
            NLogHelper.Info("窗体关闭");
        }

        /// <summary>
        /// 当文档全部加载完后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Zoom();
        }


        /// <summary>
        /// 缩放
        /// </summary>
        public void Zoom()
        {
            //获取屏幕的大小
            mFullHeight = Screen.PrimaryScreen.Bounds.Height;
            this.TopMost = true;
            if (this.Width >= 30 && mFullWidth > 10)
            {
                MainBrowser.Zoom((int) (this.Width*100.0/mFullWidth));
            }
        }


        public static void HandleMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            MessageQueue.TryAdd(message, 100);
        }

        /// <summary>
        /// 线程回调用于执行ui更新
        /// </summary>
        private void ThreadCallBack()
        {
            while (isThreadRunning)
            {
                string message = null;
                //等待1s
                if(MessageQueue.TryTake(out message,1000))
                {
                    var messageUrlPair =MessageUrlList.FirstOrDefault(r => StringUtils.EqualsEx(r.Item1, message));
                    if (messageUrlPair == null || String.IsNullOrWhiteSpace(messageUrlPair.Item2))
                    {
                        NLogHelper.Warn(string.Format("未找到消息{0}对应的url",message));
                        continue;
                    }
                    NLogHelper.Info(string.Format("接收到命令{0}，导航到{1}",message,messageUrlPair.Item2));
                    if (this.MainBrowser.InvokeRequired)
                    {
                        if (!MainBrowser.Disposing && !MainBrowser.IsDisposed)
                        {
                            MainBrowser.Invoke(new Action(() =>
                            {
                                try
                                {
                                    MainBrowser.Navigate(messageUrlPair.Item2);
                                }
                                catch (Exception ex)
                                {
                                    NLogHelper.Error(string.Format("导航到{0}失败：{1}",messageUrlPair.Item2,ex));
                                }
                            }));
                        }
                    }
                    else
                    {
                        if (!MainBrowser.Disposing && !MainBrowser.IsDisposed)
                        {
                            MainBrowser.Invoke(new Action(() =>
                            {
                                try
                                {
                                    MainBrowser.Navigate(messageUrlPair.Item2);
                                }
                                catch (Exception ex)
                                {
                                    NLogHelper.Error(string.Format("导航到{0}失败：{1}", messageUrlPair.Item2, ex));
                                }
                            }));
                        }
                    }
                }
            }
        }
    }
}
