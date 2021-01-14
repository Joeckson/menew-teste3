using Menew_Teste.Model;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;

namespace Menew_Teste.DAO
{
    class DAOUtil
    {
        //metodo para gerar o log
        public void Log(string msg)
        {
            using (StreamWriter outputFile = new StreamWriter("log-erro.txt", true))
            {
                String data = DateTime.Now.ToShortDateString();
                String hora = DateTime.Now.ToShortTimeString();
                //outputFile.WriteLine("----------------------------------------------------------------------------");
                outputFile.WriteLine(data + " " + hora + ": " + msg);
                outputFile.WriteLine("----------------------------------------------------------------------------\n");
            }
        }

        //metodo para buscar o cep
        public ModelCep BuscarCep(ModelCep cep)
        {
            var Request =  WebRequest.Create($"http://viacep.com.br/ws/{cep.cep.Replace("-","")}/json/");
            Request.Method = "GET";
            try
            {
                var Response = Request.GetResponse();
                var Stream = new StreamReader(Response.GetResponseStream());
                var ResponseStr = Stream.ReadToEnd();

                var Json = JsonConvert.DeserializeObject<ModelCep>(ResponseStr);

                Response.Close();
                Stream.Close();

                return Json;

            }catch(Exception e)
            {
                Log("Erro ao buscar cep: "+e.Message);
            }

            return cep;
        }

       

    }
}
