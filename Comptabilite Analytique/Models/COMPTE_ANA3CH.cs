namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.COMPTE_ANA3CH")]
    public partial class COMPTE_ANA3CH
    {
        public COMPTE_ANA3CH()
        {
            COMPTE_ANA4CH = new HashSet<COMPTE_ANA4CH>();
        }

        [Key]
        public byte NUMERO { get; set; }

        [StringLength(100)]
        public string LIBELLE_FR { get; set; }

        [StringLength(100)]
        public string LIBELLE_AR { get; set; }

        public virtual ICollection<COMPTE_ANA4CH> COMPTE_ANA4CH { get; set; }
    }
}
