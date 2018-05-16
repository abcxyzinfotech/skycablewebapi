using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using CableWebApi.Models;
using System.Threading.Tasks;

namespace CableWebApi.Controllers
{
    public class LoginViewModelsController : ApiController
    {
        private SkyCableWebEntities db = new SkyCableWebEntities();

        [HttpGet]
        public async Task<CableResult> Companydata()
        {
            try
            {
                var result = db.companymastermodel.ToList();
                if (result != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = result };
                }
                else
                {
                    return new CableResult { Message = "No data found", Status = 0, Response = null };
                }
            }
            catch (Exception ex)
            {
                return new CableResult { Message = ex.ToString(), Status = 0, Response = null };
            }

        }

        [HttpPost]
        public async Task<CableResult> Logindata(LoginViewModel model)
        {
            try
            {
                var result = db.loginviewmodel.Where(a => a.UserName == model.UserName && a.UserPassword == model.UserPassword && a.UserType == model.UserType && a.CompanyId == model.CompanyId).FirstOrDefault();
                if (result != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = result };
                }
                else
                {
                    return new CableResult { Message = "No data found", Status = 0, Response = null };
                }
            }
            catch (Exception ex)
            {
                return new CableResult { Message = ex.ToString(), Status = 0, Response = null };
            }
        }

        [HttpGet]
        public async Task<CableResult> DataName()
        {
            try
            {

                var result = db.databasenamemodel.ToList();
                if (result != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = result };
                }
                else
                {
                    return new CableResult { Message = "No data found", Status = 0, Response = null };
                }
            }
            catch (Exception ex)
            {
                return new CableResult { Message = ex.ToString(), Status = 0, Response = null };
            }

        }

        // GET: LoginViewModels
        //public ActionResult Index()
        //{
        //    return View(db.loginviewmodel.ToList());
        //}

        //// GET: LoginViewModels/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    LoginViewModel loginViewModel = db.loginviewmodel.Find(id);
        //    if (loginViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(loginViewModel);
        //}

        //// GET: LoginViewModels/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: LoginViewModels/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "UserID,UserName,UserPassword,UserType,CompanyId")] LoginViewModel loginViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.loginviewmodel.Add(loginViewModel);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(loginViewModel);
        //}

        //// GET: LoginViewModels/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    LoginViewModel loginViewModel = db.loginviewmodel.Find(id);
        //    if (loginViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(loginViewModel);
        //}

        //// POST: LoginViewModels/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "UserID,UserName,UserPassword,UserType,CompanyId")] LoginViewModel loginViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(loginViewModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(loginViewModel);
        //}

        //// GET: LoginViewModels/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    LoginViewModel loginViewModel = db.loginviewmodel.Find(id);
        //    if (loginViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(loginViewModel);
        //}

        //// POST: LoginViewModels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    LoginViewModel loginViewModel = db.loginviewmodel.Find(id);
        //    db.loginviewmodel.Remove(loginViewModel);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
