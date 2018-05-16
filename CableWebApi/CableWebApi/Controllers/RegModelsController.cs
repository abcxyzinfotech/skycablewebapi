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
    public class RegModelsController : ApiController
    {
        private SkyCableWebEntities db = new SkyCableWebEntities();

        [HttpPost]
        public async Task<CableResult> Customeriddata(RegModel model)
        {
            try
            {
                var result = db.regmodel.Where(a=> a.CompanyId == model.CompanyId).AsEnumerable().LastOrDefault();
                if (result != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = result };
                }
                else
                {
                    return new CableResult { Message = "No data found", Status = 2, Response = null };
                }
            }
            catch (Exception ex)
            {
                return new CableResult { Message = ex.ToString(), Status = 0, Response = null };
            }
        }
                                    //SETUPBOX
        [HttpPost]
        public async Task<CableResult> SetupboxCnt(SetupDetailModel model)
        {
            try
            {
                var result = db.setupdetailsmodel.Where(a => a.Setboxno == model.Setboxno && a.CompanyId == model.CompanyId).ToList();
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
        public async Task<CableResult> SetupboxupdateCnt(SetupDetailModel model)
        {
            try
            {
                var result = db.setupdetailsmodel.Where(a => a.Setboxno == model.Setboxno && a.CustomerID != model.CustomerID && a.CompanyId == model.CompanyId).ToList();
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
        public async Task<CableResult> Setupbox(SetupDetailModel model)
        {
            try
            {
                var result = db.setupdetailsmodel.Where(a => a.CustomerID == model.CustomerID && a.CompanyId == model.CompanyId).ToList();
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
        public async Task<CableResult> SetupboxRegUpdate(RegModel model)
        {
            try
            {               
                var _regmodel = db.regmodel.Where(a => a.CustomerID == model.CustomerID && a.CompanyId == model.CompanyId).FirstOrDefault();
               
                _regmodel.AccNoBox = model.AccNoBox;
                _regmodel.PackageName = model.PackageName;
                db.Entry(_regmodel).State = EntityState.Modified;               
                db.SaveChanges();
                if (_regmodel != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = _regmodel };
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
        public async Task<CableResult> SetupboxUpdateDisconnect(SetupDetailModel model)
        {
            try
            {
                var _regmodel = db.setupdetailsmodel.Where(a => a.CustomerID == model.CustomerID && a.CompanyId == model.CompanyId).FirstOrDefault();
                _regmodel.StatType = model.StatType;                
                db.Entry(_regmodel).State = EntityState.Modified;
                db.SaveChanges();
                if (_regmodel != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = _regmodel };
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
        public async Task<CableResult> SetupboxDelete(SetupDetailModel model)
        {
            try
            {
                var _objDel = db.setupdetailsmodel.Where(a => a.CustomerID == model.CustomerID && a.CompanyId == model.CompanyId).FirstOrDefault();
                db.setupdetailsmodel.Remove(_objDel);
                db.SaveChanges();

                if (_objDel != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = _objDel };
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
        public async Task<CableResult> SetupboxRecconectUpdate(SetupDetailModel model)
        {
            try
            {
                var _setupmodel = db.setupdetailsmodel.Where(a => a.Setboxno == model.Setboxno && a.CustomerID == model.CustomerID && a.CompanyId == model.CompanyId).FirstOrDefault();
                _setupmodel.StatType = model.StatType;                
                db.Entry(_setupmodel).State = EntityState.Modified;
                db.SaveChanges();
                if (_setupmodel != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = _setupmodel };
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
        public async Task<CableResult> SetupboxInsert(SetupDetailModel model)
        {
            try
            {
                SetupDetailModel _setupboxmodel = new SetupDetailModel();
                _setupboxmodel.CustomerID = model.CustomerID;
                _setupboxmodel.Setboxno = model.Setboxno;
                _setupboxmodel.SDate = model.SDate;
                _setupboxmodel.FormNo = model.FormNo;
                _setupboxmodel.Packeges = model.Packeges;
                _setupboxmodel.Rate = model.Rate;
                _setupboxmodel.Disc = model.Disc;
                _setupboxmodel.Amt = model.Amt;
                _setupboxmodel.CardNo = model.CardNo;
                _setupboxmodel.FaultyNo = model.FaultyNo;
                _setupboxmodel.StatType = model.StatType;
                _setupboxmodel.CompanyId = model.CompanyId;

                db.setupdetailsmodel.Add(_setupboxmodel);
                db.SaveChanges();
                if (_setupboxmodel != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = _setupboxmodel };
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

        //[HttpPost]
        //public async Task<CableResult> SetupboxDelete(SetupDetailModel model)
        //{
        //    try
        //    {
        //        var _objDel = db.setupdetailsmodel.Where(a => a.CustomerID == model.CustomerID && a.CompanyId == model.CompanyId).FirstOrDefault();
        //        db.setupdetailsmodel.Remove(_objDel);
        //        db.SaveChanges();

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

        [HttpPost]
        public async Task<CableResult> FormNameCnt(FormNameModel model)
        {
            try
            {
                var result = db.formnamemodel.Where(a => a.FieldName == model.FieldName).FirstOrDefault();
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
        public async Task<CableResult> AdminPin()
        {
            try
            {
                var result = db.adminpinmodel.ToList();
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

                                        //AREA

        [HttpPost]
        public async Task<CableResult> AreaCnt(AreaModel model)
        {
            try
            {
                var result = db.areamodel.Where(a => a.Area == model.Area && a.CompanyId == model.CompanyId).FirstOrDefault();
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
        public async Task<CableResult> AreaInsert(AreaModel model)
        {
            try
            {
                AreaModel _objarea = new AreaModel();
                _objarea.Area = model.Area;
                _objarea.CompanyId = model.CompanyId;

                db.areamodel.Add(_objarea);
                db.SaveChanges();

                if (_objarea != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = _objarea };
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
        public async Task<CableResult> AreaData(AreaModel model)
        {
            try
            {
                var result = db.areamodel.Where(a => a.CompanyId == model.CompanyId);
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

                                //PACKAGE
        [HttpPost]
        public async Task<CableResult> PackageData(packageModel model)
        {
            try
            {
                var result = db.packagemodel.Where(a => a.CompanyId == model.CompanyId);
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
        public async Task<CableResult> PackageInsert(packageModel model)
        {
            try
            {
                packageModel _objpackage = new packageModel();
                _objpackage.Package = model.Package;
                _objpackage.Rate = model.Rate;
                _objpackage.CompanyId = model.CompanyId;

                db.packagemodel.Add(_objpackage);
                db.SaveChanges();

                if (_objpackage != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = _objpackage };
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
        public async Task<CableResult> PackageUpdate(packageModel model)
        {
            try
            {
                var _objupdatepackage = db.packagemodel.Where(a => a.Package == model.Package && a.CompanyId == model.CompanyId).FirstOrDefault();
                _objupdatepackage.Package = model.Package;
                _objupdatepackage.Rate = model.Rate;

                db.Entry(_objupdatepackage).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                if (_objupdatepackage != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = _objupdatepackage };
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
        public async Task<CableResult> PackageDelete(packageModel model)
        {
            try
            {

                var _objDel = db.packagemodel.Where(a => a.Package == model.Package && a.CompanyId == model.CompanyId).FirstOrDefault();
                db.packagemodel.Remove(_objDel);
                db.SaveChanges();

                if (_objDel != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = _objDel };
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
        public async Task<CableResult> RegData(RegModel model)
        {
            try
            {
                var result = db.regmodel.Where(a => a.CompanyId == model.CompanyId);
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
        public async Task<CableResult> PackageRegData(RegModel model)
        {
            try
            {
                var result = db.regmodel.Where(a => a.CompanyId == model.CompanyId);
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
        public async Task<CableResult> PackageRegUpdate(RegModel model)
        {
            try
            {
                var _objupdateRegpackage = db.regmodel.Where(a => a.CustomerID == model.CustomerID && a.CompanyId == model.CompanyId).FirstOrDefault();
                _objupdateRegpackage.TotRate = model.TotRate;
                _objupdateRegpackage.CGSTPer = model.CGSTPer;
                _objupdateRegpackage.CSGTAmt = model.CSGTAmt;
                _objupdateRegpackage.SGSTPer = model.SGSTPer;
                _objupdateRegpackage.SGSTAmt = model.SGSTAmt;
                _objupdateRegpackage.TotAmt = model.TotAmt;

                db.Entry(_objupdateRegpackage).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                if (_objupdateRegpackage != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = _objupdateRegpackage };
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
        public async Task<CableResult> PackageRegGstoutUpdate(RegModel model)
        {
            try
            {
                var _objupdateRegpackage = db.regmodel.Where(a => a.CustomerID == model.CustomerID && a.CompanyId == model.CompanyId).FirstOrDefault();
               
                _objupdateRegpackage.CGSTPer = model.CGSTPer;
                _objupdateRegpackage.CSGTAmt = model.CSGTAmt;
                _objupdateRegpackage.SGSTPer = model.SGSTPer;
                _objupdateRegpackage.SGSTAmt = model.SGSTAmt;
                _objupdateRegpackage.TotAmt = model.TotAmt;

                db.Entry(_objupdateRegpackage).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                if (_objupdateRegpackage != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = _objupdateRegpackage };
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
        public async Task<CableResult> PackageRegSort(RegModel model)
        {
            try
            {
                var Consumerresult = db.regmodel.Where(c => c.ConsumerName.StartsWith(model.ConsumerName)).ToList();
                var Setupboxresult = db.regmodel.Where(c => c.SetupNoReg.StartsWith(model.SetupNoReg)).ToList();
                var Arearesult = db.regmodel.Where(c => c.Area.StartsWith(model.Area)).ToList(); 

                if (Consumerresult.Count != 0)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = Consumerresult };
                }
                else if (Setupboxresult.Count != 0)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = Setupboxresult };
                }
                else if (Arearesult.Count != 0)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = Setupboxresult };
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
        public async Task<CableResult> PackageCMBData(packageModel model)
        {
            try
            {
                var result = db.packagemodel.Where(a => a.CompanyId == model.CompanyId);
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
        public async Task<CableResult> AgentCnt(AgentModel model)
        {
            try
            {
                var result = db.agentmodel.Where(a => a.AgentName == model.AgentName && a.CompanyId == model.CompanyId).FirstOrDefault();
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
        public async Task<CableResult> AgentAutoID()
        {
            try
            {
                var result = db.agentmodel.AsEnumerable().LastOrDefault();
                if (result != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = result };
                }
                else
                {
                    return new CableResult { Message = "No data found", Status = 2, Response = null };
                }
            }
            catch (Exception ex)
            {
                return new CableResult { Message = ex.ToString(), Status = 0, Response = null };
            }
        }

        [HttpPost]
        public async Task<CableResult> AgentInsert(AgentModel model)
        {
            try
            {
                AgentModel agentmodel = new AgentModel();
                agentmodel.AgentId = model.AgentId;
                agentmodel.AgentName = model.AgentName;
                agentmodel.CompanyId = model.CompanyId;

                db.agentmodel.Add(agentmodel);
                db.SaveChanges();
                if (agentmodel != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = agentmodel };
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
        public async Task<CableResult> AgentDeleteData(RegModel model)
        {
            try
            {
                var result = db.regmodel.Where(a => a.AgentId == model.AgentId && a.CompanyId == model.CompanyId);
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
        public async Task<CableResult> AgentDelete(AgentModel model)
        {
            try
            {
                var _objDel = db.agentmodel.Where(a => a.AgentId == model.AgentId && a.CompanyId == model.CompanyId).ToList();
                foreach(var item in _objDel)
                {
                    db.agentmodel.Remove(item);
                    db.SaveChanges();
                }
                
                if (_objDel != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = _objDel };
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
        public async Task<CableResult> AgentData(AgentModel model)
        {
            try
            {
                var result = db.agentmodel.Where(a => a.CompanyId == model.CompanyId);
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
        public async Task<CableResult> CustData(RegModel model)
        {
            try
            {
                var result = db.regmodel.Where(a => a.CompanyId == model.CompanyId);
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

                                    //REG

        [HttpPost]
        public async Task<CableResult> RegInsert(RegModel model)
        {
            try
            {
                RegModel regmodel = new RegModel();
                regmodel.CustomerID = model.CustomerID;
                regmodel.NoBox = model.NoBox;
                regmodel.SetupNoReg = model.SetupNoReg;
                regmodel.ConsumerName = model.ConsumerName;
                regmodel.Address = model.Address;
                regmodel.LandMark = model.LandMark;
                regmodel.Mbno1 = model.Mbno1;
                regmodel.Mbno2 = model.Mbno2;
                regmodel.Area = model.Area;
                regmodel.AgentId = model.AgentId;
                regmodel.AgentName = model.AgentName;
                regmodel.CGSTPer = model.CGSTPer;
                regmodel.CSGTAmt = model.CSGTAmt;
                regmodel.SGSTPer = model.SGSTPer;
                regmodel.SGSTAmt = model.SGSTAmt;
                regmodel.TotRate = model.TotRate;
                regmodel.Dics = model.Dics;
                regmodel.TotAmt = model.TotAmt;
                regmodel.CustBal = model.CustBal;
                regmodel.RegNo = model.RegNo;
                regmodel.Type = model.Type;
                regmodel.IDProof = model.IDProof;
                regmodel.DtFrom = model.DtFrom;
                regmodel.CNameMarathi = model.CNameMarathi;
                regmodel.Remark = model.Remark;
                regmodel.ImgP1 = model.ImgP1;
                regmodel.ImgP2 = model.ImgP2;
                regmodel.ImgP3 = model.ImgP3;
                regmodel.CompanyId = model.CompanyId;
               
                db.regmodel.Add(regmodel);
                db.SaveChanges();
                if (regmodel != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = regmodel };
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
        public async Task<CableResult> RegUpdate(RegModel model)
        {
            try
            {
                var _regmodel = db.regmodel.Where(a => a.CustomerID == model.CustomerID && a.CompanyId == model.CompanyId).FirstOrDefault();
                _regmodel.ConsumerName = model.ConsumerName;
                _regmodel.Address = model.Address;
                _regmodel.Area = model.Area;
                _regmodel.Mbno1 = model.Mbno1;
                _regmodel.Mbno2 = model.Mbno2;
                _regmodel.CSGTAmt = model.CSGTAmt;
                _regmodel.SGSTAmt = model.SGSTAmt;
                _regmodel.TotRate = model.TotRate;
                _regmodel.Dics = model.Dics;
                _regmodel.TotAmt = model.TotAmt;
                _regmodel.RegNo = model.RegNo;
                _regmodel.CustBal = model.CustBal;
                _regmodel.NoBox = model.NoBox;
                _regmodel.AgentId = model.AgentId;
                _regmodel.AgentName = model.AgentName;
                _regmodel.Remark = model.Remark;
                _regmodel.IDProof = model.IDProof;
                _regmodel.SetupNoReg = model.SetupNoReg;
                _regmodel.DtFrom = model.DtFrom;
                _regmodel.LandMark = model.LandMark;
                _regmodel.CNameMarathi = model.CNameMarathi;
                _regmodel.ChangeCol = model.ChangeCol;
                _regmodel.ImgP1 = model.ImgP1;
                _regmodel.ImgP2 = model.ImgP2;
                _regmodel.ImgP3 = model.ImgP3;

                db.Entry(_regmodel).State = EntityState.Modified;
                db.SaveChanges();
                if (_regmodel != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = _regmodel };
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
        public async Task<CableResult> RegDelete(RegModel model)
        {
            try
            {
                var _objDel = db.regmodel.Where(a => a.CustomerID == model.CustomerID && a.CompanyId == model.CompanyId).FirstOrDefault();
                db.regmodel.Remove(_objDel);
                db.SaveChanges();

                if (_objDel != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = _objDel };
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
        public async Task<CableResult> RegdataFill(RegModel model)
        {
            try
            {
                var result = db.regmodel.Where(a => a.CustomerID == model.CustomerID && a.CompanyId == model.CompanyId).ToList();
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
        public async Task<CableResult> RegUpdateReconn(RegModel model)
        {
            try
            {
                var _regmodel = db.regmodel.Where(a => a.CustomerID == model.CustomerID && a.CompanyId == model.CompanyId).FirstOrDefault();
                _regmodel.TotAmt = model.TotAmt;
                _regmodel.CSGTAmt = model.CSGTAmt;
                _regmodel.SGSTAmt = model.SGSTAmt;
                _regmodel.TotRate = model.TotRate;
                _regmodel.Type = model.Type;
                db.Entry(_regmodel).State = EntityState.Modified;
                db.SaveChanges();
                if (_regmodel != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = _regmodel };
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
        public async Task<CableResult> RegUpdateNonCol(RegModel model)
        {
            try
            {
                var _regmodel = db.regmodel.Where(a => a.CustomerID == model.CustomerID && a.CompanyId == model.CompanyId).FirstOrDefault();
                _regmodel.ChangeCol = model.ChangeCol;               
                db.Entry(_regmodel).State = EntityState.Modified;
                db.SaveChanges();
                if (_regmodel != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = _regmodel };
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
        public async Task<CableResult> RegFilter(RegModel model)
        {
            try
            {
                var Consumerresult = db.regmodel.Where(c => c.ConsumerName.StartsWith(model.ConsumerName)).ToList();
                var Setupboxresult = db.regmodel.Where(c => c.SetupNoReg.StartsWith(model.SetupNoReg)).ToList();
                var Arearesult = db.regmodel.Where(c => c.Area.StartsWith(model.Area)).ToList();
                var Agentresult = db.regmodel.Where(c => c.AgentName.StartsWith(model.AgentName)).ToList();
                var Mobileresult = db.regmodel.Where(c => c.Mbno1.StartsWith(model.Mbno1)).ToList();
                var Mobile2result = db.regmodel.Where(c => c.Mbno2.StartsWith(model.Mbno2)).ToList();
                var Regnoresult = db.regmodel.Where(c => c.RegNo.StartsWith(model.RegNo)).ToList();                

                if (Consumerresult.Count != 0)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = Consumerresult };
                }
                else if(Setupboxresult.Count != 0)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = Setupboxresult };
                }
                else if(Arearesult.Count != 0)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = Arearesult };
                }
                else if (Agentresult.Count != 0)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = Agentresult };
                }
                else if(Mobileresult.Count != 0)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = Mobileresult };
                }
                else if (Mobile2result.Count != 0)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = Mobile2result };
                }
                else if(Regnoresult.Count != 0)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = Regnoresult };
                }
                else
                {
                    var Regnoresultall = db.regmodel.ToList();
                    return new CableResult { Message = "No data found", Status = 0, Response = null };
                }

            }
            catch (Exception ex)
            {
                return new CableResult { Message = ex.ToString(), Status = 0, Response = null };
            }
        }

        [HttpPost]
        public async Task<CableResult> CompanyGstinout(CompanyMasterModel model)
        {
            try
            {
                var result = db.companymastermodel.Where(a => a.CompanyId == model.CompanyId).ToList();
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
        public async Task<CableResult> ReconnectInsert(ReconnectModel model)
        {
            try
            {
                ReconnectModel regmodel = new ReconnectModel();
                regmodel.CustId = model.CustId;
                regmodel.MacId = model.MacId;
                regmodel.DiscDate = model.DiscDate;
                regmodel.Amount = model.Amount;
                regmodel.CompanyId = model.CompanyId;
               
                db.reconnectmodel.Add(regmodel);
                db.SaveChanges();
                if (regmodel != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = regmodel };
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
        public async Task<CableResult> RegRecconectUpdate(ReconnectModel model)
        {
            try
            {
                var _reconnectmodel = db.reconnectmodel.Where(a => a.MacId == model.MacId && a.CustId == model.CustId && a.CompanyId == model.CompanyId).FirstOrDefault();
                _reconnectmodel.ReconDate = model.ReconDate;
                db.Entry(_reconnectmodel).State = EntityState.Modified;
                db.SaveChanges();
                if (_reconnectmodel != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = _reconnectmodel };
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
        public async Task<CableResult> ReconnectDelete(ReconnectModel model)
        {
            try
            {
                var _objDel = db.reconnectmodel.Where(a => a.CustId == model.CustId && a.CompanyId == model.CompanyId).FirstOrDefault();
                db.reconnectmodel.Remove(_objDel);
                db.SaveChanges();

                if (_objDel != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = _objDel };
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
        public async Task<CableResult> ReconnectData(ReconnectModel model)
        {
            try
            {
                var result = db.reconnectmodel.Where(a => a.CustId == model.CustId && a.CompanyId == model.CompanyId).ToList();
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

        //// GET: RegModels
        //public ActionResult Index()
        //{
        //    return View(db.regmodel.ToList());
        //}

        //// GET: RegModels/Details/5
        //public ActionResult Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    RegModel regModel = db.regmodel.Find(id);
        //    if (regModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(regModel);
        //}

        //// GET: RegModels/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: RegModels/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CID,CustomerID,NoBox,SetupNoReg,ConsumerName,Address,LandMark,Mbno1,Mbno2,Area,AgentId,AgentName,Phone,CGSTPer,CSGTAmt,SGSTPer,SGSTAmt,TotRate,Dics,TotAmt,CustBal,RegNo,Type,ImgP1,ImgP2,ImgP3,IDProof,DtFrom,CNameMarathi,UserName,CustPassword,ChangeCol,NotifyStat,Remark,CompanyId,AccNoBox,PackageName,CDate,CTime")] RegModel regModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.regmodel.Add(regModel);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(regModel);
        //}

        //// GET: RegModels/Edit/5
        //public ActionResult Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    RegModel regModel = db.regmodel.Find(id);
        //    if (regModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(regModel);
        //}

        //// POST: RegModels/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CID,CustomerID,NoBox,SetupNoReg,ConsumerName,Address,LandMark,Mbno1,Mbno2,Area,AgentId,AgentName,Phone,CGSTPer,CSGTAmt,SGSTPer,SGSTAmt,TotRate,Dics,TotAmt,CustBal,RegNo,Type,ImgP1,ImgP2,ImgP3,IDProof,DtFrom,CNameMarathi,UserName,CustPassword,ChangeCol,NotifyStat,Remark,CompanyId,AccNoBox,PackageName,CDate,CTime")] RegModel regModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(regModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(regModel);
        //}

        //// GET: RegModels/Delete/5
        //public ActionResult Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    RegModel regModel = db.regmodel.Find(id);
        //    if (regModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(regModel);
        //}

        //// POST: RegModels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(long id)
        //{
        //    RegModel regModel = db.regmodel.Find(id);
        //    db.regmodel.Remove(regModel);
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
