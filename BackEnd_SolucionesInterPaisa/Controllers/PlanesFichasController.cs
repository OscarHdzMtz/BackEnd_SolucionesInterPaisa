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
        [HttpGet]
        public async Task<IActionResult> getPlanesFichas()
        {
            using (ITikConnection connection = ConnectionFactory.CreateConnection(TikConnectionType.Api))
            {
                connection.Open("192.168.1.85", "admin", "");

                var listPerfilesFicha = connection.LoadAll<HotspotUserProfile>();

                return Ok(listPerfilesFicha);                
            }
        }
    }
}
