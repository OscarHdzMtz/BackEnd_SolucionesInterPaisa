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

        Utilerias utilerias = new Utilerias();


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

                //OBTENEMOS LA FECHA 
                DateTime fecha = DateTime.Now;
                string fecha_str = fecha.ToString("dd/MM/yyyy HH:mm:ss");

                var passwrodFichasStrAleatorio = "";
                              
                //RECORREMOS EL FOR DE ACUERDO A LA CANTIDAD DE FICHAS QUE REQUIERE EL CLIENTE
                int cantidadFichasss = Int32.Parse(userFichas.cantidadfichas);
                for (int i = 0; i < cantidadFichasss; i++)
                {

                    //this.cadenaAleatoria(userFichas.LongitudUserFichas);
                    //OBTENEMOS LA CADENA ALEATORIO DE USUARIO FICHA DESDE LA CLASE UTILERIAS
                    var UsuarioFichasStrAleatorio = this.utilerias.cadenaAleatoriaUsers(userFichas.LongitudUserFichas, userFichas.tipoUsuarioGenerarFichas);                    
                    //VALIDAMOS SI LA OPCION SELECCIONADO ES CONTRASEÑA Y GENERAMOS LA CONTRASEÑA ALEATORIO

                    //SI SELECCIONA CONTRASEÑA OBTENEMOS LA CADENA ALEATORIO DE CONTRASEÑA FICHA DESDE LA CLASE UTILERIAS
                    if (userFichas.tipoInicioDeSesionFichas != "Pin")
                    {
                        passwrodFichasStrAleatorio = this.utilerias.cadenaAleatoriaPassword(userFichas.valorLongPassFichas, userFichas.tipoPasswordGenerarFichas);
                    }


                    //ASIGAMOS LOS VALORES A GUARDAR EN EL MIKROTIK
                    var adduserFichas = new HotspotUser()
                    {
                        Server = userFichas.servidorFichas,
                        Name = userFichas.prefijoFichas + UsuarioFichasStrAleatorio,
                        Password = passwrodFichasStrAleatorio,
                        Profile = userFichas.planesFichas,
                        Routes = userFichas.servidorFichas,
                        Comment = "creado_" + fecha_str
                    };
                    //OBTENEMOS LA LISTA DE LOS USUARIOS DEL MIKROITK
                    var listUsuariosFichas = connection.LoadAll<HotspotUser>().ToArray();

                    //VALIDAMOS SI EL USUARIO QUE SE VA AGREGAR ES IGUAL A UNO QUE ESTA EN EL MIKROTIK
                    var buscarSiExiste = listUsuariosFichas.FirstOrDefault(buscar => buscar.Name == adduserFichas.Name);
                    //SI EL VALOR DEVUELTO POR EL CODIGO ANTERIOR ES NULO ES PORQUE NO EXISTE UN USUARIO CON ESE NOMBRE
                    while (buscarSiExiste != null)  //VALIDAMOS HASTA QUE SE GENERE UN USUARIO QUE NO EXISTE
                    {
                        //ASIGNAMOS UN NUEVO VALOR AL USUARIO GENERADO ALEATOREAMENTE
                        UsuarioFichasStrAleatorio = this.utilerias.cadenaAleatoriaUsers(userFichas.LongitudUserFichas, userFichas.tipoUsuarioGenerarFichas);
                        //ASIGNAMOS EL VALOR A USUARIO DE FICHA QUE SE VA A GENERAR
                        adduserFichas.Name = UsuarioFichasStrAleatorio;
                        //VOLVEMOS A VALIDAR EL NUEVO USUARIO PARA VER QUE NO EXISTA EN EL MIKROTIK
                        buscarSiExiste = listUsuariosFichas.FirstOrDefault(buscar => buscar.Name == adduserFichas.Name);
                    }

                    ////RECORREMOS LOS USUARIOS DEL MIKROTIK PARA VALIDAR QUE NO EXISTA UN usuario CON ESE NOMBRE
                    //var listUsuariosFichas = connection.LoadAll<HotspotUser>().ToArray();
                    //for (int j = 0; j < listUsuariosFichas.Length; j++)
                    //{
                    //    //VALIDAMOS  SI EL NOMBRE DE LA FICHA QUE ESTA EN EL MIKROTIK ES IGUAL A LA FICHA QUE QUEREMOS AGREGAR
                    //    if (listUsuariosFichas[j].Name == adduserFichas.Name)
                    //    {
                    //        //SI LA FICHA ES IGUAL MANDAMOS UN ERROR DE BAD REQUES
                    //        return BadRequest(ModelState);
                    //        break;
                    //    }
                    //}
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
