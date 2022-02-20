using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Context;
using WebApi.Models;

namespace WebApi.Helpers
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DatabaseContext(
                serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>()))
            {
                if (context.Albums.Any())
                {
                    return;
                }
                context.Albums.AddRange(
                    new Album
                    {
                        Id = 1,
                        Title = "Kompilacja",
                        ArtistName = "Koniec Lata",
                        Version = "epka",
                        ReleaseDate = DateTime.Now.AddDays(-1),
                        DistributorId = 1,
                    });
                if (context.Users.Any())
                {
                    return;
                }
                context.Users.AddRange(
                    new User
                    {
                        Id = 1,
                        Name = "Polskie Nagrania",
                        PasswordSalt = "ig4TSjG8trhGIGyJ8rsmwg==",//password haslo
                        PasswordHash = "kHjpE6CJPFEucQFoxV88/Zi7GNKV5yo2pwG4oUELeRk=",
                        Username = "franek"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
