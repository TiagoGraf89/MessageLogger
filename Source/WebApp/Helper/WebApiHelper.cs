using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using WebApp.Models;
using System.Security.Claims;
using System.Web.Mvc;
using System.Text;
using System.Configuration;

namespace WebApp.Helper
{
    public class WebApiHelper
    {
        public HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiUri"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public async System.Threading.Tasks.Task<string> Authenticate(string appId, string secret)
        {
            using (var client = CreateClient())
            {
                string basicAuth = string.Format("{0}:{1}", appId, secret);
                string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(basicAuth));
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + svcCredentials);
                var response = client.PostAsync("api/default/auth", null);
                AuthResponse result = await response.Result.Content.ReadAsAsync<AuthResponse>();
                if (result != null && response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return result.Access_Token; 
                }
                else
                    return null;
            }
        }

        public async System.Threading.Tasks.Task<T> Get<T>(string uri)
        {
            using (var client = CreateClient())
            {
                var response = client.GetAsync(uri);
                T result = await response.Result.Content.ReadAsAsync<T>();
                return result;
            }
        }
        public async System.Threading.Tasks.Task<T> Post<T>(string uri, object json)
        {
            using (var client = CreateClient())
            {
                var response = client.PostAsJsonAsync(uri, json);
                T result = await response.Result.Content.ReadAsAsync<T>();
                return result;
            }
        }

        public async System.Threading.Tasks.Task<SaveResponse> PostMessageLog(MessageViewModel json,
            string token)
        {
            using (var client = CreateClient())
            {
                string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(token));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + svcCredentials);
                var response = client.PostAsJsonAsync("api/default/log", json);
                if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    SaveResponse result = await response.Result.Content.ReadAsAsync<SaveResponse>();
                    return result;
                }
                else
                    throw new Exception("Error, Server Returned: " + response.Result.StatusCode.ToString());
            }
        }
    }
}