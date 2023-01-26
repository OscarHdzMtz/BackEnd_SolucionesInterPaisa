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
    public class UsuariosFichasActivosController : ControllerBase
    {
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

                var listUsuariosFichasActivas = connection.LoadAll<HotspotActive>();
                //var ordenarlistUsuariosFichas = listUsuariosFichas.OrderBy(x => x.Name).Where(y => y.Name != "default-trial").ToList();
                return Ok(listUsuariosFichasActivas);
                connection.Close();
            }
        }
    }
}
