using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Album
    {
        [Key]
        public int AlbumID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ArtistName { get; set; }
        public string Version { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        [Required]
        public int UserID { get; set; }
        public string PictureURL { get; set; }

        public ICollection<Track> Tracks { get; set; }
        [JsonIgnore]
        public User User { get; set; }

    }
}
