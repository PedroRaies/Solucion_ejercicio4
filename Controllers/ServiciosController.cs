using Microsoft.AspNetCore.Mvc;
using WebApi_TurnosPeluqueria.Models;
using WebApi_TurnosPeluqueria.Repositories.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_TurnosPeluqueria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly IServicioRepository _servicioRepository;

        public ServiciosController(IServicioRepository servicio)
        {
            _servicioRepository = servicio;
        }



        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_servicioRepository.GetServicioList());
            }
            catch (Exception ex) 
            { 
                return StatusCode(500, ex.Message);
            }

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                var lista = _servicioRepository.GetServicioById(id);
                if (lista != null) 
                { 
                    return Ok(lista);
                }
                return BadRequest("Error al intentar GetById");
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }

        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult PostServicio([FromBody] TServicio servicio)
        {
            try
            {
                if(servicio == null)
                {
                    return BadRequest("El servicio no puede ser null");
                }
                var aux = _servicioRepository.CreateService(servicio);
                if (aux)
                {
                    return Ok("Servicio creado");
                }
                return BadRequest();
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var aux = _servicioRepository.DeleteService(id);
                if (aux)
                {
                    return Ok();
                }
                return BadRequest("Error al intentar DeleteService");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
