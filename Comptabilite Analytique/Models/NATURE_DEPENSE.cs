namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.NATURE_DEPENSE")]
    public partial class NATURE_DEPENSE
    {
        public NATURE_DEPENSE()
        {
            CLE_REPARTITION_FIXE = new HashSet<CLE_REPARTITION_FIXE>();
            CLE_REPARTITION_VARIABLE = new HashSet<CLE_REPARTITION_VARIABLE>();
            ECRITURE_ANALYTIQUE = new HashSet<ECRITURE_ANALYTIQUE>();
            NATURE_DEPENSE_SUBVENTION = new HashSet<NATURE_DEPENSE_SUBVENTION>();
        }

        [Key]
        [StringLength(4)]
        public string NUMERO { get; set; }

        [Required]
        [StringLength(4)]
        public string NDR_NUMERO { get; set; }

        [StringLength(100)]
        public string LIBELLE_FR { get; set; }

        [StringLength(100)]
        public string LIBELLE_AR { get; set; }

        public virtual ICollection<CLE_REPARTITION_FIXE> CLE_REPARTITION_FIXE { get; set; }

        public virtual ICollection<CLE_REPARTITION_VARIABLE> CLE_REPARTITION_VARIABLE { get; set; }

        public virtual ICollection<ECRITURE_ANALYTIQUE> ECRITURE_ANALYTIQUE { get; set; }

        public virtual NATURE_DEPENSE_REG NATURE_DEPENSE_REG { get; set; }

        public virtual ICollection<NATURE_DEPENSE_SUBVENTION> NATURE_DEPENSE_SUBVENTION { get; set; }
    }
}
