using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ComonWindowsService
{
    [RunInstaller(true)]
    public class CommonServiceInstaller : Installer
    {
        /// <summary>
        /// 将initalization代码放在此处
        /// </summary>
        public CommonServiceInstaller()
        {
            ServiceProcessInstaller serviceProcessInstaller = new ServiceProcessInstaller();
            ServiceInstaller serviceInstaller = new ServiceInstaller();

            //设置service count信息
            serviceProcessInstaller.Account = ServiceAccount.LocalSystem;//设置一个较高的优先级
            serviceProcessInstaller.Username = null;
            serviceProcessInstaller.Password = null;

            //# Service Information
            serviceInstaller.DisplayName = "My Common Service";//在service中显示的名称
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            //# 必须与service中的名称一致
            serviceInstaller.ServiceName = "CommonService";

            this.Installers.Add(serviceProcessInstaller);
            this.Installers.Add(serviceInstaller);
        }
    }
}
