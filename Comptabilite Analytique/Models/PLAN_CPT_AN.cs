namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.PLAN_CPT_AN")]
    public partial class PLAN_CPT_AN
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string SIEGE_N_SIEGE { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short COMPTE_ANA5CH_NUMERO { get; set; }

        [StringLength(100)]
        public string LIBELLE_FR { get; set; }

        [StringLength(100)]
        public string LIBELLE_AR { get; set; }

        public virtual COMPTE_ANA5CH COMPTE_ANA5CH { get; set; }

        public virtual SIEGE SIEGE { get; set; }
    }
}
