using ENTREGA_T1.Models;
using ENTREGA_T1.Repositories;

namespace ENTREGA_T1.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Cliente>> ObtenerTodosAsync()
        {
            return _repository.ObtenerTodosAsync();
        }

        public Task<Cliente?> ObtenerPorIdAsync(int id)
        {
            return _repository.ObtenerPorIdAsync(id);
        }

        public Task CrearAsync(Cliente cliente)
        {
            return _repository.CrearAsync(cliente);
        }

        public Task EditarAsync(Cliente cliente)
        {
            return _repository.EditarAsync(cliente);
        }
    }
}
