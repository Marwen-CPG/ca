namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.CRF_HIST")]
    public partial class CRF_HIST
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDCRF_HIST { get; set; }

        [StringLength(12)]
        public string TYPE_OPERATION { get; set; }

        [StringLength(256)]
        public string EFFECTUER_PAR { get; set; }

        public DateTime? EFFECUTER_DATE { get; set; }

        public int IDCLE_REP_FIXE { get; set; }

        public short COMPTE_NUMERO { get; set; }

        [Required]
        [StringLength(2)]
        public string SIEGE_N_SIEGE { get; set; }

        public bool? CODE_GROUPEMENT { get; set; }

        [Required]
        [StringLength(2)]
        public string UR_REPARTITION { get; set; }

        public short CA_REPARTITION { get; set; }

        [Required]
        [StringLength(4)]
        public string NATURE_DEPENSE { get; set; }

        public decimal? TAUX_REPARTITION { get; set; }

        [StringLength(4)]
        public string ANNEE_COMPTABLE { get; set; }
    }
}
