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

            var clientes = await _appDbContext.Clientes
                .Include(cliente => cliente.Enderecos)
                .Select(cliente => new {

                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    Enderecos = cliente.Enderecos.Select(endereco => new {
                        Id = endereco.Id,
                        Logradouro = endereco.Logradouro,
                        Bairro = endereco.Bairro,
                        Cidade = endereco.Cidade

                    }).ToList()

                }).ToListAsync();
            return Ok(clientes);


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {

            var clientes = await _appDbContext.Clientes
                .Include(cliente => cliente.Enderecos)
                .FirstOrDefaultAsync(cliente => cliente.Id == id);
            return Ok(clientes);

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

