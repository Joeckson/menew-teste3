using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using menew_teste3.MVC.Models;

namespace menew_teste3.MVC.DAO
{
	public class DaoConnection : IDisposable
	{
		public FbConnection Connection { get; set; }
		public static ModelConnection PathDB { get; set; }
		public DaoConnection()
		{
			OpenConnection();
		}

		public void OpenConnection()
		{
			try
			{
				Connection = new FbConnection(ConnectionString());
				Connection.Open();
			}
			catch (FbException e)
			{
				MessageBox.Show(e.Message);
			}
		}

		public string ConnectionString() =>
			$"Server={PathDB.DataSource}; User={PathDB.User}; Password={PathDB.Pwr}; Database=\"{PathDB.Database}\"";

		public void Dispose()
		{
			Connection.Close();
			GC.SuppressFinalize(this);
		}
	}
}