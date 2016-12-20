using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TASKTI.Models;
using TASKTI.DAL;

namespace TASKTI.Controllers
{
    public class TamuController : Controller
    {
        // GET: Tamu
        public ActionResult Index()
        {
            using (TamuDAL tamu = new TamuDAL())
            {
                string username =
                Session["username"] != null ? Session["username"].ToString() : string.Empty;
                return View(tamu.GetData().ToList());
            }
        }

        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                using (TamuDAL service = new TamuDAL())
                {
                    string username = Session["username"] != null ? Session["username"].ToString() : string.Empty;
                    return View(service.GetByUser(username));
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tamu tamu)
        {
            //cek apakah user sudah login
            if (Session["username"] == null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    Session["username"] = User.Identity.Name;
                }
                else
                {
                    var tempUser = Guid.NewGuid().ToString();
                    Session["username"] = tempUser;
                }
            }
            using (TamuDAL tmbh = new TamuDAL())
            {
                try
                {
                    tmbh.TambahTamu(tamu);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            using (TamuDAL services = new TamuDAL())
            {
                var result = services.GetItemByID(id);
                return View(result);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tamu tamu)
        {
            using (TamuDAL services = new TamuDAL())
            {

                services.Edit(tamu);

            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (TamuDAL service = new TamuDAL())
            {

                service.Delete(id);

            }
            return RedirectToAction("Index");
        }
    }
}