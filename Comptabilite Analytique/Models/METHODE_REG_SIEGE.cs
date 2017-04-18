namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.METHODE_REG_SIEGE")]
    public partial class METHODE_REG_SIEGE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDMETHODE_REG_SIEGE { get; set; }

        public short COMPTE_ANA5_NUMERO { get; set; }

        [Required]
        [StringLength(2)]
        public string SIEGE_N_SIEGE { get; set; }

        [StringLength(1)]
        public string CODE_GROUPEMENT { get; set; }

        [Column("METHODE_REG_SIEGE")]
        [Required]
        [StringLength(3)]
        public string METHODE_REG_SIEGE1 { get; set; }

        [StringLength(100)]
        public string LIBELLE_FR { get; set; }

        [StringLength(100)]
        public string LIBELLE_AR { get; set; }

        public virtual COMPTE_ANA5CH COMPTE_ANA5CH { get; set; }

        public virtual SIEGE SIEGE { get; set; }
    }
}
