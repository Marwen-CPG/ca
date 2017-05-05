namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.CLE_REPARTITION_VARIABLE")]
    public partial class CLE_REPARTITION_VARIABLE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDCLE_REP_VAR { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [Display(Name = "Compte Source", Prompt = "Saisir le numero de compte source de repartition")]
        [RegularExpression(@"^\d{3,5}$", ErrorMessage = "Veuillez saisir un nombre decimal composé de 3 à 5 chiffres !")]
        public int COMPTE_NUMERO { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner ce champ!")]
        [StringLength(2, ErrorMessage = "Le numero du Siège doit comporter deux chiffres")]
        [Display(Name = "Siege", Prompt = "Choisir le siege du compte source de repartition")]
        public string SIEGE_N_SIEGE { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [Display(Name = "Type répartition", Prompt = "Choisir le type de repartition")]
        [RegularExpression(@"^[3-5]$", ErrorMessage = "Veuillez saisir un chiffre entre 3 et 5 !")]
        public short CODE_GROUPEMENT { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [StringLength(2, ErrorMessage = "Le numero du Siège doit comporter deux chiffres")]
        [Display(Name = "Siège répartition", Prompt = "Choisir le siege du compte destination de  repartition")]
        public string UR_REPARTITION { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [Display(Name = "Compte destination", Prompt = "Saisir le numero de compte destination de repartition")]
        [RegularExpression(@"^\d{3,5}$", ErrorMessage = "Veuillez saisir un nombre decimal composé de 3 à 5 chiffres !")]
        public int CA_REPARTITION { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [StringLength(4, ErrorMessage = "Le numero du Nature Dépense doit comporter 4 chiffres")]
        [Display(Name = "Nature dépense", Prompt = "Saisir le numéro de la Nature Dépense")]
        public string NATURE_DEPENSE { get; set; }

        [Display(Name = "Taux répartition", Prompt = "Saisir le Taux de repartition")]
        [Required(ErrorMessage = "Veuillez renseigner ce champs !")]
        [RegularExpression(@"^\d{0,3}.\d{0,2}$", ErrorMessage = "Veuillez saisir un nombre decimal entre 0 et 100 !")]
        [Range(0d, 100d, ErrorMessage = "Le taux doit etre entre 0 et 100 %")]
        public decimal? TAUX_REPARTITION { get; set; }
        [StringLength(4, ErrorMessage = "L'année doit etre  de  4 caracteres")]
        [Display(Name = "Année Comptable", Prompt = "Saisir l'Année Compatble")]
        public string ANNEE_COMPTABLE { get; set; }


        public virtual COMPTE_ANA5CH COMPTE_ANA5CH { get; set; }

        public virtual COMPTE_ANA5CH COMPTE_ANA5CH1 { get; set; }

        [ForeignKey("SIEGE_N_SIEGE")]
        public virtual SIEGE SIEGE { get; set; }

        [ForeignKey("UR_REPARTITION")]
        public virtual SIEGE SIEGE1 { get; set; }

        public virtual NATURE_DEPENSE NATURE_DEPENSE1 { get; set; }
    }
}
