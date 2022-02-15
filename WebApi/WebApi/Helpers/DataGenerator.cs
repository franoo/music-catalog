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
                context.SaveChanges();
            }
        }
    }
}
