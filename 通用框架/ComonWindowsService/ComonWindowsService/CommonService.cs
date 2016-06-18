using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ComonWindowsService
{
    public sealed class CommonService : ServiceBase
    {
        public CommonService()
        {
            #region 初始化设置
            //此名称必须与Installer中的一致
            this.ServiceName = "CommonService";//Gets or sets the short name used to identify the service to the system.

            //this.AutoLog = true;//Indicates whether to report Start, Stop, Pause, and Continue commands in the event log.

            this.EventLog.Log = "Application"; //将Autolog的时间写到Application中

            this.CanHandlePowerEvent = true;// Gets or sets a value indicating whether the service can handle notifications of computer power status changes.
            this.CanHandleSessionChangeEvent = true;//Gets or sets a value that indicates whether the service can handle session change events received from a Terminal Server session.
            this.CanPauseAndContinue = true;//Gets or sets a value indicating whether the service can be paused and resumed.
            this.CanShutdown = true;// Gets or sets a value indicating whether the service should be notified when the system is shutting down.
            this.CanStop = true;// Gets or sets a value indicating whether the service can be stopped once it  has started.

            #endregion
        }

        /// <summary>
        /// 启动服务时执行
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
        }

        /// <summary>
        /// 停止服务时执行
        /// </summary>
        protected override void OnStop()
        {
            base.OnStop();
        }

        /// <summary>
        /// When implemented in a derived class, System.ServiceProcess.ServiceBase.OnContinue() runs when a Continue command is sent to the service by the Service Control Manager (SCM). Specifies actions to take when a service resumes normal functioning after being paused.
        /// </summary>
        protected override void OnContinue()
        {
            base.OnContinue();
        }

        /// <summary>
        /// When implemented in a derived class, executes when a Pause command is sent to the service by the Service Control Manager (SCM). Specifies actions to take when a service pauses.
        /// </summary>
        protected override void OnPause()
        {
            base.OnPause();
        }

        /// <summary>
        /// OnShutdown(): Called when the System is shutting down
        /// - Put code here when you need special handling
        ///   of code that deals with a system shutdown, such
        ///   as saving special data before shutdown.
        /// </summary>
        protected override void OnShutdown()
        {
            base.OnShutdown();
        }

        /// <summary>
        /// OnCustomCommand(): If you need to send a command to your
        ///   service without the need for Remoting or Sockets, use
        ///   this method to do custom methods.
        /// </summary>
        /// <param name="command">Arbitrary Integer between 128 & 256</param>
        protected override void OnCustomCommand(int command)
        {
            //  A custom command can be sent to a service by using this method:
            //#  int command = 128; //Some Arbitrary number between 128 & 256
            //#  ServiceController sc = new ServiceController("NameOfService");
            //#  sc.ExecuteCommand(command);

            base.OnCustomCommand(command);
        }

        /// <summary>
        /// OnPowerEvent(): Useful for detecting power status changes,
        ///   such as going into Suspend mode or Low Battery for laptops.
        /// </summary>
        /// <param name="powerStatus">The Power Broadcast Status
        /// (BatteryLow, Suspend, etc.)</param>
        protected override bool OnPowerEvent(PowerBroadcastStatus powerStatus)
        {
            return base.OnPowerEvent(powerStatus);
        }

        /// <summary>
        /// OnSessionChange(): To handle a change event
        ///   from a Terminal Server session.
        ///   Useful if you need to determine
        ///   when a user logs in remotely or logs off,
        ///   or when someone logs into the console.
        /// </summary>
        /// <param name="changeDescription">The Session Change
        /// Event that occured.</param>
        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            base.OnSessionChange(changeDescription);
        }

        /// <summary>
        ///
        ///  Disposes of the resources (other than memory) used by the System.ServiceProcess.ServiceBase.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }

}
