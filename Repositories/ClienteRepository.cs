using ENTREGA_T1.Data;
using ENTREGA_T1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ENTREGA_T1.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly EmpresaDbContext _context;

        public ClienteRepository(EmpresaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> ObtenerTodosAsync()
        {
            return await _context.Clientes
                .FromSqlRaw("EXEC sp_ListarClientes")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Cliente?> ObtenerPorIdAsync(int id)
        {
            var lista = await _context.Clientes
                .FromSqlRaw("EXEC sp_ObtenerClientePorId @ClienteID", new SqlParameter("@ClienteID", id))
                .AsNoTracking()
                .ToListAsync();

            return lista.FirstOrDefault();
        }

        public async Task CrearAsync(Cliente cliente)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertarCliente @Nombre, @CorreoElectronico",
                new SqlParameter("@Nombre", cliente.Nombre),
                new SqlParameter("@CorreoElectronico", cliente.CorreoElectronico));
        }

        public async Task EditarAsync(Cliente cliente)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_ActualizarCliente @ClienteID, @Nombre, @CorreoElectronico",
                new SqlParameter("@ClienteID", cliente.ClienteId),
                new SqlParameter("@Nombre", cliente.Nombre),
                new SqlParameter("@CorreoElectronico", cliente.CorreoElectronico));
        }
    }
}
