using System;
using System.Collections.Generic;
using System.Text;
using Xamariners.RestClient.Interfaces;
using Xamariners.RestClient.Providers;

namespace XamForms.Shell.Bdd.Bootstrapper
{
    public class UrlRewriteProvider : UrlRewriteProviderBase
    {
        public UrlRewriteProvider(IApiConfiguration apiConfiguration) : base(apiConfiguration)
        {
        }

        protected override void SetUrlMapping()
        {

        }
    }
}
