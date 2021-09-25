namespace Dominio
{
    public class Empleado
    {
        public int Id {get; set;}
        public string Nombre {get; set;}
        public string Apellidos {get; set;}
        public string Cedula {get; set;}
        public int CodigoEmpleado {get; set;}
        public NombreRol NombreRol {get; set;}
        public string sucursal {get; set;}
        public string usuario {get; set;}
        public string password {get; set;}
        public bool accesoReportes {get; set;}

    }
}