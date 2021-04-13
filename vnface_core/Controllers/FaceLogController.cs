using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using vnface_core.Models;

namespace vnface_core.Controllers
{
    public class FaceLogController : Controller
    {
        private readonly vnfaceContext _context = new vnfaceContext();

        // GET: FaceLog
        public async Task<IActionResult> Index()
        {
            return View(await _context.FaceLogTb.ToListAsync());
        }

        // GET: FaceLog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faceLogTb = await _context.FaceLogTb
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faceLogTb == null)
            {
                return NotFound();
            }

            return View(faceLogTb);
        }
        private bool FaceLogTbExists(int id)
        {
            return _context.FaceLogTb.Any(e => e.Id == id);
        }
    }
}
