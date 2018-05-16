using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using CableWebApi.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace CableWebApi.Controllers
{
    public class BillDetailsModelsController : ApiController
    {
        private SkyCableWebEntities db = new SkyCableWebEntities();

        [HttpPost]
        public async Task<CableResult> BillAreaData(RegModel model)
        {
            try
            {
                //var result = db.regmodel.Where(a => a.CompanyId == model.CompanyId).Select(m => m.Area).Distinct().ToList();
                var result = db.regmodel.Where(a => a.CompanyId == model.CompanyId).ToList();
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
        public async Task<CableResult> BillTransferData(RegModel model)
        {
            try
            {
                var result = (from vs in db.regmodel where vs.CompanyId == model.CompanyId && !(from s in db.billdetailsmodel select s.CustomerID).Contains(vs.CustomerID) select vs);
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
        public async Task<CableResult> BillReconnectDelete(BillDetailsModel model)
        {
            try
            {
                var _objDel = db.billdetailsmodel.Where(a => a.CustomerID == model.CustomerID && a.CMonth == model.CMonth && a.CYear == model.CYear && a.CompanyId == model.CompanyId).FirstOrDefault();
                db.billdetailsmodel.Remove(_objDel);
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
        public async Task<CableResult> BillRegData(RegModel model)
        {
            try
            {               
                var result = db.regmodel.Where(a => model.Area.Contains(a.Area) && a.CompanyId == model.CompanyId).ToList();
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
        public async Task<CableResult> BillRegTransferData(RegModel model)
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
        public async Task<CableResult> AutoBillNo(BillDetailsModel model)
        {
            try
            {
                var result = db.billdetailsmodel.Where(a => a.CompanyId == model.CompanyId).AsEnumerable().LastOrDefault();
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
        public async Task<CableResult> TakeTop12(BillDetailsModel model)
        {
            try
            {
                var result = db.billdetailsmodel.OrderByDescending(a => a.CustomerID == model.CustomerID && a.CompanyId == model.CompanyId).Take(4);
                //var result = result1.ToList();
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

        [HttpGet]
        public async Task<CableResult> TakeTopCmonth()
        {
            try
            {
                var result = db.billdetailsmodel.OrderByDescending(a => a.BillNo).OrderBy(a=>a.CMonth).Take(1);
                //var result = result1.ToList();
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
        public async Task<CableResult> BillInsert(BillDetailsModel model)
        {
            try
            {   
                BillDetailsModel _billinsert = new BillDetailsModel();
                _billinsert.CustomerID = model.CustomerID;
                //_billinsert.NoBox = model.NoBox;
                _billinsert.SetupBoxBill = model.SetupBoxBill;
                _billinsert.BillNo = model.BillNo;
                _billinsert.BillDate = model.BillDate;
                _billinsert.CustomerName = model.CustomerName;
                _billinsert.Address = model.Address;
                _billinsert.Mbno1 = model.Mbno1;
                _billinsert.Area = model.Area;
                _billinsert.CMonth = model.CMonth;
                _billinsert.MonthCharge = model.MonthCharge;
                _billinsert.CGSTPer = model.CGSTPer;
                _billinsert.CGSTAmt = model.CGSTAmt;
                _billinsert.SGSTPer = model.SGSTPer;
                _billinsert.SGSTAmt = model.SGSTAmt;
                _billinsert.GrandTot = model.GrandTot;
                _billinsert.OldBal = model.OldBal;
                _billinsert.PayableAmt = model.PayableAmt;
                _billinsert.Dtfrom = model.Dtfrom;
                _billinsert.ToDate = model.ToDate;
                _billinsert.PMonth = model.PMonth;
                _billinsert.Disc = model.Disc;
                _billinsert.Balance = model.Balance;
                _billinsert.AgentId = model.AgentId;
                _billinsert.AgentName = model.AgentName;
                _billinsert.RegNo = model.RegNo;
                _billinsert.CYear = model.CYear;
                _billinsert.CashDet = model.CashDet;
                _billinsert.PayStat = model.PayStat;
                _billinsert.CompanyId = model.CompanyId;
                _billinsert.PaidAmt = model.PaidAmt;
                _billinsert.PaidAmt1 = model.PaidAmt1;
                _billinsert.PayDate1 = model.PayDate1;
                _billinsert.PayDate = model.PayDate;
                _billinsert.AccNoBox = model.AccNoBox;
                _billinsert.PackageName = model.PackageName;

                db.billdetailsmodel.Add(_billinsert);
                db.SaveChanges();
              
                if (_billinsert != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = _billinsert };
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
        public async Task<CableResult> BillRegUpdate(RegModel model)
        {
            try
            {
                var _regupdate = db.regmodel.Where(a => a.CustomerID == model.CustomerID && a.CompanyId == model.CompanyId).FirstOrDefault();
                _regupdate.CustBal = model.CustBal;
                _regupdate.DtFrom = model.DtFrom;
                db.Entry(_regupdate).State = EntityState.Modified;
                db.SaveChanges();
                if (_regupdate != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = _regupdate };
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
        public async Task<CableResult> BillPaidUpdate(BillDetailsModel model)
        {
            try
            {
                var _billpaidupdate = db.billdetailsmodel.Where(a => a.BillNo == model.BillNo && a.CompanyId == model.CompanyId).FirstOrDefault();
                _billpaidupdate.OldBal = model.OldBal;
                _billpaidupdate.Dtfrom = model.Dtfrom;
                _billpaidupdate.Disc = model.Disc;
                _billpaidupdate.ToDate = model.ToDate;
                _billpaidupdate.PaidAmt = model.PaidAmt;
                _billpaidupdate.PayableAmt = model.PayableAmt;
                _billpaidupdate.PayDate = model.PayDate;
                _billpaidupdate.Balance = model.Balance;
                _billpaidupdate.PayDate1 = model.PayDate1;
                _billpaidupdate.PaidAmt1 = model.PaidAmt1;                
                db.Entry(_billpaidupdate).State = EntityState.Modified;
                db.SaveChanges();
                if (_billpaidupdate != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = _billpaidupdate };
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
        public async Task<CableResult> BillRegPaidUpdate(RegModel model)
        {
            try
            {
                var _billregpaidupdate = db.regmodel.Where(a => a.CustomerID == model.CustomerID && a.CompanyId == model.CompanyId).FirstOrDefault();
                _billregpaidupdate.CustBal = model.CustBal;
                _billregpaidupdate.DtFrom = model.DtFrom;
               
                db.Entry(_billregpaidupdate).State = EntityState.Modified;
                db.SaveChanges();
                if (_billregpaidupdate != null)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = _billregpaidupdate };
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
        public async Task<CableResult> BillFilter(BillDetailsModel model)
        {
            try
            {
                var Consumerresult = db.billdetailsmodel.Where(c => c.CustomerName.StartsWith(model.CustomerName) && c.CMonth == model.CMonth).ToList();
                var Setupboxresult = db.billdetailsmodel.Where(c => c.SetupBoxBill.StartsWith(model.SetupBoxBill) && c.CMonth == model.CMonth).ToList();
                var Arearesult = db.billdetailsmodel.Where(c => c.Area.StartsWith(model.Area) && c.CMonth == model.CMonth).ToList();
                var Agentresult = db.billdetailsmodel.Where(c => c.AgentName.StartsWith(model.AgentName) && c.CMonth == model.CMonth).ToList();
                var Mobileresult = db.billdetailsmodel.Where(c => c.Mbno1.StartsWith(model.Mbno1) && c.CMonth == model.CMonth).ToList();
                var BillNoresult = db.billdetailsmodel.Where(c => c.BillNo.ToString().StartsWith(model.BillNo.ToString()) && c.CMonth == model.CMonth).ToList();
                var Regnoresult = db.billdetailsmodel.Where(c => c.CustomerID.ToString().StartsWith(model.CustomerID.ToString()) && c.CMonth == model.CMonth).ToList();

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
                    return new CableResult { Message = "Success", Status = 1, Response = Arearesult };
                }
                else if (Agentresult.Count != 0)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = Agentresult };
                }
                else if (Mobileresult.Count != 0)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = Mobileresult };
                }
                else if (BillNoresult.Count != 0)
                {
                    return new CableResult { Message = "Success", Status = 1, Response = BillNoresult };
                }
                else if (Regnoresult.Count != 0)
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
        public async Task<CableResult> BillTransfer(SetupDetailModel model)
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
        public async Task<CableResult> BillDataCollectionList(BillDetailsModel model)
        {
            try
            {
                var result = db.billdetailsmodel.Where(a => model.Area.Contains(a.Area) && a.CMonth == model.CMonth && a.CYear == model.CYear && a.CompanyId == model.CompanyId).ToList();
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

        public async Task<CableResult> BillMonthCheck(BillDetailsModel model)
        {
            try
            {
                var result = db.billdetailsmodel.Where(a => a.CMonth == model.CMonth && a.CYear == model.CYear && a.CompanyId == model.CompanyId).ToList();
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

        public async Task<CableResult> BillMonCheck(BillDetailsModel model)
        {
            try
            {
                var result = db.billdetailsmodel.Where(a => a.CYear == model.CYear && a.CompanyId == model.CompanyId).ToList();
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

        //// GET: BillDetailsModels
        //public ActionResult Index()
        //{
        //    return View(db.billdetailsmodel.ToList());
        //}

        //// GET: BillDetailsModels/Details/5
        //public ActionResult Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BillDetailsModel billDetailsModel = db.billdetailsmodel.Find(id);
        //    if (billDetailsModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(billDetailsModel);
        //}

        //// GET: BillDetailsModels/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: BillDetailsModels/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "BID,CustomerID,NoBox,SetupBoxBill,BillNo,BillDate,CustomerName,Address,Mbno1,Area,CMonth,MonthCharge,CGSTPer,CGSTAmt,SGSTPer,SGSTAmt,GrandTot,OldBal,PayableAmt,Dtfrom,PMonth,ToDate,Disc,PaidAmt,PayDate,PaidAmt1,PayDate1,Balance,AgentId,AgentName,RegNo,CYear,CashDet,PayStat,CompanyId,AccNoBox,PackageName")] BillDetailsModel billDetailsModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.billdetailsmodel.Add(billDetailsModel);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(billDetailsModel);
        //}

        //// GET: BillDetailsModels/Edit/5
        //public ActionResult Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BillDetailsModel billDetailsModel = db.billdetailsmodel.Find(id);
        //    if (billDetailsModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(billDetailsModel);
        //}

        //// POST: BillDetailsModels/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "BID,CustomerID,NoBox,SetupBoxBill,BillNo,BillDate,CustomerName,Address,Mbno1,Area,CMonth,MonthCharge,CGSTPer,CGSTAmt,SGSTPer,SGSTAmt,GrandTot,OldBal,PayableAmt,Dtfrom,PMonth,ToDate,Disc,PaidAmt,PayDate,PaidAmt1,PayDate1,Balance,AgentId,AgentName,RegNo,CYear,CashDet,PayStat,CompanyId,AccNoBox,PackageName")] BillDetailsModel billDetailsModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(billDetailsModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(billDetailsModel);
        //}

        //// GET: BillDetailsModels/Delete/5
        //public ActionResult Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BillDetailsModel billDetailsModel = db.billdetailsmodel.Find(id);
        //    if (billDetailsModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(billDetailsModel);
        //}

        //// POST: BillDetailsModels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(long id)
        //{
        //    BillDetailsModel billDetailsModel = db.billdetailsmodel.Find(id);
        //    db.billdetailsmodel.Remove(billDetailsModel);
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
