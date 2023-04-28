using ApiPersonajesPracticaNR.Data;
using ApiPersonajesPracticaNR.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesPracticaNR.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajesContext context;
        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context = context;
        }

        public int GetMaxId()
        {
            return this.context.Personajes.Max(x => x.IdPersonaje) + 1;
        }

        //get all personajes
        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        //find one personaje
        public async Task<Personaje> FindPersonajeAsync(int id)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == id);
        }

        //insert personaje

        public async Task InsertPersonajeAsync(string nombre, string imagen, int idserie)
        {
            Personaje personaje = new Personaje();
            personaje.IdPersonaje = this.GetMaxId();
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.IdSerie = idserie;
            await this.context.Personajes.AddAsync(personaje);
            await this.context.SaveChangesAsync();

        }

        public async Task UpdatePersonajeAsync(int idpersonaje, string nombre, string imagen, int idserie)
        {
            Personaje personaje = await this.FindPersonajeAsync(idpersonaje);
            personaje.IdPersonaje = idpersonaje;
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.IdSerie = idserie;
            await this.context.SaveChangesAsync();

        }

        //delete 
        public async Task DeletePersonajeAsync(int id)
        {
            Personaje personaje = await this.FindPersonajeAsync(id);
            this.context.Personajes.Remove(personaje);
            await this.context.SaveChangesAsync();
        }
    }
}
