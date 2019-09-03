using PCLAppConfig;

namespace XamForms.Shell.Bdd.Bootstrapper
{
    public class AppSettings : IAppSettings
    {
        public AppSettings()
        {
            // GENERAL
            ApiEndpoint = ConfigurationManager.AppSettings["api.endpoint"];
            ApiAuthEndpoint = ConfigurationManager.AppSettings["api.auth"];
            ApiLoginType = ConfigurationManager.AppSettings["api.logintype"];
            ApiTimeOut = ConfigurationManager.AppSettings["api.timeout"];

            //IDS
            IdentityBaseUrl = ConfigurationManager.AppSettings["api.auth"];
            IdentityClientId = ConfigurationManager.AppSettings["identity.client.id"];
            IdentityTenantId = ConfigurationManager.AppSettings["identity.tenant.id"];
            IdentityClientSecret = ConfigurationManager.AppSettings["identity.client.secret"];
            IdentityClientResource = ConfigurationManager.AppSettings["identity.client.resource"];
            IdentityScope = ConfigurationManager.AppSettings["identity.client.scope"];
        }

        // GENERAL
        public string ApiEndpoint { get; }
        public string ApiAuthEndpoint { get; }
        public string ApiLoginType { get; }
        public string ApiTimeOut { get; }

        // IDS
        public string IdentityBaseUrl { get; }
        public string IdentityClientId { get; }
        public string IdentityTenantId { get; }
        public string IdentityClientSecret { get; }
        public string IdentityClientResource { get; }
        public string IdentityScope { get; }
    }
}