namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.ATELIER")]
    public partial class ATELIER
    {
        [Key]
        [StringLength(2)]
        [Display(Name = "Code Atelier", Prompt = "Saisir le code de l'atelier")]
        [Required]
        [RegularExpression(@"^\d{1,2}$", ErrorMessage = "Veuillez saisir un nombre decimal entre 1 et 99 ")]
        [Range(1d, 99d, ErrorMessage = "Le code doit etre entre 1 et 99")]
        public string CODE_ATELIER { get; set; }

        [StringLength(100)]
        [Display(Name = "Libelle", Prompt = "Saisir le libelle de l'atelier en Francais")]
        public string LIBELLE_FR { get; set; }

        [StringLength(100)]
        [Display(Name = "Libelle AR", Prompt = "Saisir le libelle de l'atelier en Arabe")]
        public string LIBELLE_AR { get; set; }

        [StringLength(2, ErrorMessage = "Le numero du Siège doit comporter deux chiffres")]
        [Display(Name = "Siege", Prompt = "Choisir le siege ")]
        public string SIEGE_N_SIEGE { get; set; }

        public virtual SIEGE SIEGE { get; set; } 
    }
}
