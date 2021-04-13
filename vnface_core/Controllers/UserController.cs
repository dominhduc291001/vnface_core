using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using vnface_core.Models;

namespace vnface_core.Controllers
{
    public class UserController : Controller
    {
        private vnfaceContext db = new vnfaceContext();
        // GET: user
        public ActionResult Index()
        {
            return View(db.UserTb.ToList());
        }

        // GET: user/Details/5
        public ActionResult Details(int? id)
        {
            UserTb UserTb = db.UserTb.Find(id);
            if (UserTb == null)
            {
                return HttpNotFound();
            }
            return View(UserTb);
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}
