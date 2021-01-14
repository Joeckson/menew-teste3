using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace menew_teste3.MVC.Controls.Service
{
	public static class LogError
	{
		public static async Task Log(Exception e = null, Dictionary<string, object> DictError = null)
		{
			await Task.Run(() =>
			{
				var MessageLog = new StringBuilder();
				MessageLog.Append($"--> {DateTime.Now} <--\n");
				if (!(e is null))
				{
					MessageLog.Append($"--> Origem da chamada : {e.Source}\n");
					MessageLog.Append($"--> Código da chamada : {e.HResult}\n");
					MessageLog.Append($"--> Mensagem de retorno : {e.Message}\n\n");
				}

				if (!(DictError is null))
				{
					MessageLog.Append($"*** Mensagem de retorno direcionada ***\n");
					foreach (var ErrorMsg in DictError)
						MessageLog.Append($"--> {ErrorMsg.Key} -> {ErrorMsg.Value}\n");
					MessageLog.Append($"\n");
				}
				File.AppendAllText($@"{Directory.GetCurrentDirectory()}\LogReturn.log", MessageLog.ToString());
			});
		}
	}
}
