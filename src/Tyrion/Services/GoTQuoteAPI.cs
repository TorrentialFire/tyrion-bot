using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Tyrion.Services
{
    public class GoTQuoteAPI
    {
        private static readonly string BaseURL = "https://got-quotes.herokuapp.com/quotes?char=";
        public GoTQuoteAPI() {}
        
        public async Task<JObject> Request(string character)
        {
            string responseBody = await Tyrion.HttpClient.GetStringAsync($"{BaseURL}{WebUtility.UrlEncode(character)}");

            JObject result = null;
            try
            {
                result = JObject.Parse(responseBody);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }
    }
}