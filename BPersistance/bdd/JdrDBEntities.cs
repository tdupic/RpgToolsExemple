using Microsoft.EntityFrameworkCore;
using BiblioJdr;
using BiblioJdr.metier;

namespace BPersistance
{
    public class JdrDBEntities : DbContext
    {
        public virtual DbSet<Personnage> PersonnageSet { get; set; }

        public virtual DbSet<Item> ItemSet { get; set; }

        public JdrDBEntities() { }

        public JdrDBEntities(DbContextOptions<JdrDBEntities> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(@"Data Source =rpgTools.db")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .EnableSensitiveDataLogging();
            }
        }


        /// <summary>
        /// méthode appelée lors de la création du modèle. 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<ItemPersonnage>().Property<string>("NamePerso");
            modelBuilder.Entity<ItemPersonnage>().Property<string>("NameItem");

            modelBuilder.Entity<ItemPersonnage>().HasKey("NamePerso", "NameItem");
            modelBuilder.Entity<ItemPersonnage>().HasOne(ip => ip.Item).WithMany();*/
            
            
            //modelBuilder.Entity<Personnage>().HasOne(ps => ps.ROCIventaire).WithMany ;
            modelBuilder.Entity<Item>()
                 .HasDiscriminator<string>("itemType")
                 .HasValue<Item>("itemBase").HasValue<Arme>("arme");

            modelBuilder.Entity<Item>()
                 .HasDiscriminator<string>("itemType")
                 .HasValue<Item>("itemBase").HasValue<Armure>("armure");

            modelBuilder.Entity<Item>()
                 .HasDiscriminator<string>("itemType")
                 .HasValue<Item>("itemBase").HasValue<Potion>("potion");

            modelBuilder.Entity<Item>()
                 .HasDiscriminator<string>("itemType")
                 .HasValue<Item>("itemBase").HasValue<Nouriture>("nouriture");

            modelBuilder.Entity<Item>()
                 .HasDiscriminator<string>("itemType")
                 .HasValue<Item>("itemBase").HasValue<Divers>("divers");
        }
    }
}
