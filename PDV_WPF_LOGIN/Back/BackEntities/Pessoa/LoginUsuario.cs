using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using PDV_WPF_LOGIN.Back.BackEntities.Models;

namespace PDV_WPF_LOGIN.Back.BackEntities.Pessoa
{
    public class LoginUsuario
    { 
        //Propriedades da Classe
        public string mensagem = ""; //mensagem vazia se estiver ok
        public bool tem;

        public bool efetuarLogin(string Nome_Usuario, string Senha_Usuario)
        {
            Login log = new Login();
            tem = log.verificarLogin(Nome_Usuario, Senha_Usuario);
            if (!log.mensagem.Equals("")) 
            {
                this.mensagem = log.mensagem;
            }
            return tem;

        }

        public string Cadastrar(string Nome_Usuario, decimal CPF, char Senha_Usuario)
        {
            return mensagem;
        }

        }

    }

