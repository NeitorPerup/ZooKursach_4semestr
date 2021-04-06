using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrskiyPeriodBusinessLogic.ViewModels;
using UrskiyPeriodBusinessLogic.BusinessLogics;
using UrskiyPeriodBusinessLogic.Interfaces;
using UrskiyPeriodDatabaseImplement.Implements;
using Unity;
using Unity.Lifetime;

namespace UrskiyPeriodView
{
    static class Program
    {
        public static UserViewModel User { get; set; }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new UnityContainer().AddExtension(new Diagnostic());
            Application.Run(container.Resolve<FormMain>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IPaymentStorage, PaymentStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReserveStorage, ReserveStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IRouteStorage, RouteStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IUserStorage, UserStorage>(new
            HierarchicalLifetimeManager());

            currentContainer.RegisterType<PaymentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReserveLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<RouteLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<UserLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogic>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
