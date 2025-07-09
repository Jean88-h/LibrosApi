namespace Uttt.Micro.Libro.Aplicacion
{
    public class LibroMaterialDto
    {
        public Guid? LibreriaMaterialId { get; set; }
        public required string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public Guid? AutoLibro { get; set; }

    }

}
