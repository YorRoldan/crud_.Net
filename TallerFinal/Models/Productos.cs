using System.ComponentModel.DataAnnotations;

namespace TallerFinal.Models
{
    public class Productos
    {
        [Key]
        public int IdProducto { get;set;}
        [Required(ErrorMessage ="El campo Código es obligatorio")]
        [Display(Name ="Código")]
        public int Codigo { get;set;}
        [Required(ErrorMessage = "El campo Nombre Producto es obligatorio")]
        [Display(Name = "Nombre Producto")]
        public string NombreProducto { get;set;}
        [Required(ErrorMessage = "El campo Valor Unitario es obligatorio")]
        [Display(Name = "Valor Unitario")]
        public float ValorUnitario { get;set;}
        [Required(ErrorMessage = "El campo Iva es obligatorio")]
        public float Iva { get;set;}
        [Required(ErrorMessage = "El campo Cantidad es obligatorio")]
        public int Cantidad { get;set;}
        [Required(ErrorMessage = "El campo Fecha es obligatorio")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El campo Categoria es obligatorio")]
        public int Categoria { get; set; }
        [Required(ErrorMessage = "El campo Estado es obligatorio")]
        public int Estado { get; set; }

    }
}
