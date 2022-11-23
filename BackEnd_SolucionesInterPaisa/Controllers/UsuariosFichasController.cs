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
                var ordenarlistUsuariosFichas = listUsuariosFichas.OrderBy(x => x.Name).Where(y => y.Name != "default-trial").ToList();
                return Ok(ordenarlistUsuariosFichas);
                connection.Close();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Getficha(string id)
        {
            using (ITikConnection connection = ConnectionFactory.CreateConnection(TikConnectionType.Api))
            {
                connection.Open(instPlanesfichasController.ipMKT, instPlanesfichasController.userMKT, instPlanesfichasController.passwordMKT);
                //CONSULTAMOS TODAS LAS FICHAS
                var todasLasFichas = connection.LoadAll<HotspotUser>();

                //BUSCAMOS EL USUARIO CON EL ID QUE VIENE DESDE EL FRONT
                var fichaBuscar = todasLasFichas.FirstOrDefault(y => y.Id == id);
                //var routerFichas = await _db.RoutersFichas.FirstOrDefaultAsync(c => c.idMKT == id);

                if (fichaBuscar == null)
                {
                    return NotFound();
                }

                return Ok(fichaBuscar);
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
                //RECORREMOS EL FOR DE ACUERDO A LA CANTIDAD DE FICHAS QUE REQUIERE EL CLIENTE
                for (int i = 0; i < userFichas.cantidadFichas; i++)
                {
                    var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    Random rnd = new Random();
                    var adduserFichas = new HotspotUser()
                    {
                        Server = userFichas.serverUser,
                        Name = userFichas.nameUser + rnd.Next(),
                        Password = rnd.Next(1, 10000).ToString(),
                        Profile = userFichas.profileUser,
                        Routes = userFichas.routesUser,
                        Comment = userFichas.commentuser
                    };
                    //RECORREMOS LOS USUARIOS DEL MIKROTIK PARA VALIDAR QUE NO EXISTA UN usuario CON ESE NOMBRE
                    var listUsuariosFichas = connection.LoadAll<HotspotUser>().ToArray();
                    for (int j = 0; j < listUsuariosFichas.Length; j++)
                    {
                        //VALIDAMOS  SI EL NOMBRE DE LA FICHA QUE ESTA EN EL MIKROTIK ES IGUAL A LA FICHA QUE QUEREMOS AGREGAR
                        if (listUsuariosFichas[j].Name == adduserFichas.Name)
                        {
                            //SI LA FICHA ES IGUAL MANDAMOS UN ERROR DE BAD REQUES
                            return BadRequest(ModelState);
                            break;
                        }
                    }
                    //Y SI EL USUARIO DE LAS FICHAS DEL MIKROTIK NO ES IGUAL A LA FICHA QUE QUEREMOS INGRESAR, LO GUARDAMOS EN EL MIKROTIK
                    connection.Save(adduserFichas);
                }
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuariosFichas(string id)
        {
            using (ITikConnection connection = ConnectionFactory.CreateConnection(TikConnectionType.Api))
            {
                connection.Open(instPlanesfichasController.ipMKT, instPlanesfichasController.userMKT, instPlanesfichasController.passwordMKT);
                var listUsuariosFichas = connection.LoadAll<HotspotUser>().ToArray();
                //var usuarioAeliminar = listUsuariosFichas.Where(fichas => fichas.Id == id).ToList();
                //connection.Delete(usuarioAeliminar);
                for (int buscarUsuarioFichas = 0; buscarUsuarioFichas < listUsuariosFichas.Length; buscarUsuarioFichas++)
                {
                    if (id == listUsuariosFichas[buscarUsuarioFichas].Id)
                    {
                        connection.Delete(listUsuariosFichas[buscarUsuarioFichas]);
                    }
                }
                return Ok();
            }
        }
    }
}
