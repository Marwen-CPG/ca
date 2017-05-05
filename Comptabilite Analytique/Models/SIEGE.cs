namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.SIEGE")]
    public partial class SIEGE
    {
        public SIEGE()
        {
            ATELIER = new HashSet<ATELIER>();
            COMPTE_ANA5CH = new HashSet<COMPTE_ANA5CH>();
            MAGASIN = new HashSet<MAGASIN>();
        }

        [Key]
        [Required(ErrorMessage = "Veuillez renseigner ce champ!")]
        [StringLength(2, ErrorMessage = "Le numero du Siège doit comporter deux chiffres")]
        [RegularExpression(@"^\d{1,2}$", ErrorMessage = "Veuillez saisir un nombre decimal entre 1 et 99 ")]
        [Display(Name = "Siege", Prompt = "Choisir le siege ")]
        public string NUMERO_SIEGE { get; set; }


        [StringLength(100, ErrorMessage = "La description est trop longue ! ca doit etre moins de  100 caracteres")]
        [Display(Name = "Libelle ", Prompt = "Saisir le nom du siege en Français")]
        public string LIBELLE_FR { get; set; }

        [StringLength(100, ErrorMessage = "La description est trop longue ! ca doit etre moins de  100 caracteres")]
        [Display(Name = "Libelle AR", Prompt = "Saisir le nom du siege en Arabe")]
        public string LIBELLE_AR { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner ce champ!")]
        [StringLength(2, ErrorMessage = "Le numero du Siege Comptable doit comporter deux chiffres")]
        [Display(Name = "Siege Comptable", Prompt = "Choisir le Siege Comptable ")]
        public string NUMERO_SIEGE_COMPTABLE { get; set; }

        public virtual ICollection<ATELIER> ATELIER { get; set; }

        public virtual ICollection<COMPTE_ANA5CH> COMPTE_ANA5CH { get; set; }

        public virtual ICollection<MAGASIN> MAGASIN { get; set; }
    }
}
