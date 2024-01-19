using backend_tareas.Models;
using backend_tareas.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace backend_tareas.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly TareaService _tareaService;
        public TareaController(TareaService tareaService)
        {
            this._tareaService = tareaService;
        }

        [HttpPost]
        [Route("agregar")]
        [ProducesResponseType(typeof(Tarea), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult agregar([FromBody] Tarea _tarea)
        {
            try
            {
                var resultado = _tareaService.agregarTarea(_tarea);
                if (resultado)
                    return Ok(_tarea);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("editar")]
        [ProducesResponseType(typeof(Tarea), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult editar([FromBody] Tarea _tarea)
        {
            try
            {
                var resultado = _tareaService.editarTarea(_tarea);
                if (resultado)
                    return Ok(_tarea);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest();
        }


        [HttpGet]
        [Route("porTareaPorID/{id}")]
        [ProducesResponseType(typeof(Tarea), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult porTareaPorID(int id)
        {
            try
            {
                var resultado = _tareaService.porTareaPorID(id);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("listarTareas")]
        [ProducesResponseType(typeof(Tarea), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult listarTareas()
        {
            try
            {
                var resultado = _tareaService.listarTareas();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        [ProducesResponseType(typeof(Tarea), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult eliminarTarea(int id)
        {
            try
            {
                var resultado = _tareaService.eliminarTarea(id);
                if (resultado)
                    return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest();
        }
    }
}
