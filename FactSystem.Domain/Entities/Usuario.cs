using FactSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FactSystem.Domain.Entities
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? NombreUsuario { get; set; }
        public Status Bloqueado { get; set; }
        public int IntentosFallidos { get; set; }
        public string? Contraseña { get; set; }

    }
}
