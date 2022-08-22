using System;
using System.Collections.Generic;
using System.Text;

namespace PDV_WPF_LOGIN.Back.BackEntities.Models
{
    class Usuario
    {
        public Guid Cod_Usuario { get; set; }
        public string Nome_Usuario { get; set; }
        public decimal CPF { get; set; }
        public string Senha_Usuario { get; set; }
    }
}
