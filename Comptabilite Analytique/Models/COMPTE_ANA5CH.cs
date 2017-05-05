namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.COMPTE_ANA5CH")]
    public partial class COMPTE_ANA5CH
    {
        public COMPTE_ANA5CH()
        {
            CLE_REPARTITION_FIXE = new HashSet<CLE_REPARTITION_FIXE>();
            CLE_REPARTITION_FIXE1 = new HashSet<CLE_REPARTITION_FIXE>();
            CLE_REPARTITION_VARIABLE = new HashSet<CLE_REPARTITION_VARIABLE>();
            CLE_REPARTITION_VARIABLE1 = new HashSet<CLE_REPARTITION_VARIABLE>();
            METHODE_REG_COMPAGNIE = new HashSet<METHODE_REG_COMPAGNIE>();
            METHODE_REG_SIEGE = new HashSet<METHODE_REG_SIEGE>();
            ECRITURE_ANALYTIQUE = new HashSet<ECRITURE_ANALYTIQUE>();
        }

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
        public int NUMERO { get; set; }

        [Display(Name = "Compte à 4 chiffres", Prompt = "Saisir le numero de compte  à 3 chiffres")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Veuillez saisir un nombre decimal composé de 3 chiffres !")]
        public short COMPTE_ANA4CH_NUMERO { get; set; }

        [StringLength(100, ErrorMessage = "La description est trop longue ! ca doit etre moins de  100 caracteres")]
        [Display(Name = "Libelle ", Prompt = "Saisir la description du compte en Français")]
        public string LIBELLE_FR { get; set; }

        [StringLength(100, ErrorMessage = "La description est trop longue ! ca doit etre moins de  100 caracteres")]
        [Display(Name = "Libelle AR", Prompt = "Saisir la description du compte en Arabe")]
        public string LIBELLE_AR { get; set; }

        [StringLength(4, ErrorMessage = "L'année doit etre  de  4 caracteres")]
        [Display(Name = "Année Compatble", Prompt = "Saisir l'Année Compatble")]
        public string ANNEE_COMPTABLE { get; set; }

        public virtual ICollection<CLE_REPARTITION_FIXE> CLE_REPARTITION_FIXE { get; set; }

        public virtual ICollection<CLE_REPARTITION_FIXE> CLE_REPARTITION_FIXE1 { get; set; }

        public virtual ICollection<CLE_REPARTITION_VARIABLE> CLE_REPARTITION_VARIABLE { get; set; }

        public virtual ICollection<CLE_REPARTITION_VARIABLE> CLE_REPARTITION_VARIABLE1 { get; set; }

        public virtual COMPTE_ANA4CH COMPTE_ANA4CH { get; set; }

        public virtual SIEGE SIEGE { get; set; }

        public virtual ICollection<METHODE_REG_COMPAGNIE> METHODE_REG_COMPAGNIE { get; set; }

        public virtual ICollection<METHODE_REG_SIEGE> METHODE_REG_SIEGE { get; set; }

        public virtual ICollection<ECRITURE_ANALYTIQUE> ECRITURE_ANALYTIQUE { get; set; }
    }
}
