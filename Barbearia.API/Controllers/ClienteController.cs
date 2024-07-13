using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barbearia.API.Data;
using Barbearia.API.DTO;
using Barbearia.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Barbearia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        public readonly ApplicationDbContext _dbContext;

        public ClienteController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clientes = await _dbContext.Clientes.ToListAsync();
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClienteDTO clienteDTO)
        {
            if(ModelState.IsValid)
            {
                Cliente cliente = new Cliente();
                cliente.Nome = clienteDTO.Nome;
                cliente.Telefone = clienteDTO.Telefone;
                cliente.Email = clienteDTO.Email;
                cliente.DataNascimento = clienteDTO.DataNascimento;

                _dbContext.Clientes.Add(cliente);
                await _dbContext.SaveChangesAsync();
                return CreatedAtAction("1", cliente);
            }
            return BadRequest();
        }
    }
}