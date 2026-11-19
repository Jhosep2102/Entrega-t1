using ENTREGA_T1.Models;
using ENTREGA_T1.Services;
using Microsoft.AspNetCore.Mvc;

namespace ENTREGA_T1.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteService.ObtenerTodosAsync();
            return View(clientes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Cliente());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            ModelState.Remove(nameof(Cliente.Pedidos));

            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            await _clienteService.CrearAsync(cliente);
            TempData["Mensaje"] = "cliente registrado";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _clienteService.ObtenerPorIdAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return NotFound();
            }

            ModelState.Remove(nameof(Cliente.Pedidos));

            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            await _clienteService.EditarAsync(cliente);
            TempData["Mensaje"] = "cliente actualizado";
            return RedirectToAction(nameof(Index));
        }
    }
}
