using Microsoft.AspNetCore.Mvc;
using Desafio.Models;

namespace Desafio.Controllers
{
    [ApiController]
    [Route("asesor")]
    public class AsesorController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public dynamic listarAsesor()
        {
            //todo el código
            List<Asesor> asesores = new List<Asesor>
            {
                new Asesor
                {
                    id = 1,
                    correo = "aessor@gmail.com",
                    edad = "19",
                    nombre = "Sandro Ramos"
                },
                new Asesor
                {
                    id = 2,
                    correo = "aessor2@gmail.com",
                    edad = "29",
                    nombre = "Sandro Saravia"
                }
            };

            return asesores;
                                    
        }

        [HttpPost]
        [Route("guardar")]
        public dynamic guardarAsesor(Asesor asesor)
        {
            asesor.id = 3;

            return new
            {
                success = true,
                message = "asesor registrado",
                result = asesor
            };
        }

        [HttpGet]
        [Route("listarxid")]
        public dynamic listarAsesorxid( int _id)
        {
            //obtienes el asesor de la bd
            

            return new Asesor
            {
                id = _id,
                correo = "aessor@gmail.com",
                edad = "19",
                nombre = "Sandro Ramos"
            };

        }

        [HttpPost]
        [Route("eliminar")]
        public dynamic eliminarAsesor(Asesor asesor)
        {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
            //eliminas en la db

            if(token != "sandro123.")
            {
                return new
                {
                    succes = false,
                    message = "token incorrecto",
                    result = ""
                };
            }
            
            return new
            {
                success = true,
                message = "asesor eliminado",
                result = asesor
            };
        }

        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}
