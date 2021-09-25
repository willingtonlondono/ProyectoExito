namespace Dominio
{
    public class Consola
    {
        public int Id {get; set;}

        public string Nombre {get; set;}

        public string Version {get; set;}

        public int Almacenamiento {get; set;}

        public TipoAlmacenamiento TipoAlmacenamiento {get; set;}

        public int VelocidadRam {get; set;}

        public int VelocidadProcesador {get; set;}

        public double Precio {get; set;}

    }
}