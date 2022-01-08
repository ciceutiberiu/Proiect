namespace Proiect.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Autori")]
    public partial class Autori
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string nume_autor { get; set; }

        [Required]
        [StringLength(50)]
        public string prenume_autor { get; set; }
    }
}
