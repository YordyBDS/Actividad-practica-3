using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;






namespace Biblioteca_de_clases
{


    //=================Cliente=================\\
    public class Clientes
    {
        public Clientes() { }

        public string Nombre_completo { get; set; }

        public string Correo_Electronico { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        [Key]
        public int ClienteID { get; set; }
    }


    //==================Categoria==================\\
    public class Categoria
    {
        public Categoria() { }

        public string Nombre { get; set; }

        [Key]
        public int CategoriaID { get; set; }
    }


    //==================Proveedor==================\\
    public class Proveedores
    {
        public Proveedores() { }

        public string NombreProveedor { get; set; }

        public string CorreoElectronico { get; set; }

        public string Telefono { get; set; }

        [Key]
        public int ProveedorID { get; set; }
    }


    //==================Producto==================\\
    public class Producto
    {
        public Producto() { }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Precio { get; set; }

        public int Stock { get; set; }

        [Key]
        public int ProductoID { get; set; }

        public int CategoriaID { get; set; }
    }


    //==================AppDbContext==================\\
    public class AppDbContext : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=DESKTOP-7HI1QD0;Database=base_de_datos_practica;Trusted_Connection=True;Encrypt=False;"
                );
            }
        }
    }

}
