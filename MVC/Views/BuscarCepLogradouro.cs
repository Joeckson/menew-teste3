using MaterialSkin;
using MaterialSkin.Controls;
using System;
using menew_teste3.MVC.Controls;
using menew_teste3.MVC.Models;
using menew_teste3.MVC.Controls.Service;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace menew_teste3.MVC.Views
{
	public partial class BuscarCepLogradouro : MaterialForm
	{
		public static ModelJsonCep CepBusca { get; set; } = new ModelJsonCep();
		private ModelJsonCep _CepBusca { get; set; } = new ModelJsonCep();
		public BuscarCepLogradouro()
		{
			InitializeComponent();

			#region ESTILIZANDO EM MODO ESCURO, ETC...
			var materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.AddFormToManage(this);
			materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
			materialSkinManager.EnforceBackcolorOnAllComponents = false;
			materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
			#endregion
		}

		private async void BtBuscarCep_Click(object sender, EventArgs e)
		{
			TimerAguarde.Start();
			try
			{
				_CepBusca = new ModelJsonCep();
				var cep = await ControlBuscaCepLogradouro.AsyncBuscarMeuCep(TxRua.Text, TxBairro.Text);
				if (cep.Length != 8)
					throw new InvalidOperationException($"Cep encontrado, está com valor inválido!\nCep={cep}");

				var DadosCep = await ControlCep.AsyncBuscarCep(cep);

				TimerAguarde.Stop();
				materialProgressBar1.Value = 100;

				_CepBusca.cep = cep;
				Text = $"Seu cep é {_CepBusca.cep}, sua Cidade é {DadosCep.localidade}({DadosCep.uf})";
				this.Refresh();
			}
			catch (Exception err)
			{
				TimerAguarde.Stop();
				materialProgressBar1.Value = 100;

				Text = "Cep não identificado.";
				this.Refresh();
				await LogError.Log(err);

			}

			await Task.Delay(100);
			materialProgressBar1.Value = 0;
		}

		private void BtSalvar_Click(object sender, EventArgs e)
		{
			CepBusca = _CepBusca;
			Close();
		}

		private void TxRua_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				BtBuscarCep_Click(sender, e);
		}

		private void TxBairro_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				BtBuscarCep_Click(sender, e);
		}

		private void TimerAguarde_Tick(object sender, EventArgs e)
		{
			Text = "Aguarde...";
			this.Refresh();
			if (materialProgressBar1.Value < 100)
				materialProgressBar1.PerformStep();
			else
				materialProgressBar1.Value = 0;
		}
	}
}
