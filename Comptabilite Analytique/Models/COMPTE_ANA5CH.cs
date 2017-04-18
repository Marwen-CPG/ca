namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.COMPTE_ANA5CH")]
    public partial class COMPTE_ANA5CH
    {
        public COMPTE_ANA5CH()
        {
            CLE_REPARTITION_FIXE = new HashSet<CLE_REPARTITION_FIXE>();
            CLE_REPARTITION_FIXE1 = new HashSet<CLE_REPARTITION_FIXE>();
            CLE_REPARTITION_VARIABLE = new HashSet<CLE_REPARTITION_VARIABLE>();
            CLE_REPARTITION_VARIABLE1 = new HashSet<CLE_REPARTITION_VARIABLE>();
            PLAN_CPT_AN = new HashSet<PLAN_CPT_AN>();
            METHODE_REG_COMPAGNIE = new HashSet<METHODE_REG_COMPAGNIE>();
            METHODE_REG_SIEGE = new HashSet<METHODE_REG_SIEGE>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short NUMERO { get; set; }

        public short COMPTE_ANA4CH_NUMERO { get; set; }

        [StringLength(100)]
        public string LIBELLE_FR { get; set; }

        [StringLength(100)]
        public string LIBELLE_AR { get; set; }

        public virtual ICollection<CLE_REPARTITION_FIXE> CLE_REPARTITION_FIXE { get; set; }

        public virtual ICollection<CLE_REPARTITION_FIXE> CLE_REPARTITION_FIXE1 { get; set; }

        public virtual ICollection<CLE_REPARTITION_VARIABLE> CLE_REPARTITION_VARIABLE { get; set; }

        public virtual ICollection<CLE_REPARTITION_VARIABLE> CLE_REPARTITION_VARIABLE1 { get; set; }

        public virtual COMPTE_ANA4CH COMPTE_ANA4CH { get; set; }

        public virtual ICollection<PLAN_CPT_AN> PLAN_CPT_AN { get; set; }

        public virtual ICollection<METHODE_REG_COMPAGNIE> METHODE_REG_COMPAGNIE { get; set; }

        public virtual ICollection<METHODE_REG_SIEGE> METHODE_REG_SIEGE { get; set; }
    }
}
