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
    public class FichasController : ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> GetFichas()
        {
            using (ITikConnection connection = ConnectionFactory.CreateConnection(TikConnectionType.Api))
            {
                connection.Open("192.168.1.85", "admin", "");
                ITikCommand cmd = connection.CreateCommand("/system/identity/print");
                Console.WriteLine(cmd.ExecuteScalar());

                var listPerfiles = connection.LoadAll<HotspotUser>();

                return Ok(listPerfiles);

            }

        }
    }
}
