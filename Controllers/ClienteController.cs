using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaAPI.Data;
using MinhaAPI.Models;

namespace MinhaAPI.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class ClienteController : ControllerBase 
        {
            private readonly AppDbContext _appDbContext;

            public ClienteController(AppDbContext appContext) {

                _appDbContext = appContext;

            }

        [HttpGet]
        public async Task<IActionResult> GetAll() {

            List<Cliente> clientes = await _appDbContext.Clientes
                .Include(clientes => clientes.Enderecos)
                .ToListAsync();
            return Ok(new { message = "API de Clientes funcionando!" });

        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Cliente cliente) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _appDbContext.Clientes.Add(cliente);
            await _appDbContext.SaveChangesAsync();
            return Ok("Cliente criado com sucesso!");

        }


    }
}

//Add-Migration RelacionamentoEntidades

