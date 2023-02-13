using Desafio.Models;
using Desafio.EFCore;
using Microsoft.EntityFrameworkCore;
namespace Desafio.Repository
{
    public class AsesorRepository : IAsesorRepository
    {
        public AsesorRepository()
        {
            using (var context = new ApiContext())
            {
                var asesores = new List<Asesor>
                {
                new Asesor
                {
                    nombre ="Joydip",
                    correo ="Kanjilal",
                    edad = "25",
                    id_asesor = 10                      
                },
                new Asesor
                {
                    nombre ="Fernando",
                    correo ="Carbajal",
                    edad = "27",
                    id_asesor = 12
                }                
                };
                context.Asesores.AddRange(asesores);
                context.SaveChanges();
            }
        }
        public List<Asesor> GetAsesores()
        {
            using (var context = new ApiContext())
            {
                var list = context.Asesores
                    //.Include(a => a.nombre)
                    .ToList();
                return list;
            }
        }
    }
}
