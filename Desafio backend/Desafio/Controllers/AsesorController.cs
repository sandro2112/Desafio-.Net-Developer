using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Desafio.Models;
using Desafio.Repository;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Desafio.Controllers
{
    [ApiController]
    [Route("asesor")]
    public class AsesorController : ControllerBase
    {
        public readonly IAsesorRepository _asesorRepository;
        public AsesorController(IAsesorRepository asesorRepository)
        {
            _asesorRepository = asesorRepository;
        }

        [HttpGet]
        [Route("listarAsesoresEF")]
        public ActionResult<List<Asesor>> Get()
        {
            return Ok(_asesorRepository.GetAsesores());
        }

        [HttpGet]
        [Route("listar")]
        public dynamic listarAsesor()
        {
            //todo el código
            List<Asesor> asesores = new List<Asesor>
            {
                new Asesor
                {
                    id_asesor = 1,
                    correo = "aessor@gmail.com",
                    edad = "19",
                    nombre = "Sandro Ramos"
                },
                new Asesor
                {
                    id_asesor = 2,
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
            asesor.id_asesor = 3;

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
                id_asesor = _id,
                correo = "aessor@gmail.com",
                edad = "19",
                nombre = "Sandro Ramos"
            };

        }

        [HttpGet]
        [Route("eliminar")]
        //[Authorize]
        public dynamic eliminarAsesor(Asesor asesor)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var rToken = Jwt.validarToken(identity);

            if (!rToken.success) return rToken;

            Usuario usuario = rToken.result;

            if(usuario.rol != "administrador")
            {
                return new
                {
                    success = false,
                    message = "No tiene permiso para esta api",
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
