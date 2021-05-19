using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using Correios.Net;

namespace teste3
{
    public partial class Form1 : Form
    {
        FbConnection conexao;
        FbCommand comando;
        FbDataAdapter da;
        FbDataReader dr;
        string strSQL;
        
        public Form1()
        {
            InitializeComponent();
        }

        public void LimparCampos()
        {
            foreach (TextBox txt in this.Controls.OfType<TextBox>())
                txt.Clear();
        }

        public void LoadTable()
        {
            try
            {
                conexao = new FbConnection("User=SYSDBA;PassWord=masterkey;Database=D:\\Firebird databases\\TESTE3.FDB;DataSource=localhost;Dialect=3;Charset=NONE;Pooling=true");
                strSQL = "SELECT * FROM CLIENTES";
                da = new FbDataAdapter(strSQL, conexao);
                DataTable tb = new DataTable();
                da.Fill(tb);
                tbl_dados.DataSource = tb;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            int codigo = 0;
            Int32.TryParse(txt_id.Text, out codigo);

            int numero = 0;
            Int32.TryParse(txt_num.Text, out numero);

            Clientes F = new Clientes(codigo, txt_nome.Text, txt_telef.Text, txt_email.Text, txt_cep.Text, txt_cidade.Text, txt_estado.Text, txt_rua.Text, numero, txt_complemento.Text);
            ClienteDAO.Excluir(F);

            LoadTable();
            LimparCampos();

        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            int codigo = 0;
            Int32.TryParse(txt_id.Text, out codigo);

            int numero = 0;
            Int32.TryParse(txt_num.Text, out numero);

            Clientes F = new Clientes(codigo, txt_nome.Text, txt_telef.Text, txt_email.Text, txt_cep.Text, txt_cidade.Text, txt_estado.Text, txt_rua.Text, numero, txt_complemento.Text);
            ClienteDAO.Editar(F);

            LoadTable();
            LimparCampos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTable();

        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            int numero = 10;
            Int32.TryParse(txt_num.Text, out numero);
           
            Clientes F = new Clientes (txt_nome.Text, txt_telef.Text, txt_email.Text, txt_cep.Text, txt_cidade.Text, txt_estado.Text, txt_rua.Text, numero, txt_complemento.Text);
            ClienteDAO.Salvar(F);

            LoadTable();
            LimparCampos();
        }

        private void btn_buscar_Click_1(object sender, EventArgs e)
        {
            try
            {
                conexao = new FbConnection("User=SYSDBA;PassWord=masterkey;Database=D:\\Firebird databases\\TESTE3.FDB;DataSource=localhost;Dialect=3;Charset=NONE;Pooling=true");
                strSQL = "SELECT * FROM CLIENTES WHERE ID = @ID";
                comando = new FbCommand(strSQL, conexao);
                
                comando.Parameters.AddWithValue("@ID", txt_id.Text);           
                conexao.Open();
                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    txt_nome.Text = Convert.ToString(dr["nome"]);
                    txt_telef.Text = Convert.ToString(dr["telefone"]);
                    txt_email.Text = Convert.ToString(dr["email"]);
                    txt_cep.Text = Convert.ToString(dr["cep"]);
                    txt_cidade.Text = Convert.ToString(dr["cidade"]);
                    txt_estado.Text = Convert.ToString(dr["estado"]);
                    txt_rua.Text = Convert.ToString(dr["rua"]);
                    txt_num.Text = Convert.ToString(dr["numero"]);
                    txt_complemento.Text = Convert.ToString(dr["complemento"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void txt_cep_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_cep.Text))
            {
                using (var ws = new WSCorreios.AtendeClienteClient())
                {
                    try
                    {
                        var endereco = ws.consultaCEP(txt_cep.Text.Trim());
                        txt_estado.Text = endereco.uf;
                        txt_cidade.Text = endereco.cidade;
                        txt_rua.Text = endereco.end + ", " + endereco.bairro;
                        txt_complemento.Text = endereco.complemento2;

                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, this.Text);
                    }
                }
            }
            else
            {
                MessageBox.Show("Informe um CEP Válido");
            }

        }
    }
}