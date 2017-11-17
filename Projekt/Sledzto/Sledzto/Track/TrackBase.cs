using Sledzto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Sledzto.Track
{
    public abstract class TrackBase
    {
        protected Website website;
        protected AppDbContext db;
        private List<String> emailList;
        protected int time;

        public TrackBase(Website website, int time)
        {
            db = new AppDbContext();
            emailList = db.Users.Where(x => x.WebsiteId == website.Id).Select(x => x.Email).ToList();
            this.website = website;
            this.time = time;
            TrackPage();
        }

        private void TrackPage()
        {
            var thread = new Thread(start =>
            {
                while (true)
                {
                    var mess = CheckChange();
                    if (mess != null)
                        SendMessage(mess);

                    Thread.SpinWait(time);
                }
            });
            thread.Start();
        }

        private void SendMessage(String mess)
        {
            Sender.SendEmailAsync(mess, emailList);
        }

        protected virtual String CheckChange()
        {
            return null;
        }
    }
}