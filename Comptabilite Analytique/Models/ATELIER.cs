namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.ATELIER")]
    public partial class ATELIER
    {
        [Key]
        [StringLength(2)]
        public string CODE_ATELIER { get; set; }

        [StringLength(100)]
        public string LIBELLE_FR { get; set; }

        [StringLength(100)]
        public string LIBELLE_AR { get; set; }

        [StringLength(2)]
        public string SIEGE_N_SIEGE { get; set; }

        public virtual SIEGE SIEGE { get; set; }
    }
}
