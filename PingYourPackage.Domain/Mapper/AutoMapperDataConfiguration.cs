using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model = PingYourPackage.Domain.Data.Models;
using DTO = PingYourPackage.API.Model.Dtos;

namespace PingYourPackage.Domain.Mapper
{
    public static class AutoMapperDataConfiguration
    {
        public static void Configure()
        {
            AutoMapper.Mapper.CreateMap<Model.Shipment, DTO.ShipmentRecord>();
            AutoMapper.Mapper.CreateMap<DTO.ShipmentRecord, Model.Shipment>();
            AutoMapper.Mapper.CreateMap<Model.Affiliate, DTO.AffiliateRecord>();
            AutoMapper.Mapper.CreateMap<DTO.AffiliateRecord, Model.Affiliate>();
            AutoMapper.Mapper.CreateMap<Model.PackageReceiver, DTO.PackageReceiverRecord>();
            AutoMapper.Mapper.CreateMap<DTO.PackageReceiverRecord, Model.PackageReceiver>();

        }
    }
}
