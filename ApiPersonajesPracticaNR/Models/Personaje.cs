using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPersonajesPracticaNR.Models
{
    [Table("Personajes")]
    public class Personaje
    {
        [Key]
        [Column("Idpersonaje")]
        public int IdPersonaje { get; set; }
        [Column("Personaje")]
        public string Nombre { get; set; }
        [Column("Imagen")]
        public string Imagen { get; set; }
        [Column("IdSerie")]
        public int IdSerie { get; set; }



    }
}
