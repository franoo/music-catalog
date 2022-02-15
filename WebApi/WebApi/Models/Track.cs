using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Track
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ArtistName { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public int AlbumId { get; set; }
    }
}
