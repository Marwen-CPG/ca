namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;
 
    public   class EcritureT1ViewModel
    {


        [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [StringLength(4, ErrorMessage = "Le numero Nature dépense doit comporter deux chiffres")]
        [Remote("ValidateND", "Ecriture")]
        [Display(Name = "Nature dépense", Prompt = "Saisir le numéro de la Nature Dépense")]
        public string ND_NUMERO { get; set; }


        [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [Remote("ValidateSC", "Ecriture", AdditionalFields = "SIEGE_N_SIEGED")]
        [Display(Name = "Compte ", Prompt = "Saisir le numero de compte analytique")]
        [RegularExpression(@"^9\d{4}$", ErrorMessage = "Veuillez saisir un nombre decimal composé de 5 chiffres qui commence par 9!")]
        public int COMPTE_ANA5_NUMEROD { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [StringLength(2, ErrorMessage = "Le numero du Siège doit comporter deux chiffres")]
        [Remote("ValidateSG", "Ecriture")]
        [Display(Name = "Siège", Prompt = "Choisir le Siège")]
        public string SIEGE_N_SIEGED { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [Display(Name = "Compte ", Prompt = "Saisir le numero de compte analytique")]
        [Remote("ValidateSCC", "Ecriture", AdditionalFields = "SIEGE_N_SIEGEC")]
        [RegularExpression(@"^9\d{4}$", ErrorMessage = "Veuillez saisir un nombre decimal composé de 5 chiffres qui commence par 9!")]
        public int COMPTE_ANA5_NUMEROC { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [StringLength(2, ErrorMessage = "Le numero du Siège doit comporter deux chiffres")]
        [Display(Name = "Siège", Prompt = "Choisir le Siège")]
        [Remote("ValidateSGC", "Ecriture")]
        public string SIEGE_N_SIEGEC { get; set; }


        [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [StringLength(2, ErrorMessage = "L'origine doit comporter deux chiffres")]
        [Display(Name = "Origine", Prompt = "Saisir l'origine")]
        [RegularExpression(@"\d{2}$", ErrorMessage = "L'origine doit comporter deux chiffres!")]
        public string ORIGINE { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [StringLength(2, ErrorMessage = "Le groupe doit comporter deux chiffres")]
        [Display(Name = "Groupe", Prompt = "Saisir le groupe")]
        [RegularExpression(@"\d{2}$", ErrorMessage = "Le groupe  doit comporter deux chiffres!")]
        public string GROUPE { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Ecriture", Prompt = "Choisir la date ")]
        public DateTime? DATE_ECRITURE { get; set; }



        [StringLength(100, ErrorMessage = "La description est trop longue ! ca doit etre moins de  100 caracteres")]
        [Display(Name = "Libelle ", Prompt = "Saisir la description de l'ecriture en Français")]
        public string LIBELLE_FR { get; set; }

        [StringLength(100, ErrorMessage = "La description est trop longue ! ca doit etre moins de  100 caracteres")]
        [Display(Name = "Libelle AR", Prompt = "Saisir la description de l'ecriture en Arabe")]
        public string LIBELLE_AR { get; set; }


        [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [Display(Name = "Montant")]
       // [RegularExpression(@"^-?\d*(\.\d+)?$", ErrorMessage = "Veuillez saisir un montant valide!")]
        public decimal? MONTANT { get; set; }


        [Remote("ValidateCBD", "Ecriture", AdditionalFields = "COMPTE_ANA5_NUMEROD")]
        [StringLength(6, ErrorMessage = "Le Code Budget doit comporter 6 caracteres")]
        [Display(Name = "Code Budget", Prompt = "Saisir le Code Budget")]
        public string CODE_BUDGETD { get; set; }

        [Remote("ValidateCBC", "Ecriture", AdditionalFields = "COMPTE_ANA5_NUMEROC")]
        [StringLength(6, ErrorMessage = "Le Code Budget doit comporter 6 caracteres")]
        [Display(Name = "Code Budget", Prompt = "Saisir le Code Budget")]
        public string CODE_BUDGETC { get; set; }


       // [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [Display(Name = "Compte générale", Prompt = "Saisir le numero de compte analytique")]
        [RegularExpression(@"^[1-8]\d{4}$", ErrorMessage = "Veuillez saisir un nombre decimal composé de 5 chiffres qui commence par 1..8!")]
        public string COMPTE_GENERALE { get; set; }
    }
}
