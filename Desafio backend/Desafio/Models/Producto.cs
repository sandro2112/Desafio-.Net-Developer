namespace Desafio.Models
{
    public class Producto
    {
        public string nombreProducto { get; set; }
        public double precioProducto { get; set; }
        public int id_producto { get; set; }
        public Venta venta { get; set; }
    }
}
