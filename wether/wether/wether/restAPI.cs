using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace wether
{
    class restAPI
    {
        public static async Task<T> GetDataAsync<T>(string url) where T : class
        {
            T res = null;
            using (HttpClient client = new HttpClient ())
            {
                HttpResponseMessage response = await client.GetAsync(url);
 
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        res = JsonConvert.DeserializeObject<T>(content);
                    }
                    catch (Exception e)
                    {

                        throw;
                    }
                    
                }
                return res;
            }
        }
    }


}
 