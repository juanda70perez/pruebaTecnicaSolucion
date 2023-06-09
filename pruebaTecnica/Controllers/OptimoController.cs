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
        [HttpPost()]
        public async Task<ActionResult<Mochila>> post(int PesoMaximo,int CaloriasMinima)
        {
            var funcion = new Delementos();
            var elementos = await funcion.MostrarElementos();
            var optimo = new Recursividad();
            Mochila mochila = new Mochila(PesoMaximo, CaloriasMinima);
            Mochila optima = new Mochila(PesoMaximo, CaloriasMinima);
            optima.Peso = -1;
            optimo.llenarMochila(elementos, mochila, false, optima);
            return optima;
        }
    }
}
