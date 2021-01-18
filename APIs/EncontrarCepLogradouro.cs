using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace menew_teste3.APIs
{
	public class EncontrarCepLogradouro
	{
		private static bool Complete { get; set; }
		[STAThread]
		public static async Task<string> SearchCep(string Address)
		{
			string Cep = "";

			var web = new WebBrowser();
			web.ScriptErrorsSuppressed = false;
			web.Navigating += Web_Navigating;
			web.DocumentCompleted += Web_DocumentCompleted;
			Address = "CEP " + Address;
			web.Navigate($"https://www.google.com/search?q={WebUtility.UrlEncode(Address)}");

			while (web.Document is null || !Complete)
				await Task.Delay(100);

			foreach (HtmlElement span in web.Document.GetElementsByTagName("span"))
			{
				if (span.OuterHtml.Length > 9 && span.OuterHtml.Substring(6,3).ToUpper() == "CEP")
				{
					Cep = span.OuterHtml.Substring(10, 9).Replace("-", "");
					return Cep;
				}
				await Task.Delay(50);
			}

			return Cep;
		}

		private static void Web_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			Complete = false;
		}

		private static void Web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			((WebBrowser)sender).Document.Window.Error +=
				new HtmlElementErrorEventHandler(Window_Error);
			Complete = true;
		}

		private static void Window_Error(object sender,
		 HtmlElementErrorEventArgs e)
		{
			// Ignore the error and suppress the error dialog box. 
			e.Handled = true;
		}
	}
}
