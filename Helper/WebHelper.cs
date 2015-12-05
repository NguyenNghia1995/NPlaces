using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NPlaces.Helper
{
    public class WebHelper
    {
        public WebHelper()
        {

        }
        public static async Task<string> GetStringFromRequest(string url)
        {
            string result = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var httpReponse = await httpClient.GetAsync(url);
                    result = await httpReponse.Content.ReadAsStringAsync();
                }
                catch(Exception ex)
                {

                    Debug.WriteLine(ex.Message);
                }
            }
            return result;
        }
    }
}
