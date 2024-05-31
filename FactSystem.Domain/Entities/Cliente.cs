using FactSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactSystem.Domain.Entities
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Status Activo { get; set; }
    }
}
