using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoBrowser.Utils
{
    public class TimerEx:IDisposable
    {
        /// <summary>
        /// 定时器
        /// </summary>
        private Timer _timer = null;

        /// <summary>
        /// 锁
        /// </summary>
        private object _locker = new object();

        /// <summary>
        /// 定时器是否开启
        /// 这里并不是指的是定时器是否真的启动，而是定时器的功能是否启动
        /// </summary>
        private bool _isStarted = false;

        /// <summary>
        /// 是否回调在运行
        /// </summary>
        private bool _isRunning = false;

        /// <summary>
        /// 定时器是否开启
        /// 这里并不是指的是定时器是否真的启动，而是定时器的功能是否启动
        /// </summary>
        public bool IsStarted
        {
            get
            {
                lock (_locker)
                {
                    return _isStarted;
                }
            }
            set
            {
                lock (_locker)
                {
                    _isStarted = value;
                }
            }
        }

        /// <summary>
        /// 是否回调在运行
        /// </summary>
        public bool IsRunning
        {
            get
            {
                lock (_locker)
                {
                    return _isRunning;
                }
            }
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        public TimerEx()
        {
            _timer = new Timer(new TimerCallback(TimerCallback), null, 100, 9000);
        }

        /// <summary>
        /// 开始运行
        /// </summary>
        public void Start()
        {
            IsStarted = true;
        }

        /// <summary>
        /// 结束运行
        /// </summary>
        public void Stop()
        {
            IsStarted = false;
        }

        /// <summary>
        /// 定时器回调函数
        /// </summary>
        /// <param name="state"></param>
        private void TimerCallback(object state)
        {
            //如果未启动，直接退出
            if (!IsStarted)
            {
                return;
            }

            lock (_locker)
            {
                if (_isRunning)
                {
                    //回调正在运行
                    return;
                }
                _isRunning = true;
            }

            try
            {
                CallBack(state);
            }
            catch (Exception ex)
            {
                NLogHelper.Error("定时器回调函数发生异常：" + ex);
            }
            finally
            {
                lock (_locker)
                {
                    _isRunning = false;
                }
            }
        }

        /// <summary>
        /// 实际的回调函数
        /// </summary>
        /// <param name="state"></param>
        private void CallBack(object state)
        {
            if (!MQConsumer.IsAlive())
            {
                MQConsumer.InitConsumer();
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            IsStarted = false;
            if (_timer != null)
            {
                _timer.Dispose();
            }
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            IsStarted = false;
            if (_timer != null)
            {
                _timer.Dispose();
            }
        }
    }
}
