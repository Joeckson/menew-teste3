using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using teste3;

namespace teste3
{
    class ClienteDAO
    {
        private static ClienteDAO instance;

        public static ClienteDAO getInstance()
        {
            if (instance == null)
            {
                instance = new ClienteDAO();
            }
            return instance;
        }

        public static void Salvar(Clientes cliente)
        {
                FbConnection conexao;
                FbCommand comando;
                string strSQL;

            try
            {
                conexao = new FbConnection("User=SYSDBA;PassWord=masterkey;Database=D:\\Firebird databases\\TESTE3.FDB;DataSource=localhost;Dialect=3;Charset=NONE;Pooling=true");
                strSQL = "INSERT INTO CLIENTES(NOME, TELEFONE, EMAIL, CEP, CIDADE, ESTADO, RUA, NUMERO, COMPLEMENTO) VALUES (@NOME, @TELEFONE, @EMAIL, @CEP, @CIDADE, @ESTADO, @RUA, @NUMERO, @COMPLEMENTO)";
                comando = new FbCommand(strSQL, conexao);
                comando.Parameters.AddWithValue("@NOME", cliente.getNome());
                comando.Parameters.AddWithValue("@TELEFONE", cliente.getTelefone());
                comando.Parameters.AddWithValue("@EMAIL", cliente.getEmail());
                comando.Parameters.AddWithValue("@CEP", cliente.getCep());
                comando.Parameters.AddWithValue("@CIDADE", cliente.getCidade());
                comando.Parameters.AddWithValue("@ESTADO", cliente.getEstado());
                comando.Parameters.AddWithValue("@RUA", cliente.getRua());
                comando.Parameters.AddWithValue("@NUMERO", cliente.getNumero());
                comando.Parameters.AddWithValue("@COMPLEMENTO", cliente.getComplemento());
                conexao.Open();
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
       
        }

        public static void Editar(Clientes Cliente)
        {
            FbConnection conexao;
            FbCommand comando;
            string strSQL;

            try
            {
                conexao = new FbConnection("User=SYSDBA;PassWord=masterkey;Database=D:\\Firebird databases\\TESTE3.FDB;DataSource=localhost;Dialect=3;Charset=NONE;Pooling=true");
                strSQL = "UPDATE CLIENTES SET NOME = @NOME, TELEFONE = @TELEFONE, EMAIL = @EMAIL, CEP = @CEP, CIDADE = @CIDADE, ESTADO = @ESTADO, RUA = @RUA, NUMERO = @NUMERO, COMPLEMENTO = @COMPLEMENTO WHERE ID = @ID";

                comando = new FbCommand(strSQL, conexao);
                comando.Parameters.AddWithValue("@ID", Cliente.getCodigo());
                comando.Parameters.AddWithValue("@NOME", Cliente.getNome());
                comando.Parameters.AddWithValue("@TELEFONE", Cliente.getTelefone());
                comando.Parameters.AddWithValue("@EMAIL", Cliente.getEmail());
                comando.Parameters.AddWithValue("@CEP", Cliente.getCep());
                comando.Parameters.AddWithValue("@CIDADE", Cliente.getCidade());
                comando.Parameters.AddWithValue("@ESTADO", Cliente.getEstado());
                comando.Parameters.AddWithValue("@RUA", Cliente.getRua());
                comando.Parameters.AddWithValue("@NUMERO", Cliente.getNumero());
                comando.Parameters.AddWithValue("@COMPLEMENTO", Cliente.getComplemento());
                conexao.Open();
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }       

        }

        public static void Excluir(Clientes Cliente)
        {
            FbConnection conexao;
            FbCommand comando;
            string strSQL;

            try
            {
                conexao = new FbConnection("User=SYSDBA;PassWord=masterkey;Database=D:\\Firebird databases\\TESTE3.FDB;DataSource=localhost;Dialect=3;Charset=NONE;Pooling=true");
                strSQL = "DELETE FROM CLIENTES WHERE ID = @ID";

                comando = new FbCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@ID", Cliente.getCodigo());
                conexao.Open();
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
