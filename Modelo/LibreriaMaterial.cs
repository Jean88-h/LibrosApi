﻿using System.ComponentModel.DataAnnotations;

namespace Uttt.Micro.Libro.Modelo
{
    public class LibreriaMaterial
    {

        [Key]

        public Guid? LibreriaMaterialId { get; set; }
        public string Titulo { get; set; }

        public DateTime? FechaPublicacion { get; set; }
        public Guid? AutoLibro {  get; set; }
        public int NewData { get; set; }


    }
}
