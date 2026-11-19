using System.Data;
using ENTREGA_T1.Data;
using ENTREGA_T1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ENTREGA_T1.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly EmpresaDbContext _context;

        public PedidoRepository(EmpresaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> ObtenerTodosAsync()
        {
            return await _context.Pedidos
                .FromSqlRaw("EXEC sp_ListarPedidos")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Pedido?> ObtenerPorIdAsync(int id)
        {
            var lista = await _context.Pedidos
                .FromSqlRaw("EXEC sp_ObtenerPedidoPorId @PedidoID", new SqlParameter("@PedidoID", id))
                .AsNoTracking()
                .ToListAsync();

            return lista.FirstOrDefault();
        }

        public async Task CrearAsync(Pedido pedido)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertarPedido @FechaPedido, @Monto, @Estado, @ClienteID",
                CrearFecha(pedido.FechaPedido),
                CrearMonto(pedido.Monto),
                new SqlParameter("@Estado", pedido.Estado),
                new SqlParameter("@ClienteID", pedido.ClienteId));
        }

        public async Task EditarAsync(Pedido pedido)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_ActualizarPedido @PedidoID, @FechaPedido, @Monto, @Estado, @ClienteID",
                new SqlParameter("@PedidoID", pedido.PedidoId),
                CrearFecha(pedido.FechaPedido),
                CrearMonto(pedido.Monto),
                new SqlParameter("@Estado", pedido.Estado),
                new SqlParameter("@ClienteID", pedido.ClienteId));
        }

        private static SqlParameter CrearFecha(DateOnly fecha)
        {
            return new SqlParameter("@FechaPedido", SqlDbType.Date)
            {
                Value = fecha.ToDateTime(TimeOnly.MinValue)
            };
        }

        private static SqlParameter CrearMonto(decimal monto)
        {
            return new SqlParameter("@Monto", SqlDbType.Decimal)
            {
                Precision = 10,
                Scale = 2,
                Value = monto
            };
        }
    }
}
