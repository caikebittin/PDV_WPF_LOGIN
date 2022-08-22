using System;
using System.Collections.Generic;
using System.Text;

namespace PDV_WPF_LOGIN.Back.BackEntities.Models
{
    class Venda
    {
        public Guid Venda_ID { get; set; }
        public DateTime Venda_Data { get; set; }
        public decimal VendaTOT_Valor { get; set; }
        public string Venda_FormaPgto { get; set; }
    }
}
