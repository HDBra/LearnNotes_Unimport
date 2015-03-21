using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;

namespace WpfLearn.Utils
{
    /// <summary>
    /// messagebox对话框     OpenFileDialog打开文件对话框  SaveFileDialog   
    /// </summary>
    public static class WindowUtils
    {
        /// <summary>
        /// 模态窗口 打开一个窗口，仅在新打开的窗口被关闭时返回。
        /// 通常设置公共属性，在窗口关闭后，来通过公共属性获取用户信息
        /// 在模态对话框中设置DislogResult，然后窗口关闭后，根据DialogResult和公共属性来获取用户信息
        /// </summary>
        /// <param name="window"></param>
        /// <returns>用户是否接受了 (true) 或 cancel (false) 对话框</returns>
        public static bool? ShowDialog(Window window)
        {
            //window.DialogResult = true;
            return window.ShowDialog();
        }

        /// <summary>
        /// 非模态对话框
        /// </summary>
        /// <param name="window"></param>
        public static void Show(Window window)
        {
            window.Show();
        }

        /// <summary>
        /// 获取屏幕的长宽
        /// </summary>
        /// <returns></returns>
        public static Tuple<double,double> GetScreenWidthHeight()
        {
            return new Tuple<double, double>(SystemParameters.FullPrimaryScreenWidth,SystemParameters.FullPrimaryScreenHeight);
        }

        /// <summary>
        /// Owned windows are always shown modelessly.
        /// </summary>
        /// <param name="owned"></param>
        /// <param name="owner"></param>
        public static void SetOwer(Window owned, Window owner)
        {
            owned.Owner = owner;
            owned.Show();
        }


        public static void ShowOpenFileDialog()
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF" +
            "|All files (*.*)|*.*";
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = true;
            if (myDialog.ShowDialog() == true)
            {
                List<String> lstFiles = new List<string>();
                lstFiles.Clear();
                foreach (string file in myDialog.FileNames)
                {
                    lstFiles.Add(file);
                }
            }
        }
    }
}
