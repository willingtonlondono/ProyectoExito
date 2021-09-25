using Persistencia;
using Dominio;
using System.Collections.Generic;
using System.Linq;
namespace Consola
{
    public class RepositorioEmpleado : IReposotorioEmpleados
    
    {
        Conexion conexion = new Conexion();
        public List<Empleado> consultarTodosAdmin(){
            return conexion.Empleados.Where(e => e.NombreRol == NombreRol.ADMINISTRADOR_COMPRAS ).ToList();
        }


        public void guardarEmpleado(Empleado empleado){
            conexion.Empleados.Add(empleado);
            conexion.SaveChanges();
        }

        public void eliminarEmpleado(int id){
            var empleado = conexion.Empleados.First(e => e.Id == id);
            conexion.Empleados.Remove(empleado);
            conexion.SaveChanges();
        }

        public void actualizarEmpleado(Empleado empleado){
            var empleadoBusqueda = conexion.Empleados.First(e => e.Id == empleado.Id);
            empleadoBusqueda.Nombre = empleado.Nombre;
            empleadoBusqueda.Apellidos = empleado.Apellidos;
            empleadoBusqueda.Cedula = empleado.Cedula;
            empleadoBusqueda.sucursal = empleado.sucursal;
            empleadoBusqueda.CodigoEmpleado = empleado.CodigoEmpleado;
            empleadoBusqueda.NombreRol = empleado.NombreRol;
            conexion.SaveChanges();
        }

        public Empleado consultarEmpleado(Empleado empleado){
            var empleadoBusqueda = conexion.Empleados.First(e => e.Nombre == empleado.Nombre);
            return empleadoBusqueda;
        }
            
    }
}