using System;
using System.Collections.Generic;

namespace ExamenAlejandro_Carvajal
{
    public class Menu
    {
        private List<Empleado> empleados = new List<Empleado>();

        public void MostrarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("------Examen Alejandro Carvajal----- ");
                Console.WriteLine("----- Menú de Recursos Humanos -----");
                Console.WriteLine("1. Agregar Empleados");
                Console.WriteLine("2. Consultar Empleados");
                Console.WriteLine("3. Modificar Empleados");
                Console.WriteLine("4. Borrar Empleados");
                Console.WriteLine("5. Reportes");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AggEmpleados(); 
                        break;
                    case "2":
                        ConsuEmpleado();
                        break;
                    case "3":
                        ModiEmpleado();
                        break;
                    case "4":
                        BorrarEmpleado();
                        break;
                    case "5":
                        GenerarReportes();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void AggEmpleados() 
        {
            Console.Clear();
            Console.WriteLine("----- Agregar Empleados -----");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Empleado {i + 1}:");
                Console.Write("Cédula: ");
                string cedula = Console.ReadLine();
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("Dirección: ");
                string direccion = Console.ReadLine();
                Console.Write("Teléfono: ");
                string telefono = Console.ReadLine();
                Console.Write("Salario: ");
                decimal salario = decimal.Parse(Console.ReadLine());

                empleados.Add(new Empleado(cedula, nombre, direccion, telefono, salario));

                if (i < 9) 
                {
                    Console.Write("¿Desea agregar otro empleado? (si/no): ");
                    string continuar = Console.ReadLine();
                    if (continuar.ToLower() != "si")
                    {
                        break;
                    }
                }
            }

            Console.WriteLine("Empleados agregados. Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void ConsuEmpleado()
        {
            Console.Clear();
            Console.WriteLine("----- Consultar Empleado -----");
            Console.Write("Ingrese la cédula del empleado: ");
            string cedula = Console.ReadLine();

            var empleado = empleados.Find(e => e.Cedula == cedula);
            if (empleado != null)
            {
                empleado.MostrarInformacion();
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void ModiEmpleado()
        {
            Console.Clear();
            Console.WriteLine("----- Modificar Empleado -----");
            Console.Write("Ingrese la cédula del empleado: ");
            string cedula = Console.ReadLine();

            var empleado = empleados.Find(e => e.Cedula == cedula);
            if (empleado != null)
            {
                Console.Write("Nuevo Nombre: ");
                empleado.Nombre = Console.ReadLine();
                Console.Write("Nueva Dirección: ");
                empleado.Direccion = Console.ReadLine();
                Console.Write("Nuevo Teléfono: ");
                empleado.Telefono = Console.ReadLine();
                Console.Write("Nuevo Salario: ");
                empleado.Salario = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Empleado modificado.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void BorrarEmpleado()
        {
            Console.Clear();
            Console.WriteLine("----- Borrar Empleado -----");
            Console.Write("Ingrese la cédula del empleado a borrar: ");
            string cedula = Console.ReadLine();

            var empleado = empleados.Find(e => e.Cedula == cedula);
            if (empleado != null)
            {
                empleados.Remove(empleado);
                Console.WriteLine("Empleado borrado.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void GenerarReportes()
        {
            Console.Clear();
            Console.WriteLine("----- Reportes -----");
            Console.WriteLine("1. Listar todos los empleados");
            Console.WriteLine("2. Calcular promedio de salarios");
            Console.WriteLine("3. Salario más alto y más bajo");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ListarEmpleados();
                    break;
                case "2":
                    PromedioSalarios();
                    break;
                case "3":
                    SalarioMaxMin();
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void ListarEmpleados()
        {
            Console.WriteLine("----- Lista de Empleados -----");
            foreach (var empleado in empleados)
            {
                empleado.MostrarInformacion();
            }
        }

        private void PromedioSalarios()
        {
            decimal sumaSalarios = 0;
            foreach (var empleado in empleados)
            {
                sumaSalarios += empleado.Salario;
            }
            decimal promedio = empleados.Count > 0 ? sumaSalarios / empleados.Count : 0;
            Console.WriteLine($"Promedio de salarios: {promedio:C}");
        }

        private void SalarioMaxMin()
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados para calcular.");
                return;
            }

            decimal salarioMaximo = decimal.MinValue;
            decimal salarioMinimo = decimal.MaxValue;

            foreach (var empleado in empleados)
            {
                if (empleado.Salario > salarioMaximo)
                {
                    salarioMaximo = empleado.Salario;
                }
                if (empleado.Salario < salarioMinimo)
                {
                    salarioMinimo = empleado.Salario;
                }
            }

            Console.WriteLine($"Salario más alto: {salarioMaximo:C}");
            Console.WriteLine($"Salario más bajo: {salarioMinimo:C}");
        }
    }
}

