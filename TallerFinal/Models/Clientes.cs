using System.ComponentModel.DataAnnotations;

namespace TallerFinal.Models
{
    public class Clientes
    {
        [Key]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo Apellidos es obligatorio")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "El campo Documento es obligatorio")]
        public string Documento { get; set; }
        [Required(ErrorMessage = "El campo Direccíon es obligatorio")]
        [Display(Name ="Dirección")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El campo E-mail es obligatorio")]
        [Display(Name ="E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo Celular es obligatorio")]
        public string Celular { get; set; }

    }
}
