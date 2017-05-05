namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.ECRITURE_ANALYTIQUE_HIST")]
    public partial class ECRITURE_ANALYTIQUE_HIST
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDECRIRE_ANALYTIQUE_HIST { get; set; }

        [StringLength(12)]
        public string TYPE_OPERATION { get; set; }

        [StringLength(256)]
        public string EFFECTUER_PAR { get; set; }

        public DateTime? EFFECUTER_DATE { get; set; }

        public int IDECRIRE_ANALYTIQUE { get; set; }

        [Required]
        [StringLength(4)]
        public string ND_NUMERO { get; set; }

        public short COMPTE_ANA5_NUMERO { get; set; }

        [Required]
        [StringLength(2)]
        public string SIEGE_N_SIEGE { get; set; }

        [StringLength(6)]
        public string NUMERO_SEQUENCE { get; set; }

        [StringLength(2)]
        public string ORIGINE { get; set; }

        [StringLength(2)]
        public string GROUPE { get; set; }

        public DateTime? DATE_ECRITURE { get; set; }

        [StringLength(4)]
        public string NUMERO_ECRITURE { get; set; }

        [StringLength(100)]
        public string LIBELLE_FR { get; set; }

        [StringLength(100)]
        public string LIBELLE_AR { get; set; }

        public DateTime? DATE_AJOUT { get; set; }

        [StringLength(4)]
        public string ANNEE_COMPTABLE { get; set; }

        public decimal? MONTANT { get; set; }

        [StringLength(6)]
        public string CODE_BUDGET { get; set; }

        public bool? CENTRE_ECRITURE { get; set; }

        [StringLength(5)]
        public string COMPTE_GENERALE { get; set; }
    }
}
