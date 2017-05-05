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
        [Required(ErrorMessage = "Veuillez renseigner ce champs !")]
        [Display(Name = "Compte ", Prompt = "Saisir le numero de compte  à 3 chiffres")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Veuillez saisir un nombre decimal composé de 3 chiffres !")]
        public int NUMERO { get; set; }

        [StringLength(100, ErrorMessage = "La description est trop longue ! ca doit etre moins de  100 caracteres")]
        [Display(Name = "Libelle ", Prompt = "Saisir la description du compte en Français")]
        public string LIBELLE_FR { get; set; }

        [StringLength(100, ErrorMessage = "La description est trop longue ! ca doit etre moins de  100 caracteres")]
        [Display(Name = "Libelle AR", Prompt = "Saisir la description du compte en Arabe")]
        public string LIBELLE_AR { get; set; }

        [StringLength(4,ErrorMessage = "L'année doit etre  de  4 caracteres")]
        [Display(Name = "Année Compatble", Prompt = "Saisir l'Année Compatble")]
        public string ANNEE_COMPTABLE { get; set; }
        public virtual ICollection<COMPTE_ANA4CH> COMPTE_ANA4CH { get; set; }
    }
}
