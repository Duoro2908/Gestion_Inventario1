using System;

namespace Gestion_Inventario
{
    class Program
    {
        public static void Main(string[] args)
        {
            Inventario miinventario = new Inventario();
            Console.WriteLine("Bienvenido al sistema de Gestión de Inventario");


            Console.Write("Cuantos productos desea ingresar? ");
            int cantidad = int.Parse(Console.ReadLine());

            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"Producto {i + 1}:");

                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();
                while (nombre == "")
                {
                    Console.WriteLine("El nombre no puede estar vacío.");
                    Console.Write("Nombre: ");
                    nombre = Console.ReadLine();
                }

                double precio;
                do
                {
                    Console.Write("Precio: ");
                    precio = double.Parse(Console.ReadLine());
                    if (precio <= 0)
                    {
                        Console.WriteLine("El precio debe ser un número positivo corrija");
                    }
                } while (precio <= 0);

                Producto miproducto = new Producto(nombre, precio);
                miinventario.Agregar_Producto(miproducto);
                Console.WriteLine("\n");
            }

            while (true)
            {
                Console.WriteLine("puedes agregar alguna opcion si deseas:");
                Console.WriteLine("\n");
                Console.WriteLine("1 Filtrar y ordenar productos por precio mínimo");
                Console.WriteLine("2 Actualizar precio de un producto");
                Console.WriteLine("3 Eliminar un producto");
                Console.WriteLine("4 Contar y agrupar productos por rango de precio");
                Console.WriteLine("5 Generar reporte del inventario");
                Console.WriteLine("6. Salir");

                Console.Write("Seleccione una opción por favor: ");
                int opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        Console.Write("Ingrese el precio mínimo para filtrar los productos: ");
                        double precio_Minimo = double.Parse(Console.ReadLine());
                        var productos_Filtrados = miinventario.Filtrar_Y_Ordenar_Productos(precio_Minimo);
                        Console.WriteLine("\n");

                        Console.WriteLine("Productos filtrados y ordenados:");
                        foreach (var producto in productos_Filtrados)
                        {
                            producto.Mostrar_Informacion();
                        }
                        break;

                    case 2:
                        Console.Write("Ingrese el nombre del producto a actualizar: ");
                        string nombre_A_actualizar = Console.ReadLine();
                        Console.WriteLine("\n");
                        Console.Write("Ingrese el precio nuevo: ");
                        double Precio_nuevo = double.Parse(Console.ReadLine());
                        miinventario.Precio_Actualizado(nombre_A_actualizar, Precio_nuevo);
                        break;

                    case 3:
                        Console.Write("Ingrese el nombre del producto que quiere eliminar: ");
                        string nombre_Eliminar = Console.ReadLine();
                        Console.WriteLine("\n");
                        miinventario.Productos_Eliminados(nombre_Eliminar);
                        break;

                    case 4:
                        miinventario.Contar_Productos_Por_Rango_De_Precio();

                        break;

                    case 5:
                        miinventario.Reportes_Resumidos();
                        break;

                    case 6:
                        Console.WriteLine("Gracias por utilizar el sistema fue un gusto servirle");
                        Console.WriteLine("Att: Futuro Ing: Alexander Mendez");
                        return;

                    default:
                        Console.WriteLine("Opción no válida, intente nuevamente");
                        break;
                }
            }
        }
    }
}
