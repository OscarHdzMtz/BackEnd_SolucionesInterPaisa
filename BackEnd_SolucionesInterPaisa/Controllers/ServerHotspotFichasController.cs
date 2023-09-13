using BackEnd_SolucionesInterPaisa.data;
using BackEnd_SolucionesInterPaisa.Models;
using BackEnd_SolucionesInterPaisa.ApiMikrotik;
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
    public class ServerHotspotFichasController : ControllerBase
    {             
            
            //Obteniendo variables del controlador PlanesFichasController
            Utilerias instPlanesfichasController = new Utilerias();
        [HttpGet]
        //Agregar el codigo de estado que retorna cuando todo sale bien
        [ProducesResponseType(200, Type = typeof(List<PlanesFichas>))]
        [ProducesResponseType(400)] //bad request, cuando algo sale mal
        public async Task<IActionResult> GetServerHostpotFichas()
        {

            using (ITikConnection connection = ConnectionFactory.CreateConnection(TikConnectionType.Api))
            {
                connection.Open(instPlanesfichasController.ipMKT, 8728, instPlanesfichasController.userMKT, instPlanesfichasController.passwordMKT);
                //ITikCommand cmd = connection.CreateCommand("ip/hotspot/ip-binding");
                //var identity = cmd.ExecuteScalar();
                //Console.WriteLine("Identity: {0}", identity);
                var servidoresHotspot = connection.LoadAll<HotspotServer>().ToList();
                //AGREGAMOS EL SERVIDOR all A LA LISTA DE SERVIDORES HOTSPOT YA QUE NO VIENE AGREGADO
                var addServidor = new HotspotServer()
                {
                    Id = "*0",
                    Name = "all"
                };
                servidoresHotspot.Add(addServidor);
                //ORDENAMOS LA LISTA POR NOMBRES
                var ordenerServiodoresHotspot = servidoresHotspot.OrderBy(x => x.Name);
                connection.Close();
                return Ok(ordenerServiodoresHotspot);
            }
        }
    }
}
