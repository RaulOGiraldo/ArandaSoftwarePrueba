using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(250)]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(50)]
        public string Categoria { get; set; }
        public string Imagen { get; set; }
    }
}
