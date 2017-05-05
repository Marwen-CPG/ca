namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.PLAN_CPT_AN")]
    public partial class PLAN_CPT_AN
    {
        [Key]
        [Column(Order = 0)]
        [Required(ErrorMessage = "Veuillez renseigner ce champ!")]
        [StringLength(2, ErrorMessage = "Le numero du Siège doit comporter deux chiffres")]
        [Display(Name = "Siege", Prompt = "Choisir le siege ")]
        public string SIEGE_N_SIEGE { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Veuillez renseigner ce champs !")]
        [Display(Name = "Compte ", Prompt = "Saisir le numero de compte  à 5 chiffres")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Veuillez saisir un nombre decimal composé de 5 chiffres !")]
        public short COMPTE_ANA5CH_NUMERO { get; set; }

        [StringLength(100, ErrorMessage = "La description est trop longue ! ca doit etre moins de  100 caracteres")]
        [Display(Name = "Libelle ", Prompt = "Saisir la description du compte en Français")]
        public string LIBELLE_FR { get; set; }

        [StringLength(100, ErrorMessage = "La description est trop longue ! ca doit etre moins de  100 caracteres")]
        [Display(Name = "Libelle AR", Prompt = "Saisir la description du compte en Arabe")]
        public string LIBELLE_AR { get; set; }

        public virtual COMPTE_ANA5CH COMPTE_ANA5CH { get; set; }

        public virtual SIEGE SIEGE { get; set; }
    }
}
