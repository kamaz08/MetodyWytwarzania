using Sledzto.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;

namespace Sledzto.Track
{
    public class RegexTrack : TrackBase
    {
        private String Reg;

        public RegexTrack(Option option) : base(option)
        {
            Reg = option.Options;
        }


        protected override Mess CheckChange()
        {

            String result;
            using (var webClient = new System.Net.WebClient())
                result = webClient.DownloadString(website.Url);

            Regex regex = new Regex(Reg);
            Match match = regex.Match(result);
            if (match.Success)
                return new Mess
                {
                    Message = $"Zmiana na stronie {website.Name}\n pod adresem {website.Url}\n Metoda wyrażenie regularne: {Reg}\n\n Sledzto \n Czas {DateTime.Now}",
                    Last = ""
                };
            return null;
        }
    }
}