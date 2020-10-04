using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallerApiBasica.BL.Interface;
using TallerApiBasica.Models;

namespace TallerApiBasica.Controllers
{
    [Route("api/Empleados")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IEmpleado _empleado;

        public PersonasController(IEmpleado empleado)
        {
            _empleado = empleado;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var datos = await _empleado.ObtenerEmpleados();
                return Ok(datos);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ObtenerEmpleado/{id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            try
            {
                var datos = await _empleado.ObtenerEmpleados(Id.ToString());
                return Ok(datos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
