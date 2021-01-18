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
using System.Drawing;
using menew_teste3.MVC.Views;

namespace menew_teste3
{
	public partial class Clientes : MaterialForm
	{
		public Dictionary<ControlCliente.CodeErrorDados, Action> AcaoDadosValidados { get; set; }
		public TipoEntrada AtualTipoEntrada { get; set; }
		public enum TipoEntrada
		{
			Inserir,
			Atualizar
		}
		public List<ModelCliente> ListaClientes { get; set; }



		public Clientes()
		{
			InitializeComponent();

			#region ESTILIZANDO EM MODO ESCURO, ETC...
			var materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.AddFormToManage(this);
			materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
			materialSkinManager.EnforceBackcolorOnAllComponents = false;
			materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
			#endregion

			AcaoDadosValidados = new Dictionary<ControlCliente.CodeErrorDados, Action>()
			{
				{ ControlCliente.CodeErrorDados.CepInvalido, ()=>{ TxCep.Select(); } },
				{ ControlCliente.CodeErrorDados.CepVazio, ()=>{ TxCep.Select(); } },
				{ ControlCliente.CodeErrorDados.EmailVazio, ()=>{ TxEmail.Select(); } },
				{ ControlCliente.CodeErrorDados.EmailInvalido, ()=>{ TxEmail.Select(); } },
				{ ControlCliente.CodeErrorDados.NomeVazio, ()=>{ TxNomeCliente.Select(); } },
				{ ControlCliente.CodeErrorDados.NumeroVazio, ()=>{ TxNumero.Select(); } },
				{ ControlCliente.CodeErrorDados.NumeroInvalido, ()=>{ TxNumero.Select(); } },
				{ ControlCliente.CodeErrorDados.TelefoneVazio, ()=>{ TxTelefone.Select(); } },
				{ ControlCliente.CodeErrorDados.TelefoneInvalido, ()=>{ TxTelefone.Select(); } },
			};
		}

		private void Clientes_Load(object sender, EventArgs e)
		{
			#region VALIDANDO CAMINHO DO BANCO
			var CurrentDir = Directory.GetCurrentDirectory();
			if (!File.Exists($@"{CurrentDir}\menew.ini"))
				File.WriteAllText($@"{CurrentDir}\menew.ini", $"[DB]\nPATH={CurrentDir}\\Database\\CLIENTS.fdb");

			var FileIni = new IniReader($@"{CurrentDir}\menew.ini");
			if (!File.Exists(FileIni.GetValue("PATH", "DB")))
			{
				MessageBox.Show($"Favor configurar o caminho do banco de dados no arquivo menew.ini.\nO arquivo menew.ini deverá estar nesse diretório:\n{Directory.GetCurrentDirectory()}\\menew.ini", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Close();
			}
			#endregion

			DaoConnection.PathDB = new ModelConnection()
			{
				DataSource = ModelConnection.datasource.localhost,
				Database = FileIni.GetValue("PATH", "DB"),
				Pwr = "masterkey",
				User = "SYSDBA"
			};

			CarregarDadosGrid();

			#region ESTILIZANDO
			LbSearch.BackColor = Color.Transparent;
			LbSearch.ForeColor = Color.White;
			LbSearch.Font = new Font("Segoe UI", 13);
			LbSearch.Text = " Click para buscar o cliente";

			TxNomeCliente.Select();
			#endregion
		}



		private void GridClientes_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			var User = new ModelCliente()
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



		private async void BtSalvar_Click(object sender, EventArgs e)
		{
			var MessageErrorDados = "";
			int currentIndex = 0;
			var codeErrorDados = new ControlCliente.CodeErrorDados();

			if (AtualTipoEntrada == TipoEntrada.Atualizar)
			{
				currentIndex = GridClientes.CurrentRow.Index;
				var User = new ModelCliente()
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
					await ControlCliente.AsyncValidarDados(User);

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
				GridClientes.Rows[currentIndex].Cells[0].Selected = true;
			}
			else if (AtualTipoEntrada == TipoEntrada.Inserir)
			{
				var User = new ModelCliente()
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
					await ControlCliente.AsyncValidarDados(User);

					Pn1.Visible = false;
					GridClientes.Enabled = true;

					await ControlCliente.AsyncCriarCliente(User);

					if (GridClientes.Rows.Count > 0)
						currentIndex = GridClientes.RowCount;
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
				try
				{
					AcaoDadosValidados[codeErrorDados]();
					MessageBox.Show(MessageErrorDados, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception err)
				{
					await LogError.Log(err);
				}
			}
			else
			{
				await CarregarDadosGrid();
				if (GridClientes.Rows.Count >= currentIndex)
				{
					try
					{
						GridClientes.Rows[currentIndex].Selected = true;
						GridClientes.Rows[currentIndex].Cells[1].Selected = true;
					}
					catch (Exception err) { }
					GridClientes.Select();
					TxNomeCliente.Select();
				}
			}
		}

		private void BtCancelar_Click(object sender, EventArgs e)
		{
			LimparCampos();
			BloquearCampos();

			Pn1.Visible = false;
			GridClientes.Enabled = true;
			if (GridClientes.Rows.Count > 0)
				GridClientes.CurrentRow.Selected = true;
			GridClientes.Select();
		}



		private void BtNovoCliente_Click(object sender, EventArgs e)
		{
			if (Pn1.Visible)
				return;
			AtualTipoEntrada = TipoEntrada.Inserir;

			DesbloquearCampos();
			LimparCampos();
			TxNomeCliente.Select();

			Pn1.Visible = true;
			GridClientes.Enabled = false;
		}

		private void BtEditarCliente_Click(object sender, EventArgs e)
		{
			if (Pn1.Visible)
				return;
			if (GridClientes.Rows.Count == 0)
				return;
			AtualTipoEntrada = TipoEntrada.Atualizar;
			Pn1.Visible = true;
			GridClientes.Enabled = false;
			DesbloquearCampos();
		}

		private async void BtDeletarCliente_Click(object sender, EventArgs e)
		{
			if (Pn1.Visible)
				return;
			if (GridClientes.Rows.Count == 0)
				return;
			var Msg = MessageBox.Show(
				"Deseja realmente deletar esse cliente?",
				"Atenção!",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Exclamation
			);
			if (Msg == DialogResult.Yes)
			{
				var User = new ModelCliente()
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



		private async void BtCarregarCep_Click(object sender, EventArgs e)
		{
			var _ = TxCep.SelectionStart;
			try
			{
				var DadosCep = await ControlCep.AsyncBuscarCep(TxCep.Text);

				TxCep.Text = DadosCep.cep.Replace("-", "");
				TxCidade.Text = DadosCep.localidade;
				TxUf.Text = DadosCep.uf;
				TxRua.Text = DadosCep.logradouro;
				TxComplemento.Text = DadosCep.complemento;

				TxNumero.Select();
			}
			catch (Exception err)
			{
				await LogError.Log(err, DictError: new Dictionary<string, object>()
					{
						{ "Não foi possível adcionar o CEP ", $"[CEP = {TxCep.Text}]" }
					});
			}
			TxCep.SelectionStart = _;
		}



		private void LbSearch_Click(object sender, EventArgs e)
		{
			LbSearch.Visible = false;
			TxSearch.Select();
		}

		private async void TxSearch_TextChanged(object sender, EventArgs e)
		{
			var value = TxSearch.Text;
			LbSearch.Text = value;
			if (value != "")
			{
				//SÓ PARA EXEMPLIFICAR QUE É POSSÍVEL FAZER SEM CONSULTAR AO DB NOVAMENTE.
				//var FilterCliente =
				//	from cliente in ListaClientes
				//	where
				//	cliente.Nome.Contains(value) | cliente.Rua.Contains(value) |
				//	cliente.Estado.Contains(value) | cliente.Cidade.Contains(value)
				//	select cliente;
				var Cliente = new ModelCliente()
				{
					Nome = TxSearch.Text,
					Telefone = TxSearch.Text,
					Email = TxSearch.Text,
					Cidade = TxSearch.Text,
					Rua = TxSearch.Text
				};
				var FilterCliente = await ControlCliente.AsyncBuscarClientes(Cliente, ControlCliente.TipoBusca.PrincipaisCampos);
				GridClientes.DataSource = FilterCliente;
			}
			else
				GridClientes.DataSource = ListaClientes;
		}

		private void TxSearch_Leave(object sender, EventArgs e)
		{
			LbSearch.Visible = true;
			if (LbSearch.Text.Trim() == "")
				LbSearch.Text = "Buscar cliente";
		}

		private void BtSearch_Click(object sender, EventArgs e) =>
			TxSearch_Leave(sender, e);

		
		
		void BloquearCampos()
		{
			TxNomeCliente.ReadOnly = true;
			TxTelefone.ReadOnly = true;
			TxEmail.ReadOnly = true;
			TxCep.ReadOnly = true;
			TxNumero.ReadOnly = true;
			TxComplemento.ReadOnly = true;
			BtDescobrirCep.Enabled = false;
		}
		void DesbloquearCampos()
		{
			TxNomeCliente.ReadOnly = false;
			TxTelefone.ReadOnly = false;
			TxEmail.ReadOnly = false;
			TxCep.ReadOnly = false;
			TxNumero.ReadOnly = false;
			TxComplemento.ReadOnly = false;
			BtDescobrirCep.Enabled = true;
		}
		void LimparCampos()
		{
			TxNomeCliente.Text = "";
			TxTelefone.Text = "";
			TxEmail.Text = "";
			TxCep.Text = "";
			TxCidade.Text = "";
			TxUf.Text = "";
			TxRua.Text = "";
			TxNumero.Text = "";
			TxComplemento.Text = "";
		}
		public async Task CarregarDadosGrid()
		{
			LimparCampos();
			BloquearCampos();
			ListaClientes = new List<ModelCliente>();
			GridClientes.DataSource = new List<string>();

			var dao = new DaoClientes();
			ListaClientes = await dao.AsyncSelect("SELECT * FROM clientes");

			GridClientes.DataSource = ListaClientes;
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
			catch (Exception e)
			{

			}
			GridClientes.Select();
			TxNomeCliente.Select();
		}



		private void BtDescobrirCep_Click(object sender, EventArgs e)
		{
			new BuscarCepLogradouro().ShowDialog();

			TxCep.Text = BuscarCepLogradouro.CepBusca.cep;
			TxNumero.Select();
		}



		private void TxNumero_Enter(object sender, EventArgs e)
		{
			if (TxCep.Text.Trim() != "")
				BtCarregarCep_Click(sender, e);
		}
		private void TxCep_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter | e.KeyCode == Keys.Tab)
			{
				BtCarregarCep_Click(sender, new EventArgs());
			}
		}
	}
}