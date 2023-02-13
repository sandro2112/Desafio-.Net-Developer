namespace Desafio.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public string idVenta { get; set; }
        public List<Producto> listaProductos { get; set; }
        public string idAsesor { get; set; }
    }
}
