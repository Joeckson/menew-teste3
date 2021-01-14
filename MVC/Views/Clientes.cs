using MaterialSkin;
using MaterialSkin.Controls;
using menew_teste3.MVC.DAO;
using System;
using menew_teste3.MVC.Models;
using menew_teste3.MVC.Controls;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Forms;
using menew_teste3.MVC.Controls.Service;
using System.IO;

namespace menew_teste3
{
	public partial class Clientes : MaterialForm
	{
		public Dictionary<ControlCliente.CodeErrorDados, Action> ActionDadosValidados { get; set; }
		public TypeInput CurrentTypeInput { get; set; }
		public enum TypeInput
		{
			Insert,
			Update
		}

		public Clientes()
		{
			InitializeComponent();

			var materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.AddFormToManage(this);
			materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
			materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

			ActionDadosValidados = new Dictionary<ControlCliente.CodeErrorDados, Action>()
			{
				{ ControlCliente.CodeErrorDados.CepInvalido, ()=>{ TxCep.Select(); } },
				{ ControlCliente.CodeErrorDados.CepVazio, ()=>{ TxCep.Select(); } },
				{ ControlCliente.CodeErrorDados.EmailVazio, ()=>{ TxEmail.Select(); } },
				{ ControlCliente.CodeErrorDados.NomeVazio, ()=>{ TxNomeCliente.Select(); } },
				{ ControlCliente.CodeErrorDados.NumeroVazio, ()=>{ TxNumero.Select(); } },
				{ ControlCliente.CodeErrorDados.TelefoneVazio, ()=>{ TxTelefone.Select(); } },
			};
		}

		private void Clientes_Load(object sender, EventArgs e)
		{
			var FileIni = new IniReader($@"{Directory.GetCurrentDirectory()}\menew.ini");
			if (!File.Exists(FileIni.GetValue("PATH", "DB")))
			{
				MessageBox.Show($"Favor configurar o caminho do banco de dados no arquivo menew.ini.\nO arquivo menew.ini deverá estar nesse diretório:\n{Directory.GetCurrentDirectory()}\\menew.ini", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Close();
			}
			DaoConnection.PathDB = new ModelConnection()
			{
				DataSource = ModelConnection.datasource.localhost,
				Database = FileIni.GetValue("PATH", "DB"),
				Pwr = "masterkey",
				User = "SYSDBA"
			};

			CarregarDadosGrid();

			TxNomeCliente.Select();
		}

		public async Task CarregarDadosGrid()
		{
			GridClientes.DataSource = new List<string>();

			var dao = new DaoClientes();
			var Clientes = await dao.AsyncSelect("select * from clientes");

			GridClientes.DataSource = Clientes;
			try
			{
				if (GridClientes.Columns.Count > 0)
					GridClientes.Columns[0].Visible = false;
				if (GridClientes.Rows.Count > 0)
				{
					GridClientes.Rows[0].Selected = true;
					GridClientes.Rows[0].Cells[0].Selected = true;
				}
			}
			catch
			{

			}
			GridClientes.Select();
		}

		private void GridClientes_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			var User = new ModelUser()
			{
				Id = Convert.ToInt32(GridClientes.Rows[e.RowIndex].Cells[0].Value),
				Nome = GridClientes.Rows[e.RowIndex].Cells[1].Value.ToString(),
				Telefone = GridClientes.Rows[e.RowIndex].Cells[2].Value.ToString(),
				Email = GridClientes.Rows[e.RowIndex].Cells[3].Value.ToString(),
				Cep = GridClientes.Rows[e.RowIndex].Cells[4].Value.ToString(),
				Cidade = GridClientes.Rows[e.RowIndex].Cells[5].Value.ToString(),
				Estado = GridClientes.Rows[e.RowIndex].Cells[6].Value.ToString(),
				Rua = GridClientes.Rows[e.RowIndex].Cells[7].Value.ToString(),
				Numero = (GridClientes.Rows[e.RowIndex].Cells[8].Value ?? "").ToString(),
				Complemento = GridClientes.Rows[e.RowIndex].Cells[9].Value.ToString(),
			};
			TxNomeCliente.Text = User.Nome;
			TxTelefone.Text = User.Telefone;
			TxEmail.Text = User.Email;
			TxCep.Text = User.Cep;
			TxCidade.Text = User.Cidade;
			TxUf.Text = User.Estado;
			TxRua.Text = User.Rua;
			TxNumero.Text = User.Numero.Trim();
			TxComplemento.Text = User.Complemento;
		}

		private void BtNovoCliente_Click(object sender, EventArgs e)
		{
			CurrentTypeInput = TypeInput.Insert;

			#region CLEAN FIELDS
			TxNomeCliente.Text = "";
			TxTelefone.Text = "";
			TxEmail.Text = "";
			TxCep.Text = "";
			TxCidade.Text = "";
			TxUf.Text = "";
			TxRua.Text = "";
			TxNumero.Text = "";
			TxComplemento.Text = "";
			#endregion
			TxNomeCliente.Select();

			Pn1.Visible = true;
			GridClientes.Enabled = false;
		}

		private async void BtSalvar_Click(object sender, EventArgs e)
		{
			var MessageErrorDados = "";
			var codeErrorDados = new ControlCliente.CodeErrorDados();

			if (CurrentTypeInput == TypeInput.Update)
			{
				var User = new ModelUser()
				{
					Id = Convert.ToInt32(GridClientes.CurrentRow.Cells[0].Value),
					Nome = TxNomeCliente.Text,
					Telefone = TxTelefone.Text,
					Email = TxEmail.Text,
					Cep = TxCep.Text,
					Cidade = TxCidade.Text,
					Estado = TxUf.Text,
					Rua = TxRua.Text,
					Numero = TxNumero.Text,
					Complemento = TxComplemento.Text,
				};

				try
				{
					await ControlCliente.AsyncValidarDadods(User);

					Pn1.Visible = false;
					GridClientes.Enabled = true;

					await ControlCliente.AsyncAtualizarCliente(User);
				}
				catch (Exception err)
				{
					codeErrorDados = (ControlCliente.CodeErrorDados)err.HResult;
					MessageErrorDados = err.Message;
					await LogError.Log(err);
				}

			}
			else if (CurrentTypeInput == TypeInput.Insert)
			{
				var User = new ModelUser()
				{
					Nome = TxNomeCliente.Text,
					Telefone = TxTelefone.Text,
					Email = TxEmail.Text,
					Cep = TxCep.Text,
					Cidade = TxCidade.Text,
					Estado = TxUf.Text,
					Rua = TxRua.Text,
					Numero = TxNumero.Text,
					Complemento = TxComplemento.Text,
				};

				try
				{
					await ControlCliente.AsyncValidarDadods(User);

					Pn1.Visible = false;
					GridClientes.Enabled = true;

					await ControlCliente.AsyncCriarCliente(User);
				}
				catch (Exception err)
				{
					codeErrorDados = (ControlCliente.CodeErrorDados)err.HResult;
					MessageErrorDados = err.Message;
					await LogError.Log(err);
				}

			}

			if (codeErrorDados != ControlCliente.CodeErrorDados.NONE)
			{
				ActionDadosValidados[codeErrorDados]();
				MessageBox.Show(MessageErrorDados, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
				await CarregarDadosGrid();

		}

		private async void BtDeletarCliente_Click(object sender, EventArgs e)
		{
			var Msg = MessageBox.Show(
				"Deseja realmente deletar esse cliente?",
				"Atenção!",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Exclamation
			);
			if (Msg == DialogResult.Yes)
			{
				var User = new ModelUser()
				{
					Id = Convert.ToInt32(GridClientes.CurrentRow.Cells[0].Value),
					Nome = TxNomeCliente.Text,
					Telefone = TxTelefone.Text,
					Email = TxEmail.Text,
					Cep = TxCep.Text,
					Cidade = TxCidade.Text,
					Estado = TxUf.Text,
					Rua = TxRua.Text,
					Numero = TxNumero.Text,
					Complemento = TxComplemento.Text,
				};

				await ControlCliente.AsyncDeletarCliente(User);

				await CarregarDadosGrid();
			}
		}

		private void BtEditarCliente_Click(object sender, EventArgs e)
		{
			CurrentTypeInput = TypeInput.Update;
			Pn1.Visible = true;
			GridClientes.Enabled = false;
		}

		private void BtCancelar_Click(object sender, EventArgs e)
		{
			Pn1.Visible = false;
			GridClientes.Enabled = true;
			GridClientes.CurrentRow.Selected = true;
			GridClientes.Select();
		}

		private void TxCep_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter | e.KeyCode == Keys.Tab)
			{
				BtCarregarCep_Click(sender, new EventArgs());
			}
		}

		private void TxNumero_Enter(object sender, EventArgs e)
		{
			if (TxCep.Text.Trim() != "")
				BtCarregarCep_Click(sender, e);
		}

		private async void BtCarregarCep_Click(object sender, EventArgs e)
		{
			var _ = TxCep.SelectionStart;
			try
			{
				var DadosCep = await ControlCep.BuscarCep(TxCep.Text);

				TxCep.Text = DadosCep.cep.Replace("-", "");
				TxCidade.Text = DadosCep.localidade;
				TxUf.Text = DadosCep.uf;
				TxRua.Text = DadosCep.logradouro;
				TxComplemento.Text = DadosCep.complemento;

				TxNumero.Select();
			}
			catch
			{
				await LogError.Log(DictError: new Dictionary<string, object>()
					{
						{ "Não foi possível adcionar o CEP ", $"[CEP = {TxCep.Text}]" }
					});
			}
			TxCep.SelectionStart = _;
		}
	}
}
