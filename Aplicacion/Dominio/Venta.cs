namespace Dominio
{
    public class Venta
    {
       public int Id {get;set;}

        public string NumeroFactura {get;set;}

        public Producto Producto {get;set;}
    
        public int CantidadProducto {get;set;}

        public double TotalVenta {get;set;}

        public Empleado Empleado {get;set;}
    }
}