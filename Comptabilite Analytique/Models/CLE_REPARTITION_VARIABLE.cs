namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.CLE_REPARTITION_VARIABLE")]
    public partial class CLE_REPARTITION_VARIABLE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDCLE_REP_VAR { get; set; }

        public short COMPTE_NUMERO { get; set; }

        [Required]
        [StringLength(2)]
        public string SIEGE_N_SIEGE { get; set; }

        public short COMPTE_ANALYTIQUE { get; set; }

        public bool? CODE_GROUPEMENT { get; set; }

        [Required]
        [StringLength(2)]
        public string UR_REPARTITION { get; set; }

        public short CA_REPARTITION { get; set; }

        [Required]
        [StringLength(4)]
        public string NATURE_DEPENSE { get; set; }

        public decimal? TAUX_REPARTITION { get; set; }

        public virtual COMPTE_ANA5CH COMPTE_ANA5CH { get; set; }

        public virtual COMPTE_ANA5CH COMPTE_ANA5CH1 { get; set; }

        public virtual SIEGE SIEGE { get; set; }

        public virtual SIEGE SIEGE1 { get; set; }

        public virtual NATURE_DEPENSE NATURE_DEPENSE1 { get; set; }
    }
}
