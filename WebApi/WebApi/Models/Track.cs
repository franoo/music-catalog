using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Track
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int TrackNumber { get; set; }
        public int Length { get; set; }//seconds
        [Required]
        public string ArtistName { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        [Required]
        public int AlbumID { get; set; }
        [JsonIgnore]
        public Album Album { get; set; }
    }
}
