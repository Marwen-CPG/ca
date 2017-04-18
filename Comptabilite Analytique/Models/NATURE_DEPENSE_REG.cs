namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.NATURE_DEPENSE_REG")]
    public partial class NATURE_DEPENSE_REG
    {
        public NATURE_DEPENSE_REG()
        {
            NATURE_DEPENSE = new HashSet<NATURE_DEPENSE>();
        }

        [Key]
        [StringLength(4)]
        public string NUMERO { get; set; }

        [StringLength(100)]
        public string LIBELLE_FR { get; set; }

        [StringLength(100)]
        public string LIBELLE_AR { get; set; }

        public virtual ICollection<NATURE_DEPENSE> NATURE_DEPENSE { get; set; }
    }
}
