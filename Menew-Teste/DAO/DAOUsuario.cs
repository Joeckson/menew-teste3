using FirebirdSql.Data.FirebirdClient;
using Menew_Teste.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace Menew_Teste.DAO
{
    public class DAOUsuario
    {
        ModelUsuario usuario = new ModelUsuario();
        FbConnection conexao = DAOConnection.getInstaciaFB().AbrirConexao();
        FbCommand comando    = new FbCommand();
        DAOUtil util         = new DAOUtil();
        string sql           = "";
        
        public void InsertUser(ModelUsuario usuario)
        {
            using (FbConnection con = DAOConnection.getInstaciaFB().AbrirConexao())
            {                
                con.Open();
                sql = "INSERT INTO TBUSUARIOS(NOME,TELEFONE,EMAIL,CIDADE,RUA,COMPLEMENTO,ESTADO,NUMERO,CEP)VALUES(@NOME,@TELEFONE,@EMAIL,@CIDADE,@RUA,@COMPLEMENTO,@ESTADO,@NUMERO,@CEP)";
                comando = new FbCommand(sql, con);

                comando.Parameters.AddWithValue("@NOME", usuario.Nome);
                comando.Parameters.AddWithValue("@TELEFONE", usuario.Telefone);
                comando.Parameters.AddWithValue("@EMAIL", usuario.Email);
                comando.Parameters.AddWithValue("@CIDADE", usuario.Cidade);
                comando.Parameters.AddWithValue("@RUA", usuario.Rua);
                comando.Parameters.AddWithValue("@COMPLEMENTO", usuario.Complemento);
                comando.Parameters.AddWithValue("@ESTADO", usuario.Estado);
                comando.Parameters.AddWithValue("@CEP", usuario.Cep);
                comando.Parameters.AddWithValue("@NUMERO", usuario.Numero);

                try
                {
                    comando.ExecuteNonQuery();
                    util.Log(usuario.Nome + " foi Cadastrado com sucesso!");
                    MessageBox.Show("Salvo com sucesso!");
                }
                catch (Exception e)
                {
                    util.Log("erro ao salvar usuário => " + e.Message);
                }
                finally
                {
                    con.Close();
                }

            }
        }
        public void UpdateUser(ModelUsuario usuario)
        {
            using (FbConnection con = DAOConnection.getInstaciaFB().AbrirConexao())
            {
                
                con.Open();
                sql = "UPDATE TBUSUARIOS SET NOME=@NOME,TELEFONE=@TELEFONE,EMAIL=@EMAIL,CIDADE=@CIDADE,RUA=@RUA,COMPLEMENTO=@COMPLEMENTO,ESTADO=@ESTADO,CEP=@CEP,NUMERO=@NUMERO WHERE ID=@ID";
                comando = new FbCommand(sql, con);

                comando.Parameters.AddWithValue("@ID",usuario.Id);
                comando.Parameters.AddWithValue("@NOME", usuario.Nome);
                comando.Parameters.AddWithValue("@TELEFONE", usuario.Telefone);
                comando.Parameters.AddWithValue("@EMAIL", usuario.Email);
                comando.Parameters.AddWithValue("@CIDADE", usuario.Cidade);
                comando.Parameters.AddWithValue("@RUA", usuario.Rua);
                comando.Parameters.AddWithValue("@COMPLEMENTO", usuario.Complemento);
                comando.Parameters.AddWithValue("@ESTADO", usuario.Estado);
                comando.Parameters.AddWithValue("@CEP", usuario.Cep);
                comando.Parameters.AddWithValue("@NUMERO", usuario.Numero);

                try
                {
                    comando.ExecuteNonQuery();
                    util.Log(usuario.Nome + " foi Cadastrado com sucesso!");
                    MessageBox.Show("Salvo com sucesso!");
                }
                catch (Exception e)
                {
                    util.Log("erro ao salvar usuário => " + e.Message);
                }
                finally
                {
                    con.Close();
                }

            }
        }
        public void DeleteUser(int _id)
        {
            using (FbConnection con = DAOConnection.getInstaciaFB().AbrirConexao())
            {
                con.Open();
                sql = "DELETE FROM TBUSUARIOS WHERE ID=@ID";
                comando = new FbCommand(sql, con);

                comando.Parameters.AddWithValue("@ID",_id);
                try
                {
                    comando.ExecuteNonQuery();
                    util.Log(" Usuario foi deletado! "+_id);
                    MessageBox.Show("Usuario deletado!");
                }
                catch (Exception e)
                {
                    util.Log("erro ao salvar usuário => " + e.Message);
                }
                finally
                {
                    con.Close();
                }

            }
        }
        public void GetDados(string sql_Dados,DataGridView tabela)
        {
            using (FbConnection con = DAOConnection.getInstaciaFB().AbrirConexao())
            {
                con.Open();
                sql = sql_Dados;
                try
                {
                    comando = new FbCommand(sql_Dados, con);
                    FbDataAdapter dataAdapter = new FbDataAdapter(comando);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    tabela.DataSource = dataTable;

                }catch(Exception ex)
                {
                    util.Log("Erro ao carregar tabela=>"+ex.Message);
                }
            }
        }
    }
}

