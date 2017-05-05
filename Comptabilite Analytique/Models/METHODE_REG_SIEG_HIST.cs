namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.METHODE_REG_SIEG_HIST")]
    public partial class METHODE_REG_SIEG_HIST
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDMETHODE_REG_SIEG_HIST { get; set; }

        [StringLength(12)]
        public string TYPE_OPERATION { get; set; }

        [StringLength(256)]
        public string EFFECTUER_PAR { get; set; }

        public DateTime? EFFECUTER_DATE { get; set; }

        public int IDMETHODE_REG_COMPAGNIE { get; set; }

        public short COMPTE_ANA5_NUMERO { get; set; }

        [Required]
        [StringLength(2)]
        public string SIEGE_N_SIEGE { get; set; }

        [StringLength(1)]
        public string CODE_GROUPEMENT { get; set; }

        [Required]
        [StringLength(3)]
        public string METHODE_REG_SIEGE { get; set; }

        [StringLength(100)]
        public string LIBELLE_FR { get; set; }

        [StringLength(100)]
        public string LIBELLE_AR { get; set; }

        [StringLength(4)]
        public string ANNEE_COMPTABLE { get; set; }
    }
}
