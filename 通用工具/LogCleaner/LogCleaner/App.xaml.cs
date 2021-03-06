﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using LogCleaner.Models;
using LogCleaner.Quartzs;
using LogCleaner.Utils;

namespace LogCleaner
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            NLogHelper.Info("程序启动");

            #region 重置当前路径
            try
            {
                string dirPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                NLogHelper.Info("设置当前路径为:{0}，原当前路径为：{1}".FormatWith(dirPath,Environment.CurrentDirectory));
                if (!string.IsNullOrEmpty(dirPath))
                {
                    Environment.CurrentDirectory = dirPath;
                }
            }
            catch (Exception ex)
            {
                NLogHelper.Error("设置当前路径失败:"+ex);
            }
            #endregion

            #region 加载配置项初始化job
            //加载配置文件
            List<CleanDir> cleanDirs = null;
            if (File.Exists(SerializeHelper.DestFile))
            {
                cleanDirs = SerializeHelper.ToObject<List<CleanDir>>(SerializeHelper.DestFile);
                NLogHelper.Info("加载配置文件"+SerializeHelper.DestFile);
            }
            else
            {
                NLogHelper.Warn("未能找到配置文件"+SerializeHelper.DestFile);
            }

            if (cleanDirs == null)
            {
                cleanDirs = new List<CleanDir>();
            }

            //加载配置任务
            foreach (var cleanDirItem in cleanDirs)
            {
                if (!CleanManager.IsManaged(cleanDirItem.Directory))
                {
                    CleanManager.AddCleanJob(cleanDirItem);
                }
            }

            QuartzHelper.GetInstance().Start();
            #endregion
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_OnExit(object sender, ExitEventArgs e)
        {
            NLogHelper.Info("用户退出");
            QuartzHelper.GetInstance().Shutdown();
            Environment.Exit(0);
        }

        /// <summary>
        /// 处理异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            NLogHelper.Fatal("捕获到未处理UI异常："+e.Exception);
        }
    }
}
