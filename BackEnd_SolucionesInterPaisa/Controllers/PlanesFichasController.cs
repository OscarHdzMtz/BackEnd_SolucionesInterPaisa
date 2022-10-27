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
    public class PlanesFichasController : ControllerBase
    {
        public string ipMKT = "192.168.1.81";
        public string userMKT = "admin";
        public string passwordMKT = "";
        [HttpGet]
        public async Task<IActionResult> getPlanesFichas()
        {

            using (ITikConnection connection = ConnectionFactory.CreateConnection(TikConnectionType.Api))
            {
                connection.Open(ipMKT, userMKT, passwordMKT);

                var listPerfilesFicha = connection.LoadAll<HotspotUserProfile>();
                listPerfilesFicha.Count();
                
                return Ok(listPerfilesFicha);                
            }
        }
        [HttpPost]
        [ProducesResponseType(201)] //en POST se usa 201 cuando guarda correctamente
        [ProducesResponseType(400)] //bad request, cuando algo sale mal
        [ProducesResponseType(500)] //Error interno, cuabndo algo no le esta llegando correctamente
        public async Task<IActionResult> AddPlanesFichas([FromBody] PlanesFichas planesFichas)
        {
            using (ITikConnection connection = ConnectionFactory.CreateConnection(TikConnectionType.Api))
            {
                connection.Open(ipMKT, userMKT, passwordMKT);
                var profile = new HotspotUserProfile()
                {
                    Name = planesFichas.nameProfile,
                    AddressPool = planesFichas.addressPoolProfile,
                    RateLimit = planesFichas.velocidadSubidaBajadaProfile,
                    MacCookieTimeout = planesFichas.limiteDeTiempoProfile,
                    AddMacCookie = planesFichas.addMacCookieProfile,
                    OnLogin = planesFichas.onLoginProfile,
                    OnLogout = planesFichas.onLogoutProfile
                };
                connection.Save(profile);
                return Ok(profile);
            }
        }
    }
}
