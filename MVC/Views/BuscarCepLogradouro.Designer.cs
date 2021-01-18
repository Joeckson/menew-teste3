
namespace menew_teste3.MVC.Views
{
	partial class BuscarCepLogradouro
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.TxRua = new MaterialSkin.Controls.MaterialTextBox();
			this.TxBairro = new MaterialSkin.Controls.MaterialTextBox();
			this.BtBuscarCep = new MaterialSkin.Controls.MaterialButton();
			this.BtSalvar = new MaterialSkin.Controls.MaterialButton();
			this.TimerAguarde = new System.Windows.Forms.Timer(this.components);
			this.materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
			this.SuspendLayout();
			// 
			// TxRua
			// 
			this.TxRua.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TxRua.Depth = 0;
			this.TxRua.Font = new System.Drawing.Font("Roboto", 12F);
			this.TxRua.Hint = "Rua";
			this.TxRua.Location = new System.Drawing.Point(12, 95);
			this.TxRua.MaxLength = 400;
			this.TxRua.MouseState = MaterialSkin.MouseState.OUT;
			this.TxRua.Multiline = false;
			this.TxRua.Name = "TxRua";
			this.TxRua.Size = new System.Drawing.Size(374, 50);
			this.TxRua.TabIndex = 11;
			this.TxRua.Text = "";
			this.TxRua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxRua_KeyDown);
			// 
			// TxBairro
			// 
			this.TxBairro.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TxBairro.Depth = 0;
			this.TxBairro.Font = new System.Drawing.Font("Roboto", 12F);
			this.TxBairro.Hint = "Bairro";
			this.TxBairro.Location = new System.Drawing.Point(392, 95);
			this.TxBairro.MaxLength = 400;
			this.TxBairro.MouseState = MaterialSkin.MouseState.OUT;
			this.TxBairro.Multiline = false;
			this.TxBairro.Name = "TxBairro";
			this.TxBairro.Size = new System.Drawing.Size(186, 50);
			this.TxBairro.TabIndex = 12;
			this.TxBairro.Text = "";
			this.TxBairro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxBairro_KeyDown);
			// 
			// BtBuscarCep
			// 
			this.BtBuscarCep.AutoSize = false;
			this.BtBuscarCep.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BtBuscarCep.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtBuscarCep.Depth = 0;
			this.BtBuscarCep.DrawShadows = true;
			this.BtBuscarCep.HighEmphasis = true;
			this.BtBuscarCep.Icon = null;
			this.BtBuscarCep.Location = new System.Drawing.Point(12, 155);
			this.BtBuscarCep.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.BtBuscarCep.MouseState = MaterialSkin.MouseState.HOVER;
			this.BtBuscarCep.Name = "BtBuscarCep";
			this.BtBuscarCep.Size = new System.Drawing.Size(140, 41);
			this.BtBuscarCep.TabIndex = 13;
			this.BtBuscarCep.Text = "Buscar CEP";
			this.BtBuscarCep.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
			this.BtBuscarCep.UseAccentColor = true;
			this.BtBuscarCep.UseVisualStyleBackColor = true;
			this.BtBuscarCep.Click += new System.EventHandler(this.BtBuscarCep_Click);
			// 
			// BtSalvar
			// 
			this.BtSalvar.AutoSize = false;
			this.BtSalvar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BtSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtSalvar.Depth = 0;
			this.BtSalvar.DrawShadows = true;
			this.BtSalvar.HighEmphasis = true;
			this.BtSalvar.Icon = null;
			this.BtSalvar.Location = new System.Drawing.Point(392, 155);
			this.BtSalvar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.BtSalvar.MouseState = MaterialSkin.MouseState.HOVER;
			this.BtSalvar.Name = "BtSalvar";
			this.BtSalvar.Size = new System.Drawing.Size(186, 41);
			this.BtSalvar.TabIndex = 14;
			this.BtSalvar.Text = "Está correto, salvar";
			this.BtSalvar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
			this.BtSalvar.UseAccentColor = true;
			this.BtSalvar.UseVisualStyleBackColor = true;
			this.BtSalvar.Click += new System.EventHandler(this.BtSalvar_Click);
			// 
			// TimerAguarde
			// 
			this.TimerAguarde.Tag = "0";
			this.TimerAguarde.Tick += new System.EventHandler(this.TimerAguarde_Tick);
			// 
			// materialProgressBar1
			// 
			this.materialProgressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.materialProgressBar1.Depth = 0;
			this.materialProgressBar1.Location = new System.Drawing.Point(-1, 64);
			this.materialProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialProgressBar1.Name = "materialProgressBar1";
			this.materialProgressBar1.Size = new System.Drawing.Size(590, 5);
			this.materialProgressBar1.TabIndex = 15;
			// 
			// BuscarCepLogradouro
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(590, 211);
			this.Controls.Add(this.materialProgressBar1);
			this.Controls.Add(this.BtSalvar);
			this.Controls.Add(this.BtBuscarCep);
			this.Controls.Add(this.TxBairro);
			this.Controls.Add(this.TxRua);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BuscarCepLogradouro";
			this.Sizable = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Tag = "";
			this.Text = "Cep não identificado";
			this.ResumeLayout(false);

		}

		#endregion
		private MaterialSkin.Controls.MaterialTextBox TxRua;
		private MaterialSkin.Controls.MaterialTextBox TxBairro;
		private MaterialSkin.Controls.MaterialButton BtBuscarCep;
		private MaterialSkin.Controls.MaterialButton BtSalvar;
		private System.Windows.Forms.Timer TimerAguarde;
		private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;
	}
}