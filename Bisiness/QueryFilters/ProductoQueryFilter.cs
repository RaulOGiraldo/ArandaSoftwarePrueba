namespace Bisiness.QueryFilters
{
    public class ProductoQueryFilter
    {
        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public string Categoria { get; set; } = "";
        public string Ordenamiento { get; set; } = "asc";
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}
