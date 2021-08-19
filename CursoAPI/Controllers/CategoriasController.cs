using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CursoMVC.Models;

namespace CursoAPI.Controllers
{
    [Route(template: "api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly Context _context;

        public CategoriasController(Context context)
        {
            _context = context;
        }

        //GET: api/Categorias
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }

        //GET: api/Categorias/5
        [HttpGet(template: "{id}")]

        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        //PUT: api/Categorias/5
        [HttpPut(template: "{id}")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
                {
                    return NotFound();
                }

                else
                {
                    throw;
                }

            }

            return NoContent();

        }

        //POST: api/Categorias
        [HttpPost]

        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("GetCategoria", routeValues: new { id = categoria.Id }, value: categoria);
        }

        //DELETE: api/Categoria/5
        [HttpDelete]

        public async Task<ActionResult<Categoria>> DeleteCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.Id == id);
        }
    }

}   
        
        

    

