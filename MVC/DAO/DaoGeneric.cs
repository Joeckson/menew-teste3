using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using menew_teste3.MVC.Controls.Service;
using menew_teste3.MVC.Models;

namespace menew_teste3.MVC.DAO
{
	public abstract class DaoGeneric<T> where T : ModelGeneric
	{
		public async Task AsyncInsert(string sql, Dictionary<string, object> parameters)
		{
			var DictError = new Dictionary<string, object>()
			{
				{ "Inserindo um dado", "" },
				{ "Tipo do objeto do Model", typeof(T) },
				{"<--->","" },
				{ "SQL utilizado", sql },
				{ "Conexão com banco", DaoConnection.PathDB.Database }
			};

			if (sql is null)
			{
				await LogError.Log(DictError: DictError);
				return;
			}

			try
			{

				using (var conn = new DaoConnection())
				{
					using (var cmd = conn.Connection.CreateCommand())
					{
						cmd.CommandText = sql;
						if (!(parameters is null))
							foreach (var param in parameters)
								cmd.Parameters.Add(param.Key, param.Value);

						await cmd.ExecuteNonQueryAsync();
					}
				}
			}
			catch (Exception e)
			{
				await LogError.Log(e, DictError);
				throw e;
			}
			finally
			{
				await LogError.Log(DictError: DictError);
			}
		}

		public async Task AsyncUpdate(string sql, Dictionary<string, object> parameters)
		{
			var DictError = new Dictionary<string, object>()
			{
				{ "Atualizando um dado", "" },
				{ "Tipo do objeto do Model", typeof(T) },
				{"<--->","" },
				{ "SQL utilizado", sql },
				{ "Conexão com banco", DaoConnection.PathDB.Database }
			};

			if (sql is null)
			{
				await LogError.Log(DictError: DictError);
				return;
			}

			try
			{
				using (var conn = new DaoConnection())
				{
					using (var cmd = conn.Connection.CreateCommand())
					{
						cmd.CommandText = sql;
						if (!(parameters is null))
							foreach (var param in parameters)
								cmd.Parameters.Add(param.Key, param.Value);

						await cmd.ExecuteNonQueryAsync();
					}
				}
			}
			catch (Exception e)
			{
				await LogError.Log(e, DictError);
				throw e;
			}
			finally
			{
				await LogError.Log(DictError: DictError);
			}
		}

		public async Task AsyncDelete(string sql, Dictionary<string, object> parameters)
		{
			var DictError = new Dictionary<string, object>()
			{
				{ "Deletando um dado", "" },
				{ "Tipo do objeto do Model", typeof(T) },
				{"<--->","" },
				{ "SQL utilizado", sql },
				{ "Conexão com banco", DaoConnection.PathDB.Database }
			};

			if (sql is null)
			{
				await LogError.Log(DictError: DictError);
				return;
			}

			try
			{
				using (var conn = new DaoConnection())
				{
					using (var cmd = conn.Connection.CreateCommand())
					{
						cmd.CommandText = sql;
						if (!(parameters is null))
							foreach (var param in parameters)
								cmd.Parameters.Add(param.Key, param.Value);

						await cmd.ExecuteNonQueryAsync();
					}
				}
			}
			catch (Exception e)
			{
				await LogError.Log(e, DictError);
				throw e;
			}
			finally
			{
				await LogError.Log(DictError: DictError);
			}
		}

		public async Task<List<T>> AsyncSelect(string sql, Dictionary<string, object> parameters = null)
		{
			var DictError = new Dictionary<string, object>()
			{
				{ "Selecionando dado(s)", "" },
				{ "Tipo do objeto do Model", typeof(T) },
				{"<--->","" },
				{ "SQL utilizado", sql },
				{ "Conexão com banco", DaoConnection.PathDB.Database }
			};

			var ListModel = new List<T>();
			if (sql is null)
				return new List<T>();

			try
			{
				using (var conn = new DaoConnection())
				{
					using (var cmd = conn.Connection.CreateCommand())
					{
						cmd.CommandText = sql;
						if (!(parameters is null))
							foreach (var param in parameters)
								cmd.Parameters.Add(param.Key, param.Value);

						using (var reader = await cmd.ExecuteReaderAsync())
						{
							while (reader.Read())
							{
								T Model = (T)Activator.CreateInstance(typeof(T));
								foreach (var property in Model.ListarPropriedades())
									Model[property] = reader[property];
								ListModel.Add(Model);
							}
						}
					}
				}
			}
			catch (Exception e)
			{
				await LogError.Log(e, DictError);
				throw e;
			}
			finally
			{
				await LogError.Log(DictError: DictError);
			}

			return ListModel;
		}
	}
}
