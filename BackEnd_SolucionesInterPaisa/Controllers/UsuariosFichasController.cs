using BackEnd_SolucionesInterPaisa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tik4net;
using tik4net.Objects;
using tik4net.Objects.Ip.Hotspot;

namespace BackEnd_SolucionesInterPaisa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosFichasController : ControllerBase
    {
        //Obteniendo variables del controlador PlanesFichasController
        PlanesFichasController instPlanesfichasController = new PlanesFichasController();


        [HttpGet]
        //Agregar el codigo de estado que retorna cuando todo sale bien
        [ProducesResponseType(200, Type = typeof(List<PlanesFichas>))]
        [ProducesResponseType(400)] //bad request, cuando algo sale mal
        public async Task<IActionResult> GetFichas()
        {
            using (ITikConnection connection = ConnectionFactory.CreateConnection(TikConnectionType.Api))
            {
                connection.Open(instPlanesfichasController.ipMKT, instPlanesfichasController.userMKT, instPlanesfichasController.passwordMKT);

                var listUsuariosFichas = connection.LoadAll<HotspotUser>();

                return Ok(listUsuariosFichas);
                connection.Close();
            }
        }

        [HttpPost]
        [ProducesResponseType(201)] //en POST se usa 201 cuando guarda correctamente
        [ProducesResponseType(400)] //bad request, cuando algo sale mal
        [ProducesResponseType(500)] //Error interno, cuabndo algo no le esta llegando correctamente
        public async Task<IActionResult> AddUsuarioFichas([FromBody] UsuarioFichas userFichas)
        {
            using (ITikConnection connection = ConnectionFactory.CreateConnection(TikConnectionType.Api))
            {
                connection.Open(instPlanesfichasController.ipMKT, instPlanesfichasController.userMKT, instPlanesfichasController.passwordMKT);
                var adduserFichas = new HotspotUser()
                {
                    Server = userFichas.serverUser,
                    Name = userFichas.nameUser,
                    Password = userFichas.passwordUser,
                    Profile = userFichas.profileUser,
                    Routes = userFichas.routesUser,
                    Comment = userFichas.commentuser
                };
                connection.Save(adduserFichas);                
                return Ok(adduserFichas);
            }
        }
    }
}
