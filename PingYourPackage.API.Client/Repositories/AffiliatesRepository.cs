using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using DTO = PingYourPackage.API.Model.Dtos;
using ResponseModels = PingYourPackage.API.Model.ResponseModels;
using Repository = PingYourPackage.API.Client.Repositories;
using System.Net.Http.Formatting;


namespace PingYourPackage.API.Client.Repositories
{
    public class AffiliatesRepository : IDisposable
    {
        private readonly string ApiBaseUrl = "http://localhost:60595/";

        public ICollection<DTO.AffiliateRecord> GetAffiliates()
        {
            List<DTO.AffiliateRecord> result = null;
            HttpClient client = new HttpClient();
            string apiUrl = string.Format(@"{0}{1}", this.ApiBaseUrl, "api/Affiliates");
            var task = client.GetAsync(apiUrl).ContinueWith((System.Threading.Tasks.Task<HttpResponseMessage> responseTask) =>
            {
                var response = responseTask.Result;
                var readTask = response.Content.ReadAsAsync<List<DTO.AffiliateRecord>>();
                result = readTask.Result;
            });
            task.Wait();
            return result;
        }

        public DTO.AffiliateRecord GetAffiliate(int id)
        {
            DTO.AffiliateRecord result = null;
            HttpClient client = new HttpClient();
            string apiUrl = string.Format(@"{0}{1}", this.ApiBaseUrl, "api/Affiliates/" + id);
            var task = client.GetAsync(apiUrl).ContinueWith((System.Threading.Tasks.Task<HttpResponseMessage> responseTask) =>
            {
                var response = responseTask.Result;
                var readTask = response.Content.ReadAsAsync<DTO.AffiliateRecord>();
                result = readTask.Result;
            });
            task.Wait();
            return result;
        }

        public DTO.AffiliateRecord GetAffiliateByReferenceNumber(string number)
        {
            DTO.AffiliateRecord result = null;
            HttpClient client = new HttpClient();
            string apiUrl = string.Format(@"{0}{1}{2}", this.ApiBaseUrl, "api/Affiliates?number=", number);
            var task = client.GetAsync(apiUrl).ContinueWith((System.Threading.Tasks.Task<HttpResponseMessage> responseTask) =>
            {
                var response = responseTask.Result;
                var readTask = response.Content.ReadAsAsync<DTO.AffiliateRecord>();
                result = readTask.Result;
            });
            task.Wait();
            return result;
        }

        public string InsertAffiliate(DTO.AffiliateRecord newAffiliate)
        {
            HttpResponseMessage response = null;
            HttpClient client = new HttpClient();
            string apiUrl = string.Format(@"{0}{1}", this.ApiBaseUrl, "api/Affiliates");
            HttpContent content = new ObjectContent<DTO.AffiliateRecord>(newAffiliate, new JsonMediaTypeFormatter());
            var task = client.PostAsync(apiUrl, content).ContinueWith((System.Threading.Tasks.Task<HttpResponseMessage> responseTask) =>
            {
                response = responseTask.Result;
            });
            task.Wait();
            return response.Headers.Location.AbsoluteUri;
        }

        public ResponseModels.Result RemoveAffiliate(int id)
        {
            ResponseModels.Result result = null;
            HttpClient client = new HttpClient();
            string apiUrl = string.Format(@"{0}{1}", this.ApiBaseUrl, "api/Affiliates/" + id);
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
