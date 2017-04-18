namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.MAGASIN")]
    public partial class MAGASIN
    {
        [Key]
        [StringLength(2)]
        public string CODE_MAGASIN { get; set; }

        [Required]
        [StringLength(2)]
        public string SIEGE_N_SIEGE { get; set; }

        [StringLength(100)]
        public string LIBELLE_FR { get; set; }

        [StringLength(100)]
        public string LIBELLE_AR { get; set; }

        public virtual SIEGE SIEGE { get; set; }
    }
}
