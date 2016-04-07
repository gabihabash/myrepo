using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Text;
using DTO = PingYourPackage.API.Model.Dtos;
using ResponseModels = PingYourPackage.API.Model.ResponseModels;
using Repository = PingYourPackage.API.Client.Repositories;
using System.Net.Http.Formatting;
using System.Threading;

namespace PingYourPackage.API.Client.Repositories
{
    public class ShipmentsRepository : IDisposable
    {
        private readonly string ApiBaseUrl = "http://localhost:60595/";

        public ICollection<DTO.ShipmentRecord> GetShipments()
        {
            List<DTO.ShipmentRecord> result = null;
            HttpClient client = new HttpClient();
            string apiUrl = string.Format(@"{0}{1}", this.ApiBaseUrl,"api/Shipments");
            var task = client.GetAsync(apiUrl).ContinueWith((System.Threading.Tasks.Task<HttpResponseMessage> responseTask) =>
            {
                var response = responseTask.Result;
                var readTask = response.Content.ReadAsAsync<List<DTO.ShipmentRecord>>();
                result = readTask.Result;
            });
            task.Wait();
            return result;
        }

        public DTO.ShipmentRecord GetShipment(int id)
        {
            DTO.ShipmentRecord result = null;
            HttpClient client = new HttpClient();
            string apiUrl = string.Format(@"{0}{1}", this.ApiBaseUrl, "api/Shipments/"+id);
            var task = client.GetAsync(apiUrl).ContinueWith((System.Threading.Tasks.Task<HttpResponseMessage> responseTask) =>
            {
                var response = responseTask.Result;
                var readTask = response.Content.ReadAsAsync<DTO.ShipmentRecord>();
                result = readTask.Result;
            });
            task.Wait();
            return result;
        }

        public ICollection<DTO.ShipmentRecord> GetShipmentsByAffiliateId(int id)
        {
            List<DTO.ShipmentRecord> results = null;
            HttpClient client = new HttpClient();
            string apiUrl = string.Format(@"{0}{1}{2}", this.ApiBaseUrl, "api/AffiliateShipments/", id);
            var task = client.GetAsync(apiUrl).ContinueWith((System.Threading.Tasks.Task<HttpResponseMessage> responseTask) =>
            {
                var response = responseTask.Result;
                var readTask = response.Content.ReadAsAsync<List<DTO.ShipmentRecord>>();
                results = readTask.Result;
            });
            task.Wait();
            return results;
        }

        public string InsertShipment(DTO.ShipmentRecord newShipment)
        {
            HttpResponseMessage response = null;
            HttpClient client = new HttpClient();
            string apiUrl = string.Format(@"{0}{1}", this.ApiBaseUrl, "api/Shipments");
            HttpContent content = new ObjectContent<DTO.ShipmentRecord>(newShipment, new JsonMediaTypeFormatter());
            var task = client.PostAsync(apiUrl, content).ContinueWith((System.Threading.Tasks.Task<HttpResponseMessage> responseTask) =>
            {
                response = responseTask.Result;
            });
            task.Wait();
            return response.Headers.Location.AbsoluteUri;
        }

        public string UpdateShipment(int shipmentId, DTO.ShipmentRecord modifiedShipment)
        {
            HttpResponseMessage response = null;
            HttpClient client = new HttpClient();
            string apiUrl = string.Format(@"{0}{1}", this.ApiBaseUrl, "api/Shipments/"+shipmentId);
            HttpContent content = new ObjectContent<DTO.ShipmentRecord>(modifiedShipment, new JsonMediaTypeFormatter());
            var task = client.PutAsync(apiUrl, content).ContinueWith((System.Threading.Tasks.Task<HttpResponseMessage> responseTask) =>
            {
                response = responseTask.Result;
            });
            task.Wait();
            return response.Headers.Location.AbsoluteUri;
        }

        public ResponseModels.Result RemoveShipment(int id)
        {
            ResponseModels.Result result = null;
            HttpClient client = new HttpClient();
            string apiUrl = string.Format(@"{0}{1}",this.ApiBaseUrl, "api/shipments/"+id);
            var task = client.DeleteAsync(apiUrl).ContinueWith((System.Threading.Tasks.Task<HttpResponseMessage> responseTask) =>
            {
                var response = responseTask.Result;
                var readTask = response.Content.ReadAsAsync<ResponseModels.Result>();
                result = readTask.Result;
            });
            task.Wait();
            return result;
        }

        public void Dispose()
        {
            
        }
    }
}
