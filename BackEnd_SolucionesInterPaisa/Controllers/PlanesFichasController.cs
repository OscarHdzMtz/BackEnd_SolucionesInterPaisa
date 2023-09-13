using BackEnd_SolucionesInterPaisa.data;
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
      
        public readonly ApplicationDbContext _db;

        //CREAR CONSTRUCTOR
        public PlanesFichasController(ApplicationDbContext db)
        {
            _db = db;
        }

        Utilerias instPlanesfichasController = new Utilerias();
        [HttpGet]
        public async Task<IActionResult> getPlanesFichas()
        {

            using (ITikConnection connection = ConnectionFactory.CreateConnection(TikConnectionType.Api))
            {
                connection.Open(instPlanesfichasController.ipMKT, instPlanesfichasController.userMKT, instPlanesfichasController.passwordMKT);

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
                connection.Open(instPlanesfichasController.ipMKT, instPlanesfichasController.userMKT, instPlanesfichasController.passwordMKT);


                var profileSearch = connection.LoadList<HotspotUserProfile>().ToArray();

                //validamos si EL ID VIENE DIFERENTE A NULL Y RECORREMOS LOS PERFILES PARA VALIDAR SI EXISTE UNO CON EL ID QUE VIENE DESDE EL FRONT
                if (planesFichas.idProfile != null)
                {
                    for (int posicionrecorrida = 0; posicionrecorrida < profileSearch.Length; posicionrecorrida++)
                    {
                        if (planesFichas.idProfile == profileSearch[posicionrecorrida].Id)
                        {
                            connection.Delete(profileSearch[posicionrecorrida]);
                        }
                    }
                }
                
                var profile = new HotspotUserProfile()
                {
                    Name = planesFichas.nameProfile,
                    AddressPool = planesFichas.addressPoolProfile,
                    RateLimit = planesFichas.velocidadSubidaBajadaProfile,
                    MacCookieTimeout = planesFichas.limiteDeTiempoProfile,
                    //                    AddMacCookie = planesFichas.addMacCookieProfile,
                    OnLogin = planesFichas.onLoginProfile,
                    OnLogout = planesFichas.onLogoutProfile
                };
                connection.Save(profile);

                if (planesFichas == null)
                {
                    return BadRequest(ModelState);
                }
                //validamos que el dato a insertar sea valido
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (planesFichas.idProfile == "")
                {
                    planesFichas.idProfile = profile.Id;

                    await _db.AddAsync(planesFichas);
                    await _db.SaveChangesAsync();
                }
                else
                {

                }      
                

                return Ok(profile);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanesFichas(string id)
        {
            using (ITikConnection connection = ConnectionFactory.CreateConnection(TikConnectionType.Api))
            {
                connection.Open(instPlanesfichasController.ipMKT, instPlanesfichasController.userMKT, instPlanesfichasController.passwordMKT);

                var profile = connection.LoadList<HotspotUserProfile>().ToArray();

                    //RECORREMOS LOS PERFILES PARA VALIDAR SI EXISTE UNO CON EL ID QUE VIENE DESDE EL FRONT
                    for (int posicionrecorrida = 0; posicionrecorrida < profile.Length; posicionrecorrida++)
                    {
                        if (id == profile[posicionrecorrida].Id)
                        {
                            connection.Delete(profile[posicionrecorrida]);
                        }                        
                    }
                    return Ok();                              
            }
        }
    }
}
