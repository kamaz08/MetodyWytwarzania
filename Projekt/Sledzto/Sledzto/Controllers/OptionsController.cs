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
    public class OptionsController : ApiController
    {
        AppDbContext db = new AppDbContext();


        [HttpGet]
        public List<OptionVM> GetOptions(int websiteId)
        {
            return db.Option.Where(x => x.WebsiteId == websiteId)
                .ToList()
                .Select<Option, OptionVM>(x => x)
                .ToList();
        }


        [HttpPost]
        public bool AddWebsite(OptionVM model)
        {
            if (model == null)
                return false;

            db.Option.Add(new Option
            {
                Frequency = model.Frequency,
                OneTime = model.OneTime,
                TrackigTechnique = model.TrackigTechnique,
                WebsiteId = model.WebsiteId
            });
            db.SaveChanges();
            return true;
        }



    }
}
