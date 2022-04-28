using System.ComponentModel.DataAnnotations;

namespace TallerFinal.Models
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage ="El campo Documento es obligatorio")]
        public string Documento { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo Apellidos es obligatorio")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "El campo Celular es obligatorio")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "El campo E-mail es obligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo Rol es obligatorio")]
        public int Rol { get; set; }

    }
}
