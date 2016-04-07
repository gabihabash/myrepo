using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using PingYouPackage.Api.Resolver.Resolver;
using PingYourPackage.Domain.Resolver;

namespace PingYourPackage.API.Resolver
{
    public static class Configuration
    {
        public static UnityResolver Configure()
        {
            UnityContainer container = new UnityContainer();

            DependencyConfiguration.Configure(container);
        
            return new UnityResolver(container);
        }

    }
}
