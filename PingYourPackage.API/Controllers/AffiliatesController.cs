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

namespace PingYourPackage.API.Controllers
{
    public class AffiliatesController : ApiController
    {
        public IAffiliatesControllerLogic controller;       

        public AffiliatesController(AffiliatesControllerLogic affiliateControllerLogic)
        {
            this.controller = affiliateControllerLogic;
        }
        
        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            var affiliates = this.controller.GetAllAffiliates();

            return affiliates != null ? this.Request.CreateResponse<IEnumerable<DTO.AffiliateRecord>>
                (HttpStatusCode.OK, affiliates) : new HttpResponseMessage(HttpStatusCode.NotFound); 
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            var affiliate = this.controller.GetAffiliate(id);
                        
            return affiliate != null ? this.Request.CreateResponse<DTO.AffiliateRecord>(HttpStatusCode.OK, affiliate) : new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        // GET api/<controller>?number=5
        public HttpResponseMessage Get(string number)
        {
            var affiliate = this.controller.GetAffiliateByReferenceNumber(number);

            return affiliate != null ? this.Request.CreateResponse<DTO.AffiliateRecord>(HttpStatusCode.OK, affiliate) : new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        // POST api/<controller>
        public HttpResponseMessage Post(DTO.AffiliateRecord item)
        {
            var affiliate = this.controller.InsertAffiliate(item);
            
            if (affiliate == null)
            { 
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            var responseMessage = Request.CreateResponse(HttpStatusCode.Created);
            responseMessage.Headers.Location = new Uri(string.Format(@"{0}/{1}", Request.RequestUri, affiliate.Id.ToString()));
            
            return responseMessage;
        }    
   
        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, DTO.AffiliateRecord item)
        {
            var affiliate = this.controller.ModifyAffiliate(id, item);

            if (affiliate == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            var responseMessage = Request.CreateResponse(HttpStatusCode.OK);
            responseMessage.Headers.Location = new Uri(Request.RequestUri.ToString());

            return responseMessage;
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            var responseResult = this.controller.RemoveAffiliate(id);           
            return responseResult == null ? Request.CreateResponse(HttpStatusCode.OK) : Request.CreateResponse(HttpStatusCode.NotFound, responseResult.Message);
        }

    }
}
