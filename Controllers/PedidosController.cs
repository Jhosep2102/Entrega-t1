using ENTREGA_T1.Models;
using ENTREGA_T1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ENTREGA_T1.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IPedidoService _pedidoService;
        private readonly IClienteService _clienteService;

        public PedidosController(IPedidoService pedidoService, IClienteService clienteService)
        {
            _pedidoService = pedidoService;
            _clienteService = clienteService;
        }

        public async Task<IActionResult> Index()
        {
            var pedidos = await _pedidoService.ObtenerTodosAsync();
            var clientes = await _clienteService.ObtenerTodosAsync();
            ViewBag.Clientes = clientes.ToDictionary(c => c.ClienteId, c => c.Nombre);
            return View(pedidos);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await CargarListas();
            return View(new Pedido { FechaPedido = DateOnly.FromDateTime(DateTime.Today) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pedido pedido)
        {
            ModelState.Remove(nameof(Pedido.Cliente));

            if (!ModelState.IsValid)
            {
                await CargarListas();
                return View(pedido);
            }

            await _pedidoService.CrearAsync(pedido);
            TempData["Mensaje"] = "pedido registrado";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var pedido = await _pedidoService.ObtenerPorIdAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            await CargarListas();
            return View(pedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pedido pedido)
        {
            if (id != pedido.PedidoId)
            {
                return NotFound();
            }

            ModelState.Remove(nameof(Pedido.Cliente));

            if (!ModelState.IsValid)
            {
                await CargarListas();
                return View(pedido);
            }

            await _pedidoService.EditarAsync(pedido);
            TempData["Mensaje"] = "pedido actualizado";
            return RedirectToAction(nameof(Index));
        }

        private async Task CargarListas()
        {
            var clientes = await _clienteService.ObtenerTodosAsync();
            ViewBag.Clientes = new SelectList(clientes, nameof(Cliente.ClienteId), nameof(Cliente.Nombre));
            ViewBag.Estados = new SelectList(new List<string> { "Pendiente", "Entregado", "Cancelado" });
        }
    }
}
