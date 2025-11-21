using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class ImageModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public DateTime UploadDate { get; set; } = DateTime.Now;
    }
}

