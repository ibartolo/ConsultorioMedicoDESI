using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Web;
using System.Text;

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
	}
}