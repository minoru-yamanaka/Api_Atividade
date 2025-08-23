using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaAPI.Data;
using MinhaAPI.Models;

namespace MinhaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public EnderecoController(AppDbContext appContext)
        {
            _appDbContext = appContext;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    // Se Endereco tem relação com Cliente
        //    var enderecos = await _appDbContext.Endereco
        //        .Include(e => e.Cliente) // <-- ajuste aqui
        //        .ToListAsync();

        //    return Ok(enderecos);
        //}

        // Puxar endereços de um cliente específico
        // GET http://localhost:5215/api/endereco/cliente/1
        [HttpGet("cliente/{clienteId}")]
        public async Task<IActionResult> GetByCliente(int clienteId)
        {
            var enderecos = await _appDbContext.Endereco
                .Where(e => e.ClienteId == clienteId)
                .ToListAsync();

            if (!enderecos.Any())
                return NotFound("Nenhum endereço encontrado para este cliente.");

            return Ok(enderecos);
        }

        // Puxar um endereço específico por Id
        // GET http://localhost:5215/api/endereco/3
        [HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var endereco = await _appDbContext.Endereco
        //        .Include(e => e.Cliente)
        //        .FirstOrDefaultAsync(e => e.Id == id);

        //    if (endereco == null)
        //        return NotFound("Endereço não encontrado.");

        //    return Ok(endereco);
        //}

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Endereco endereco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _appDbContext.Endereco.Add(endereco);
            await _appDbContext.SaveChangesAsync();

            return Ok("Endereço criado com sucesso!");
            return CreatedAtAction(nameof(GetByCliente), new { id = endereco.Id }, endereco);

        }
    }
}
