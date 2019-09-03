using System;
using Xamariners.RestClient.Interfaces;
using Xamariners.RestClient.Providers;

namespace XamForms.Shell.Bdd.Bootstrapper
{
    public class RestConfiguration : IRestConfiguration
    {
        public IUrlRewriteProvider UrlRewriteProvider { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IApiConfiguration ApiConfiguration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double TimeOut => throw new NotImplementedException();
    }
}
