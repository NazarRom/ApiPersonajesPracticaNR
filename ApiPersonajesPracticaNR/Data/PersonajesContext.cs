using ApiPersonajesPracticaNR.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesPracticaNR.Data
{
    public class PersonajesContext : DbContext
    {
        public PersonajesContext(DbContextOptions<PersonajesContext> options) :base(options) { }
        public DbSet<Personaje> Personajes { get; set; }
    }
}
