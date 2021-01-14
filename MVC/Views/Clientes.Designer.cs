
namespace menew_teste3
{
	partial class Clientes
	{
		/// <summary>
		/// Variável de designer necessária.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpar os recursos que estão sendo usados.
		/// </summary>
		/// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código gerado pelo Windows Form Designer

		/// <summary>
		/// Método necessário para suporte ao Designer - não modifique 
		/// o conteúdo deste método com o editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.TxNomeCliente = new MaterialSkin.Controls.MaterialTextBox();
			this.TxTelefone = new MaterialSkin.Controls.MaterialTextBox();
			this.TxEmail = new MaterialSkin.Controls.MaterialTextBox();
			this.TxCep = new MaterialSkin.Controls.MaterialTextBox();
			this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
			this.TxCidade = new MaterialSkin.Controls.MaterialTextBox();
			this.TxUf = new MaterialSkin.Controls.MaterialTextBox();
			this.TxRua = new MaterialSkin.Controls.MaterialTextBox();
			this.TxNumero = new MaterialSkin.Controls.MaterialTextBox();
			this.TxComplemento = new MaterialSkin.Controls.MaterialTextBox();
			this.BtNovoCliente = new MaterialSkin.Controls.MaterialButton();
			this.BtEditarCliente = new MaterialSkin.Controls.MaterialButton();
			this.BtDeletarCliente = new MaterialSkin.Controls.MaterialButton();
			this.GridClientes = new System.Windows.Forms.DataGridView();
			this.Pn1 = new System.Windows.Forms.Panel();
			this.BtCancelar = new MaterialSkin.Controls.MaterialButton();
			this.BtSalvar = new MaterialSkin.Controls.MaterialButton();
			this.BtCarregarCep = new MaterialSkin.Controls.MaterialButton();
			((System.ComponentModel.ISupportInitialize)(this.GridClientes)).BeginInit();
			this.Pn1.SuspendLayout();
			this.SuspendLayout();
			// 
			// TxNomeCliente
			// 
			this.TxNomeCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TxNomeCliente.Depth = 0;
			this.TxNomeCliente.Font = new System.Drawing.Font("Roboto", 12F);
			this.TxNomeCliente.Hint = "Nome";
			this.TxNomeCliente.Location = new System.Drawing.Point(22, 83);
			this.TxNomeCliente.MaxLength = 400;
			this.TxNomeCliente.MouseState = MaterialSkin.MouseState.OUT;
			this.TxNomeCliente.Multiline = false;
			this.TxNomeCliente.Name = "TxNomeCliente";
			this.TxNomeCliente.Size = new System.Drawing.Size(266, 50);
			this.TxNomeCliente.TabIndex = 0;
			this.TxNomeCliente.Text = "";
			// 
			// TxTelefone
			// 
			this.TxTelefone.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TxTelefone.Depth = 0;
			this.TxTelefone.Font = new System.Drawing.Font("Roboto", 12F);
			this.TxTelefone.Hint = "Telefone";
			this.TxTelefone.Location = new System.Drawing.Point(294, 83);
			this.TxTelefone.MaxLength = 400;
			this.TxTelefone.MouseState = MaterialSkin.MouseState.OUT;
			this.TxTelefone.Multiline = false;
			this.TxTelefone.Name = "TxTelefone";
			this.TxTelefone.Size = new System.Drawing.Size(167, 50);
			this.TxTelefone.TabIndex = 1;
			this.TxTelefone.Text = "";
			// 
			// TxEmail
			// 
			this.TxEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TxEmail.Depth = 0;
			this.TxEmail.Font = new System.Drawing.Font("Roboto", 12F);
			this.TxEmail.Hint = "E-Mail";
			this.TxEmail.Location = new System.Drawing.Point(22, 139);
			this.TxEmail.MaxLength = 400;
			this.TxEmail.MouseState = MaterialSkin.MouseState.OUT;
			this.TxEmail.Multiline = false;
			this.TxEmail.Name = "TxEmail";
			this.TxEmail.Size = new System.Drawing.Size(266, 50);
			this.TxEmail.TabIndex = 2;
			this.TxEmail.Text = "";
			// 
			// TxCep
			// 
			this.TxCep.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TxCep.Depth = 0;
			this.TxCep.Font = new System.Drawing.Font("Roboto", 12F);
			this.TxCep.Hint = "Cep";
			this.TxCep.Location = new System.Drawing.Point(22, 212);
			this.TxCep.MaxLength = 8;
			this.TxCep.MouseState = MaterialSkin.MouseState.OUT;
			this.TxCep.Multiline = false;
			this.TxCep.Name = "TxCep";
			this.TxCep.Size = new System.Drawing.Size(102, 50);
			this.TxCep.TabIndex = 3;
			this.TxCep.Text = "";
			this.TxCep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxCep_KeyDown);
			// 
			// materialDivider1
			// 
			this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.materialDivider1.Depth = 0;
			this.materialDivider1.Location = new System.Drawing.Point(22, 195);
			this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialDivider1.Name = "materialDivider1";
			this.materialDivider1.Size = new System.Drawing.Size(439, 11);
			this.materialDivider1.TabIndex = 7;
			this.materialDivider1.Text = "materialDivider1";
			// 
			// TxCidade
			// 
			this.TxCidade.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TxCidade.Depth = 0;
			this.TxCidade.Font = new System.Drawing.Font("Roboto", 12F);
			this.TxCidade.Hint = "Cidade";
			this.TxCidade.Location = new System.Drawing.Point(194, 212);
			this.TxCidade.MaxLength = 400;
			this.TxCidade.MouseState = MaterialSkin.MouseState.OUT;
			this.TxCidade.Multiline = false;
			this.TxCidade.Name = "TxCidade";
			this.TxCidade.ReadOnly = true;
			this.TxCidade.Size = new System.Drawing.Size(267, 50);
			this.TxCidade.TabIndex = 9;
			this.TxCidade.Text = "";
			// 
			// TxUf
			// 
			this.TxUf.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TxUf.Depth = 0;
			this.TxUf.Font = new System.Drawing.Font("Roboto", 12F);
			this.TxUf.Hint = "UF";
			this.TxUf.Location = new System.Drawing.Point(130, 212);
			this.TxUf.MaxLength = 2;
			this.TxUf.MouseState = MaterialSkin.MouseState.OUT;
			this.TxUf.Multiline = false;
			this.TxUf.Name = "TxUf";
			this.TxUf.ReadOnly = true;
			this.TxUf.Size = new System.Drawing.Size(58, 50);
			this.TxUf.TabIndex = 8;
			this.TxUf.Text = "";
			// 
			// TxRua
			// 
			this.TxRua.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TxRua.Depth = 0;
			this.TxRua.Font = new System.Drawing.Font("Roboto", 12F);
			this.TxRua.Hint = "Rua";
			this.TxRua.Location = new System.Drawing.Point(21, 268);
			this.TxRua.MaxLength = 400;
			this.TxRua.MouseState = MaterialSkin.MouseState.OUT;
			this.TxRua.Multiline = false;
			this.TxRua.Name = "TxRua";
			this.TxRua.ReadOnly = true;
			this.TxRua.Size = new System.Drawing.Size(374, 50);
			this.TxRua.TabIndex = 10;
			this.TxRua.Text = "";
			// 
			// TxNumero
			// 
			this.TxNumero.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TxNumero.Depth = 0;
			this.TxNumero.Font = new System.Drawing.Font("Roboto", 12F);
			this.TxNumero.Hint = "Nº";
			this.TxNumero.Location = new System.Drawing.Point(401, 268);
			this.TxNumero.MaxLength = 2;
			this.TxNumero.MouseState = MaterialSkin.MouseState.OUT;
			this.TxNumero.Multiline = false;
			this.TxNumero.Name = "TxNumero";
			this.TxNumero.Size = new System.Drawing.Size(60, 50);
			this.TxNumero.TabIndex = 4;
			this.TxNumero.Text = "";
			this.TxNumero.Enter += new System.EventHandler(this.TxNumero_Enter);
			// 
			// TxComplemento
			// 
			this.TxComplemento.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TxComplemento.Depth = 0;
			this.TxComplemento.Font = new System.Drawing.Font("Roboto", 12F);
			this.TxComplemento.Hint = "Complemento";
			this.TxComplemento.Location = new System.Drawing.Point(21, 324);
			this.TxComplemento.MaxLength = 400;
			this.TxComplemento.MouseState = MaterialSkin.MouseState.OUT;
			this.TxComplemento.Multiline = false;
			this.TxComplemento.Name = "TxComplemento";
			this.TxComplemento.Size = new System.Drawing.Size(440, 50);
			this.TxComplemento.TabIndex = 5;
			this.TxComplemento.Text = "";
			// 
			// BtNovoCliente
			// 
			this.BtNovoCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtNovoCliente.AutoSize = false;
			this.BtNovoCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BtNovoCliente.Depth = 0;
			this.BtNovoCliente.DrawShadows = true;
			this.BtNovoCliente.HighEmphasis = true;
			this.BtNovoCliente.Icon = null;
			this.BtNovoCliente.Location = new System.Drawing.Point(21, 397);
			this.BtNovoCliente.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.BtNovoCliente.MouseState = MaterialSkin.MouseState.HOVER;
			this.BtNovoCliente.Name = "BtNovoCliente";
			this.BtNovoCliente.Size = new System.Drawing.Size(140, 41);
			this.BtNovoCliente.TabIndex = 11;
			this.BtNovoCliente.Text = "Novo";
			this.BtNovoCliente.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
			this.BtNovoCliente.UseAccentColor = false;
			this.BtNovoCliente.UseVisualStyleBackColor = true;
			this.BtNovoCliente.Click += new System.EventHandler(this.BtNovoCliente_Click);
			// 
			// BtEditarCliente
			// 
			this.BtEditarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtEditarCliente.AutoSize = false;
			this.BtEditarCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BtEditarCliente.Depth = 0;
			this.BtEditarCliente.DrawShadows = true;
			this.BtEditarCliente.HighEmphasis = true;
			this.BtEditarCliente.Icon = null;
			this.BtEditarCliente.Location = new System.Drawing.Point(172, 397);
			this.BtEditarCliente.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.BtEditarCliente.MouseState = MaterialSkin.MouseState.HOVER;
			this.BtEditarCliente.Name = "BtEditarCliente";
			this.BtEditarCliente.Size = new System.Drawing.Size(140, 41);
			this.BtEditarCliente.TabIndex = 12;
			this.BtEditarCliente.Text = "Editar";
			this.BtEditarCliente.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
			this.BtEditarCliente.UseAccentColor = false;
			this.BtEditarCliente.UseVisualStyleBackColor = true;
			this.BtEditarCliente.Click += new System.EventHandler(this.BtEditarCliente_Click);
			// 
			// BtDeletarCliente
			// 
			this.BtDeletarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtDeletarCliente.AutoSize = false;
			this.BtDeletarCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BtDeletarCliente.Depth = 0;
			this.BtDeletarCliente.DrawShadows = true;
			this.BtDeletarCliente.HighEmphasis = true;
			this.BtDeletarCliente.Icon = null;
			this.BtDeletarCliente.Location = new System.Drawing.Point(321, 397);
			this.BtDeletarCliente.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.BtDeletarCliente.MouseState = MaterialSkin.MouseState.HOVER;
			this.BtDeletarCliente.Name = "BtDeletarCliente";
			this.BtDeletarCliente.Size = new System.Drawing.Size(140, 41);
			this.BtDeletarCliente.TabIndex = 13;
			this.BtDeletarCliente.Text = "Deletar";
			this.BtDeletarCliente.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
			this.BtDeletarCliente.UseAccentColor = false;
			this.BtDeletarCliente.UseVisualStyleBackColor = true;
			this.BtDeletarCliente.Click += new System.EventHandler(this.BtDeletarCliente_Click);
			// 
			// GridClientes
			// 
			this.GridClientes.AllowUserToAddRows = false;
			this.GridClientes.AllowUserToDeleteRows = false;
			this.GridClientes.AllowUserToOrderColumns = true;
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
			this.GridClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.GridClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GridClientes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
			this.GridClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.GridClientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.GridClientes.GridColor = System.Drawing.Color.Black;
			this.GridClientes.Location = new System.Drawing.Point(468, 83);
			this.GridClientes.MultiSelect = false;
			this.GridClientes.Name = "GridClientes";
			this.GridClientes.ReadOnly = true;
			this.GridClientes.RowHeadersVisible = false;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
			dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
			this.GridClientes.RowsDefaultCellStyle = dataGridViewCellStyle4;
			this.GridClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.GridClientes.ShowEditingIcon = false;
			this.GridClientes.Size = new System.Drawing.Size(364, 355);
			this.GridClientes.TabIndex = 14;
			this.GridClientes.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridClientes_RowEnter);
			// 
			// Pn1
			// 
			this.Pn1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Pn1.Controls.Add(this.BtCancelar);
			this.Pn1.Controls.Add(this.BtSalvar);
			this.Pn1.Location = new System.Drawing.Point(21, 390);
			this.Pn1.Name = "Pn1";
			this.Pn1.Size = new System.Drawing.Size(440, 48);
			this.Pn1.TabIndex = 15;
			this.Pn1.Visible = false;
			// 
			// BtCancelar
			// 
			this.BtCancelar.AutoSize = false;
			this.BtCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BtCancelar.Depth = 0;
			this.BtCancelar.DrawShadows = true;
			this.BtCancelar.HighEmphasis = true;
			this.BtCancelar.Icon = null;
			this.BtCancelar.Location = new System.Drawing.Point(231, 4);
			this.BtCancelar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.BtCancelar.MouseState = MaterialSkin.MouseState.HOVER;
			this.BtCancelar.Name = "BtCancelar";
			this.BtCancelar.Size = new System.Drawing.Size(140, 41);
			this.BtCancelar.TabIndex = 14;
			this.BtCancelar.Text = "Cancelar";
			this.BtCancelar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
			this.BtCancelar.UseAccentColor = true;
			this.BtCancelar.UseVisualStyleBackColor = true;
			this.BtCancelar.Click += new System.EventHandler(this.BtCancelar_Click);
			// 
			// BtSalvar
			// 
			this.BtSalvar.AutoSize = false;
			this.BtSalvar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BtSalvar.Depth = 0;
			this.BtSalvar.DrawShadows = true;
			this.BtSalvar.HighEmphasis = true;
			this.BtSalvar.Icon = null;
			this.BtSalvar.Location = new System.Drawing.Point(83, 4);
			this.BtSalvar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.BtSalvar.MouseState = MaterialSkin.MouseState.HOVER;
			this.BtSalvar.Name = "BtSalvar";
			this.BtSalvar.Size = new System.Drawing.Size(140, 41);
			this.BtSalvar.TabIndex = 13;
			this.BtSalvar.Text = "Salvar";
			this.BtSalvar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
			this.BtSalvar.UseAccentColor = true;
			this.BtSalvar.UseVisualStyleBackColor = true;
			this.BtSalvar.Click += new System.EventHandler(this.BtSalvar_Click);
			// 
			// BtCarregarCep
			// 
			this.BtCarregarCep.AutoSize = false;
			this.BtCarregarCep.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BtCarregarCep.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtCarregarCep.Depth = 0;
			this.BtCarregarCep.DrawShadows = true;
			this.BtCarregarCep.HighEmphasis = true;
			this.BtCarregarCep.Icon = null;
			this.BtCarregarCep.Location = new System.Drawing.Point(113, 213);
			this.BtCarregarCep.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.BtCarregarCep.MouseState = MaterialSkin.MouseState.HOVER;
			this.BtCarregarCep.Name = "BtCarregarCep";
			this.BtCarregarCep.Size = new System.Drawing.Size(12, 11);
			this.BtCarregarCep.TabIndex = 16;
			this.BtCarregarCep.Text = "🔃";
			this.BtCarregarCep.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
			this.BtCarregarCep.UseAccentColor = true;
			this.BtCarregarCep.UseVisualStyleBackColor = true;
			this.BtCarregarCep.Click += new System.EventHandler(this.BtCarregarCep_Click);
			// 
			// Clientes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(844, 450);
			this.Controls.Add(this.BtCarregarCep);
			this.Controls.Add(this.Pn1);
			this.Controls.Add(this.GridClientes);
			this.Controls.Add(this.BtDeletarCliente);
			this.Controls.Add(this.BtEditarCliente);
			this.Controls.Add(this.BtNovoCliente);
			this.Controls.Add(this.TxComplemento);
			this.Controls.Add(this.TxNumero);
			this.Controls.Add(this.TxRua);
			this.Controls.Add(this.TxUf);
			this.Controls.Add(this.TxCidade);
			this.Controls.Add(this.materialDivider1);
			this.Controls.Add(this.TxCep);
			this.Controls.Add(this.TxEmail);
			this.Controls.Add(this.TxTelefone);
			this.Controls.Add(this.TxNomeCliente);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(844, 450);
			this.Name = "Clientes";
			this.Text = "Cadastro de clientes";
			this.Load += new System.EventHandler(this.Clientes_Load);
			((System.ComponentModel.ISupportInitialize)(this.GridClientes)).EndInit();
			this.Pn1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private MaterialSkin.Controls.MaterialTextBox TxNomeCliente;
		private MaterialSkin.Controls.MaterialTextBox TxTelefone;
		private MaterialSkin.Controls.MaterialTextBox TxEmail;
		private MaterialSkin.Controls.MaterialTextBox TxCep;
		private MaterialSkin.Controls.MaterialDivider materialDivider1;
		private MaterialSkin.Controls.MaterialTextBox TxCidade;
		private MaterialSkin.Controls.MaterialTextBox TxUf;
		private MaterialSkin.Controls.MaterialTextBox TxRua;
		private MaterialSkin.Controls.MaterialTextBox TxNumero;
		private MaterialSkin.Controls.MaterialTextBox TxComplemento;
		private MaterialSkin.Controls.MaterialButton BtNovoCliente;
		private MaterialSkin.Controls.MaterialButton BtEditarCliente;
		private MaterialSkin.Controls.MaterialButton BtDeletarCliente;
		private System.Windows.Forms.DataGridView GridClientes;
		private System.Windows.Forms.Panel Pn1;
		private MaterialSkin.Controls.MaterialButton BtSalvar;
		private MaterialSkin.Controls.MaterialButton BtCancelar;
		private MaterialSkin.Controls.MaterialButton BtCarregarCep;
	}
}

