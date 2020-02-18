using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    //We want to download the text from an Url
    public static class Test
    {
        private static string url = @"http://www.google.com/robots.txt";

        public static void NonFacade()
        {
            var request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            using var response = request.GetResponse();
            var dataStream = response.GetResponseStream();
            using var reader = new StreamReader(dataStream);
            var responseFromServer = reader.ReadToEnd();
        }

        public static void Facade()
        {
            var responseFromServer = new WebClient().DownloadString(url);
        }
    }
}