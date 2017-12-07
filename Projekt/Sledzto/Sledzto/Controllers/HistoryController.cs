using Sledzto.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sledzto.Controllers
{
    public class HistoryController : ApiController
    {
        AppDbContext db = new AppDbContext();


        [HttpGet]
        public List<HistoryVM> GetHistory(int optionId)
        {
            return db.History.Where(x => x.OptionId == optionId)
                .OrderByDescending(x => x.DateTime)
                .Take(10)
                .ToList()
                .Select(x=>new HistoryVM
                {
                    DateTime = x.DateTime.ToLongDateString(),
                    Message = x.Message
                })
                .ToList();
        }
    }
}
