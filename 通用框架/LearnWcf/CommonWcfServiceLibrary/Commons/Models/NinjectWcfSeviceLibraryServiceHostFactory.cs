using System.ServiceModel;
using CommonWcfServiceLibrary.Removable.Models;
using Ninject;
using Ninject.Extensions.Wcf;
using Ninject.Web.Common;

namespace CommonWcfServiceLibrary.Commons.Models
{
    /// <summary>
    /// 创建serviceHostFactory类
    /// </summary>
    public class NinjectWcfSeviceLibraryServiceHostFactory:NinjectServiceHostFactory
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public NinjectWcfSeviceLibraryServiceHostFactory()
        {
            var kernel = new StandardKernel();
            //绑定disposable对象在requestscope中
            kernel.Bind<DisposableModel>().ToSelf().InRequestScope();
            kernel.Bind<ServiceHost>().To<NinjectServiceHost>();

            SetKernel(kernel);
        }
    }
}