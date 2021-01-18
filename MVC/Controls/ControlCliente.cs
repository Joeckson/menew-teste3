using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using menew_teste3.MVC.Controls.Service;
using menew_teste3.MVC.Models;

namespace menew_teste3.MVC.Controls
{
	public class ControlCliente
	{
		public enum TipoBusca
		{
			PrincipaisCampos
		}

		public readonly static Dictionary<TipoBusca, string> DicionarioBusca = new Dictionary<TipoBusca, string>()
		{
			{ TipoBusca.PrincipaisCampos,
				"WHERE LOWER(NOME) LIKE '%'||LOWER(@NOME)||'%' OR " +
				"LOWER(TELEFONE) LIKE '%'||LOWER(@TELEFONE)||'%' OR " +
				"LOWER(CIDADE) LIKE '%'||LOWER(@CIDADE)||'%' OR " +
				"LOWER(RUA) LIKE '%'||LOWER(@RUA)||'%'" }
		};

		public static async Task<List<ModelCliente>> AsyncBuscarClientes(ModelCliente Cliente, TipoBusca tipoBusca)
		{
			var DaoCliente = new DAO.DaoClientes();
			var Propertys = new Dictionary<string, object>();
			var DadosCliente = new List<ModelCliente>();

			foreach (var Property in Cliente.ListarPropriedades())
				Propertys.Add(Property, Cliente[Property]);

			try
			{
				DadosCliente = await DaoCliente.AsyncSelect($"SELECT * FROM clientes {DicionarioBusca[tipoBusca]}", Propertys);
			}
			catch (Exception e)
			{
				await LogError.Log(e);
			}

			return DadosCliente;
		}
		public static async Task AsyncCriarCliente(ModelCliente Cliente)
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
			foreach (var Property in Cliente.ListarPropriedades())
				Propertys.Add(Property, Cliente[Property]);
			try
			{
				await DaoCliente.AsyncInsert(sql, Propertys);
			}
			catch (Exception e)
			{
				await LogError.Log(e);
			}
		}

		public static async Task AsyncAtualizarCliente(ModelCliente Cliente)
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
			foreach (var Property in Cliente.ListarPropriedades())
				Propertys.Add(Property, Cliente[Property]);
			try
			{
				await DaoCliente.AsyncUpdate(sql, Propertys);
			}
			catch (Exception e)
			{
				await LogError.Log(e);
			}
		}

		public static async Task AsyncDeletarCliente(ModelCliente Cliente)
		{
			var DaoCliente = new DAO.DaoClientes();
			var Propertys = new Dictionary<string, object>();
			var sql = "DELETE FROM clientes WHERE Id = @Id";
			foreach (var Property in Cliente.ListarPropriedades())
				Propertys.Add(Property, Cliente[Property]);
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
			EmailInvalido,
			NumeroVazio,
			NumeroInvalido,
			TelefoneVazio,
			TelefoneInvalido,
			CepInvalido,
			CepVazio
		}

		public static async Task AsyncValidarDados(ModelCliente Cliente)
		{
			if (Cliente.Cep.Trim() == "")
				throw new InvalidCastException($"Campo cep está vazio [Cep={Cliente.Cep}]", CodeErrorDados.CepVazio.GetHashCode());
			if (!Regex.IsMatch(Cliente.Cep, "[0-9]"))
				throw new InvalidCastException($"Campo cep inválido [CEP={Cliente.Cep}]", CodeErrorDados.CepInvalido.GetHashCode());
			await Task.Delay(5);

			if (Cliente.Nome.Trim() == "")
				throw new InvalidCastException($"Campo nome está vazio [Nome={Cliente.Nome}]", CodeErrorDados.NomeVazio.GetHashCode());
			if (Cliente.Email.Trim() == "")
				throw new InvalidCastException($"Campo e-mail está vazio [E-mail={Cliente.Email}]", CodeErrorDados.EmailVazio.GetHashCode());
			if (!Cliente.Email.Contains("@"))
				throw new InvalidCastException($"Campo e-mail inválido [E-mail={Cliente.Email}]", CodeErrorDados.EmailInvalido.GetHashCode());
			await Task.Delay(5);

			if (Cliente.Telefone.Trim() == "")
				throw new InvalidCastException($"Campo telefone está vazio [Telefone={Cliente.Telefone}]", CodeErrorDados.TelefoneVazio.GetHashCode());
			if (!Regex.IsMatch(Cliente.Telefone, @"(\(\d{2}\)\d{1}|\d{3})(\ |)\d{4}(\-|)\d{4}"))
				throw new InvalidCastException($"Campo telefone inválido [Telefone={Cliente.Telefone}]", CodeErrorDados.TelefoneInvalido.GetHashCode());
			if (Cliente.Numero.Trim() == "")
				throw new InvalidCastException($"Campo Nº está vazio [Número={Cliente.Numero}]", CodeErrorDados.NumeroVazio.GetHashCode());
			if (!Regex.IsMatch(Cliente.Numero, "[0-9]"))
				throw new InvalidCastException($"Campo Nº inválido [Número={Cliente.Numero}]", CodeErrorDados.NumeroInvalido.GetHashCode());
		}
	}
}
