using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Net;
using PingYourPackage.Domain.Contracts;
using PingYourPackage.Domain.Api;
using DTO = PingYourPackage.API.Model.Dtos;


namespace PingYourPackage.API.Controllers
{
    public class AffiliateShipmentsController : ApiController
    {
        public IAffiliateShipmentsControllerLogic controller;

        public AffiliateShipmentsController(AffiliateShipmentsControllerLogic controller)
        {
            this.controller = controller;
        }

        public HttpResponseMessage Get(int id)
        {
            var shipments = this.controller.GetShipmentsByAffiliateId(id);

            return shipments != null ? this.Request.CreateResponse<IEnumerable<DTO.ShipmentRecord>>(HttpStatusCode.OK, shipments) : new HttpResponseMessage(HttpStatusCode.NotFound); 
        }


    }
}
