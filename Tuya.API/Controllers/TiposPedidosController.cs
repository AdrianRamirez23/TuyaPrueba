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
    public class TiposPedidosController : ControllerBase
    {
        private readonly APIContext context;

        public TiposPedidosController(APIContext context)
        {
            this.context = context;
        }
        // GET: api/<TiposPedidosController>
        /// <summary>
        /// Obtiene la lista de tipos de pedidos creados en la base de datos
        /// </summary>     
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.TiposPedidos.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<TiposPedidosController>/5
        /// <summary>
        /// Obtiene un Tipo de Pedido por Id
        /// </summary>     
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var tp = context.TiposPedidos.FirstOrDefault(c => c.IdTipoPedido == id);
                return Ok(tp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<TiposPedidosController>
        /// <summary>
        /// Crea un nuevo tipo de pedido
        /// </summary>
        /// <param name="categorias"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] TiposPedidos tiposPedidos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.TiposPedidos.Add(tiposPedidos);
                    context.SaveChanges();
                    return Ok(tiposPedidos);

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

        // PUT api/<TiposPedidosController>/5
        /// <summary>
        /// Edita los tipos de pedidos creados
        /// </summary>
        /// <param name="id"></param>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TiposPedidos tiposPedidos)
        {
            try
            {
                if (tiposPedidos.IdTipoPedido == id && ModelState.IsValid)
                {
                    context.Entry(tiposPedidos).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok(tiposPedidos);
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

        // DELETE api/<TiposPedidosController>/5
        /// <summary>
        /// Elimina un tipo de pedidos
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var cat = context.TiposPedidos.FirstOrDefault(c => c.IdTipoPedido == id);
                if (cat != null)
                {
                    context.TiposPedidos.Remove(cat);
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
