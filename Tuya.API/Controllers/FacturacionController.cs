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
    public class FacturacionController : ControllerBase
    {
        private readonly APIContext context;

        public FacturacionController(APIContext context)
        {
            this.context = context;
        }
        // GET: api/<FacturacionController>
        /// <summary>
        /// Obtiene la lista facturas
        /// </summary>     
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Facturas.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<FacturacionController>/5
        /// <summary>
        /// Obtiene una factura por id
        /// </summary>     
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var fac = context.Facturas.FirstOrDefault(c => c.IdFactura == id);
                return Ok(fac);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<FacturacionController>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="detalleFactura"></param>
        /// <param name="Flete"></param>
        /// <param name="IdCliente"></param>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        [HttpPost("{Flete}/{IdCliente}/{IdUsuario}")]
        public ActionResult Post([FromBody] List<DetalleFactura> detalleFactura, double? Flete, string IdCliente, int IdUsuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var idDetalle = (from det in context.DetalleFactura orderby det.IdDetalleFactura descending select det.IdDetalleFactura).FirstOrDefault();

                    var IdClien = context.Clientes.FirstOrDefault(c => c.IdCliente == IdCliente);
                    var IdUss = context.Usuarios.FirstOrDefault(c => c.IdUsuario == IdUsuario);
                    

                    if(IdClien != null)
                    {
                        if(IdUss != null)
                        {
                            if (idDetalle > 0)
                            {
                                idDetalle = idDetalle + 1;
                            }
                            else
                            {
                                idDetalle = 1;
                            }

                            double SubTotal = 0;
                            double Impuestos = 0;

                            foreach (DetalleFactura detalle in detalleFactura)
                            {
                                var prod = context.Productos.FirstOrDefault(p => p.IdProducto == detalle.IdProducto);
                                if(prod != null)
                                {
                                    detalle.IdDetalleFactura = idDetalle;
                                    context.DetalleFactura.Add(detalle);
                                    context.SaveChanges();
                                    var precio = (from pro in context.Productos where pro.IdProducto == detalle.IdProducto select pro.Precio).FirstOrDefault();
                                    SubTotal = SubTotal + (precio * detalle.Cantidad);
                                }
                                else
                                {
                                    return BadRequest("El producto no existe");
                                }

                            }
                            Impuestos = SubTotal * 0.19;

                            Facturas fac = new Facturas()
                            {
                                IdCliente = IdCliente,
                                IdDetalleFactura = idDetalle,
                                SubTotal = SubTotal,
                                Impuestos = Impuestos,
                                Flete = (Flete != null) ? Flete.Value : 0,
                                Total = SubTotal - Impuestos + Flete.Value,
                                UsuarioFactura = IdUsuario,
                                FechaFactura = DateTime.Today
                            };

                            context.Facturas.Add(fac);
                            context.SaveChanges();

                            return Ok(fac);
                        }
                        else
                        {
                            return BadRequest("El usuario no existe");
                        }
                    }
                    else
                    {
                        return BadRequest("El Cliente no existe");
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

   
        [HttpPost]
        public ActionResult Post( [FromBody] Pedidos Pedidos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var idFac = context.Facturas.FirstOrDefault(f => f.IdFactura == Pedidos.IdFactura);
                    var idDet = context.DetalleFactura.FirstOrDefault(d => d.IdDetalleFactura == Pedidos.IdDetalleFactura);
                    if (Pedidos.FechaReparto < Pedidos.FechaDespacho)
                    {
                        Pedidos.FechaReparto = null;
                    }
                    if (Pedidos.FechaEntrega < Pedidos.FechaDespacho)
                    {
                        Pedidos.FechaEntrega = null;
                    }
                    if(idFac != null)
                    {
                        if(idDet != null)
                        {
                            context.Pedidos.Add(Pedidos);
                            context.SaveChanges();
                            return Ok(Pedidos);
                        }
                        else
                        {
                            return BadRequest("El detalle de factura no existe");
                        }
                    }
                    else
                    {
                        return BadRequest("La Factura no existe");
                    }
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
