using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PDV_WPF_LOGIN.Back.BackEntities.Connection
{
    public class ConexaoSql
    {
        SqlConnection cn = new SqlConnection();

        //Construtor
        public ConexaoSql()
        {
            cn.ConnectionString = @"Data Source=(local);Initial Catalog=SistemaVendas;Integrated Security=True";
        }

        //Metodo Conectar - Verifica se já está conectado (state = Irá conectar se estiver desconectado.)
        public SqlConnection conectar()
        {
            if (cn.State == System.Data.ConnectionState.Closed)
            {
                cn.Open();
            }

            return cn;
        }

        //Metodo Desconectar - Verifica se já está desconectado (state = Irá desconectar se estiver conectado.) 
        public void desconectar()
        {
            if (cn.State == System.Data.ConnectionState.Open)
            {
                cn.Close();
            }
        }
    }
}

