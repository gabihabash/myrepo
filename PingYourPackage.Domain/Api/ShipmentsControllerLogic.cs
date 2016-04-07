using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO = PingYourPackage.API.Model.Dtos;
using Model = PingYourPackage.Domain.Data.Models;
using Repository = PingYourPackage.Domain.Data.Repositories;
using Contracts = PingYourPackage.Domain.Contracts;
using ResponseModels = PingYourPackage.API.Model.ResponseModels;

namespace PingYourPackage.Domain.Api
{
    public class ShipmentsControllerLogic : Contracts.IShipmentsControllerLogic
    {
        private readonly Data.Contracts.IShipmentRepository<Model.Shipment> Repository;

        //public ShipmentsControllerLogic()
        //{
        //    this.Repository = new Repository.ShipmentRepository();
        //}

        public ShipmentsControllerLogic(Repository.ShipmentRepository shipmentRepository)
        {
            this.Repository = shipmentRepository;
        }

        public DTO.ShipmentRecord GetShipment(int id)
        {
            var query = this.Repository.GetSingle(id);
            if (query != null)
            {                
                return AutoMapper.Mapper.Map<Model.Shipment, DTO.ShipmentRecord>(query);
            }
            return null;

        }

        public IEnumerable<DTO.ShipmentRecord> GetAllShipments()
        {
            var query = this.Repository.GetAll();
            if (query != null && query.Count() > 0)
            {
                var shipmentRecords = new List<DTO.ShipmentRecord>();
                foreach (var item in query)
                {
                    var shipmentItem = AutoMapper.Mapper.Map<Model.Shipment, DTO.ShipmentRecord>(item);
                    shipmentRecords.Add(shipmentItem);
                }
                return shipmentRecords;
            }
            return null;
        }

        public DTO.ShipmentRecord InsertShipment(DTO.ShipmentRecord shipmentRecord)
        {
            int result = 0;
            if (shipmentRecord != null)
            {
                var shipment = AutoMapper.Mapper.Map<DTO.ShipmentRecord, Model.Shipment>(shipmentRecord);
                result = this.Repository.Add(shipment);

                if (result > 0)
                {
                    return AutoMapper.Mapper.Map<Model.Shipment, DTO.ShipmentRecord>(shipment);
                }
            }
            return null;            
        }

        public DTO.ShipmentRecord ModifyShipment(int id, DTO.ShipmentRecord shipmentRecord)
        {
            int result = 0;
            if (id > 0 && shipmentRecord != null)
            {
                var shipment = AutoMapper.Mapper.Map<DTO.ShipmentRecord, Model.Shipment>(shipmentRecord);
                result = this.Repository.Edit(id, shipment);
                return AutoMapper.Mapper.Map<Model.Shipment, DTO.ShipmentRecord>(shipment);
            }
            return null;
        }

        public ResponseModels.Result RemoveShipment(int id)
        {
            int result = 0;
            if (id > 0)
            {
                result = this.Repository.Delete(id);
                if (result > 0)
                {
                    return null;
                }
            }
            return new ResponseModels.Result("Record could not be found.");
            
        }

        public DTO.ShipmentRecord GetShipmentByTrackingNumber(string number)
        {
            if (!string.IsNullOrWhiteSpace(number))
            {
                var query = this.Repository.GetShipmentByTrackingNumber(number);
                if (query != null)
                {
                    return AutoMapper.Mapper.Map<Model.Shipment, DTO.ShipmentRecord>(query);
                }
            }
            return null;
        }
        
        
    }
}
