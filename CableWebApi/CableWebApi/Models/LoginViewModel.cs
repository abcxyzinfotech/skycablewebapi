using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CableWebApi.Models
{
    public class LoginViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; }
        public string CompanyId { get; set; }
    }

    public class CompanyMasterModel
    {        
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyMobNo { get; set; }
        public string CompanyEmailId { get; set; }
        public string CompanyGSTNo { get; set; }
        public byte[] CompanyLogo { get; set; }
        public string AccountNo { get; set; }
        public string IFSC { get; set; }
        public string WihGST { get; set; }
        public string GSTinout { get; set; }
        public Nullable<long> CompanyId { get; set; }
        public string RemarkBill { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Srno { get; set; }

    }

    public class DatabaseNameModel
    {        
        public string MyServerName { get; set; }
        public string MyDatabaseName { get; set; }
        public string MyPath { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Srno { get; set; }
    }

    public class RegModel
    {        
        public long CustomerID { get; set; }
        public Nullable<decimal> NoBox { get; set; }
        public string SetupNoReg { get; set; }
        public string ConsumerName { get; set; }
        public string Address { get; set; }
        public string LandMark { get; set; }
        public string Mbno1 { get; set; }
        public string Mbno2 { get; set; }
        public string Area { get; set; }
        public Nullable<long> AgentId { get; set; }
        public string AgentName { get; set; }
        public string Phone { get; set; }
        public Nullable<decimal> CGSTPer { get; set; }
        public Nullable<decimal> CSGTAmt { get; set; }
        public Nullable<decimal> SGSTPer { get; set; }
        public Nullable<decimal> SGSTAmt { get; set; }
        public Nullable<decimal> TotRate { get; set; }
        public string Dics { get; set; }
        public Nullable<decimal> TotAmt { get; set; }
        public Nullable<decimal> CustBal { get; set; }
        public string RegNo { get; set; }
        public string Type { get; set; }
        public byte[] ImgP1 { get; set; }
        public byte[] ImgP2 { get; set; }
        public byte[] ImgP3 { get; set; }
        public string IDProof { get; set; }
        public Nullable<System.DateTime> DtFrom { get; set; }
        public string CNameMarathi { get; set; }
        public string UserName { get; set; }
        public string CustPassword { get; set; }
        public string ChangeCol { get; set; }
        public Nullable<int> NotifyStat { get; set; }
        public string Remark { get; set; }
        public string CompanyId { get; set; }
        public Nullable<decimal> AccNoBox { get; set; }
        public string PackageName { get; set; }        
        public Nullable<System.DateTime> CDate { get; set; }
        public string CTime { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CID { get; set; }       
    }

    public class SetupDetailModel
    {       
        public Nullable<long> CustomerID { get; set; }
        public string Setboxno { get; set; }
        public string SDate { get; set; }
        public string FormNo { get; set; }
        public string Packeges { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> Disc { get; set; }
        public Nullable<decimal> Amt { get; set; }
        public Nullable<decimal> CardNo { get; set; }
        public string FaultyNo { get; set; }
        public string StatType { get; set; }
        public string CompanyId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SID { get; set; }
    }

    public class FormNameModel
    {       
        public Nullable<int> Status { get; set; }
        public string FieldName { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Srno { get; set; }
    }

    public class AdminPinModel
    {        
        public string AdminPin { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long srno { get; set; }
    }

    public class AgentModel
    {       
        public Nullable<int> AgentId { get; set; }
        public string AgentName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string CompanyId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Aid { get; set; }
    }

    public class AreaModel
    {       
        public string Area { get; set; }
        public string CompanyId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AreaId { get; set; }
    }

   
    public class packageModel
    {       
        public string Package { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public string CompanyId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PID { get; set; }

    }

    public class ReconnectModel
    {       
        public Nullable<long> CustId { get; set; }
        public string MacId { get; set; }
        public DateTime? ReconDate { get; set; }
        public DateTime? DiscDate { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string CompanyId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RID { get; set; }
    }
    
    public class BillDetailsModel
    {    
        public Nullable<long> CustomerID { get; set; }
        public int NoBox { get; set; }
        public string SetupBoxBill { get; set; }
        public int BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Mbno1 { get; set; }
        public string Area { get; set; }
        public string CMonth { get; set; }
        public Nullable<decimal> MonthCharge { get; set; }
        public Nullable<decimal> CGSTPer { get; set; }
        public Nullable<decimal> CGSTAmt { get; set; }
        public Nullable<decimal> SGSTPer { get; set; }
        public Nullable<decimal> SGSTAmt { get; set; }
        public Nullable<decimal> GrandTot { get; set; }
        public Nullable<decimal> OldBal { get; set; }
        public Nullable<decimal> PayableAmt { get; set; }
        public Nullable<DateTime> Dtfrom { get; set; }
        public string PMonth { get; set; }
        public string ToDate { get; set; }
        public Nullable<decimal> Disc { get; set; }
        public Nullable<decimal> PaidAmt { get; set; }       
        public string PayDate { get; set; }
        public Nullable<decimal> PaidAmt1 { get; set; }
        public string PayDate1 { get; set; }
        public Nullable<decimal> Balance { get; set; }
        public long AgentId { get; set; }
        public string AgentName { get; set; }
        public string RegNo { get; set; }
        public string CYear { get; set; }
        public string CashDet { get; set; }
        public string PayStat { get; set; }
        public string CompanyId { get; set; }
        public Nullable<decimal> AccNoBox { get; set; }
        public string PackageName { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long BID { get; set; }
    }

    public class CDateModel
    {
        public DateTime CDate { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CD { get; set; }
    }
}