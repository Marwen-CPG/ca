namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.METHODE_REG_COMPAGNIE")]
    public partial class METHODE_REG_COMPAGNIE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDMETHODE_REG_COMPAGNIE { get; set; }

        public short COMPTE_ANA5_NUMERO { get; set; }

        [Required]
        [StringLength(2)]
        public string SIEGE_N_SIEGE { get; set; }

        public bool? CODE_GROUPEMENT { get; set; }

        [Column("METHODE_REG_COMPAGNIE")]
        [Required]
        [StringLength(3)]
        public string METHODE_REG_COMPAGNIE1 { get; set; }

        public decimal? LIBELLE_FR { get; set; }

        public virtual COMPTE_ANA5CH COMPTE_ANA5CH { get; set; }

        public virtual SIEGE SIEGE { get; set; }
    }
}
