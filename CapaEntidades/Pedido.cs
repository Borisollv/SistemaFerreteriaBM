using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public int IdCliente { get; set; }
    }
}
