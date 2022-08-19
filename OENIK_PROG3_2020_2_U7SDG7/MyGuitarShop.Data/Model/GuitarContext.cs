namespace MyGuitarShop.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Responsible for the initialization of the database.
    /// </summary>
    public class GuitarContext : DbContext
    {
        // Connection string: Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True

        /// <summary>
        /// Initializes a new instance of the <see cref="GuitarContext"/> class.
        /// </summary>
        public GuitarContext()
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Gets or sets the elements of the Guitar table.
        /// </summary>
        public virtual DbSet<Guitar> Guitars { get; set; }

        /// <summary>
        /// Gets or sets the elements of the Amp table.
        /// </summary>
        public virtual DbSet<Amp> Amps { get; set; }

        /// <summary>
        /// Gets or sets the elements of the Accessories table.
        /// </summary>
        public virtual DbSet<Accessory> Accessories { get; set; }

        /// <summary>
        /// Gets or sets the elements of the GuitarAmps table.
        /// </summary>
        public virtual DbSet<GuitarAmp> GuitarAmps { get; set; }

        /// <summary>
        /// Gets or sets the elements of the GuitarAccessories table.
        /// </summary>
        public virtual DbSet<GuitarAccessory> GuitarAccessories { get; set; }

        /// <summary>
        /// Responsible for the setting up of the database.
        /// </summary>
        /// <param name="optionsBuilder">DbContextOptionBuilder type optionsBuilder, used to configure instances.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                        .UseLazyLoadingProxies()
                        .UseSqlServer(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\Database.mdf; Integrated Security = True");
            }
        }

        /// <summary>
        /// Responsible for the initalization, and connection of the database.
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder type modelBuilder, used to initialize Database.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guitar g0 = new Guitar() { GuitarId = 1, Brand = "Gibson", Modell = "Les Paul 500", Category = "Electric Guitar", Type = "Les Paul", Price = 200000, FretNumber = 20 };
            Guitar g1 = new Guitar() { GuitarId = 2, Brand = "Fender", Modell = "American Stratocaster", Category = "Electric Guitar", Type = "Stratocaster", Price = 220000, FretNumber = 18 };
            Guitar g2 = new Guitar() { GuitarId = 3, Brand = "Fender", Modell = "Deluxe Stratocaster", Category = "Electric Guitar", Type = "Stratocaster", Price = 300000, FretNumber = 20 };
            Guitar g3 = new Guitar() { GuitarId = 4, Brand = "Fender", Modell = "American Professional II", Category = "Electric Guitar", Type = "Telecaster", Price = 520000, FretNumber = 20 };
            Guitar g4 = new Guitar() { GuitarId = 5, Brand = "PRS", Modell = "SE Custom 24 Floyd", Category = "Electric Guitar", Type = "PRS", Price = 730000, FretNumber = 24 };
            Guitar g5 = new Guitar() { GuitarId = 6, Brand = "Gibson", Modell = "SG Standard HC", Category = "Electric Guitar", Type = "SG", Price = 550000, FretNumber = 20 };
            Guitar g6 = new Guitar() { GuitarId = 7, Brand = "Martin", Modell = "000-10E-01", Category = "Acoustic Guitar", Type = "Western", Price = 360000, FretNumber = 20 };
            Guitar g7 = new Guitar() { GuitarId = 8, Brand = "Martin", Modell = "OMJM John Mayer", Category = "Acoustic Guitar", Type = "Folk", Price = 960000, FretNumber = 20 };
            Guitar g8 = new Guitar() { GuitarId = 9, Brand = "Taylor", Modell = "214ce Plus", Category = "Acoustic Guitar", Type = "Western", Price = 380000, FretNumber = 20 };

            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            GuitarAmp ga0 = new GuitarAmp();
            GuitarAmp ga1 = new GuitarAmp();
            GuitarAmp ga2 = new GuitarAmp();
            GuitarAmp ga3 = new GuitarAmp();
            GuitarAmp ga4 = new GuitarAmp();
            GuitarAmp ga5 = new GuitarAmp();
            GuitarAmp ga6 = new GuitarAmp();

            //--------------------------------------------------------------------------------------------------------------------------------------------
            Amp am0 = new Amp() { AmpId = 1, Brand = "Orange", Modell = "CR120C", Power = 120, Type = "Transistor", Price = 244000 };
            Amp am1 = new Amp() { AmpId = 2, Brand = "Fender", Modell = "Tone Master Deluxe Reverb", Power = 100, Type = "Tube", Price = 315000 };
            Amp am2 = new Amp() { AmpId = 3, Brand = "Boss", Modell = "Katana", Power = 100, Type = "Transistor", Price = 160000 };
            Amp am3 = new Amp() { AmpId = 4, Brand = "Fender", Modell = "Acoustic Junior", Power = 100, Type = "Transistor", Price = 132000 };
            Amp am4 = new Amp() { AmpId = 5, Brand = "Orange", Modell = "Crush Acoustic", Power = 30, Type = "Transistor", Price = 120000 };

            //--------------------------------------------------------------------------------------------------------------------------------------------
            GuitarAccessory gac0 = new GuitarAccessory();
            GuitarAccessory gac1 = new GuitarAccessory();
            GuitarAccessory gac2 = new GuitarAccessory();
            GuitarAccessory gac3 = new GuitarAccessory();
            GuitarAccessory gac4 = new GuitarAccessory();
            GuitarAccessory gac5 = new GuitarAccessory();
            GuitarAccessory gac6 = new GuitarAccessory();
            GuitarAccessory gac7 = new GuitarAccessory();

            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Accessory ac0 = new Accessory() { AccessoryId = 1, Determination = "Guitar Strings", Brand = "Ernie Ball", Modell = "EXL 110", Quantity = 1, Price = 3000, DiscountPrice = 2000 };
            Accessory ac1 = new Accessory() { AccessoryId = 2, Determination = "Guitar Strings", Brand = "D'Addario", Modell = "EZ-900", Quantity = 1, Price = 2090, DiscountPrice = 1590 };
            Accessory ac2 = new Accessory() { AccessoryId = 3, Determination = "Guitar Strings", Brand = "Rotosound", Modell = "NXA10", Quantity = 1, Price = 8000, DiscountPrice = 7200 };
            Accessory ac3 = new Accessory() { AccessoryId = 4, Determination = "Picks", Brand = "Fender", Modell = "351", Quantity = 1, Price = 290, DiscountPrice = 200 };
            Accessory ac4 = new Accessory() { AccessoryId = 5, Determination = "Picks", Brand = "Dunlop", Modell = "44R", Quantity = 1, Price = 300, DiscountPrice = 230 };
            Accessory ac5 = new Accessory() { AccessoryId = 6, Determination = "Instrument Cables", Brand = "Fender", Modell = "Professional Series Black 5,5", Quantity = 1, Price = 5890, DiscountPrice = 5290 };
            Accessory ac6 = new Accessory() { AccessoryId = 7, Determination = "Instrument Cables", Brand = "Fender", Modell = "Professional Series White 3", Quantity = 1, Price = 4890, DiscountPrice = 3290 };
            Accessory ac7 = new Accessory() { AccessoryId = 8, Determination = "Instrument Cables", Brand = "Fender", Modell = "Deluxe Series", Quantity = 1, Price = 6590, DiscountPrice = 6090 };
            Accessory ac8 = new Accessory() { AccessoryId = 9, Determination = "Guitar Bags and Cases", Brand = "Fender", Modell = "Classic Series Tele", Quantity = 1, Price = 42900, DiscountPrice = 40000 };
            Accessory ac9 = new Accessory() { AccessoryId = 10, Determination = "Guitar Bags and Cases", Brand = "Fender", Modell = "FA405", Quantity = 1, Price = 8590, DiscountPrice = 7090 };
            Accessory ac10 = new Accessory() { AccessoryId = 11, Determination = "Guitar Bags and Cases", Brand = "Pasadena", Modell = "402EG", Quantity = 1, Price = 41900, DiscountPrice = 40900 };
            Accessory ac11 = new Accessory() { AccessoryId = 12, Determination = "Guitar Bags and Cases", Brand = "Ibanez", Modell = "IGB541-NB", Quantity = 1, Price = 12900, DiscountPrice = 10900 };

            //----------------------------------------------------------------------------------------------------------------------------------------------

            // GuitarAmp table
            ga0.GuitarId = g0.GuitarId;
            ga0.AmpId = am0.AmpId;

            ga1.GuitarId = g1.GuitarId;
            ga1.AmpId = am0.AmpId;

            ga2.GuitarId = g1.GuitarId;
            ga2.AmpId = am1.AmpId;

            ga3.GuitarId = g4.GuitarId;
            ga3.AmpId = am2.AmpId;

            ga4.GuitarId = g7.GuitarId;
            ga4.AmpId = am3.AmpId;

            ga5.GuitarId = g6.GuitarId;
            ga5.AmpId = am4.AmpId;

            ga6.GuitarId = g8.GuitarId;
            ga6.AmpId = am4.AmpId;

            // GuitarAccessory
            gac0.GuitarId = g0.GuitarId;
            gac0.AccessoryId = ac0.AccessoryId;

            gac1.GuitarId = g4.GuitarId;
            gac1.AccessoryId = ac0.AccessoryId;

            gac2.GuitarId = g2.GuitarId;
            gac2.AccessoryId = ac4.AccessoryId;

            gac3.GuitarId = g3.GuitarId;
            gac3.AccessoryId = ac3.AccessoryId;

            gac4.GuitarId = g3.GuitarId;
            gac4.AccessoryId = ac8.AccessoryId;

            gac5.GuitarId = g4.GuitarId;
            gac5.AccessoryId = ac6.AccessoryId;

            gac6.GuitarId = g6.GuitarId;
            gac6.AccessoryId = ac10.AccessoryId;

            gac7.GuitarId = g8.GuitarId;
            gac7.AccessoryId = ac11.AccessoryId;

            //-------------------------------------------------------------------------------------
            // modelbuilder?
            modelBuilder.Entity<GuitarAmp>()
                .HasKey(ga => new { ga.GuitarId, ga.AmpId });

            modelBuilder.Entity<GuitarAmp>()
                .HasOne(ga => ga.Guitar)
                .WithMany(g => g.GuitarAmps)
                .HasForeignKey(ga => ga.GuitarId);

            modelBuilder.Entity<GuitarAmp>()
                .HasOne(ga => ga.Amp)
                .WithMany(a => a.GuitarAmps)
                .HasForeignKey(ga => ga.AmpId);

            modelBuilder.Entity<GuitarAccessory>()
                .HasKey(gac => new { gac.GuitarId, gac.AccessoryId });

            modelBuilder.Entity<GuitarAccessory>()
                .HasOne(gac => gac.Guitar)
                .WithMany(g => g.GuitarAccessories)
                .HasForeignKey(gac => gac.GuitarId);

            modelBuilder.Entity<GuitarAccessory>()
                .HasOne(gac => gac.Accessory)
                .WithMany(a => a.GuitarAccessories)
                .HasForeignKey(gac => gac.AccessoryId);

            modelBuilder.Entity<Guitar>().HasData(g0, g1, g2, g3, g4, g5, g6, g7, g8);
            modelBuilder.Entity<GuitarAmp>().HasData(ga0, ga1, ga2, ga3, ga4, ga5, ga6);
            modelBuilder.Entity<Amp>().HasData(am0, am1, am2, am3, am4);
            modelBuilder.Entity<GuitarAccessory>().HasData(gac0, gac1, gac2, gac3, gac4, gac5, gac6, gac7);
            modelBuilder.Entity<Accessory>().HasData(ac0, ac1, ac2, ac3, ac4, ac5, ac6, ac7, ac8, ac9, ac10, ac11);
        }
    }
}
