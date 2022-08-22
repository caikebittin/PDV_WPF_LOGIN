using PDV_WPF_LOGIN.Back.BackEntities.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PDV_WPF_LOGIN.Back.BackEntities.Produtos
{
    class ConsultaProdutos
    {
        SqlCommand cmd = new SqlCommand();
        ConexaoSql con = new ConexaoSql();
        SqlDataReader dr; //onde as informações ficaram "guardadas"
        public bool tem = false; //colocado falso para não precisar criar o else
        public string mensagem;
        public bool consultarProdutos(int Produto_Cod, string Produto_Desc)
        {
            //Comando SQL
            cmd.CommandText = @"select top 1 * from Produtos where nome = @Produto_Cod and senha = @Produto_Desc ";
            cmd.Parameters.AddWithValue("@Produto_Cod", Produto_Cod);
            cmd.Parameters.AddWithValue("@Produto_Desc", Produto_Desc);

            try
            {
                cmd.Connection = con.conectar(); //Conectar ao Banco (usando a conexão criada em ConexaoSql.cs)

                dr = cmd.ExecuteReader(); //Executar comando de pegar informação do banco de dados e guardar no DR.

                if (dr.HasRows) //Verificar se foi encontrado alguma linha
                {
                    tem = true;
                }
                else if (tem == false)
                {
                    this.mensagem = "Produto não encontrado.\n Favor verificar as informações ou cadastrar o mesmo!";
                }
            }
            catch (SqlException Ex)
            {
                this.mensagem = "Falha ao consultar o produto\n" + Ex;
            }

            return tem;

        }
    }
}

