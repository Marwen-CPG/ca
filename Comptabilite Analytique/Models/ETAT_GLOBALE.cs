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
        [Required]
        [StringLength(6)]
        public string MOISENCOURS { get; set; }

        public bool CHEVAUCHEMENT { get; set; }

        public bool VEROUILLE { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
    }
}
