using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pruebaTecnica.Datos;
using pruebaTecnica.Models;
using pruebaTecnica.Utilidades;
using System.Xml.Linq;

namespace pruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptimoController : ControllerBase
    {
        [HttpPost]
        public Task<ActionResult<Mochila>> Post([FromBody] List<Element> elementos)
        {
            //valores quemados por el requisito
            int PesoMaximo = 10;
            int CaloriasMinima = 15;
            var optimo = new Recursividad();
            Mochila mochila = new Mochila(PesoMaximo, CaloriasMinima);
            Mochila optima = new Mochila(PesoMaximo, CaloriasMinima);
            optima.Peso = -1;
            optimo.llenarMochila(elementos, mochila, false, optima);
            return Task.FromResult<ActionResult<Mochila>>(optima);
        }
    }
}
