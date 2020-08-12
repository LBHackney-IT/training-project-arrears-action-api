using ArrearsActionAPI.V1.Domain;
using ArrearsActionAPI.V1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArrearsActionAPI.V1.Factories
{
    public static class EntityFactory
    {
        public static ArrearsAction ToDomain(this ArrearsActionEntity databaseEntity)
        {
            return new ArrearsAction()
            {
                ActionBalance = databaseEntity.action_balance,
                ActionCat = databaseEntity.action_cat,
                ActionCode = databaseEntity.action_code,
                ActionComment = databaseEntity.action_comment,
                ActionDate = databaseEntity.action_date,
                ActionDeferred = databaseEntity.action_deferred,
                ActionDocNo = databaseEntity.action_doc_no,
                ActionNo = databaseEntity.action_no,
                ActionNrBalance = databaseEntity.action_nr_balance,
                ActionProcessNo = databaseEntity.action_process_no,
                ActionSet = databaseEntity.action_set,
                ActionStatus = databaseEntity.act_status,
                ActionSubcode = databaseEntity.action_subcode,
                ActionSubNo = databaseEntity.action_subno,
                ActionType = databaseEntity.action_type,
                AractionSid = databaseEntity.araction_sid,
                CommOnly = databaseEntity.comm_only,
                CompAvail = databaseEntity.comp_avail,
                CompDisplay = databaseEntity.comp_display,
                CourtordSid = databaseEntity.courtord_sid,
                DeferralReason = databaseEntity.deferral_reason,
                DeferredUntil = databaseEntity.deferred_until,
                NoticeSid = databaseEntity.notice_sid,
                OleObj = databaseEntity.ole_obj,
                SeverityLevel = databaseEntity.severity_level,
                TenancyAgreementRef = databaseEntity.tag_ref,
                USaffAractionRef = databaseEntity.u_saff_araction_ref,
                Username = databaseEntity.username,
                WarrantSid = databaseEntity.warrant_sid,
            };
        }

        public static List<ArrearsAction> ToDomain(this IEnumerable<ArrearsActionEntity> people)
        {
            return people.Select(a => a.ToDomain()).ToList();
        }
    }
}
