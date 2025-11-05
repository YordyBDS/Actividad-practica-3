using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formulario_4.Entidad_producto
{
    internal class Producto
    {
        public Producto() { }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Precio { get; set; }

        public int Stock { get; set; }

        public int ID_Categoria { get; set; }

        public int ID_producto { get; set; }
    }
}
