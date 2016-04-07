using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using DomainControllers = PingYourPackage.Domain.Api;
using DomainContracts = PingYourPackage.Domain.Contracts;
using DataRepository = PingYourPackage.Domain.Data.Repositories;
using DataContracts = PingYourPackage.Domain.Data.Contracts;
using DataModels = PingYourPackage.Domain.Data.Models;

namespace PingYourPackage.Domain.Resolver
{
    public static class DependencyConfiguration
    {
        public static void Configure(UnityContainer container)
        {
            container.RegisterType<DomainContracts.IShipmentsControllerLogic, DomainControllers.ShipmentsControllerLogic>(new HierarchicalLifetimeManager());
            container.RegisterType<DataContracts.IShipmentRepository<DataModels.Shipment>, DataRepository.ShipmentRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<DomainContracts.IAffiliatesControllerLogic, DomainControllers.AffiliatesControllerLogic>(new HierarchicalLifetimeManager());
            container.RegisterType<DataContracts.IAffiliateRepository<DataModels.Affiliate>, DataRepository.AffiliateRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<DomainContracts.IAffiliateShipmentsControllerLogic, DomainControllers.AffiliateShipmentsControllerLogic>(new HierarchicalLifetimeManager());

            
        }

    }
}
