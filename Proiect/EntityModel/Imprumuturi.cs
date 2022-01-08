namespace Proiect.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Imprumuturi")]
    public partial class Imprumuturi
    {
        public int id { get; set; }

        [StringLength(50)]
        public string cnp_client { get; set; }
        public int id_carte { get; set; }

        [Column(TypeName = "date")]
        public DateTime? data_retur { get; set; }

        public virtual Client Client { get; set; }
        
    }
}
