namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.METHODE_REG_COMPAGNIE")]
    public partial class METHODE_REG_COMPAGNIE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDMETHODE_REG_COMPAGNIE { get; set; }


        [Required(ErrorMessage = "Veuillez renseigner ce champs !")]
        [Display(Name = "Compte ", Prompt = "Saisir le numero de compte  à 5 chiffres")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Veuillez saisir un nombre decimal composé de 5 chiffres !")]
        public short COMPTE_ANA5_NUMERO { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner ce champ!")]
        [StringLength(2, ErrorMessage = "Le numero du Siège doit comporter deux chiffres")]
        [Display(Name = "Siege", Prompt = "Choisir le siege ")]
        public string SIEGE_N_SIEGE { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [Display(Name = "Type groupement", Prompt = "Choisir le type de groupement")]
        [RegularExpression(@"^[3-5]$", ErrorMessage = "Veuillez saisir un chiffre entre 3 et 5 !")]
        public short CODE_GROUPEMENT { get; set; }

        [Column("METHODE_REG_COMPAGNIE")]
        [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [StringLength(3)]
        [Display(Name = "methode de  groupement", Prompt = "Saisir le numero de la methode de  groupement")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Veuillez saisir un nombre de 3 chiffres !")]
        public string METHODE_REG_COMPAGNIE1 { get; set; }


        [StringLength(100, ErrorMessage = "La description est trop longue ! ca doit etre moins de  100 caracteres")]
        [Display(Name = "Libelle ", Prompt = "Saisir la description de la methode de regroupement en Français")]
        public string LIBELLE_FR { get; set; }

        [StringLength(100, ErrorMessage = "La description est trop longue ! ca doit etre moins de  100 caracteres")]
        [Display(Name = "Libelle AR", Prompt = "Saisir la description de la methode de regroupement en arabe")]
        public string LIBELLE_AR { get; set; }

        public virtual COMPTE_ANA5CH COMPTE_ANA5CH { get; set; }

        public virtual SIEGE SIEGE { get; set; }
    }
}
