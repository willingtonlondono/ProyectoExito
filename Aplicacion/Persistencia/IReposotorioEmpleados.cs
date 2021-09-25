using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IReposotorioEmpleados
    {

        public List<Empleado> consultarTodosAdmin();

        public void guardarEmpleado(Empleado empleado);

        public void eliminarEmpleado(int id);


        public void actualizarEmpleado(Empleado empleado);

        public Empleado consultarEmpleado(Empleado empleado);
         
    }
}