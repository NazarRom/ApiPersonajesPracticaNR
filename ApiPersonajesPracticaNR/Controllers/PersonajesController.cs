using ApiPersonajesPracticaNR.Models;
using ApiPersonajesPracticaNR.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonajesPracticaNR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonajes repo;

        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> GetAllPersonajes()
        {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personaje>> FindPersonaje(int id)
        {
            return await this.repo.FindPersonajeAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> InsertPersonaje(Personaje personaje)
        {
            await this.repo.InsertPersonajeAsync(personaje.Nombre, personaje.Imagen, personaje.IdSerie);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePersonaje(Personaje personaje)
        {
            await this.repo.UpdatePersonajeAsync(personaje.IdPersonaje,personaje.Nombre, personaje.Imagen, personaje.IdSerie);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePersonaje(int id)
        {
            await this.repo.DeletePersonajeAsync(id);
            return Ok();
        }
    }
}
