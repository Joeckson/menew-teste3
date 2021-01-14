namespace menew_teste3.MVC.Models
{
	public class ModelConnection
	{
		public enum datasource
		{
			localhost
		}

		public datasource DataSource { get; set; }
		public string Database { get; set; }
		public string User { get; set; }
		public string Pwr { get; set; }
	}
}
