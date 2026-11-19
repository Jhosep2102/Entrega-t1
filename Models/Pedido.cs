using System;
using System.Collections.Generic;

namespace ENTREGA_T1.Models;

public partial class Pedido
{
    public int PedidoId { get; set; }

    public DateOnly FechaPedido { get; set; }

    public decimal Monto { get; set; }

    public string Estado { get; set; } = null!;

    public int ClienteId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;
}
