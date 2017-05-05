namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARWENAMARA.NATURE_DEPENSE_REG")]
    public partial class NATURE_DEPENSE_REG
    {
        public NATURE_DEPENSE_REG()
        {
            NATURE_DEPENSE = new HashSet<NATURE_DEPENSE>();
        }

        [Key]
        [Required(ErrorMessage = "Veuillez renseigner ce champ !")]
        [StringLength(4, ErrorMessage = "La nature depense regroupée doit comporter 4 chiffres")]
        [Display(Name = "Nature dépense regroupée", Prompt = "Saisir le numero de la Nature dépense regroupée")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Veuillez saisir un nombre de 4 chiffres !")]
        public string NUMERO { get; set; }

        [StringLength(100, ErrorMessage = "La description est trop longue ! ca doit etre moins de  100 caracteres")]
        [Display(Name = "Libelle ", Prompt = "Saisir la description de la Nature Dépense regroupée en Français")]
        public string LIBELLE_FR { get; set; }

        [StringLength(100, ErrorMessage = "La description est trop longue ! ca doit etre moins de  100 caracteres")]
        [Display(Name = "Libelle AR", Prompt = "Saisir la description de la Nature Dépense regroupée en Arabe")]
        public string LIBELLE_AR { get; set; }

        public virtual ICollection<NATURE_DEPENSE> NATURE_DEPENSE { get; set; }
    }
}
