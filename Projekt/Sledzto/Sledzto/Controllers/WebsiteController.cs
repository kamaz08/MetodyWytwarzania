using Sledzto.Models;
using Sledzto.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sledzto.Controllers
{
    public class WebsiteController : ApiController
    {
        AppDbContext db = new AppDbContext();


        [HttpGet]
        public List<Website> GetWebsite()
        {
            return db.Website.ToList();
        }

        [HttpGet]
        public List<WebsiteVM> GetListWebstite()
        {
            return db.Website.Select(x => new WebsiteVM
            {
                Id = x.Id,
                Name = x.Name,
                Url = x.Url,
                OptionList = db.Option.Where(y => y.WebsiteId == x.Id).Select(y => y.TrackigTechnique).ToList()
            }).ToList();
        }


        [HttpPost]
        public bool AddWebsite(Website model)
        {
            if (model == null || model.Name == null || model.Url == null)
                return false;

            db.Website.Add(new Website
            {
                Name = model.Name,
                Url = model.Url
            });
            db.SaveChanges();
            return true;
        }

    }
}
