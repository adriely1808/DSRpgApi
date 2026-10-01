using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;

namespace RpgApi.Models
{
    public class Arma
    {
        public int id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Dano { get; set; }
    }
}

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArmasController : ControllerBase
    {
        private readonly DataContext _context;

        public ArmasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var arma = await _context.TB_ARMAS.ToListAsync();
            return Ok(arma);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var arma = await _context.TB_ARMAS.FirstOrDefaultAsync(x => x.id == id);
            
            if (arma == null)
            {
                return NotFound();
            }

            return Ok(arma);
        }


           [HttpGet("GetAll")]
        public async Task<IActionResult> get()
        {
            try
            {
                List<Arma> lista = await _context.TB_ARMAS.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Arma novaArma)
        {
            await _context.TB_ARMAS.AddAsync(novaArma);
            await _context.SaveChangesAsync();
            return Ok(novaArma.id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Arma arma)
        {
            _context.TB_ARMAS.Update(arma);
            await _context.SaveChangesAsync();
            return Ok(arma);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var arma = await _context.TB_ARMAS.FirstOrDefaultAsync(x => x.id == id);

            if (arma == null)
            {
                return NotFound();
            }

            _context.TB_ARMAS.Remove(arma);
            await _context.SaveChangesAsync();
            return Ok(arma);
        }
    }
}