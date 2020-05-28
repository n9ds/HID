namespace HID_PDF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using HID_PDF.Domain;
    using HID_PDF.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<SongLibrary>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HID_PDF.Data.SongLibrary context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Bands.Add(new Band()
            {
                Id = 1,
                Name = "BSD"
            });
            context.Bands.Add(new Band()
            {
                Id = 2,
                Name = "LLCC"
            });
            context.Bands.Add(new Band()
            {
                Id = 3,
                Name = "VMB"
            });
            context.Bands.Add(new Band()
            {
                Id = 4,
                Name = "N9DS and the Extras"
            });

            context.Songs.Add(new Song()
            {
                Id = 1,
                Title = "All I ever wanted",
                Instrument = "Bass",
                Key = "E",
                Major = true,
                Filepath= @"c:\music\All.pdf",
                FirstNote = "G#"
            }) ;

            context.Songs.Add(new Song()
            {
                Id = 2,
                Title = "All Of Me",
                Instrument = "Tenor Sax",
                Key = "C",
                Major = true,
                Filepath = @"c:\music\AllOfMe.pdf",
                FirstNote = "C"
            });

        }
    }
}
