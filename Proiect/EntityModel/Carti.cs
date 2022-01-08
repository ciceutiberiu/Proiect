namespace Proiect.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Carti")]
    public partial class Carti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Carti()
        {
            Bibliotecars = new HashSet<Bibliotecar>();
            Clients = new HashSet<Client>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string nume_carte { get; set; }

        [StringLength(50)]
        public string nume_autor { get; set; }

        [StringLength(50)]
        public string prenume_autor { get; set; }

        public int numar_pagini { get; set; }

        [StringLength(50)]
        public string categorie { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bibliotecar> Bibliotecars { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Client> Clients { get; set; }
    }
}
