namespace Dominio
{
    public class Producto
    {
        public int Id {get;set;}

        public string CodigoProducto {get;set;}

        public double PrecioCompra {get;set;}

        public double PrecioVenta {get;set;}

        public Empleado Empleado {get;set;}

        public bool vendido {get; set;}
    }
}