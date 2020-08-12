using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArrearsActionAPI.V1.Domain
{
    public class ArrearsAction
    {
        public string TenancyAgreementRef { get; set; }
        public int ActionSet { get; set; }
        public int ActionNo { get; set; }
        public string ActionCode { get; set; }
        public DateTime? ActionDate { get; set; }
        public decimal? ActionBalance { get; set; }
        public string ActionComment { get; set; }
        public string Username { get; set; }
        public bool CommOnly { get; set; }
        public byte[] OleObj { get; set; }
        public int? AractionSid { get; set; }
        public bool? ActionDeferred { get; set; }
        public DateTime? DeferredUntil { get; set; }
        public string DeferralReason { get; set; }
        public int? SeverityLevel { get; set; }
        public decimal? ActionNrBalance { get; set; }
        public string ActionType { get; set; }
        public string ActionStatus { get; set; }
        public string ActionCat { get; set; }
        public int? ActionSubNo { get; set; }
        public string ActionSubcode { get; set; }
        public int? ActionProcessNo { get; set; }
        public int? NoticeSid { get; set; }
        public int? CourtordSid { get; set; }
        public int? WarrantSid { get; set; }
        public int? ActionDocNo { get; set; }
        public string CompAvail { get; set; }
        public string CompDisplay { get; set; }
        public string USaffAractionRef { get; set; }
    }
}
