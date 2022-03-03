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
                context.Database.EnsureCreated();

                if (context.Users.Any())
                {
                    return;   // DB has been already seeded
                }

                var users = new User[] {
                    new User
                    {
                        //UserID = 1,
                        Name = "Polskie Nagrania",
                        PasswordSalt = "ig4TSjG8trhGIGyJ8rsmwg==",//password haslo
                        PasswordHash = "kHjpE6CJPFEucQFoxV88/Zi7GNKV5yo2pwG4oUELeRk=",
                        Username = "franek"
                    },
                    new User
                    {
                        //UserID = 2,
                        Name = "Sony Music Polska",
                        PasswordSalt = "6FiluQytdrtjTDyfQxm4bw==",//password haselko //these values I've generated with generateHash post method
                        PasswordHash = "0M+VrKegVuKOZG+Ea1Y1fNyW/KqvISorqIVqtzpmHZg=",
                        Username = "sony"
                    }
                };
                foreach(User u in users)
                {
                    context.Users.Add(u);
                }
                context.SaveChanges();
                var albums = new Album[] {
                    new Album
                    {
                        //AlbumID = 1,
                        Title = "Lato Widzę",
                        ArtistName = "Koniec Lata",
                        Version = "singiel",
                        ReleaseYear = 2019,
                        UserID = 1,
                        PictureURL= "https://firebasestorage.googleapis.com/v0/b/music-portfolio-df66a.appspot.com/o/1607376173257?alt=media&token=5bc65302-f7b9-4559-a9c6-d47390879a0f"
                    },
                    new Album
                    {
                        //AlbumID = 2,
                        Title = "VA [ATV001]",
                        ArtistName = "Various Artist",
                        Version = "kompilacja",
                        ReleaseYear = 2022,
                        UserID = 1,
                        PictureURL = "https://firebasestorage.googleapis.com/v0/b/music-portfolio-df66a.appspot.com/o/atawizm.jpg?alt=media&token=301bc9c0-6d6d-400d-b92d-3b2c28a3c64b",
                    },
                    new Album
                    {
                        //AlbumID = 3,
                        Title = "VA [ATV002]",
                        ArtistName = "Various Artist",
                        Version = "kompilacja2",
                        ReleaseYear = 2022,
                        UserID = 2,
                        PictureURL = "https://firebasestorage.googleapis.com/v0/b/music-portfolio-df66a.appspot.com/o/atawizm.jpg?alt=media&token=301bc9c0-6d6d-400d-b92d-3b2c28a3c64b",
                    },
                    new Album
                    {
                        //AlbumID = 1,
                        Title = "Carte Blanche",
                        ArtistName = "Vapes",
                        Version = "Ep",
                        ReleaseYear = 2016,
                        UserID = 1,
                        PictureURL= "https://firebasestorage.googleapis.com/v0/b/music-portfolio-df66a.appspot.com/o/1607375590519?alt=media&token=8fab563e-f4de-404f-bca4-bf9d0b0e08db"                    
                    },
                };
                foreach(Album a in albums)
                {
                    context.Albums.Add(a);
                }
                context.SaveChanges();
                var tracks = new Track[]{
                    new Track
                    {
                        //ID = 1,
                        Title = "Intro",
                        ArtistName = "Koniec Lata",
                        ReleaseYear = 2019,
                        AlbumID = 2,
                        TrackNumber = 1,
                        Length= 190
                    },
                    new Track
                    {
                        //ID = 2,
                        Title = "Intro Instrumental",
                        ArtistName = "Koniec Lata",
                        ReleaseYear = 2019,
                        AlbumID = 2,
                        TrackNumber = 2,
                        Length= 191
                    },
                    new Track
                    {
                        //ID = 3,
                        Title = "ATV1",
                        ArtistName = "FKR",
                        ReleaseYear = 2021,
                        AlbumID = 1,
                        TrackNumber = 1,
                        Length= 380
                    },
                    new Track
                    {
                        //ID = 4,
                        Title = "ATV2",
                        ArtistName = "ABRTH",
                        ReleaseYear = 2022,
                        AlbumID = 1,
                        TrackNumber = 2,
                        Length= 385
                    },
                    new Track
                    {
                        //ID = 1,
                        Title = "Pociągi",
                        ArtistName = "Koniec Lata",
                        ReleaseYear = 2019,
                        AlbumID = 2,
                        TrackNumber = 3,
                        Length= 205
                    },
                    new Track
                    {
                        //ID = 1,
                        Title = "Akademia",
                        ArtistName = "Koniec Lata",
                        ReleaseYear = 2019,
                        AlbumID = 2,
                        TrackNumber = 4,
                        Length= 287
                    },
                    new Track
                    {
                        //ID = 1,
                        Title = "Carte Blanche",
                        ArtistName = "Vapes",
                        ReleaseYear = 2016,
                        AlbumID = 4,
                        TrackNumber = 1,
                        Length= 366
                    },
                    new Track
                    {
                        //ID = 1,
                        Title = "The Fence",
                        ArtistName = "Vapes",
                        ReleaseYear = 2015,
                        AlbumID = 4,
                        TrackNumber = 2,
                        Length= 400
                    },
                };
                foreach(Track t in tracks)
                {
                    context.Tracks.Add(t);
                }
                context.SaveChanges();
            }
        }
    }
}
