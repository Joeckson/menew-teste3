using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 namespace Menew_Teste.Model
{
    public class ModelUsuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cep{ get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Rua {get;set;}
        public string Numero { get; set; }
        public string Complemento { get; set; }

    }
}
