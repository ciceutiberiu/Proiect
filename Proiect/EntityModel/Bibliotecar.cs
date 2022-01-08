namespace Proiect.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bibliotecar")]
    public partial class Bibliotecar
    {
        [Key]
        [StringLength(50)]
        public string CNP { get; set; }

        [Required]
        [StringLength(50)]
        public string nume_bibliotecar { get; set; }

        [Required]
        [StringLength(50)]
        public string prenume_bibliotecar { get; set; }

        [Required]
        [StringLength(50)]
        public string numar_tel { get; set; }

        public int? id_carte { get; set; }

        public virtual Carti Carti { get; set; }
    }
}
