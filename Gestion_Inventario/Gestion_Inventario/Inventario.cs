using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Inventario
{
    public class Inventario
    {
        private List<Producto> productos;

        public Inventario()
        {
            productos = new List<Producto>();
        }
        public void Agregar_Producto(Producto producto)
        {
            productos.Add(producto);
        }
        public IEnumerable<Producto> Filtrar_Y_Ordenar_Productos(double precio_Minimo)
        {
            return productos
                .Where(p => p.Precio > precio_Minimo)
                .OrderBy(p => p.Precio);
        }

        public void Precio_Actualizado(string nombre_producto, double Precio_nuevo)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre == nombre_producto);
            if (producto != null)
            {
                producto.Precio = Precio_nuevo;
                Console.WriteLine($"El precio de {nombre_producto} ha sido actualizado a {Precio_nuevo}");
            }
            else
            {
                Console.WriteLine("Lo sentimos producto no encontrado");
            }
        }
        public void Productos_Eliminados(string nombre_producto)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre == nombre_producto);
            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine($"El producto {nombre_producto} fue eliminado");
            }
            else
            {
                Console.WriteLine("EL producto no fue encontrado");
            }
        }


        public void Contar_Productos_Por_Rango_De_Precio()
        {
            int rango_Menor_150 = productos.Count(p => p.Precio < 150);
            int rango_Entre_150y500 = productos.Count(p => p.Precio >= 150 && p.Precio <= 500);
            int rango_Mayor_500 = productos.Count(p => p.Precio > 500);


            Console.WriteLine("\n");
            Console.WriteLine($"Productos que tienen precio menor a 150: {rango_Menor_150}");
            Console.WriteLine($"Productos que tienen precio entre 150 y 500: {rango_Entre_150y500}");
            Console.WriteLine($"Productos que tienen precio mayor a 500: {rango_Mayor_500}");
        }


        public void Reportes_Resumidos()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay ningun producto en el inventario.");
                return;
            }

            double precio_Promedio = productos.Average(p => p.Precio);
            var producto_Mas_Caro = productos.OrderByDescending(p => p.Precio).First();
            var producto_Mas_Barato = productos.OrderBy(p => p.Precio).First();

            Console.WriteLine("\n");
            Console.WriteLine($"Aqui le proporcionamos un Reporte de inventario");
            Console.WriteLine($"Total de productos: {productos.Count}");
            Console.WriteLine($"Precio promedio: {precio_Promedio}");
            Console.WriteLine($"Producto más caro: {producto_Mas_Caro.Nombre} con precio de: {producto_Mas_Caro.Precio}");
            Console.WriteLine($"Producto más barato: {producto_Mas_Barato.Nombre}  con precio de: {producto_Mas_Barato.Precio}");
        }
    }
}





