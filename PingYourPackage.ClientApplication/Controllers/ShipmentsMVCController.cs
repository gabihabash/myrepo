using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Text;
using PingYourPackage.ClientApplication.Models;
using DTO = PingYourPackage.API.Model.Dtos;
using ResponseModels = PingYourPackage.API.Model.ResponseModels;

namespace PingYourPackage.ClientApplication.Controllers
{
    public class ShipmentsMVCController : Controller
    {
        //
        // GET: /ShipmentsMVC/
        private PingYourPackage.API.Client.Repositories.ShipmentsRepository repo;

        public ActionResult Index()
        {
            List<ShipmentViewModel> shipments = null;
            var client = new HttpClient();
            var task = client.GetAsync("http://localhost:60595/api/shipments").ContinueWith((responseTask) =>
            {
                var response = responseTask.Result;
                var readTask = response.Content.ReadAsAsync<List<ShipmentViewModel>>();
                readTask.Wait();
                shipments = readTask.Result;
            });
            task.Wait();
            return View(shipments);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public void Create(ShipmentViewModel model)
        {
            if (model != null)
            {
                var client = new HttpClient();
                string postData = JsonConvert.SerializeObject(model);
                HttpContent content = new StringContent(postData, Encoding.UTF8, "application/json");
                client.PostAsync("http://localhost:57986/api/shipments", content).ContinueWith((responseTask) =>
                {
                    responseTask.Result.EnsureSuccessStatusCode();
                });
            }
        }

        public ActionResult Details(int id)
        {
            ShipmentViewModel shipment = null;
            HttpClient client = new HttpClient();
            var task = client.GetAsync("http://localhost:57986/api/shipments/" + id).ContinueWith((responseTask) => {
                var response = responseTask.Result;
                var readTask = response.Content.ReadAsAsync<ShipmentViewModel>();
                readTask.Wait();
                shipment = readTask.Result;
            });
            task.Wait();
            return View(shipment);
        }

        public string AllShipments()
        {
            using (repo = new API.Client.Repositories.ShipmentsRepository())
            {
                return JsonConvert.SerializeObject(repo.GetShipments());
            }

        }

        public string AffiliateShipments(int id)
        {
            using (repo = new API.Client.Repositories.ShipmentsRepository())
            {
                return JsonConvert.SerializeObject(repo.GetShipmentsByAffiliateId(id));
            }
        }

        [HttpPost]
        public string AddNewShipment(DTO.ShipmentRecord model)
        {
            if (model != null)
            {
                using (repo = new API.Client.Repositories.ShipmentsRepository())
                {
                    return repo.InsertShipment(model);
                }
            }
            return string.Empty;
        }

        [HttpPut]
        public string UpdateShipment(DTO.ShipmentRecord model)
        {
            if (model != null)
            {
                using (repo = new API.Client.Repositories.ShipmentsRepository())
                {
                    return repo.UpdateShipment(model.Id, model);
                }
            }
            return string.Empty;
        }

        [HttpDelete]
        public ResponseModels.Result DeleteShipment(int id)
        {
            if (id > 0)
            {
                using (repo = new API.Client.Repositories.ShipmentsRepository())
                {
                    return repo.RemoveShipment(id);                    
                }
            }
            return null;
        }
    }
}
