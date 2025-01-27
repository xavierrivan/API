using APIProductos.Data;
using APIProductos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProductos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly ApplicationDBC _db;

        public PacienteController(ApplicationDBC db)
        {
            _db = db;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Paciente> products = await _db.Paciente.ToListAsync();
            return Ok(products);
        }

        // GET api/<PacienteController>/5
        [HttpGet("{IdPaciente}")]
        public async Task<IActionResult> Get(int IdPaciente)
        {
            Paciente Paciente = await _db.Paciente.FirstOrDefaultAsync(x => x.id == IdPaciente);
            if (Paciente != null)
            {
                return Ok(Paciente);
            }
            return BadRequest();

        }

        // POST api/<PacienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Paciente Paciente)
        {
            Paciente Paciente2 = await _db.Paciente.FirstOrDefaultAsync(x => x.id == Paciente.id);
            if (Paciente2 == null && Paciente != null)
            {
                await _db.Paciente.AddAsync(Paciente);
                await _db.SaveChangesAsync();
                return Ok(Paciente);
            }
            return BadRequest("No se pudo crear el Paciente");

        }

        // PUT api/<PacienteController>/5
        [HttpPut("{IdPaciente}")]
        public async Task<IActionResult> Put(int IdPaciente, [FromBody] Paciente Paciente)
        {
            Paciente Paciente2 = await _db.Paciente.FirstOrDefaultAsync(x => x.id == IdPaciente);
            if (Paciente2 != null)
            {
                Paciente2.nombre = Paciente.nombre != null ? Paciente.nombre : Paciente2.nombre;
                Paciente2.edad = Paciente.edad != null ? Paciente.edad : Paciente2.edad; ;
                Paciente2.genero = Paciente.genero != null ? Paciente.genero : Paciente2.genero; ;
                _db.Paciente.Update(Paciente2);
                await _db.SaveChangesAsync();
                return Ok(Paciente2);
            }
            return BadRequest();

        }

        // DELETE api/<PacienteController>/5
        [HttpDelete("{IdPaciente}")]
        public async Task<IActionResult> Delete(int IdPaciente)
        {
            Paciente Paciente = await _db.Paciente.FirstOrDefaultAsync(x => x.id == IdPaciente);
            if (Paciente != null)
            {
                _db.Paciente.Remove(Paciente);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest("No se pudo borrar el Paciente");
        }

    }
}