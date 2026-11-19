using ENTREGA_T1.Models;
using ENTREGA_T1.Repositories;

namespace ENTREGA_T1.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _repository;

        public PedidoService(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Pedido>> ObtenerTodosAsync()
        {
            return _repository.ObtenerTodosAsync();
        }

        public Task<Pedido?> ObtenerPorIdAsync(int id)
        {
            return _repository.ObtenerPorIdAsync(id);
        }

        public Task CrearAsync(Pedido pedido)
        {
            return _repository.CrearAsync(pedido);
        }

        public Task EditarAsync(Pedido pedido)
        {
            return _repository.EditarAsync(pedido);
        }
    }
}
