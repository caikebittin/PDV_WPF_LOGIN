using System;
using System.Collections.Generic;
using System.Text;

namespace PDV_WPF_LOGIN.Back.BackEntities.Models
{
    class Produto
    {
        public int Produto_Cod { get; set; }
        public string Produto_Desc { get; set; }
        public decimal Produto_Custo { get; set; }
        public decimal Produto_Valor_Venda { get; set; }
    }
}
