namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.COMPTE_ANA4CH")]
    public partial class COMPTE_ANA4CH
    {
        public COMPTE_ANA4CH()
        {
            COMPTE_ANA5CH = new HashSet<COMPTE_ANA5CH>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short NUMERO { get; set; }

        public byte COMPTE_ANA3CH_NUMERO { get; set; }

        [StringLength(100)]
        public string LIBELLE_FR { get; set; }

        [StringLength(100)]
        public string LIBELLE_AR { get; set; }

        public virtual COMPTE_ANA3CH COMPTE_ANA3CH { get; set; }

        public virtual ICollection<COMPTE_ANA5CH> COMPTE_ANA5CH { get; set; }
    }
}
