using FirebirdSql.Data.FirebirdClient;
using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace Menew_Teste.DAO
{
    public class DAOConnection
    {
        private static readonly DAOConnection InstanciaFB = new DAOConnection();
        private DAOConnection() { }

        public static DAOConnection getInstaciaFB()
        {
            return InstanciaFB;
        }

        public FbConnection AbrirConexao()
        {
            string conn = ConfigurationManager.ConnectionStrings["ConexaoBD"].ToString();
            return new FbConnection(conn);
        }



    }
}
