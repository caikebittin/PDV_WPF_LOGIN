using PDV_WPF_LOGIN.Back.BackEntities.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PDV_WPF_LOGIN.Back.BackEntities.Pessoa
{
    public class CadastroUsuario
    {
        //Propriedades da classe 
        ConexaoSql conexao = new ConexaoSql();
        SqlCommand cmd = new SqlCommand();
        public string mensagem { get; set; }
        public string nomeUsuario { get; set; }
        public decimal cpfUsuario { get; set; }
        public char Senha_Usuario { get; set; }

        //Construtor da classe 
        public CadastroUsuario(string Nome_Usuario, decimal CPF, char Senha_Usuario)
        {
            CadastrarUsuario(Nome_Usuario, CPF, Senha_Usuario);
        }

        public void CadastrarUsuario(string Nome_Usuario, decimal CPF, char Senha_Usuario)
        {
            //Comando SQL
            cmd.CommandText = @"insert into Pessoa (Cod_Usuario, Nome_Usuario, CPF, Senha_Usuario) 
                                values (newid(), @nome, @ident, @senha)";

            //Parametros
            cmd.Parameters.AddWithValue("@nome", Nome_Usuario);
            cmd.Parameters.AddWithValue("@ident", CPF);
            cmd.Parameters.AddWithValue("@senha", Senha_Usuario);

            try
            {
                //Conectar ao Banco (usando a conexão criada em ConexaoSql.cs)
                cmd.Connection = conexao.conectar();
                //Executar comando
                cmd.ExecuteNonQuery();
                //Desconectar (usando metodos criados em ConexalSql.cs)
                conexao.desconectar();
                //Mensagem de sucesso
                this.mensagem = "Usuário cadastrado com sucesso!";
            }
            catch (SqlException ex)
            {
                //Mensagem de erro
                this.mensagem = $"Erro ao se conectar com o banco de dados.\n" + ex;
            }
        }
    }
}
