using PDV_WPF_LOGIN.Back.BackEntities.Connection;
using System;
using System.Collections.Generic;
using PDV_WPF_LOGIN.Back.BackEntities.Produtos;
using System.Data.SqlClient;
using System.Text;
using PDV_WPF_LOGIN.Back.BackEntities.Models;

namespace PDV_WPF_LOGIN.Back.BackEntities.Produtos
{
    class CadastrarProduto
    {//Propriedades da classe 
        ConexaoSql conexao = new ConexaoSql();
        SqlCommand cmd = new SqlCommand();
        public string mensagem;


        //Construtor da classe 
        public CadastrarProduto(int Produto_Cod, string Produto_Desc, decimal Produto_Custo, decimal Produto_Valor_Venda)
        {
            CadastroProduto(Produto_Cod, Produto_Desc, Produto_Custo, Produto_Valor_Venda);
        }

        public void CadastroProduto(int Produto_Cod, string Produto_Desc, decimal Produto_Custo, decimal Produto_Valor_Venda)
        {
            //Comando SQL
            cmd.CommandText = @"insert into Produtos (Produto_Cod, Produto_Desc, Produto_Custo, Produto_Valor_Venda) values (@cod, @descr, @custo, @valorvenda)";

            //Parametros
            cmd.Parameters.AddWithValue("@cod", Produto_Cod);
            cmd.Parameters.AddWithValue("@descr", Produto_Desc);
            cmd.Parameters.AddWithValue("@custo", Produto_Custo);
            cmd.Parameters.AddWithValue("@valorvenda", Produto_Valor_Venda);

            try
            {   //Conectar ao Banco (usando a conexão criada em ConexaoSql.cs)
                cmd.Connection = conexao.conectar();
                //Executar comando
                cmd.ExecuteNonQuery();
                //Desconectar (usando metodos criados em ConexalSql.cs)
                conexao.desconectar();
                //Mensagem de sucesso
                this.mensagem = "Produto cadastrado com sucesso!";
            }
            catch (SqlException ex)
            {
                //Mensagem de erro
                this.mensagem = $"O produto não foi cadastrado!\n Erro ao conectar-se com o banco de dados.\n" + ex;
            }
        }
    }
}
}
