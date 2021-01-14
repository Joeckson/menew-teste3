using menew_teste3.MVC.Models;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System;
using menew_teste3.MVC.Controls.Service;
using System.Collections.Generic;

namespace menew_teste3.MVC.Controls
{
	public class ControlCep
	{
		public static async Task<ModelJsonCep> BuscarCep(string cep)
		{
			var ModelCep = new ModelJsonCep()
			{
				cep = cep.Replace("-", "")
			};
			var DictError = new Dictionary<string, object>();
			DictError.Add("URL de consulta CEP : ", $"http://viacep.com.br/ws/{ModelCep.cep}/json/");

			var Request = WebRequest.Create($"http://viacep.com.br/ws/{ModelCep.cep}/json/");
			Request.Method = "GET";

			try
			{
				var Response = await Request.GetResponseAsync();
				var StreamResponse = new StreamReader(Response.GetResponseStream());
				var ResponseStr = await StreamResponse.ReadToEndAsync();
				ModelCep = JsonConvert.DeserializeObject<ModelJsonCep>(ResponseStr);

				Response.Close();
				StreamResponse.Close();
			}
			catch (Exception e)
			{
				await LogError.Log(e, DictError);
				throw e;
			}

			return ModelCep;
		}
	}
}
