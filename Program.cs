using System;
using System.Collections.Generic;

namespace AgendaPro
{
    class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public Persona(int id, string nombre, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Telefono = telefono;
        }
    }

    class Cita
    {
        public int PersonaId { get; set; }
        public string Fecha { get; set; }
        public string Descripcion { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Persona> personas = new List<Persona>();
            List<Cita> citas = new List<Cita>();
            int opcion = 0;

            while (opcion != 6)
            {
                Console.WriteLine("\n===== SISTEMA AGENDA PRO =====");
                Console.WriteLine("1. Registrar persona");
                Console.WriteLine("2. Listar personas");
                Console.WriteLine("3. Crear cita");
                Console.WriteLine("4. Listar citas por PersonaId");
                Console.WriteLine("5. Mostrar todas las citas");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("⚠️ Opción inválida. Debe ingresar un número del 1 al 6.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        try
                        {
                            Console.Write("ID: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            if (personas.Exists(p => p.Id == id))
                            {
                                Console.WriteLine("⚠️ Ya existe una persona con ese ID.");
                                break;
                            }

                            Console.Write("Nombre: ");
                            string nombre = Console.ReadLine();

                            Console.Write("Teléfono: ");
                            string telefono = Console.ReadLine();

                            personas.Add(new Persona(id, nombre, telefono));
                            Console.WriteLine("✅ Persona registrada correctamente.");
                        }
                        catch
                        {
                            Console.WriteLine("⚠️ Error: Ingrese datos válidos.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("\n--- LISTADO DE PERSONAS ---");
                        if (personas.Count == 0)
                            Console.WriteLine("No hay personas registradas.");
                        else
                            foreach (var p in personas)
                                Console.WriteLine($"{p.Id}|{p.Nombre}|{p.Telefono}");
                        break;

                    case 3:
                        try
                        {
                            Console.Write("Ingrese el ID de la persona: ");
                            int pid = Convert.ToInt32(Console.ReadLine());

                            if (!personas.Exists(p => p.Id == pid))
                            {
                                Console.WriteLine("❌ No existe ninguna persona con ese ID.");
                                break;
                            }

                            Console.Write("Fecha (dd/mm/aaaa): ");
                            string fecha = Console.ReadLine();

                            Console.Write("Descripción: ");
                            string desc = Console.ReadLine();

                            citas.Add(new Cita { PersonaId = pid, Fecha = fecha, Descripcion = desc });
                            Console.WriteLine("✅ Cita registrada correctamente.");
                        }
                        catch
                        {
                            Console.WriteLine("⚠️ Error al ingresar los datos de la cita.");
                        }
                        break;

                    case 4:
                        Console.Write("Ingrese el ID de la persona: ");
                        int buscarId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"\n--- CITAS DE PERSONA {buscarId} ---");
                        bool tieneCitas = false;
                        foreach (var c in citas)
                        {
                            if (c.PersonaId == buscarId)
                            {
                                Console.WriteLine($"{c.PersonaId}|{c.Fecha}|{c.Descripcion}");
                                tieneCitas = true;
                            }
                        }
                        if (!tieneCitas)
                            Console.WriteLine("Esta persona no tiene citas registradas.");
                        break;

                    case 5:
                        Console.WriteLine("\n--- TODAS LAS CITAS ---");
                        if (citas.Count == 0)
                            Console.WriteLine("No hay citas registradas.");
                        else
                            foreach (var c in citas)
                                Console.WriteLine($"{c.PersonaId}|{c.Fecha}|{c.Descripcion}");
                        break;

                    case 6:
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