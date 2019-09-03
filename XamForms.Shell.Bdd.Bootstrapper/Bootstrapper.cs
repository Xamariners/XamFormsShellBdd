using System;
using CommonServiceLocator;
using Unity;
using Unity.ServiceLocation;
using Xamariners.RestClient.Interfaces;
using Xamariners.RestClient.Models;
using Xamariners.RestClient.Providers;
using Xamariners.RestClient.Services;

namespace XamForms.Shell.Bdd.Bootstrapper
{
    public sealed class BootStrapper
    {
        private readonly IAppSettings _appSettings;
        private static Lazy<IUnityContainer> _container;

        public static IAppSettings AppSettings { get; private set; }

        public static void Initialize(IAppSettings appSettings)
        {
            AppSettings = appSettings;
            new BootStrapper(appSettings);
        }

        public static void Dispose()
        {
            if (Container != null)
            {
                foreach (var reg in Container.Registrations)
                    reg.LifetimeManager.RemoveValue();
               
                Container.Dispose();
                _container = null;

                ServiceLocator.SetLocatorProvider(null);
            }
        }

        private BootStrapper(IAppSettings appSettings)
        {
            _appSettings = appSettings;

            _container = new Lazy<IUnityContainer>(() =>
            {
                UnityContainer container = new UnityContainer();
                container.RegisterInstance(appSettings);

                // Register other services
                RegisterCommonServices(container);

                RegisterServices(container);

                var locator = new UnityServiceLocator(container);
                ServiceLocator.SetLocatorProvider(() => locator);

                return container;
            });
        }

        /// <summary>
        /// Unity Container
        /// </summary>
        public static IUnityContainer Container => _container?.Value;

        /// <summary>
        /// Use this method to register anything shared external services in non shared projects.
        /// Example: register for OTPServices, etc.
        /// </summary>
        /// <param name="container"></param>
        public void RegisterCommonServices(IUnityContainer container)
        {
            container.RegisterInstance<IAppSettings>(_appSettings);

            // TODO: should take timeout and enable rewrite val from _appSettings
            var apiConfiguration = new ApiConfiguration(_appSettings.ApiEndpoint, _appSettings.ApiAuthEndpoint, null,
                null, int.Parse(_appSettings.ApiTimeOut), false);
            container.RegisterInstance<IApiConfiguration>(apiConfiguration);

            var idsConfiguration = new IDSConfiguration(_appSettings.IdentityBaseUrl, _appSettings.IdentityClientId, _appSettings.IdentityTenantId, _appSettings.IdentityClientSecret,
                _appSettings.IdentityClientResource, _appSettings.IdentityScope);

            container.RegisterInstance<IIDSConfiguration>(idsConfiguration);

            container.RegisterSingleton<IRestClient, RestClientMSAL>();
            container.RegisterSingleton<IRestConfiguration, RestConfiguration>();
            container.RegisterSingleton<IUrlRewriteProvider, UrlRewriteProvider>();

          
            container.RegisterSingleton<IAdAuthService, AdAuthService>();
        }

        /// <summary>
        /// Use this method to register anything concrete external services in non shared projects.
        /// Example: register for OTPServices, etc.
        /// </summary>
        /// <param name="container"></param>
        public void RegisterServices(IUnityContainer container)
        {
           // container.RegisterType<IMyService,MyService>();
        }
    }
}
