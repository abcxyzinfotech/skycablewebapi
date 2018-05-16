using CableWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
//using CableWebApi.Entity;

namespace CableWebApi.Controllers
{
    public class AccountController : ApiController
    {
       // SkyCableWebEntities _objCab = new SkyCableWebEntities();

        //[HttpGet]
        //public async Task<CableResult> Companydata()
        //{
        //    try
        //    {
               
        //        var result = _objCab.tblCompanyMasters.ToList();
        //        if (result != null)
        //        {
        //            return new CableResult { Message = "Success", Status = 1, Response = result };
        //        }
        //        else
        //        {
        //            return new CableResult { Message = "No data found", Status = 0, Response = null };
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return new CableResult { Message = ex.ToString(), Status = 0, Response = null };
        //    }
           
        //}

        //[HttpPost]
        //public async Task<CableResult> Logindata(LoginViewModel model)
        //{
        //    try
        //    {
        //        var result = _objCab.tblLogins.Where(a => a.UserName == model.UserName && a.UserPassword == model.UserPassword && a.UserType == model.UserType && a.CompanyId == model.CompanyId).FirstOrDefault();
        //        if (result != null)
        //        {
        //            return new CableResult { Message = "Success", Status = 1, Response = result };
        //        }
        //        else
        //        {
        //            return new CableResult { Message = "No data found", Status = 0, Response = null };
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return new CableResult { Message = ex.ToString(), Status = 0, Response = null };
        //    }
        //}

        //[HttpGet]
        //public async Task<CableResult> DataName()
        //{
        //    try
        //    {

        //        var result = _objCab.tblDatabaseNames.ToList();
        //        if (result != null)
        //        {
        //            return new CableResult { Message = "Success", Status = 1, Response = result };
        //        }
        //        else
        //        {
        //            return new CableResult { Message = "No data found", Status = 0, Response = null };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new CableResult { Message = ex.ToString(), Status = 0, Response = null };
        //    }

        //}

    }
}
