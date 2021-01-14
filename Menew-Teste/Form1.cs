using Menew_Teste.DAO;
using Menew_Teste.Model;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Menew_Teste
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _daoUsuario.GetDados("SELECT * FROM TBUSUARIOS",TBUsuario);//CARREGA OS DADOS
            OrganizaGrid();
            txtNome.Focus();
        }
        int id=0;
        ModelUsuario _usuario    = new  ModelUsuario();
        DAOUsuario   _daoUsuario = new DAOUsuario();
        DAOUtil      _util       = new DAOUtil();
        ModelCep modelCep        = new ModelCep();  
        //**********************************************
        
        //Evento para poder fechar o  programa
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Ação do botao salvar
        private void BtSalvar_Click(object sender, EventArgs e)
        {
            _usuario.Nome = txtNome.Text;
            _usuario.Cep = txtCep.Text;
            _usuario.Cidade = txtCidade.Text;
            _usuario.Complemento = txtComplemento.Text;
            _usuario.Email = txtEmail.Text;
            _usuario.Estado = txtEstado.Text;
            _usuario.Numero = txtNumero.Text;
            _usuario.Rua = txtRua.Text;
            _usuario.Telefone = txtTelefone.Text;
            _usuario.Id = id;
            if (id == 0)
            {
                _daoUsuario.InsertUser(_usuario);
                _daoUsuario.GetDados("SELECT * FROM TBUSUARIOS", TBUsuario);
                OrganizaGrid();
                ClearCamp();
            }
            else
            {
                _daoUsuario.UpdateUser(_usuario);
                _daoUsuario.GetDados("SELECT * FROM TBUSUARIOS", TBUsuario);
                OrganizaGrid();
                ClearCamp();
            }
        }
        //Evento da tabela ao clicar preencher os campos
        private void TBUsuario_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(this.TBUsuario.CurrentRow.Cells[0].Value.ToString());
            txtNome.Text = this.TBUsuario.CurrentRow.Cells[1].Value.ToString();
            txtTelefone.Text = this.TBUsuario.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = this.TBUsuario.CurrentRow.Cells[3].Value.ToString();
            txtCidade.Text = this.TBUsuario.CurrentRow.Cells[4].Value.ToString();
            txtRua.Text = this.TBUsuario.CurrentRow.Cells[5].Value.ToString();
            txtComplemento.Text = this.TBUsuario.CurrentRow.Cells[6].Value.ToString();
            txtEstado.Text = this.TBUsuario.CurrentRow.Cells[7].Value.ToString();
            txtCep.Text = this.TBUsuario.CurrentRow.Cells[8].Value.ToString();
            txtComplemento.Text = this.TBUsuario.CurrentRow.Cells[9].Value.ToString();
        }
        //acao para excluir usuario
        private void btExcluir_Click(object sender, EventArgs e)
        {
            _daoUsuario.DeleteUser(id);
            ClearCamp();
        }
        //Ação do botão para procurar o cep
        private void btCep_Click(object sender, EventArgs e)
        {
            modelCep.cep = txtCep.Text;
            var cep = _util.BuscarCep(modelCep);
            txtRua.Text = cep.logradouro;
            txtCidade.Text = cep.localidade;
            txtEstado.Text = cep.uf;
            txtNumero.Focus();
        }

        //***********************************************
        //Metodo para organizar as tabelas
        public void OrganizaGrid()
        {
            TBUsuario.Columns[0].Visible = false;
            TBUsuario.Columns[1].Width = 200;
            TBUsuario.Columns[2].Width = 150;
            TBUsuario.Columns[3].Width = 150;
            TBUsuario.Columns[4].Visible = false;
            TBUsuario.Columns[5].Visible = false;
            TBUsuario.Columns[6].Visible = false;
            TBUsuario.Columns[7].Visible = false;
            TBUsuario.Columns[8].Visible = false;
            TBUsuario.Columns[9].Visible = false;
        }
        //Metodo para limpar os campos
        public void ClearCamp()
        {
            id = 0;
            txtCep.Text = null;
            txtCidade.Text = null;
            txtComplemento.Text = null;
            txtEmail.Text = null;
            txtEstado.Text = null;
            txtNome.Text = null;
            txtNumero.Text = null;
            txtPesquisa.Text = null;
            txtRua.Text = null;
            txtTelefone.Text = null;
            txtNome.Focus();
        }
        //**************************************************************

        //nessa parte fica o eventos para quando o usuario apertar enter mudar o campo
        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtTelefone.Focus();
                e.Handled = true;
            }
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtEmail.Focus();
                e.Handled = true;
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e. KeyChar == (char)13)
            {
                txtCep.Focus();
                e.Handled = true;
            }
        }
        //buscar o cep ao apertar no enter
        private void txtCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                modelCep.cep = txtCep.Text;
                var cep = _util.BuscarCep(modelCep);
                txtRua.Text = cep.logradouro;
                txtCidade.Text = cep.localidade;
                txtEstado.Text = cep.uf;
                txtNumero.Focus();
            }
        }
        //Botão limpar
        private void BtLimpar_Click(object sender, EventArgs e)
        {
            ClearCamp();
        }
        //Evento para pesquisar usuario
        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            _daoUsuario.GetDados("select * from TBUSUARIOS where nome like('%" + txtPesquisa.Text + "%')",TBUsuario);
        }
        //Evento para Minimizar
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
