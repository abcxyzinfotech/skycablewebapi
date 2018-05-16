using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CableWebApi.Models
{
    public class CableResult
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Response { get; set; }
    }

    //public class LoginViewModel
    //{
    //    public string UserID { get; set; }
    //    public string UserName { get; set; }
    //    public string UserPassword { get; set; }
    //    public string UserType { get; set; }
    //    public string CompanyId { get; set; }
    //}

    //public class CompanyMasterModel
    //{
    //    public string CompanyName { get; set; }
    //    public string CompanyAddress { get; set; }
    //    public string CompanyMobNo { get; set; }
    //    public string CompanyEmailId { get; set; }
    //    public string CompanyGSTNo { get; set; }
    //    public byte[] CompanyLogo { get; set; }
    //    public string AccountNo { get; set; }
    //    public string IFSC { get; set; }
    //    public string WihGST { get; set; }
    //    public string GSTinout { get; set; }
    //    public Nullable<long> CompanyId { get; set; }
    //    public string RemarkBill { get; set; }
    //    public long Srno { get; set; }
    //}
}