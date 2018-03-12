using MyApp.BLL;
using MyApp.BLL.Ports;
using MyApp.Repository;
using MyApp.Repository.Ports;
using MyApp.Repository.Repo;
using MyApp.UI.Managers;
using System;
using Unity;

namespace MyApp.UI
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container

        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;

        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // Register database
            container.RegisterType(typeof(IRepository<>), typeof(Repository.Repo.Repository<>));

            // Register repositories
            container.RegisterType<ITaskRepository, TaskRepository>();
            container.RegisterType<ITaskManageRepository, TaskManageRepository>();
            container.RegisterType<IFrequencyRepository, FrequencyRepository>();
            container.RegisterType<IStatusRepository, StatusRepository>();

            // Register services
            container.RegisterType<ITaskService, TaskService>();
            container.RegisterType<ITaskManageService, TaskManageService>();
            container.RegisterType<IFrequencyService, FrequencyService>();
            container.RegisterType<IStatusService, StatusService>();

            // Register managers
            container.RegisterType<TaskManager>("TaskManager");
        }
    }
}