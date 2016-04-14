using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Formatting;
using PingYourPackage.Domain.Contracts;
using PingYourPackage.Domain.Api;
using DTO = PingYourPackage.API.Model.Dtos;
using System.Threading.Tasks;
using System.Threading;

namespace PingYourPackage.API.Controllers
{
    public class PackageReceiverController : ApiController
    {
        public IPackageReceiverControllerLogic controller;

        public PackageReceiverController(PackageReceiverControllerLogic packageReceiverControllerLogic)
        {
            this.controller = packageReceiverControllerLogic;
        }

        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            var packageReceivers = this.controller.GetAllPackageReceivers();

            return packageReceivers != null ? this.Request.CreateResponse<IEnumerable<DTO.PackageReceiverRecord>>(HttpStatusCode.OK, packageReceivers) : new HttpResponseMessage(HttpStatusCode.NotFound); 
        }
    }
}
