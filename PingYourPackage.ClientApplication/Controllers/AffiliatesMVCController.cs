using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PingYourPackage.ClientApplication.Models;
using DTO = PingYourPackage.API.Model.Dtos;
using ResponseModels = PingYourPackage.API.Model.ResponseModels;

namespace PingYourPackage.ClientApplication.Controllers
{
    public class AffiliatesMVCController : Controller
    {
        //
        // GET: /AffiliateMVC/
        private PingYourPackage.API.Client.Repositories.AffiliatesRepository repo;

        public ActionResult Index()
        {
            return View();
        }

        public string AllAffiliates()
        {
            using (repo = new API.Client.Repositories.AffiliatesRepository())
            {
                return JsonConvert.SerializeObject(repo.GetAffiliates());
            }
        }

        public string AddNewAffiliate(DTO.AffiliateRecord model)
        {
            if (model != null)
            {
                using (repo = new API.Client.Repositories.AffiliatesRepository())
                {
                    return repo.InsertAffiliate(model);
                }
            }
            return string.Empty;
        }

        public DTO.AffiliateRecord GetAffiliateByReferenceNumber(string refNbr)
        {
            using (repo = new API.Client.Repositories.AffiliatesRepository())
            {
                return repo.GetAffiliateByReferenceNumber(refNbr);
            }
        }

    }
}
