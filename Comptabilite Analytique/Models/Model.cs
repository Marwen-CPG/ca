namespace Comptabilite_Analytique.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=db")
        {
        }

        public virtual DbSet<ATELIER> ATELIER { get; set; }
        public virtual DbSet<CLE_REPARTITION_FIXE> CLE_REPARTITION_FIXE { get; set; }
        public virtual DbSet<CLE_REPARTITION_VARIABLE> CLE_REPARTITION_VARIABLE { get; set; }
        public virtual DbSet<COMPTE_ANA3CH> COMPTE_ANA3CH { get; set; }
        public virtual DbSet<COMPTE_ANA4CH> COMPTE_ANA4CH { get; set; }
        public virtual DbSet<COMPTE_ANA5CH> COMPTE_ANA5CH { get; set; }
        public virtual DbSet<CRF_HIST> CRF_HIST { get; set; }
        public virtual DbSet<CRV_HIST> CRV_HIST { get; set; }
        public virtual DbSet<ECRITURE_ANALYTIQUE> ECRITURE_ANALYTIQUE { get; set; }
        public virtual DbSet<ECRITURE_ANALYTIQUE_HIST> ECRITURE_ANALYTIQUE_HIST { get; set; }
        public virtual DbSet<MAGASIN> MAGASIN { get; set; }
        public virtual DbSet<METHODE_REG_COMP_HIST> METHODE_REG_COMP_HIST { get; set; }
        public virtual DbSet<METHODE_REG_COMPAGNIE> METHODE_REG_COMPAGNIE { get; set; }
        public virtual DbSet<METHODE_REG_SIEG_HIST> METHODE_REG_SIEG_HIST { get; set; }
        public virtual DbSet<METHODE_REG_SIEGE> METHODE_REG_SIEGE { get; set; }
        public virtual DbSet<NATURE_DEPENSE> NATURE_DEPENSE { get; set; }
        public virtual DbSet<NATURE_DEPENSE_REG> NATURE_DEPENSE_REG { get; set; }
        public virtual DbSet<NATURE_DEPENSE_SUBVENTION> NATURE_DEPENSE_SUBVENTION { get; set; }
        public virtual DbSet<SIEGE> SIEGE { get; set; }
        public virtual DbSet<ETAT_GLOBALE> ETAT_GLOBALE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ATELIER>()
                .Property(e => e.CODE_ATELIER)
                .IsUnicode(false);

            modelBuilder.Entity<ATELIER>()
                .Property(e => e.LIBELLE_FR)
                .IsUnicode(false);

            modelBuilder.Entity<ATELIER>()
                .Property(e => e.LIBELLE_AR)
                .IsUnicode(false);

            modelBuilder.Entity<ATELIER>()
                .Property(e => e.SIEGE_N_SIEGE)
                .IsUnicode(false);

            modelBuilder.Entity<CLE_REPARTITION_FIXE>()
                .Property(e => e.SIEGE_N_SIEGE)
               
                .IsUnicode(false);

            modelBuilder.Entity<CLE_REPARTITION_FIXE>()
                .Property(e => e.UR_REPARTITION)
                .IsUnicode(false);

            modelBuilder.Entity<CLE_REPARTITION_FIXE>()
                .Property(e => e.NATURE_DEPENSE)
                .IsUnicode(false);

            modelBuilder.Entity<CLE_REPARTITION_FIXE>()
                .Property(e => e.TAUX_REPARTITION)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CLE_REPARTITION_FIXE>()
                .Property(e => e.ANNEE_COMPTABLE)
                .IsUnicode(false);

            modelBuilder.Entity<CLE_REPARTITION_VARIABLE>()
                .Property(e => e.SIEGE_N_SIEGE)
                .IsUnicode(false);

            modelBuilder.Entity<CLE_REPARTITION_VARIABLE>()
                .Property(e => e.UR_REPARTITION)
                .IsUnicode(false);

            modelBuilder.Entity<CLE_REPARTITION_VARIABLE>()
                .Property(e => e.NATURE_DEPENSE)
                .IsUnicode(false);

            modelBuilder.Entity<CLE_REPARTITION_VARIABLE>()
                .Property(e => e.TAUX_REPARTITION)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CLE_REPARTITION_VARIABLE>()
                .Property(e => e.ANNEE_COMPTABLE)
                .IsUnicode(false);

            modelBuilder.Entity<COMPTE_ANA3CH>()
                .Property(e => e.LIBELLE_FR)
                .IsUnicode(false);

            modelBuilder.Entity<COMPTE_ANA3CH>()
                .Property(e => e.LIBELLE_AR)
                .IsUnicode(false);

            modelBuilder.Entity<COMPTE_ANA3CH>()
                .Property(e => e.ANNEE_COMPTABLE)
                .IsUnicode(false);

            modelBuilder.Entity<COMPTE_ANA3CH>()
                .HasMany(e => e.COMPTE_ANA4CH)
                .WithRequired(e => e.COMPTE_ANA3CH)
                .HasForeignKey(e => e.COMPTE_ANA3CH_NUMERO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COMPTE_ANA4CH>()
                .Property(e => e.LIBELLE_FR)
                .IsUnicode(false);

            modelBuilder.Entity<COMPTE_ANA4CH>()
                .Property(e => e.LIBELLE_AR)
                .IsUnicode(false);

            modelBuilder.Entity<COMPTE_ANA4CH>()
                .Property(e => e.ANNEE_COMPTABLE)
                .IsUnicode(false);

            modelBuilder.Entity<COMPTE_ANA4CH>()
                .HasMany(e => e.COMPTE_ANA5CH)
                .WithRequired(e => e.COMPTE_ANA4CH)
                .HasForeignKey(e => e.COMPTE_ANA4CH_NUMERO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COMPTE_ANA5CH>()
                .Property(e => e.SIEGE_N_SIEGE)
                .IsUnicode(false);

            modelBuilder.Entity<COMPTE_ANA5CH>()
                .Property(e => e.LIBELLE_FR)
                .IsUnicode(false);

            modelBuilder.Entity<COMPTE_ANA5CH>()
                .Property(e => e.LIBELLE_AR)
                .IsUnicode(false);

            modelBuilder.Entity<COMPTE_ANA5CH>()
                .Property(e => e.ANNEE_COMPTABLE)
                .IsUnicode(false);

            modelBuilder.Entity<COMPTE_ANA5CH>()
                .HasMany(e => e.CLE_REPARTITION_FIXE)
                .WithRequired(e => e.COMPTE_ANA5CH)
                .HasForeignKey(e => new { e.SIEGE_N_SIEGE, e.COMPTE_NUMERO })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COMPTE_ANA5CH>()
                .HasMany(e => e.CLE_REPARTITION_FIXE1)
                .WithRequired(e => e.COMPTE_ANA5CH1)
                .HasForeignKey(e => new { e.SIEGE_N_SIEGE, e.CA_REPARTITION })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COMPTE_ANA5CH>()
                .HasMany(e => e.CLE_REPARTITION_VARIABLE)
                .WithRequired(e => e.COMPTE_ANA5CH)
                .HasForeignKey(e => new { e.SIEGE_N_SIEGE, e.COMPTE_NUMERO })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COMPTE_ANA5CH>()
                .HasMany(e => e.CLE_REPARTITION_VARIABLE1)
                .WithRequired(e => e.COMPTE_ANA5CH1)
                .HasForeignKey(e => new { e.SIEGE_N_SIEGE, e.CA_REPARTITION })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COMPTE_ANA5CH>()
                .HasMany(e => e.METHODE_REG_COMPAGNIE)
                .WithRequired(e => e.COMPTE_ANA5CH)
                .HasForeignKey(e => new { e.SIEGE_N_SIEGE, e.COMPTE_ANA5_NUMERO })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COMPTE_ANA5CH>()
                .HasMany(e => e.METHODE_REG_SIEGE)
                .WithRequired(e => e.COMPTE_ANA5CH)
                .HasForeignKey(e => new { e.SIEGE_N_SIEGE, e.COMPTE_ANA5_NUMERO })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COMPTE_ANA5CH>()
                .HasMany(e => e.ECRITURE_ANALYTIQUE)
                .WithRequired(e => e.COMPTE_ANA5CH)
                .HasForeignKey(e => new { e.SIEGE_N_SIEGE, e.COMPTE_ANA5_NUMERO })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CRF_HIST>()
                .Property(e => e.TYPE_OPERATION)
                .IsUnicode(false);

            modelBuilder.Entity<CRF_HIST>()
                .Property(e => e.EFFECTUER_PAR)
                .IsUnicode(false);

            modelBuilder.Entity<CRF_HIST>()
                .Property(e => e.SIEGE_N_SIEGE)
                .IsUnicode(false);

            modelBuilder.Entity<CRF_HIST>()
                .Property(e => e.UR_REPARTITION)
                .IsUnicode(false);

            modelBuilder.Entity<CRF_HIST>()
                .Property(e => e.NATURE_DEPENSE)
                .IsUnicode(false);

            modelBuilder.Entity<CRF_HIST>()
                .Property(e => e.TAUX_REPARTITION)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CRF_HIST>()
                .Property(e => e.ANNEE_COMPTABLE)
                .IsUnicode(false);

            modelBuilder.Entity<CRV_HIST>()
                .Property(e => e.TYPE_OPERATION)
                .IsUnicode(false);

            modelBuilder.Entity<CRV_HIST>()
                .Property(e => e.EFFECTUER_PAR)
                .IsUnicode(false);

            modelBuilder.Entity<CRV_HIST>()
                .Property(e => e.SIEGE_N_SIEGE)
                .IsUnicode(false);

            modelBuilder.Entity<CRV_HIST>()
                .Property(e => e.UR_REPARTITION)
                .IsUnicode(false);

            modelBuilder.Entity<CRV_HIST>()
                .Property(e => e.NATURE_DEPENSE)
                .IsUnicode(false);

            modelBuilder.Entity<CRV_HIST>()
                .Property(e => e.TAUX_REPARTITION)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CRV_HIST>()
                .Property(e => e.ANNEE_COMPTABLE)
                .IsUnicode(false);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE>()
                .Property(e => e.ND_NUMERO)
                .IsUnicode(false);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE>()
                .Property(e => e.SIEGE_N_SIEGE)
                .IsUnicode(false);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE>()
                .Property(e => e.NUMERO_SEQUENCE)
                .IsUnicode(false);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE>()
                .Property(e => e.ORIGINE)
                .IsUnicode(false);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE>()
                .Property(e => e.GROUPE)
                .IsUnicode(false);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE>()
                .Property(e => e.NUMERO_ECRITURE)
                .IsUnicode(false);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE>()
                .Property(e => e.LIBELLE_FR)
                .IsUnicode(false);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE>()
                .Property(e => e.LIBELLE_AR)
                .IsUnicode(false);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE>()
                .Property(e => e.ANNEE_COMPTABLE)
                .IsUnicode(false);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE>()
                .Property(e => e.MONTANT)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE>()
                .Property(e => e.CODE_BUDGET)
                .IsUnicode(false);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE>()
                .Property(e => e.COMPTE_GENERALE)
                .IsUnicode(false);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE_HIST>()
                .Property(e => e.TYPE_OPERATION)
                .IsUnicode(false);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE_HIST>()
                .Property(e => e.EFFECTUER_PAR)
                .IsUnicode(false);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE_HIST>()
                .Property(e => e.ND_NUMERO)
                .IsUnicode(false);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE_HIST>()
                .Property(e => e.SIEGE_N_SIEGE)
                .IsUnicode(false);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE_HIST>()
                .Property(e => e.NUMERO_SEQUENCE)
                .IsUnicode(false);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE_HIST>()
                .Property(e => e.ORIGINE)
                .IsUnicode(false);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE_HIST>()
                .Property(e => e.GROUPE)
                .IsUnicode(false);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE_HIST>()
                .Property(e => e.NUMERO_ECRITURE)
                .IsUnicode(false);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE_HIST>()
                .Property(e => e.LIBELLE_FR)
                .IsUnicode(false);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE_HIST>()
                .Property(e => e.LIBELLE_AR)
                .IsUnicode(false);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE_HIST>()
                .Property(e => e.ANNEE_COMPTABLE)
                .IsUnicode(false);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE_HIST>()
                .Property(e => e.MONTANT)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE_HIST>()
                .Property(e => e.CODE_BUDGET)
                .IsUnicode(false);

            modelBuilder.Entity<ECRITURE_ANALYTIQUE_HIST>()
                .Property(e => e.COMPTE_GENERALE)
                .IsUnicode(false);

            modelBuilder.Entity<MAGASIN>()
                .Property(e => e.CODE_MAGASIN)
                .IsUnicode(false);

            modelBuilder.Entity<MAGASIN>()
                .Property(e => e.SIEGE_N_SIEGE)
                .IsUnicode(false);

            modelBuilder.Entity<MAGASIN>()
                .Property(e => e.LIBELLE_FR)
                .IsUnicode(false);

            modelBuilder.Entity<MAGASIN>()
                .Property(e => e.LIBELLE_AR)
                .IsUnicode(false);

            modelBuilder.Entity<METHODE_REG_COMP_HIST>()
                .Property(e => e.TYPE_OPERATION)
                .IsUnicode(false);

            modelBuilder.Entity<METHODE_REG_COMP_HIST>()
                .Property(e => e.EFFECTUER_PAR)
                .IsUnicode(false);

            modelBuilder.Entity<METHODE_REG_COMP_HIST>()
                .Property(e => e.SIEGE_N_SIEGE)
                .IsUnicode(false);

            modelBuilder.Entity<METHODE_REG_COMP_HIST>()
                .Property(e => e.METHODE_REG_COMPAGNIE)
                .IsUnicode(false);

            modelBuilder.Entity<METHODE_REG_COMP_HIST>()
                .Property(e => e.LIBELLE_FR)
                .IsUnicode(false);

            modelBuilder.Entity<METHODE_REG_COMP_HIST>()
                .Property(e => e.ANNEE_COMPTABLE)
                .IsUnicode(false);

            modelBuilder.Entity<METHODE_REG_COMPAGNIE>()
                .Property(e => e.SIEGE_N_SIEGE)
                .IsUnicode(false);

            modelBuilder.Entity<METHODE_REG_COMPAGNIE>()
                .Property(e => e.METHODE_REG_COMPAGNIE1)
                .IsUnicode(false);

            modelBuilder.Entity<METHODE_REG_COMPAGNIE>()
                .Property(e => e.LIBELLE_FR)
                .IsUnicode(false);

            modelBuilder.Entity<METHODE_REG_COMPAGNIE>()
                .Property(e => e.ANNEE_COMPTABLE)
                .IsUnicode(false);

            modelBuilder.Entity<METHODE_REG_SIEG_HIST>()
                .Property(e => e.TYPE_OPERATION)
                .IsUnicode(false);

            modelBuilder.Entity<METHODE_REG_SIEG_HIST>()
                .Property(e => e.EFFECTUER_PAR)
                .IsUnicode(false);

            modelBuilder.Entity<METHODE_REG_SIEG_HIST>()
                .Property(e => e.SIEGE_N_SIEGE)
                .IsUnicode(false);

            modelBuilder.Entity<METHODE_REG_SIEG_HIST>()
                .Property(e => e.CODE_GROUPEMENT)
                .IsUnicode(false);

            modelBuilder.Entity<METHODE_REG_SIEG_HIST>()
                .Property(e => e.METHODE_REG_SIEGE)
                .IsUnicode(false);

            modelBuilder.Entity<METHODE_REG_SIEG_HIST>()
                .Property(e => e.LIBELLE_FR)
                .IsUnicode(false);

            modelBuilder.Entity<METHODE_REG_SIEG_HIST>()
                .Property(e => e.LIBELLE_AR)
                .IsUnicode(false);

            modelBuilder.Entity<METHODE_REG_SIEG_HIST>()
                .Property(e => e.ANNEE_COMPTABLE)
                .IsUnicode(false);

            modelBuilder.Entity<METHODE_REG_SIEGE>()
                .Property(e => e.SIEGE_N_SIEGE)
                .IsUnicode(false);

            modelBuilder.Entity<METHODE_REG_SIEGE>()
                .Property(e => e.CODE_GROUPEMENT)
                .IsUnicode(false);

            modelBuilder.Entity<METHODE_REG_SIEGE>()
                .Property(e => e.METHODE_REG_SIEGE1)
                .IsUnicode(false);

            modelBuilder.Entity<METHODE_REG_SIEGE>()
                .Property(e => e.LIBELLE_FR)
                .IsUnicode(false);

            modelBuilder.Entity<METHODE_REG_SIEGE>()
                .Property(e => e.LIBELLE_AR)
                .IsUnicode(false);

            modelBuilder.Entity<METHODE_REG_SIEGE>()
                .Property(e => e.ANNEE_COMPTABLE)
                .IsUnicode(false);

            modelBuilder.Entity<NATURE_DEPENSE>()
                .Property(e => e.NUMERO)
                .IsUnicode(false);

            modelBuilder.Entity<NATURE_DEPENSE>()
                .Property(e => e.NDR_NUMERO)
                .IsUnicode(false);

            modelBuilder.Entity<NATURE_DEPENSE>()
                .Property(e => e.LIBELLE_FR)
                .IsUnicode(false);

            modelBuilder.Entity<NATURE_DEPENSE>()
                .Property(e => e.LIBELLE_AR)
                .IsUnicode(false);

            modelBuilder.Entity<NATURE_DEPENSE>()
                .HasMany(e => e.CLE_REPARTITION_FIXE)
                .WithRequired(e => e.NATURE_DEPENSE1)
                .HasForeignKey(e => e.NATURE_DEPENSE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NATURE_DEPENSE>()
                .HasMany(e => e.CLE_REPARTITION_VARIABLE)
                .WithRequired(e => e.NATURE_DEPENSE1)
                .HasForeignKey(e => e.NATURE_DEPENSE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NATURE_DEPENSE>()
                .HasMany(e => e.ECRITURE_ANALYTIQUE)
                .WithRequired(e => e.NATURE_DEPENSE)
                .HasForeignKey(e => e.ND_NUMERO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NATURE_DEPENSE>()
                .HasMany(e => e.NATURE_DEPENSE_SUBVENTION)
                .WithRequired(e => e.NATURE_DEPENSE)
                .HasForeignKey(e => e.ND_NUMERO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NATURE_DEPENSE_REG>()
                .Property(e => e.NUMERO)
                .IsUnicode(false);

            modelBuilder.Entity<NATURE_DEPENSE_REG>()
                .Property(e => e.LIBELLE_FR)
                .IsUnicode(false);

            modelBuilder.Entity<NATURE_DEPENSE_REG>()
                .Property(e => e.LIBELLE_AR)
                .IsUnicode(false);

            modelBuilder.Entity<NATURE_DEPENSE_REG>()
                .HasMany(e => e.NATURE_DEPENSE)
                .WithRequired(e => e.NATURE_DEPENSE_REG)
                .HasForeignKey(e => e.NDR_NUMERO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NATURE_DEPENSE_SUBVENTION>()
                .Property(e => e.NUMERO)
                .IsUnicode(false);

            modelBuilder.Entity<NATURE_DEPENSE_SUBVENTION>()
                .Property(e => e.ND_NUMERO)
                .IsUnicode(false);

            modelBuilder.Entity<NATURE_DEPENSE_SUBVENTION>()
                .Property(e => e.LIBELLE_FR)
                .IsUnicode(false);

            modelBuilder.Entity<NATURE_DEPENSE_SUBVENTION>()
                .Property(e => e.LIBELLE_AR)
                .IsUnicode(false);

            modelBuilder.Entity<SIEGE>()
                .Property(e => e.NUMERO_SIEGE)
                .IsUnicode(false);

            modelBuilder.Entity<SIEGE>()
                .Property(e => e.LIBELLE_FR)
                .IsUnicode(false);

            modelBuilder.Entity<SIEGE>()
                .Property(e => e.LIBELLE_AR)
                .IsUnicode(false);

            modelBuilder.Entity<SIEGE>()
                .Property(e => e.NUMERO_SIEGE_COMPTABLE)
                .IsUnicode(false);

            modelBuilder.Entity<SIEGE>()
                .HasMany(e => e.ATELIER)
                .WithOptional(e => e.SIEGE)
                .HasForeignKey(e => e.SIEGE_N_SIEGE);

            modelBuilder.Entity<SIEGE>()
                .HasMany(e => e.COMPTE_ANA5CH)
                .WithRequired(e => e.SIEGE)
                .HasForeignKey(e => e.SIEGE_N_SIEGE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SIEGE>()
                .HasMany(e => e.MAGASIN)
                .WithRequired(e => e.SIEGE)
                .HasForeignKey(e => e.SIEGE_N_SIEGE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ETAT_GLOBALE>()
                .Property(e => e.ANNEE_COMPTABLE)
                .IsUnicode(false);

            modelBuilder.Entity<ETAT_GLOBALE>()
                .Property(e => e.MOISENCOURS)
                .IsUnicode(false);

 
        }
    }
}
