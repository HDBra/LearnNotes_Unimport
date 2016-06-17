using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LogCleaner.Models;
using LogCleaner.Utils;
using Xceed.Wpf.Toolkit.Core;
using MessageBox = Xceed.Wpf.Toolkit.MessageBox;

namespace LogCleaner.Windows
{
    /// <summary>
    /// ConfigWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ConfigWindow : Window
    {
        private string Directory { get; set; }

        /// <summary>
        /// 清理细节
        /// </summary>
        public CleanDir CleanDir { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dir"></param>
        public ConfigWindow(string dir)
        {
            Directory = dir;
            this.CleanDir = new CleanDir();
            this.CleanDir.Directory = dir;
            InitializeComponent();
        }

        /// <summary>
        /// 配置完成相应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigWizard_OnFinish(object sender, RoutedEventArgs e)
        {
            //清空初值
            this.CleanDir = new CleanDir();
            //设置当前目录
            this.CleanDir.Directory = Directory;

            int? dayKeeps = IuDays.Value;
            if (!dayKeeps.HasValue || dayKeeps.Value < 1)
            {
                MessageBox.Show("没有选择执行日志保留天数", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                return;
            }
            this.CleanDir.ReserveDays = dayKeeps.Value;
            DateTime? time = TpTime.Value;
            if (!time.HasValue)
            {
                MessageBox.Show("没有选择执行时间", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                return;
            }

            DateTime execTime = time.Value;
            if (RadioByDay.IsChecked == true)
            {
                this.CleanDir.CleanDetail.CleanMode = CleanMode.ByDay;
                this.CleanDir.CleanDetail.WeekOrMonthList.Clear();
                this.CleanDir.CleanDetail.CronExpression = CleanDetail.DayCronFormat.FormatWith(execTime.Second,execTime.Minute,execTime.Hour);
            }

            #region byweek
            if (RadioByWeek.IsChecked == true)
            {
                this.CleanDir.CleanDetail.WeekOrMonthList.Clear();
                this.CleanDir.CleanDetail.CronExpression = string.Empty;
                this.CleanDir.CleanDetail.CleanMode = CleanMode.ByWeek;

                if (CbWeek7.IsChecked == true)
                {
                    //周日
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("1");
                }

                if (CbWeek1.IsChecked == true)
                {
                    //周一
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("2");
                }

                if (CbWeek2.IsChecked == true)
                {
                    //周二
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("3");
                }

                if (CbWeek3.IsChecked == true)
                {
                    //周3
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("4");
                }

                if (CbWeek4.IsChecked == true)
                {
                    //周4
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("5");
                }

                if (CbWeek5.IsChecked == true)
                {
                    //周5
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("6");
                }

                if (CbWeek6.IsChecked == true)
                {
                    //周6
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("7");
                }


                if (this.CleanDir.CleanDetail.WeekOrMonthList.Count == 0)
                {
                    MessageBox.Show("按周执行没有选择任何日期", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    return;
                }

                StringBuilder sb = new StringBuilder();
                foreach (string item in this.CleanDir.CleanDetail.WeekOrMonthList)
                {
                    sb.Append(item + ",");
                }

                this.CleanDir.CleanDetail.CronExpression = CleanDetail.WeekCronFormat.FormatWith(execTime.Second,
                    execTime.Minute, execTime.Hour, sb.ToString().TrimEnd(','));

            }
            #endregion

            #region ByMonth
            if (RadioByMonth.IsChecked == true)
            {
                this.CleanDir.CleanDetail.CleanMode = CleanMode.ByMonth;
                this.CleanDir.CleanDetail.WeekOrMonthList.Clear();
                this.CleanDir.CleanDetail.CronExpression = string.Empty;

                if (Cb1.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("1");
                }

                if (Cb2.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("2");
                }

                if (Cb3.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("3");
                }

                if (Cb4.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("4");
                }

                if (Cb5.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("5");
                }

                if (Cb6.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("6");
                }

                if (Cb7.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("7");
                }

                if (Cb8.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("8");
                }

                if (Cb9.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("9");
                }

                if (Cb10.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("10");
                }

                if (Cb11.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("11");
                }

                if (Cb12.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("12");
                }

                if (Cb13.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("13");
                }

                if (Cb14.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("14");
                }

                if (Cb15.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("15");
                }

                if (Cb16.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("16");
                }

                if (Cb17.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("17");
                }

                if (Cb18.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("18");
                }

                if (Cb19.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("19");
                }

                if (Cb20.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("20");
                }

                if (Cb21.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("21");
                }

                if (Cb22.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("22");
                }

                if (Cb23.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("23");
                }

                if (Cb24.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("24");
                }

                if (Cb25.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("25");
                }

                if (Cb26.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("26");
                }

                if (Cb27.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("27");
                }

                if (Cb28.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("28");
                }

                if (Cb29.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("29");
                }

                if (Cb30.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("30");
                }

                if (Cb31.IsChecked == true)
                {
                    this.CleanDir.CleanDetail.WeekOrMonthList.Add("31");
                }
                
                if (this.CleanDir.CleanDetail.WeekOrMonthList.Count == 0)
                {
                    MessageBox.Show("按月执行没有选择任何日期", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    return;
                }

                StringBuilder sb = new StringBuilder();
                foreach (string item in this.CleanDir.CleanDetail.WeekOrMonthList)
                {
                    sb.Append(item + ",");
                }

                this.CleanDir.CleanDetail.CronExpression = CleanDetail.MonthCronFormat.FormatWith(execTime.Second,
                    execTime.Minute, execTime.Hour, sb.ToString().TrimEnd(','));

            }

            #endregion

            if (CleanManager.IsManaged(Directory))
            {
                //该目录已经被管理
                MessageBox.Show(string.Format("目录 {0} 已经被管理", Directory), "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                this.Close();
                return;
            }

            //加入管理
            CleanManager.AddCleanJob(CleanDir);
            DialogResult = true;
            this.Close();

        }

        /// <summary>
        /// 当进入第二个页面时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SecondPage_OnEnter(object sender, RoutedEventArgs e)
        {
            if (RadioByDay.IsChecked == true)
            {
                GbMonth.Visibility = Visibility.Collapsed;
                GbWeek.Visibility = Visibility.Collapsed;
            }

            if (RadioByMonth.IsChecked == true)
            {
                GbMonth.Visibility = Visibility.Visible;
                GbWeek.Visibility = Visibility.Collapsed;
            }

            if (RadioByWeek.IsChecked == true)
            {
                GbMonth.Visibility = Visibility.Collapsed;
                GbWeek.Visibility = Visibility.Visible;
            }
        }

    }
}
