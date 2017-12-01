using Sledzto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sledzto.Controllers
{
    public class UserController : ApiController
    {
        AppDbContext db = new AppDbContext();


        [HttpGet]
        public void Subscribe(int optionId, String email, MessageTypeEnum type)
        {
            db.User.Add(new Models.User
            {
                Email = email,
                MessageType = type,
                OptionId = optionId
            });

            db.SaveChanges();
        }


    }
}
