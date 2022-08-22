using PDV_WPF_LOGIN.Back.BackEntities.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PDV_WPF_LOGIN.Back.BackEntities.Pessoa
{
    class Login
    {
        SqlCommand cmd = new SqlCommand();
        ConexaoSql con = new ConexaoSql();
        SqlDataReader dr; //onde as informações ficaram "guardadas"
        public bool tem = false; //colocado falso para não precisar criar o else
        public string mensagem;
        public bool verificarLogin(string Nome_Usuario, string Senha_Usuario)
        {
            //Comando SQL
            cmd.CommandText = @"select top 1 * from pessoa where nome = @Nome_Usuario and senha = @Senha_Usuario ";
            cmd.Parameters.AddWithValue("@Nome_Usuario", Nome_Usuario);
            cmd.Parameters.AddWithValue("@Senha_Usuario", Senha_Usuario);

            try
            {
                cmd.Connection = con.conectar(); //Conectar ao Banco (usando a conexão criada em ConexaoSql.cs)

                dr = cmd.ExecuteReader(); //Executar comando de pegar informação do banco de dados e guardar no DR.

                if (dr.HasRows) //Verificar se foi encontrado alguma linha
                {
                    tem = true;
                }
                else if (tem == false) {
                    this.mensagem = "Usuário e senha não encontrados.\n Favor cadastrar o usuário!";
                }
            }
            catch (SqlException Ex)
            {
                this.mensagem = "Falha ao efetuar o login\n" + Ex;
            }

            return tem;

        }
    }
}
