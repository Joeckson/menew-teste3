using menew_teste3.APIs;
using menew_teste3.MVC.Controls.Service;
using System;
using System.Threading.Tasks;

namespace menew_teste3.MVC.Controls
{
	public static class ControlBuscaCepLogradouro
	{
		public async static Task<string> AsyncBuscarMeuCep(string Logradouro, string Bairro)
		{
			try
			{
				return await EncontrarCepLogradouro.SearchCep($"{Logradouro}, {Bairro}");
			} catch (Exception e)
			{
				await LogError.Log(e);
			}
			return default;
		}
	}
}
