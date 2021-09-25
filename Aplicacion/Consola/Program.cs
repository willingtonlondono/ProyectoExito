using System;
using Dominio;
using Persistencia;
using System.Linq;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            
            RepositorioEmpleado repositorioEmpleado = new RepositorioEmpleado();
            Empleado empleado = new Empleado();
            empleado.Nombre = "Santiago";
            empleado.Apellidos = "Castañeda";
            empleado.Cedula = "1234";
            empleado.CodigoEmpleado = 1234;
            empleado.sucursal = "Manizales";
            empleado.NombreRol = NombreRol.ADMINISTRADOR_COMPRAS;
            repositorioEmpleado.guardarEmpleado(empleado);
        }
    }
}
