using APIProductos.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace APIProductos.Data
{
    public class ApplicationDBC:DbContext
    {
        public ApplicationDBC(
            DbContextOptions<ApplicationDBC> options): base(options) 
        {

        }
        DbSet<Producto> Producto{get; set;}
    }
}
