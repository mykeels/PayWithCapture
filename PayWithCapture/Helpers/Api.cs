using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using PayWithCapture.Common;
using PayWithCapture.Extensions;
using System.Threading.Tasks;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace PayWithCapture.Helpers
{
    public class Api
    {
        private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            // If the certificate is a valid, signed certificate, return true.
            if (error == SslPolicyErrors.None)
            {
                return true;
            }

            Console.WriteLine("X509Certificate [{0}] Policy Error: '{1}'",
                cert.Subject,
                error.ToString());

            return false;
        }

        public static string Get(string url, Dictionary<string, string> headers = null, NetworkCredential credentials = null)
        {
            WebClient client = new WebClient();
            if ((headers != null))
            {
                foreach (var h_loopVariable in headers)
                {
                    var h = h_loopVariable;
                    client.Headers.Add(h.Key, h.Value);
                }
            }
            if (credentials != null)
            {
                client.Credentials = credentials;
                client.Headers.Add("Authorization", "Basic " +
                    Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(credentials.UserName + ":" +
                    credentials.Password)));
            }
            client.BaseAddress = url;
            Stream stream = new MemoryStream();
            stream = client.OpenRead(url);
            string b = "";
            using (StreamReader br = new StreamReader(stream, Encoding.UTF8))
            {
                try
                {
                    b = br.ReadToEnd();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return b;
        }

        public static T Get<T>(string url, Dictionary<string, string> headers = null, NetworkCredential credentials = null)
        {
            string response = Get(url, headers, credentials);
            T ret = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response);
            return ret; 
        }

        public static async Task<string> GetAsync(string url, Dictionary<string, string> headers = null, NetworkCredential credentials = null)
        {
            return await Task.Run(() => Get(url, headers, credentials));
        }

        public static async Task<T> GetAsync<T>(string url, Dictionary<string, string> headers = null, NetworkCredential credentials = null)
        {
            return await Task<T>.Run(() =>
            {
                return Get<T>(url, headers, credentials);
            });
        }

        public static string Post(string url, string value, string contenttype = Constants.CONTENT_TYPE_JSON,
            Dictionary<string, string> headers = null, bool useSsl = false, NetworkCredential credentials = null)
        {
            if (useSsl)
            {
                ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
            }
            WebClient w = new WebClient();
            if ((headers != null))
            {
                foreach (var h_loopVariable in headers)
                {
                    var h = h_loopVariable;
                    w.Headers.Add(h.Key, h.Value);
                }
            }
            if (credentials != null)
            {
                w.Credentials = credentials;
                w.Headers.Add("Authorization", "Basic " +
                    Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(credentials.UserName + ":" +
                    credentials.Password)));
            }
            w.Headers.Add("Content-Type", contenttype);
            w.Headers.Add("Accept", "text/plain, " + contenttype);
            return w.UploadString(url, value);
        }

        public static T Post<T>(string url, string value, string contenttype = Constants.CONTENT_TYPE_JSON, Dictionary<string, string> headers = null, bool useSsl = false, NetworkCredential credentials = null)
        {
            string response = Post(url, value, contenttype, headers, useSsl, credentials);
            T ret = default(T);
            if (contenttype == Constants.CONTENT_TYPE_XML)
            {
                ret = System.Xml.Linq.XElement.Parse(response).ToObject<T>();
            }
            else
            {
                ret = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response);
            }

            return ret;
        }

        public static async Task<string> PostAsync(string url, string value, string contenttype = Constants.CONTENT_TYPE_JSON, Dictionary<string, string> headers = null, bool useSsl = false, NetworkCredential credentials = null)
        {
            return await Task<string>.Run(() => Post(url, value, contenttype, headers, useSsl, credentials));
        }

        public static async Task<T> PostAsync<T>(string url, string value, string contenttype = Constants.CONTENT_TYPE_JSON, Dictionary<string, string> headers = null, bool useSsl = false, NetworkCredential credentials = null)
        {
            return await Task<T>.Run(() => Post<T>(url, value, contenttype, headers, useSsl, credentials));
        }

        public static string UrlFormEncode(string json)
        {
            var dict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                if (!string.IsNullOrEmpty(kvp.Key) && !string.IsNullOrEmpty(kvp.Value))
                {
                    if (sb.Length > 0) sb.Append('&');
                    sb.Append(System.Web.HttpUtility.UrlEncode(kvp.Key));
                    sb.Append('=');
                    sb.Append(System.Web.HttpUtility.UrlEncode(kvp.Value));
                }
            }
            return sb.ToString();
        }
    }
}
