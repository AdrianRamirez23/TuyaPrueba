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
    public class ClientesController : ControllerBase
    {
        private readonly APIContext context;

        public ClientesController(APIContext context)
        {
            this.context = context;
        }
        // GET: api/<ClientesController>
        /// <summary>
        /// Obtiene la lista de clientes creados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Clientes.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ClientesController>/5
        /// <summary>
        /// Obtener cliente por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                var cliet = context.Clientes.FirstOrDefault(c => c.IdCliente == id);
                return Ok(cliet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ClientesController>
        /// <summary>
        /// Crea un nuevo cliente
        /// </summary>
        /// <param name="clientes"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] Clientes clientes)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Clientes.Add(clientes);
                    context.SaveChanges();
                    return Ok(clientes);
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

        // PUT api/<ClientesController>/5
        /// <summary>
        /// Actualiza un cliente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clientes"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Clientes clientes)
        {
            try
            {
                if (clientes.IdCliente == id && ModelState.IsValid)
                {
                    context.Entry(clientes).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok(clientes);
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

        // DELETE api/<ClientesController>/5
        /// <summary>
        /// Elimina un cliente por id de cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                var cliet = context.Clientes.FirstOrDefault(c => c.IdCliente == id);
                if (cliet != null)
                {
                    context.Clientes.Remove(cliet);
                    context.SaveChanges();
                    return Ok();
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
