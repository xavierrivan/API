using APIProductos.Data;
using APIProductos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProductos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResultadoController : Controller
    {
        private readonly ApplicationDBC _db;

        public ResultadoController(ApplicationDBC db)
        {
            _db = db;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Resultado> resultado = await _db.Resultado.ToListAsync();
            return Ok(resultado);
        }

        // GET api/<ResultadoController>/5
        [HttpGet("{IdResultado}")]
        public async Task<IActionResult> Get(int IdResultado)
        {
            Resultado Resultado = await _db.Resultado.FirstOrDefaultAsync(x => x.Id == IdResultado);
            if (Resultado != null)
            {
                return Ok(Resultado);
            }
            return BadRequest();

        }

        // POST api/<ResultadoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Resultado Resultado)
        {
            Resultado Resultado2 = await _db.Resultado.FirstOrDefaultAsync(x => x.Id == Resultado.Id);
            if (Resultado2 == null && Resultado != null)
            {
                await _db.Resultado.AddAsync(Resultado);
                await _db.SaveChangesAsync();
                return Ok(Resultado);
            }
            return BadRequest("No se pudo crear el Resultado");

        }

        // PUT api/<ResultadoController>/5
        [HttpPut("{IdResultado}")]
        public async Task<IActionResult> Put(int IdResultado, [FromBody] Resultado Resultado)
        {
            Resultado Resultado2 = await _db.Resultado.FirstOrDefaultAsync(x => x.Id == IdResultado);
            if (Resultado2 != null)
            {
                Resultado2.PacienteId = Resultado.PacienteId != null ? Resultado.PacienteId : Resultado2.PacienteId;
                Resultado2.Hemoglobina = Resultado.Hemoglobina != null ? Resultado.Hemoglobina : Resultado2.Hemoglobina; ;
                Resultado2.GlobulosRojos = Resultado.GlobulosRojos != null ? Resultado.GlobulosRojos : Resultado2.GlobulosRojos;
                Resultado2.Colesterol = Resultado.Colesterol != null ? Resultado.Colesterol : Resultado2.Colesterol; ;
                _db.Resultado.Update(Resultado2);
                await _db.SaveChangesAsync();
                return Ok(Resultado2);
            }
            return BadRequest();

        }

        // DELETE api/<ResultadoController>/5
        [HttpDelete("{IdResultado}")]
        public async Task<IActionResult> Delete(int IdResultado)
        {
            Resultado Resultado = await _db.Resultado.FirstOrDefaultAsync(x => x.Id == IdResultado);
            if (Resultado != null)
            {
                _db.Resultado.Remove(Resultado);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest("No se pudo borrar el Resultado");
        }
    }
}
