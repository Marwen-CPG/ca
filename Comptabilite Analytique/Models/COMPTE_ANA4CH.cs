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
        [Required(ErrorMessage = "Veuillez renseigner ce champs !")]
        [Display(Name = "Compte ", Prompt = "Saisir le numero de compte  à 4 chiffres")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Veuillez saisir un nombre decimal composé de 4 chiffres !")]
        public short NUMERO { get; set; }

        [Display(Name = "Compte à 3 chiffres", Prompt = "Saisir le numero de compte  à 3 chiffres")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Veuillez saisir un nombre decimal composé de 3 chiffres !")]
        public int COMPTE_ANA3CH_NUMERO { get; set; }

        [StringLength(100, ErrorMessage = "La description est trop longue ! ca doit etre moins de  100 caracteres")]
        [Display(Name = "Libelle ", Prompt = "Saisir la description du compte en Français")]
        public string LIBELLE_FR { get; set; }

        [StringLength(100, ErrorMessage = "La description est trop longue ! ca doit etre moins de  100 caracteres")]
        [Display(Name = "Libelle AR", Prompt = "Saisir la description du compte en Arabe")]
        public string LIBELLE_AR { get; set; }

        [StringLength(4, ErrorMessage = "L'année doit etre  de  4 caracteres")]
        [Display(Name = "Année Compatble", Prompt = "Saisir l'Année Compatble")]
        public string ANNEE_COMPTABLE { get; set; }

        public virtual COMPTE_ANA3CH COMPTE_ANA3CH { get; set; }

        public virtual ICollection<COMPTE_ANA5CH> COMPTE_ANA5CH { get; set; }
    }
}
