using BackEnd_SolucionesInterPaisa.data;
using BackEnd_SolucionesInterPaisa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_SolucionesInterPaisa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutersFichasController : ControllerBase
    {
        //
        public readonly ApplicationDbContext _db;     

        //CREAR CONSTRUCTOR
        public RoutersFichasController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetRoutersFichas()
        {
            var routersFichas = await _db.RoutersFichas.OrderBy(c => c.direccionIPMKT).ToListAsync();
            return Ok(routersFichas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRouterFichas(int id)
        {
            var routerFichas = await _db.RoutersFichas.FirstOrDefaultAsync(c => c.idMKT == id);
            if (routerFichas == null)
            {
                return NotFound();
            }

            return Ok(routerFichas);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoutersFichas([FromBody] RoutersFichas modelRoutersFichas)
        {
            //validamos que no este vacio 
            if (modelRoutersFichas == null)
            {
                return BadRequest(ModelState);
            }
            //validamos que el dato a insertar sea valido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _db.AddAsync(modelRoutersFichas);
            await _db.SaveChangesAsync();
            return Ok(modelRoutersFichas);
        }


    }
}
