using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO = PingYourPackage.API.Model.Dtos;
using ResponseModels = PingYourPackage.API.Model.ResponseModels;

namespace PingYourPackage.Domain.Contracts
{
    public interface IShipmentsControllerLogic
    {
        DTO.ShipmentRecord GetShipment(int id);
        IEnumerable<DTO.ShipmentRecord> GetAllShipments();
        DTO.ShipmentRecord InsertShipment(DTO.ShipmentRecord record);
        DTO.ShipmentRecord ModifyShipment(int id, DTO.ShipmentRecord record);
        ResponseModels.Result RemoveShipment(int id);
        DTO.ShipmentRecord GetShipmentByTrackingNumber(string number);
    }
}
