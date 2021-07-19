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
    public class ProductosController : ControllerBase
    {
        private readonly APIContext context;

        public ProductosController(APIContext context)
        {
            this.context = context;
        }

        // GET: api/<ProductosController>
        /// <summary>
        /// Obtiene la lista de productos creados en la base de datos
        /// </summary>        
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Productos.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProductosController>/5
        /// <summary>
        /// Obtiene el productos creado en la base de datos por Id de producto
        /// </summary>  
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var prods = context.Productos.FirstOrDefault(c => c.IdProducto == id);
                return Ok(prods);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProductosController>
        /// <summary>
        /// Crea un nuevo producto
        /// </summary>  
        [HttpPost("{StockCEDI}/{StockVMI}/{StockTienda}/{StockMKP}")]
        public ActionResult Post( int StockCEDI, int StockVMI, int StockTienda, int StockMKP, [FromBody] Productos prod)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cat = context.Categorias.FirstOrDefault(c => c.IdCategoria == prod.IdCategoria);

                    if (cat != null)
                    {
                        Stocks stocks = new Stocks
                        {
                            StockCEDI = StockCEDI,
                            StockVMI = StockVMI,
                            StockTienda = StockTienda,
                            StockMKP = StockMKP
                        };
                        context.Stocks.Add(stocks);
                        context.SaveChanges();
                        prod.IdStock = stocks.IdStock;
                        context.Productos.Add(prod);
                        context.SaveChanges();
                        return Ok(prod);
                    }
                    else
                    {
                        return BadRequest("Categoria no existe");
                    }

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

        // PUT api/<ProductosController>/5
        /// <summary>
        /// Actualiza un producto creado en la base de datos
        /// </summary>  
        [HttpPut("{id}/{StockCEDI}/{StockVMI}/{StockTienda}/{StockMKP}")]
        public ActionResult Put(int id, int StockCEDI, int StockVMI, int StockTienda, int StockMKP, [FromBody] Productos prod)
        {
            try
            {
                if (prod.IdProducto == id)
                {
                    Stocks stocks = new Stocks
                    {
                        IdStock=prod.IdStock,
                        StockCEDI = StockCEDI,
                        StockVMI = StockVMI,
                        StockTienda = StockTienda,
                        StockMKP = StockMKP
                    };
                    context.Entry(stocks).State = EntityState.Modified;
                    context.Entry(prod).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok(prod);
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

        // DELETE api/<ProductosController>/5
        /// <summary>
        /// Elimina un producto de la lista de productos creados en la base de datos
        /// </summary>  
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var prods = context.Productos.FirstOrDefault(c => c.IdProducto == id);
                
                if (prods != null)
                {
                    var stocks = context.Stocks.FirstOrDefault(f => f.IdStock == prods.IdStock);
                    context.Stocks.Remove(stocks);
                    context.Productos.Remove(prods);
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
