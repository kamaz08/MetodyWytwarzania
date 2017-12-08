namespace Sledzto.Migrations
{
    using Sledzto.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Sledzto.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Sledzto.AppDbContext context)
        {
            AppDbContext db = new AppDbContext();
            var x = new string[] { "http://ki.pwr.edu.pl/gebala/dyd/jftt2017.html", "http://cs.pwr.edu.pl/syga/courses/db/db_rules.html", "http://onet.pl/", "http://repostuj.pl/", "http://forbes.pl/" };
            var y = new string[] { "Formalne", "Bazy danych", "onet", "repostuj", "forbes" };

            List<Website> list = new List<Website>();

            for(int i =0; i< 5; i++)
            {
                list.Add(new Website
                {
                    Name = y[i],
                    Url = x[i]
                });
            }

            db.Website.AddRange(list);

            db.SaveChanges();

            var list1 = new List<Option>();

            for(int i = 0; i < 5; i++)
            {
                list1.Add(new Option
                {
                    Frequency = 5,
                    OneTime = true,
                    TrackigTechnique = TrackigTechniqueEnum.Regex,
                    Options = "Lista 4",
                    WebsiteId = list[i].Id
                });

                list1.Add(new Option
                {
                    Frequency = 5,
                    TrackigTechnique = TrackigTechniqueEnum.Hash,
                    WebsiteId = list[i].Id
                });
            }

            db.Option.AddRange(list1);

            db.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
