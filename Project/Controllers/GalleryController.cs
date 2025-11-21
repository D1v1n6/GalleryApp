using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using PhotoGallery.Models;

namespace Project.Controllers
{
        public class GalleryController : Controller
        {
            private readonly ApplicationDbContext _context;
            private readonly IWebHostEnvironment _environment;

            public GalleryController(ApplicationDbContext context, IWebHostEnvironment environment)
            {
                _context = context;
                _environment = environment;
            }

            // GET: Gallery
            public IActionResult Index()
            {
                var images = _context.Images.OrderByDescending(i => i.UploadDate).ToList();
                return View(images);
            }

            // GET: Gallery/Upload
            public IActionResult Upload()
            {
                return View();
            }

            // POST: Gallery/Upload
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Upload(ImageModel model, IFormFile imageFile)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    string uploadDir = Path.Combine(_environment.WebRootPath, "uploads");
                    if (!Directory.Exists(uploadDir))
                        Directory.CreateDirectory(uploadDir);

                    string fileName = $"{Path.GetFileNameWithoutExtension(imageFile.FileName)}_{DateTime.Now.Ticks}{Path.GetExtension(imageFile.FileName)}";
                    string filePath = Path.Combine(uploadDir, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }

                    model.ImagePath = "/uploads/" + fileName;

                    _context.Add(model);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", "Please select an image file.");
                return View(model);
            }
        }
    }

