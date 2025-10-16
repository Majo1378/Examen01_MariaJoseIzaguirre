using System;
using System.Collections.Generic;

namespace ElectroPlus
{
    class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Producto> productos = new List<Producto>();
            int opcion = 0;

            while (opcion != 5)
            {
                Console.WriteLine("\n===== SISTEMA DE INVENTARIO - ELECTROPLUS =====");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Listar productos");
                Console.WriteLine("3. Buscar producto por código");
                Console.WriteLine("4. Mostrar productos sin stock");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("⚠️ Opción inválida. Debe ingresar un número del 1 al 5.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        try
                        {
                            Producto nuevo = new Producto();

                            Console.Write("Código: ");
                            nuevo.Codigo = Console.ReadLine();

                            Console.Write("Nombre: ");
                            nuevo.Nombre = Console.ReadLine();

                            Console.Write("Precio: ");
                            nuevo.Precio = Convert.ToDecimal(Console.ReadLine());

                            Console.Write("Cantidad: ");
                            nuevo.Cantidad = Convert.ToInt32(Console.ReadLine());

                            productos.Add(nuevo);
                            Console.WriteLine("✅ Producto agregado correctamente.");
                        }
                        catch
                        {
                            Console.WriteLine("⚠️ Error: Ingrese valores válidos para precio y cantidad.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("\n--- LISTA DE PRODUCTOS ---");
                        if (productos.Count == 0)
                            Console.WriteLine("No hay productos registrados.");
                        else
                            foreach (var p in productos)
                                Console.WriteLine($"{p.Codigo}|{p.Nombre}|{p.Precio}|{p.Cantidad}");
                        break;

                    case 3:
                        Console.Write("Ingrese el código a buscar: ");
                        string cod = Console.ReadLine();
                        var encontrado = productos.Find(p => p.Codigo == cod);
                        if (encontrado != null)
                            Console.WriteLine($"{encontrado.Codigo}|{encontrado.Nombre}|{encontrado.Precio}|{encontrado.Cantidad}");
                        else
                            Console.WriteLine("❌ Producto no encontrado.");
                        break;

                    case 4:
                        Console.WriteLine("\n--- PRODUCTOS SIN STOCK ---");
                        bool haySinStock = false;
                        foreach (var p in productos)
                        {
                            if (p.Cantidad == 0)
                            {
                                Console.WriteLine($"{p.Codigo}|{p.Nombre}|{p.Precio}|{p.Cantidad}");
                                haySinStock = true;
                            }
                        }
                        if (!haySinStock)
                            Console.WriteLine("Todos los productos tienen stock disponible.");
                        break;

                    case 5:
                        Console.WriteLine("👋 Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("⚠️ Opción no válida, intente de nuevo.");
                        break;
                }
            }
        }
    }
}