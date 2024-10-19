using System;

namespace ExamenAlejandro_Carvajal
{
    public class Empleado
    {
        private string cedula;
        private string nombre;
        private string direccion;
        private string telefono;
        private decimal salario;

        public Empleado(string cedula, string nombre, string direccion, string telefono, decimal salario)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.salario = salario;
        }

        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public decimal Salario { get => salario; set => salario = value; }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Cédula: {cedula}");
            Console.WriteLine($"Nombre: {nombre}");
            Console.WriteLine($"Dirección: {direccion}");
            Console.WriteLine($"Teléfono: {telefono}");
            Console.WriteLine($"Salario: {salario:C}"); 
        }
    }
}
