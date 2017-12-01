using Sledzto.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;

namespace Sledzto.Track
{
    public class HashTrack : TrackBase
    {
        private String LastHash;

        public HashTrack(Option option) : base(option)
        {
            LastHash = option.History
                .OrderByDescending(x => x.DateTime)
                .Select(x => x.Last)
                .FirstOrDefault() ?? getHash();
        }


        protected override Mess CheckChange()
        {
            var temp = getHash();
            if (LastHash != temp)
                return new Mess
                {
                    Message = $"Zmiana na stronie {website.Name}\n pod adresem {website.Url}\n Metoda Hash\n\n Sledzto \n Czas {DateTime.Now}",
                    Last = temp
                };
            return null;
        }

        private String getHash()
        {
            String result;
            using (var webClient = new System.Net.WebClient())
                result = webClient.DownloadString(website.Url);

            return getHash(result);
        }

        private static string getHash(string input)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();
            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);
            return Convert.ToBase64String(byteHash);
        }


    }
}