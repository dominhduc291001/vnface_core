using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using vnface_core.Models;

namespace vnface_core.Controllers
{
    public class FaceController : Controller
    {
        private readonly vnfaceContext _context = new vnfaceContext();
        private readonly IWebHostEnvironment _hostEnvironment;

        public FaceController(IWebHostEnvironment hostEnvironment)
        {
                 this._hostEnvironment = hostEnvironment;
        }
        // GET: Face
        public async Task<IActionResult> Index()
        {
            return View(await _context.FaceTb.ToListAsync());
        }

        // GET: Face/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faceTb = await _context.FaceTb
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faceTb == null)
            {
                return NotFound();
            }

            return View(faceTb);
        }

        // GET: Face/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Face/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Gender,Age,Feature")] FaceTb faceTb, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = file.FileName;
                string path = Path.Combine(wwwRootPath + "/static/upload/person/", fileName);
                var fileStream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(fileStream);
                string filesave = "/static/upload/person/" + fileName;
                faceTb.FaceImage = filesave;
                _context.Add(faceTb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faceTb);
        }

        private bool FaceTbExists(int id)
        {
            return _context.FaceTb.Any(e => e.Id == id);
        }
    }
}
