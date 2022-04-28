using System.ComponentModel.DataAnnotations;

namespace TallerFinal.Models
{
    public class Categorias
    {
        [Key]
        public int IdCategoria { get; set; }
        [Display(Name="Nombre Categoría")]
        public string NombreCategoria { get; set; }
    }
}
