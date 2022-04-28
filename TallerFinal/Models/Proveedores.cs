using System.ComponentModel.DataAnnotations;

namespace TallerFinal.Models
{
    public class Proveedores
    {
        [Key]
        public int IdProveedor { get; set; }
        [Required(ErrorMessage ="El campo Nit es obligatorio")]
        public int Nit { get; set; }
        [Required(ErrorMessage = "El campo Empresa es obligatorio")]
        public string Empresa { get; set; }
        [Required(ErrorMessage = "El campo Dirección es obligatorio")]
        [Display(Name ="Dirección")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El campo E-mail es obligatorio")]
        [Display(Name ="E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo Nombre Contacto es obligatorio")]
        [Display(Name ="Nombre Contacto")]
        public string NombreContacto { get; set; }
        [Required(ErrorMessage = "El campo Teléfono es obligatorio")]
        [Display(Name ="Teléfono")]
        public string Telefono { get; set; }
    }
}
