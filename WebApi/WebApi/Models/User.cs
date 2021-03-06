using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        [JsonIgnore]
        public string PasswordSalt { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
