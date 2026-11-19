using ENTREGA_T1.Models;

namespace ENTREGA_T1.Repositories
{
    public interface IPedidoRepository
    {
        Task<List<Pedido>> ObtenerTodosAsync();

        Task<Pedido?> ObtenerPorIdAsync(int id);

        Task CrearAsync(Pedido pedido);

        Task EditarAsync(Pedido pedido);
    }
}
