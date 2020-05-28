namespace HID_PDF.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using HID_PDF.Domain;
  
  
    public class SongLibrary : DbContext
    {
        // Your context has been configured to use a 'SongLibrary' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'HID_PDF.SongLibrary' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SongLibrary' 
        // connection string in the application configuration file.
        public SongLibrary()
            : base("name=SongLibrary")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<Library> Libraries { get; set; }
        public virtual DbSet<Setlist> Setlists { get; set; }
        public virtual DbSet<SetlistEntry> SetlistEntries { get; set; }
        public virtual DbSet<Band> Bands { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().HasKey(i => i.Id);
            modelBuilder.Entity<Library>().HasKey(l => l.Id).HasMany(L => L.Songs);
            modelBuilder.Entity<Setlist>().HasKey(p => p.Id).HasMany(p => p.SetlistEntries);
        }
    }
}