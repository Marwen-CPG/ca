namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.ECRITURE_ANALYTIQUE")]
    public partial class ECRITURE_ANALYTIQUE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDECRIRE_ANALYTIQUE { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [StringLength(4, ErrorMessage = "Le numero du Si�ge doit comporter deux chiffres")]
        [Display(Name = "Nature d�pense", Prompt = "Saisir le num�ro de la Nature D�pense")]
        public string ND_NUMERO { get; set; }


        [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [Display(Name = "Compte ", Prompt = "Saisir le numero de compte analytique")]
        [RegularExpression(@"^9\d{4}$", ErrorMessage = "Veuillez saisir un nombre decimal compos� de 5 chiffres qui commence par 9!")]
        public int COMPTE_ANA5_NUMERO { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [StringLength(2, ErrorMessage = "Le numero du Si�ge doit comporter deux chiffres")]
        [Display(Name = "Si�ge", Prompt = "Choisir le Si�ge")]
        public string SIEGE_N_SIEGE { get; set; }


        [StringLength(6, ErrorMessage = "Le Num�ro de s�quence doit comporter 6 chiffres")]
        [Display(Name = "Num�ro de s�quence", Prompt = "Saisir le Num�ro de s�quence")]
        public string NUMERO_SEQUENCE { get; set; }


        [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [StringLength(2, ErrorMessage = "L'origine comporter deux chiffres")]
        [Display(Name = "Origine", Prompt = "Saisir l'origine")]
        public string ORIGINE { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [StringLength(2, ErrorMessage = "L'origine comporter deux chiffres")]
        [Display(Name = "Groupe", Prompt = "Saisir le groupe")]
        public string GROUPE { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Ecriture", Prompt = "Choisir la date ")]
        public DateTime? DATE_ECRITURE { get; set; }

        [StringLength(4, ErrorMessage = "Le numero ne doit pas depasser 4 chiffres")]
        [Display(Name = "Num�ro Ecriture", Prompt = "Num�ro Ecriture ")]
        public string NUMERO_ECRITURE { get; set; }

        [StringLength(100, ErrorMessage = "La description est trop longue ! ca doit etre moins de  100 caracteres")]
        [Display(Name = "Libelle ", Prompt = "Saisir la description de l'ecriture en Fran�ais")]
        public string LIBELLE_FR { get; set; }

        [StringLength(100, ErrorMessage = "La description est trop longue ! ca doit etre moins de  100 caracteres")]
        [Display(Name = "Libelle AR", Prompt = "Saisir la description de l'ecriture en Arabe")]
        public string LIBELLE_AR { get; set; }

        [Display(Name = "Date d'ajout")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DATE_AJOUT { get; set; }


        [StringLength(4, ErrorMessage = "La saisie n'est une ann�e valide")]
        [Display(Name = "Ann�e Compatable")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Veuillez saisir une ann�e valide !")]
        public string ANNEE_COMPTABLE { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [Display(Name = "Montant")]
       // [RegularExpression(@"^-?\d*(\.\d+)?$", ErrorMessage = "Veuillez saisir un montant valide!")]
        public decimal? MONTANT { get; set; }

        [StringLength(6, ErrorMessage = "Le Code Budget doit comporter 6 caracteres")]
        [Display(Name = "Code Budget", Prompt = "Saisir le Code Budget")]
        public string CODE_BUDGET { get; set; }


        [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [Display(Name = "Centre de l'�criture", Prompt = "Saisir le centre de l'�criture analytique")]
       [RegularExpression(@"^[0-9]$", ErrorMessage = "Veuillez saisir un nombre compos� d'un seul chiffre!")]
        public short? CENTRE_ECRITURE { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [Display(Name = "Compte g�n�rale", Prompt = "Saisir le numero de compte analytique")]
        [RegularExpression(@"^[1-8]\d{4}$", ErrorMessage = "Veuillez saisir un nombre decimal compos� de 5 chiffres qui commence par 1..8!")]
        public string COMPTE_GENERALE { get; set; }

        public virtual COMPTE_ANA5CH COMPTE_ANA5CH { get; set; }

        public virtual NATURE_DEPENSE NATURE_DEPENSE { get; set; }
    }
}
