namespace Proiect.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Imprumuturis = new HashSet<Imprumuturi>();
        }

        [Key]
        [StringLength(50)]
        public string CNP { get; set; }

        [Required]
        [StringLength(50)]
        public string nume_client { get; set; }

        [Required]
        [StringLength(50)]
        public string prenume_client { get; set; }

        [Required]
        [StringLength(50)]
        public string numar_tel { get; set; }

        [Column(TypeName = "date")]
        public DateTime? data_retur { get; set; }

        public int? id_carte { get; set; }

        public virtual Carti Carti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Imprumuturi> Imprumuturis { get; set; }
    }
}
