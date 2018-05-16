
using CableWebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CableWebApi.Controllers
{
    public class RegistrationController : ApiController
    {
        //SkyCableWebEntities _objCab = new SkyCableWebEntities();

        //[HttpGet]
        //public async Task<CableResult> Customeriddata()
        //{
        //    try
        //    {
        //        var result = _objCab.tblRegs.AsEnumerable().LastOrDefault();
        //        if (result != null)
        //        {
        //            return new CableResult { Message = "Success", Status = 1, Response = result };
        //        }
        //        else
        //        {
        //            return new CableResult { Message = "No data found", Status = 2, Response = null };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new CableResult { Message = ex.ToString(), Status = 0, Response = null };
        //    }
        //}

        //[HttpPost]
        //public async Task<CableResult> SetupboxCnt(SetupDetailModel model)
        //{
        //    try
        //    {
        //        var result = _objCab.tblSetupDetails.Where(a => a.Setboxno == model.Setboxno && a.CompanyId == model.CompanyId).FirstOrDefault();
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

        //[HttpPost]
        //public async Task<CableResult> SetupboxInsert(SetupDetailModel model)
        //{
        //    try
        //    {
        //        tblSetupDetail _setupboxmodel = new tblSetupDetail();
        //        _setupboxmodel.CustomerID = model.CustomerID;
        //        _setupboxmodel.Setboxno = model.Setboxno;
        //        _setupboxmodel.SDate = model.SDate;
        //        _setupboxmodel.FormNo = model.FormNo;
        //        _setupboxmodel.Packeges = model.Packeges;
        //        _setupboxmodel.Rate = model.Rate;
        //        _setupboxmodel.Disc = model.Disc;
        //        _setupboxmodel.Amt = model.Amt;
        //        _setupboxmodel.CardNo = model.CardNo;
        //        _setupboxmodel.FaultyNo = model.FaultyNo;
        //        _setupboxmodel.StatType = model.StatType;
        //        _setupboxmodel.CompanyId = model.CompanyId;

        //        _objCab.tblSetupDetails.Add(_setupboxmodel);
        //        _objCab.SaveChanges();
        //        if (_setupboxmodel != null)
        //        {
        //            return new CableResult { Message = "Success", Status = 1, Response = _setupboxmodel };
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

        //[HttpPost]
        //public async Task<CableResult> FormNameCnt(FormNameModel model)
        //{
        //    try
        //    {
        //        var result = _objCab.tblFormNames.Where(a => a.FieldName == model.FieldName).FirstOrDefault();
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

        //[HttpGet]
        //public async Task<CableResult> AdminPin()
        //{
        //    try
        //    {
        //        var result = _objCab.tblAdminPins.ToList();
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

        //[HttpPost]
        //public async Task<CableResult> AreaCnt(AreaModel model)
        //{
        //    try
        //    {
        //        var result = _objCab.tblAreas.Where(a => a.Area == model.Area && a.CompanyId == model.CompanyId).FirstOrDefault();
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

        //[HttpPost]
        //public async Task<CableResult> AreaInsert(AreaModel model)
        //{
        //    try
        //    {
        //        tblArea _objarea = new tblArea();
        //        _objarea.Area = model.Area;
        //        _objarea.CompanyId = model.CompanyId;

        //        _objCab.tblAreas.Add(_objarea);
        //        _objCab.SaveChanges();

        //        if (_objarea != null)
        //        {
        //            return new CableResult { Message = "Success", Status = 1, Response = _objarea };
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

        //[HttpPost]
        //public async Task<CableResult> AreaData(AreaModel model)
        //{
        //    try
        //    {
        //        var result = _objCab.tblAreas.Where(a => a.CompanyId == model.CompanyId);
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

        //[HttpPost]
        //public async Task<CableResult> PackageData(packageModel model)
        //{
        //    try
        //    {
        //        var result = _objCab.tblpackages.Where(a => a.CompanyId == model.CompanyId);
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

        //[HttpPost]
        //public async Task<CableResult> PackageInsert(packageModel model)
        //{
        //    try
        //    {
        //        using (var context = new SkyCableEntities())
        //        {
        //            var result = context.pack.SqlQuery("SP_Package @PackageName,@IUD", new SqlParameter("Package", model.Package), new SqlParameter("IUD", "S")).ToList();
        //        }
                   
        //         tblpackage _objpackage = new tblpackage();
        //        _objpackage.Package = model.Package;
        //        _objpackage.Rate = model.Rate;
        //        _objpackage.CompanyId = model.CompanyId;

        //        _objCab.tblpackages.Add(_objpackage);
        //        _objCab.SaveChanges();

        //        if (_objpackage != null)
        //        {
        //            return new CableResult { Message = "Success", Status = 1, Response = _objpackage };
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

        //[HttpPost]
        //public async Task<CableResult> PackageUpdate(packageModel model)
        //{
        //    try
        //    {
        //        var _objupdatepackage = _objCab.tblpackages.Where(a => a.Package == model.Package && a.CompanyId == model.CompanyId).FirstOrDefault();
        //        _objupdatepackage.Package = model.Package;
        //        _objupdatepackage.Rate = model.Rate;

        //        _objCab.Entry(_objupdatepackage).State = System.Data.Entity.EntityState.Modified;
        //        _objCab.SaveChanges();

        //        if (_objupdatepackage != null)
        //        {
        //            return new CableResult { Message = "Success", Status = 1, Response = _objupdatepackage };
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

        //[HttpPost]
        //public async Task<CableResult> PackageDelete(packageModel model)
        //{
        //    try
        //    {

        //        var _objDel = _objCab.tblpackages.Where(a => a.Package == model.Package && a.CompanyId == model.CompanyId).FirstOrDefault();
        //        _objCab.tblpackages.Remove(_objDel);
        //        _objCab.SaveChanges();

        //        if (_objDel != null)
        //        {
        //            return new CableResult { Message = "Success", Status = 1, Response = _objDel };
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

        //[HttpPost]
        //public async Task<CableResult> RegData(RegModel model)
        //{
        //    try
        //    {
        //        var result = _objCab.tblRegs.Where(a => a.CompanyId == model.CompanyId);
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

        //[HttpPost]
        //public async Task<CableResult> PackageRegUpdate(RegModel model)
        //{
        //    try
        //    {
        //        var _objupdateRegpackage = _objCab.tblRegs.Where(a => a.CustomerID == model.CustomerID && a.CompanyId == model.CompanyId).FirstOrDefault();
        //        _objupdateRegpackage.TotRate = model.TotRate;
        //        _objupdateRegpackage.CGSTPer = model.CGSTPer;
        //        _objupdateRegpackage.CSGTAmt = model.CSGTAmt;
        //        _objupdateRegpackage.SGSTPer = model.SGSTPer;
        //        _objupdateRegpackage.SGSTAmt = model.SGSTAmt;
        //        _objupdateRegpackage.TotAmt = model.TotAmt;

        //        _objCab.Entry(_objupdateRegpackage).State = System.Data.Entity.EntityState.Modified;
        //        _objCab.SaveChanges();

        //        if (_objupdateRegpackage != null)
        //        {
        //            return new CableResult { Message = "Success", Status = 1, Response = _objupdateRegpackage };
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
