namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.ETAT_GLOBALE")]
    public partial class ETAT_GLOBALE
    {
        [Key]
        [StringLength(4)]
        public string ANNEE_COMPTABLE { get; set; }

 
        [StringLength(6)]
        public string MOISENCOURS { get; set; }

       
        public bool CHEVAUCHEMENT { get; set; }

       
        public bool VEROUILLE { get; set; }

        public int NUMSEQ { get; set; }

        public int NUMECR { get; set; }

        [StringLength(6)]
        public string MOISCHEV { get; set; }
    }
}
