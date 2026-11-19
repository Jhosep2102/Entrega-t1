using ENTREGA_T1.Models;

namespace ENTREGA_T1.Services
{
    public interface IPedidoService
    {
        Task<List<Pedido>> ObtenerTodosAsync();

        Task<Pedido?> ObtenerPorIdAsync(int id);

        Task CrearAsync(Pedido pedido);

        Task EditarAsync(Pedido pedido);
    }
}
