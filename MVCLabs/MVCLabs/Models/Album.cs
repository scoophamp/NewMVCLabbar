using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCLabs.Models
{
    public class Album
    {
        public Guid AlbumID { get; set; }
        [Required(ErrorMessage = "You have to enter a name")]
        public string AlbumName { get; set; }
        public List<Comments> AlbumComment { get; set; }
        public List<Photo> Photos { get; set; }
    }
}