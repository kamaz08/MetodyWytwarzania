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
        private bool oneTime;
        private int optionId;

        public TrackBase(Option option)
        {
            db = new AppDbContext();
            emailList = db.User.Where(x => x.OptionId == option.Id).Select(x => x.Email).ToList();

            this.website = option.Website;
            this.time = option.Frequency;
            this.oneTime = option.OneTime;
            this.optionId = option.Id;
        }

        public void TrackPage()
        {
            var thread = new Thread(start =>
            {
                while (true)
                {
                    var mess = CheckChange();
                    if (mess != null)
                    {
                        SendMessage(mess.Message);
                        db.History.Add(new History
                        {
                            DateTime = DateTime.Now,
                            Message = mess.Message,
                            Last = mess.Last,
                            OptionId = optionId
                        });

                        db.SaveChanges();

                        if (oneTime) break;
                    }
                    Thread.Sleep(1000 * 60 * (time == 0 ? 1 : time));
                }
            });
            thread.Start();
        }

        private void SendMessage(String mess)
        {
            emailList = db.User.Where(x => x.OptionId == optionId).Select(x => x.Email).ToList();


            Sender.SendEmailAsync(mess, emailList);
        }

        protected virtual Mess CheckChange()
        {
            return null;
        }

        protected class Mess
        {
            public String Message { get; set; }
            public String Last { get; set; }
        }

    }
}