namespace TallerFinal.ClasesDTO
{
    public class ProductosDTO
    {
        public int IdProducto { get; set; }     
        public int Codigo { get; set; }              
        public string NombreProducto { get; set; }    
        public float ValorUnitario { get; set; }     
        public float Iva { get; set; }      
        public int Cantidad { get; set; }       
        public DateTime Fecha { get; set; }     
        public string Categoria { get; set; }   
        public int Estado { get; set; }
        public string NombreCategoria { get; set; }
    }
}
