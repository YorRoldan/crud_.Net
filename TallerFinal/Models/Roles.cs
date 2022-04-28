using System.ComponentModel.DataAnnotations;

namespace TallerFinal.Models
{
    public class Roles
    {
        [Key]
        public int IdRol { get; set; }
        [Display(Name="Nombre Rol")]
        public string NombreRol { get; set; }
    }
}
