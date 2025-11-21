using Microsoft.EntityFrameworkCore;
using Project.Models;
using System.Collections.Generic;

namespace PhotoGallery.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<ImageModel> Images { get; set; }
    }
}
