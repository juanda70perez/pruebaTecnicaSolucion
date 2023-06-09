using Microsoft.AspNetCore.Mvc;
using pruebaTecnica.Datos;
using pruebaTecnica.Models;
using pruebaTecnica.Utilidades;

namespace pruebaTecnica.Controllers
{
    [ApiController]
    [Route("api/elementos")]
    public class ElementController : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<Element>>> Get()
        {
            var funcion = new Delementos();
            var lista = await funcion.MostrarElementos();
            return Json(lista);
        }
        [HttpPost]
        public async Task Post([FromBody] Element element)
        {
            var funcion = new Delementos();
            await funcion.InsertarElementos(element);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Element element)
        {
            var funcion = new Delementos();
            element.Id = id;
            await funcion.EditarElementos(element);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Element element = new Element();
            var funcion = new Delementos();
            element.Id = id;
            await funcion.EliminarElemento(element);
            return NoContent();
        }
    }
}
