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
        [HttpGet]
        public async Task<ActionResult<Mochila>> post(int PesoMaximo,int CaloriasMinima)
        {
            var funcion = new Delementos();
            //se trae los elementos de la base de datos
            var elementos = await funcion.MostrarElementos();
            //inicializamos nuestra clase donde esta nuestro algoritmo de backtracking
            var optimo = new Recursividad();
            //inicializamos nuestra mochila con las condiciones que el usuario nos paso
            Mochila mochila = new Mochila(PesoMaximo, CaloriasMinima);
            Mochila optima = new Mochila(PesoMaximo, CaloriasMinima);
            //es importante para saber que la mochila no tiene ningun elemento por lo tanto el peso es diferente de 0, ya que 0 puede ser una solucion posible
            optima.Peso = -1;
            optimo.llenarMochila(elementos, mochila, false, optima);
            return optima;
        }
    }
}
