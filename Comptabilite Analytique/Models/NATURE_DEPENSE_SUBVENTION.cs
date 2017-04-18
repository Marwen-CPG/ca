namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.NATURE_DEPENSE_SUBVENTION")]
    public partial class NATURE_DEPENSE_SUBVENTION
    {
        [Key]
        [StringLength(4)]
        public string NUMERO { get; set; }

        [Required]
        [StringLength(4)]
        public string ND_NUMERO { get; set; }

        [StringLength(100)]
        public string LIBELLE_FR { get; set; }

        [StringLength(100)]
        public string LIBELLE_AR { get; set; }

        public virtual NATURE_DEPENSE NATURE_DEPENSE { get; set; }
    }
}
