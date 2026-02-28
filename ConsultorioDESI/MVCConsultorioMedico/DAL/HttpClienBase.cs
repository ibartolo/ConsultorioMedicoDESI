using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Web;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace MVCConsultorioMedico.DAL
{
	public class HttpClienBase
	{
		private HttpClient httpClient;
		private string BaseURL;

		public HttpClienBase()
		{
			BaseURL = ConfigurationManager.AppSettings["BaseUrlApi"];

			httpClient = new HttpClient()
			{ 
				Timeout = TimeSpan.FromMinutes(2),
				BaseAddress = new Uri(BaseURL)
			};
		}

		public async Task<T> RequestAsync<T>(string endPoint, HttpMethod method, T contect, Func<string, T> func, string token = "", string conetntype = "application/json") where T : class
        {
			using (var r = new HttpRequestMessage()
			{ 
				Content = (contect != null ? new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(contect), Encoding.UTF8, conetntype) : null),
				Method = method,
				RequestUri = new Uri(httpClient.BaseAddress, endPoint)
            })
			using (var responseMeesage = await httpClient.SendAsync(r))
			{
				if (responseMeesage.IsSuccessStatusCode)
				{
					var stringContent = await responseMeesage.Content.ReadAsStringAsync();
					return func?.Invoke(stringContent);
				}
				else
				{
					return default(T);
				}
			}
		}

		public async Task<T> TokenAsync<T>(string endPoint, IEnumerable<KeyValuePair<string, string>> content, string contenType = "application/json")
		{
			SetParameterHeader(contenType, string.Empty);
            using (HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(endPoint, new FormUrlEncodedContent(content)))
            {
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    using (var st = new StreamReader(await httpResponseMessage.Content.ReadAsStreamAsync()))
                    {
                        return JsonConvert.DeserializeObject<T>(await st.ReadToEndAsync());
                    }
                }
                else
                {
                    return default(T);
                }
            }
        }

		private void SetParameterHeader(string contenType, string token)
		{
			httpClient.DefaultRequestHeaders.Clear();
			httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(contenType));
			if (!string.IsNullOrEmpty(token))
			{
				httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
			}
		}
	}
}