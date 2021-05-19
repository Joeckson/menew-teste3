using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;


namespace teste3
{
    class Conexao
    {
        private Conexao()
        {
            FbConnection conexao;

            try
            {
                conexao = new FbConnection("User=SYSDBA;PassWord=masterkey;Database=D:\\Firebird databases\\TESTE3.FDB;DataSource=localhost;Dialect=3;Charset=NONE;Pooling=true");
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }
        
     }
}
