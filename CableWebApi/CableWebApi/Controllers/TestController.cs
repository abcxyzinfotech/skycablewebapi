using CableWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CableWebApi.Controllers
{
    public class TestController : ApiController
    {

        //private SkyCableEntities db = new SkyCableEntities();
        
        //[HttpPost]
        //public async Task<CableResult> Logindata(packageModel model)
        //{
           
        //    try
        //    {
        //        using (var context = new SkyCableEntities())
        //        {
        //            string PKG = "HD";
        //            string IUD = "S";
        //            // var result = context.packageModels.SqlQuery("[SP_Packageok] @PackageName", new SqlParameter("Package", PKG)).ToList();
        //            var result = context.Database.SqlQuery<packageModel>("exec SP_Packageok @packg,@IUD", new SqlParameter("packg", PKG), new SqlParameter("IUD", IUD)).ToList();
        //            if (result != null)
        //            {
        //                return new CableResult { Message = "Success", Status = 1, Response = result };
        //            }
        //            else
        //            {
        //                return new CableResult { Message = "No data found", Status = 0, Response = null };
        //            }
        //        }
        //        //    var result = context.tblLogins.Where(a => a.UserName == model.UserName && a.UserPassword == model.UserPassword && a.UserType == model.UserType && a.CompanyId == model.CompanyId).FirstOrDefault();
               
        //    }
        //    catch (Exception ex)
        //    {
        //        return new CableResult { Message = ex.ToString(), Status = 0, Response = null };
        //    }
        //}
    }
}
