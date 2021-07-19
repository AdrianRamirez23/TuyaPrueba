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
    public class CategoriasController : ControllerBase
    {
        private readonly APIContext context;

        public CategoriasController(APIContext context)
        {
            this.context = context;
        }
        // GET: api/<CategoriasController>
        /// <summary>
        /// Obtiene la lista de categorias creados en la base de datos
        /// </summary>     
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Categorias.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CategoriasController>/5
        /// <summary>
        /// Obtiene una categoría por Id
        /// </summary>     
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var cat = context.Categorias.FirstOrDefault(c => c.IdCategoria == id);
                return Ok(cat);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CategoriasController>
        /// <summary>
        /// Crea una nueva categoria
        /// </summary>
        /// <param name="categorias"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] Categorias categorias)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Categorias.Add(categorias);
                    context.SaveChanges();
                    return Ok(categorias);
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

        // PUT api/<CategoriasController>/5
        /// <summary>
        /// Edita las categorías creadas
        /// </summary>
        /// <param name="id"></param>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Categorias categorias)
        {
            try
            {
                if (categorias.IdCategoria == id && ModelState.IsValid)
                {
                    context.Entry(categorias).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok(categorias);
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

        // DELETE api/<CategoriasController>/5
        /// <summary>
        /// Elimina una categoria de la base de datos
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var cat = context.Categorias.FirstOrDefault(c => c.IdCategoria == id);
                if (cat != null)
                {
                    context.Categorias.Remove(cat);
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
