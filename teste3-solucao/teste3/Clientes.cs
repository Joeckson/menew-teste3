using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//model
namespace teste3
{
    class Clientes
    {
        private int codigo;
        private string nome;
        private string telefone;
        private string email;
        private string cep;
        private string cidade;
        private string estado;
        private string rua;
        private int numero;
        private string complemento;

        public Clientes(string nome, string telefone, string email, string cep, string cidade, string estado, string rua, int numero, string complemento)
        {
            //this.codigo = codigo;
            this.nome = nome;
            this.telefone = telefone;
            this.email = email;
            this.cep = cep;
            this.cidade = cidade;
            this.estado = estado;
            this.rua = rua;
            this.numero = numero;
            this.complemento = complemento;
        }

        public Clientes(int codigo, string nome, string telefone, string email, string cep, string cidade, string estado, string rua, int numero, string complemento)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.telefone = telefone;
            this.email = email;
            this.cep = cep;
            this.cidade = cidade;
            this.estado = estado;
            this.rua = rua;
            this.numero = numero;
            this.complemento = complemento;
        }

        public int getCodigo()
        {
            return codigo;
        }

        public void setCodigo(int codigo)
        {
            this.codigo = codigo;
        }

        public string getNome()
        {
            return nome;
        }

        public void setNome(string nome)
        {
            this.nome = nome;
        }

        public string getTelefone()
        {
            return telefone;
        }

        public void setTelefone(string telefone)
        {
            this.telefone = telefone;
        }

        public string getEmail()
        {
            return email;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public string getCep()
        {
            return cep;
        }

        public void setCep(string cep)
        {
            this.cep = cep;
        }

        public string getCidade()
        {
            return cidade;
        }

        public void setCidade(string cidade)
        {
            this.cidade = cidade;
        }

        public string getEstado()
        {
            return estado;
        }

        public void setEstado(string estado)
        {
            this.estado = estado;
        }

        public string getRua()
        {
            return rua;
        }

        public void setRua(string rua)
        {
            this.rua = rua;
        }

        public int getNumero()
        {
            return numero;
        }

        public void setNumero(int numero)
        {
            this.numero = numero;
        }

        public string getComplemento()
        {
            return complemento;
        }

        public void setComplemento(string complemento)
        {
            this.complemento = complemento;
        }
    }
}