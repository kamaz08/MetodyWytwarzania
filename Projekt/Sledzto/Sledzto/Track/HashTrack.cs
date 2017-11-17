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
        private HashAlgorithm sha;

        public HashTrack(Website website, int time) : base(website, time)
        {
            LastHash = getHash();
        }


        protected override string CheckChange()
        {
            var temp = getHash();
            if (LastHash != temp)
                return $"Zmiana na stronie {website.Name}\n pod adresem {website.Url}\n Metoda Hash\n\n Sledzto";
            return null;
        }

        private String getHash()
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(website.Url);
            myRequest.Method = "GET";
            string result;
            using (WebResponse myResponse = myRequest.GetResponse())
            {
                myResponse.Close();
                using (StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8))
                {
                    result = sr.ReadToEnd();

                    sr.Close();
                }
            }
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