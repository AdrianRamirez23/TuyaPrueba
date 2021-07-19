using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuya.API.Context;
using Tuya.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tuya.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposUsuariosController : ControllerBase
    {
        private readonly APIContext context;

        public TiposUsuariosController(APIContext context)
        {
            this.context = context;
        }
        // GET: api/<TiposUsuariosController>
        /// <summary>
        /// Obtiene la lista de tipos de usuarios creados en la base de datos
        /// </summary>     
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.TiposUsuarios.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<TiposUsuariosController>/5
        /// <summary>
        /// Obtiene un tipo de usuario por id
        /// </summary>     
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var tiposUsuarios = context.TiposUsuarios.FirstOrDefault(c => c.IdTipoUsuario == id);
                return Ok(tiposUsuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<TiposUsuariosController>
        /// <summary>
        /// Crea un nuevo tipo de usuario
        /// </summary>
        /// <param name="tiposUsuarios"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] TiposUsuarios tiposUsuarios)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.TiposUsuarios.Add(tiposUsuarios);
                    context.SaveChanges();
                    return Ok(tiposUsuarios);

                }
                else
                {
                    return BadRequest("Model is invalid");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TiposUsuariosController>/5
        /// <summary>
        /// Edita los tipos de usuario creados
        /// </summary>
        /// <param name="id"></param>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TiposUsuarios tiposUsuarios)
        {
            try
            {
                if (tiposUsuarios.IdTipoUsuario == id && ModelState.IsValid)
                {
                    context.Entry(tiposUsuarios).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok(tiposUsuarios);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<TiposUsuariosController>/5
        /// <summary>
        /// Elimina un tipo de usuario creado en base de datos or id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var tipos = context.TiposUsuarios.FirstOrDefault(c => c.IdTipoUsuario == id);
                if (tipos != null)
                {
                    context.TiposUsuarios.Remove(tipos);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
