using ENTREGA_T1.Models;

namespace ENTREGA_T1.Services
{
    public interface IClienteService
    {
        Task<List<Cliente>> ObtenerTodosAsync();

        Task<Cliente?> ObtenerPorIdAsync(int id);

        Task CrearAsync(Cliente cliente);

        Task EditarAsync(Cliente cliente);
    }
}
