﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAjax.Models
{
    public class Album
    {
        public Guid AlbumID { get; set; }
        [Required(ErrorMessage = "Must enter a name for the Album")]
        public string AlbumName { get; set; }
        public List<Comments> AlbumComment { get; set; }
        public List<Photo> Photos { get; set; }
    }
}