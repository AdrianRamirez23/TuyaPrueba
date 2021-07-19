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
    public class UsuariosController : ControllerBase
    {
        private readonly APIContext context;

        public UsuariosController(APIContext context)
        {
            this.context = context;
        }
        // GET: api/<UsuariosController>
        /// <summary>
        /// Obtiene la lista de usuarios creados en la base de datos
        /// </summary>     
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Usuarios.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<UsuariosController>/5
        /// <summary>
        /// Obtiene un usuario por id
        /// </summary>     
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var us = context.Usuarios.FirstOrDefault(c => c.IdUsuario == id);
                return Ok(us);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<UsuariosController>
        /// <summary>
        /// Crea un nuevo Usuario
        /// </summary>
        /// <param name="categorias"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] Usuarios usuarios)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Usuarios.Add(usuarios);
                    context.SaveChanges();
                    return Ok(usuarios);

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

        // PUT api/<UsuariosController>/5
        /// <summary>
        /// Edita usuario por id
        /// </summary>
        /// <param name="id"></param>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Usuarios usuarios)
        {
            try
            {
                if (usuarios.IdUsuario == id && ModelState.IsValid)
                {
                    context.Entry(usuarios).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok(usuarios);
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

        // DELETE api/<UsuariosController>/5
        /// <summary>
        /// Elimina un usuario por id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var uss = context.Usuarios.FirstOrDefault(c => c.IdUsuario == id);
                if (uss != null)
                {
                    context.Usuarios.Remove(uss);
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
