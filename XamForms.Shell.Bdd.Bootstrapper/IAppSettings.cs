namespace XamForms.Shell.Bdd.Bootstrapper
{
    public interface IAppSettings
    {
        // GENERAL
        string ApiEndpoint { get; }
        string ApiAuthEndpoint { get; }
        string ApiLoginType { get; }
        string ApiTimeOut { get; }

        // IDS
        string IdentityBaseUrl { get; }
        string IdentityClientId { get; }
        string IdentityTenantId { get; }
        string IdentityClientSecret { get; }
        string IdentityClientResource { get; }
        string IdentityScope { get; }
    }
}