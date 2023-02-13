namespace Desafio.Models
{
    public class Venta
    {
        public string idVenta { get; set; }
        public List<Producto> listaProductos { get; set; }
        public string idAsesor { get; set; }
    }
}
