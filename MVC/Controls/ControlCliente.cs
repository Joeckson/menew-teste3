using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using menew_teste3.MVC.Controls.Service;
using menew_teste3.MVC.Models;

namespace menew_teste3.MVC.Controls
{
	public class ControlCliente
	{
		public static async Task AsyncCriarCliente(ModelUser User)
		{
			var DaoCliente = new DAO.DaoClientes();
			var Propertys = new Dictionary<string, object>();
			var sql = @"
				INSERT INTO clientes (
					NOME, EMAIL, CEP, ESTADO, RUA,
					COMPLEMENTO, TELEFONE, CIDADE, NUMERO
				) VALUES (
					@NOME, @EMAIL, @CEP, @ESTADO, @RUA,
					@COMPLEMENTO, @TELEFONE, @CIDADE, @NUMERO
				)";
			foreach (var Property in User.ListarPropriedades())
				Propertys.Add(Property, User[Property]);
			try
			{
				await DaoCliente.AsyncInsert(sql, Propertys);
			}
			catch (Exception e)
			{
				await LogError.Log(e);
			}
		}

		public static async Task AsyncAtualizarCliente(ModelUser User)
		{
			var DaoCliente = new DAO.DaoClientes();
			var Propertys = new Dictionary<string, object>();
			var sql = @"
				UPDATE clientes SET
					NOME = @NOME,
					EMAIL = @EMAIL,
					CEP = @CEP,
					ESTADO = @ESTADO,
					RUA = @RUA,
					COMPLEMENTO = @COMPLEMENTO,
					TELEFONE = @TELEFONE,
					CIDADE = @CIDADE,
					NUMERO = @NUMERO
				WHERE Id = @Id";
			foreach (var Property in User.ListarPropriedades())
				Propertys.Add(Property, User[Property]);
			try
			{
				await DaoCliente.AsyncUpdate(sql, Propertys);
			}
			catch (Exception e)
			{
				await LogError.Log(e);
			}
		}

		public static async Task AsyncDeletarCliente(ModelUser User)
		{
			var DaoCliente = new DAO.DaoClientes();
			var Propertys = new Dictionary<string, object>();
			var sql = "DELETE FROM clientes WHERE Id = @Id";
			foreach (var Property in User.ListarPropriedades())
				Propertys.Add(Property, User[Property]);
			try
			{
				await DaoCliente.AsyncUpdate(sql, Propertys);
			}
			catch (Exception e)
			{
				await LogError.Log(e);
			}
		}

		public enum CodeErrorDados : int
		{
			NONE,
			NomeVazio,
			EmailVazio,
			NumeroVazio,
			TelefoneVazio,
			CepInvalido,
			CepVazio
		}
		public static async Task AsyncValidarDadods(ModelUser User)
		{
			if (User.Cep.Trim() == "")
				throw new InvalidCastException($"Campo cep está vazio [Cep={User.Cep}]", CodeErrorDados.CepVazio.GetHashCode());
			if (!Regex.IsMatch(User.Cep.Replace("-", ""), "[0-9]"))
				throw new InvalidCastException($"Não foi possível inserir porque o Cep é inválido [CEP={User.Cep}]");
			await Task.Delay(5);

			if (User.Nome.Trim() == "")
				throw new InvalidCastException($"Campo nome está vazio [Nome={User.Nome}]", CodeErrorDados.NomeVazio.GetHashCode());
			if (User.Email.Trim() == "")
				throw new InvalidCastException($"Campo e-mail está vazio [E-mail={User.Email}]", CodeErrorDados.EmailVazio.GetHashCode());
			await Task.Delay(5);

			if (User.Telefone.Trim() == "")
				throw new InvalidCastException($"Campo telefone está vazio [Telefone={User.Telefone}]", CodeErrorDados.TelefoneVazio.GetHashCode());
			if (User.Numero.Trim() == "")
				throw new InvalidCastException($"Campo Nº está vazio [Número={User.Numero}]", CodeErrorDados.NumeroVazio.GetHashCode());
		}
	}
}
