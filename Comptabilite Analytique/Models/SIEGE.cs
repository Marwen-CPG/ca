namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.SIEGE")]
    public partial class SIEGE
    {
        public SIEGE()
        {
            ATELIER = new HashSet<ATELIER>();
            CLE_REPARTITION_FIXE = new HashSet<CLE_REPARTITION_FIXE>();
            CLE_REPARTITION_FIXE1 = new HashSet<CLE_REPARTITION_FIXE>();
            CLE_REPARTITION_VARIABLE = new HashSet<CLE_REPARTITION_VARIABLE>();
            CLE_REPARTITION_VARIABLE1 = new HashSet<CLE_REPARTITION_VARIABLE>();
            ECRITURE_ANALYTIQUE = new HashSet<ECRITURE_ANALYTIQUE>();
            MAGASIN = new HashSet<MAGASIN>();
            METHODE_REG_COMPAGNIE = new HashSet<METHODE_REG_COMPAGNIE>();
            METHODE_REG_SIEGE = new HashSet<METHODE_REG_SIEGE>();
            PLAN_CPT_AN = new HashSet<PLAN_CPT_AN>();
        }

        [Key]
        [StringLength(2)]
        public string NUMERO_SIEGE { get; set; }

        [StringLength(100)]
        public string LIBELLE_FR { get; set; }

        [StringLength(100)]
        public string LIBELLE_AR { get; set; }

        [StringLength(2)]
        public string NUMERO_SIEGE_COMPTABLE { get; set; }

        public virtual ICollection<ATELIER> ATELIER { get; set; }

        public virtual ICollection<CLE_REPARTITION_FIXE> CLE_REPARTITION_FIXE { get; set; }

        public virtual ICollection<CLE_REPARTITION_FIXE> CLE_REPARTITION_FIXE1 { get; set; }

        public virtual ICollection<CLE_REPARTITION_VARIABLE> CLE_REPARTITION_VARIABLE { get; set; }

        public virtual ICollection<CLE_REPARTITION_VARIABLE> CLE_REPARTITION_VARIABLE1 { get; set; }

        public virtual ICollection<ECRITURE_ANALYTIQUE> ECRITURE_ANALYTIQUE { get; set; }

        public virtual ICollection<MAGASIN> MAGASIN { get; set; }

        public virtual ICollection<METHODE_REG_COMPAGNIE> METHODE_REG_COMPAGNIE { get; set; }

        public virtual ICollection<METHODE_REG_SIEGE> METHODE_REG_SIEGE { get; set; }

        public virtual ICollection<PLAN_CPT_AN> PLAN_CPT_AN { get; set; }
    }
}
