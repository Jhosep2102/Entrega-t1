using ENTREGA_T1.Models;

namespace ENTREGA_T1.Repositories
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> ObtenerTodosAsync();

        Task<Cliente?> ObtenerPorIdAsync(int id);

        Task CrearAsync(Cliente cliente);

        Task EditarAsync(Cliente cliente);
    }
}
