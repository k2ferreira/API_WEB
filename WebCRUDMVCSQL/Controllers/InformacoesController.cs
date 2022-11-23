using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCRUDMVCSQL.Models;

namespace WebCRUDMVCSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformacoesController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult GetClientes()
        {
            List<Informacoes> clientes = new List<Informacoes>();
            clientes.Add(new Informacoes()
            {
               ID = 1,
                Nome = "Saldanha",
                saldo = "23.400,55",
                clienteVIP ="SIM"
            });
            clientes.Add(new Informacoes()
            {
                ID = 2,
                Nome = "Ronaldp",
                saldo = "78.250,30",
                clienteVIP = "SIM"
            });
            clientes.Add(new Informacoes()
            {
                ID = 3,
                Nome = "Manoel",
                saldo = "400,10",
                clienteVIP = "SIM"
            });
            return new ObjectResult(clientes);
        }
    }
}

