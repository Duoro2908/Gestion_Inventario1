using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Inventario
{
    public class Producto
    {
        public string Nombre { get; set; }

        public double Precio { get; set; }

        public Producto(string nombre, double precio)
        {
            Nombre = nombre;
            Precio = precio;
        }
        public void Mostrar_Informacion()
        {
            Console.WriteLine($"Nombre:{Nombre},Precio:{Precio}");
        }
    }
}