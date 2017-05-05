namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.MAGASIN")]
    public partial class MAGASIN
    {
        [Required(ErrorMessage = "Veuillez renseigner ce champ!")]
        [Key]
        [StringLength(2, ErrorMessage = "Le Code Magasin doit comporter deux chiffres")]
        [RegularExpression(@"^\d{1,2}$", ErrorMessage = "Veuillez saisir un nombre decimal entre 01 et 99 !")]
        [Display(Name = "Code Magasin", Prompt = "Saisir le Code Magasin")]
        public string CODE_MAGASIN { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner ce champ!")]
        [StringLength(2, ErrorMessage = "Le numero du Siège doit comporter deux chiffres")]
        [Display(Name = "Siege", Prompt = "Choisir le siege du magasin")]
        public string SIEGE_N_SIEGE { get; set; }

        [StringLength(100, ErrorMessage = "La description est trop longue ! ca doit etre moins de  100 caracteres")]
        [Display(Name = "Libelle ", Prompt = "Saisir la description du magasin en Français")]
        public string LIBELLE_FR { get; set; }

        [StringLength(100, ErrorMessage = "La description est trop longue ! ca doit etre moins de  100 caracteres")]
        [Display(Name = "Libelle AR", Prompt = "Saisir la description du magasin en Arabe")]
        public string LIBELLE_AR { get; set; }

        public virtual SIEGE SIEGE { get; set; }
    }
}
