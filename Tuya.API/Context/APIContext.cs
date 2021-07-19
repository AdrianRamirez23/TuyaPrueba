using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuya.API.Models;

namespace Tuya.API.Context
{
    public class APIContext: DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {

        }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Stocks> Stocks { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<TiposPedidos> TiposPedidos { get; set; }
        public DbSet<TiposUsuarios> TiposUsuarios  { get; set; }
        public DbSet<Usuarios> Usuarios  { get; set; }
        public DbSet<DetalleFactura> DetalleFactura  { get; set; }
        public DbSet<Facturas> Facturas  { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
    }
}
