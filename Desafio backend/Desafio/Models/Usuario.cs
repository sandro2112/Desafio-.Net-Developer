namespace Desafio.Models
{
    public class Usuario
    {
        public string idUsuario { get; set; }
        public string nameUsuario { get; set;}
        public string passwordUsuario { get; set;}
        public string rol { get; set; }
        public static List<Usuario> DB()
        {
            var list = new List<Usuario>()
            {
                new Usuario()
                {
                    idUsuario = "1",
                    nameUsuario = "Gabriel",
                    passwordUsuario = "123.",
                    rol = "asesor"
                },
                new Usuario()
                {
                    idUsuario = "2",
                    nameUsuario = "Joel",
                    passwordUsuario = "123.",
                    rol = "asesor"
                },
                new Usuario()
                {
                    idUsuario = "3",
                    nameUsuario = "Martin",
                    passwordUsuario = "123.",
                    rol = "asesor"
                },
                new Usuario()
                {
                    idUsuario = "1",
                    nameUsuario = "Alonso",
                    passwordUsuario = "123.",
                    rol = "administrador"
                }
            };

            return list;
        }
    }
}
