using ArrearsActionAPI.V1.Factories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArrearsActionAPI.UnitTests.V1.Factories
{
    [TestFixture]
    public class EntityFactoryTests
    {
        [Test]
        public void Given_ArrearsAction_database_record__When_EntityFactory_ToDomain_extension_method_is_called__Then_it_outputs_a_correctly_mapped_ArrearsAction_Domain_object()
        {
            var arrears_action = TestHelper.Generate_ArrearsActionEntity();

            var arrears_domain = arrears_action.ToDomain();

            Assert.AreEqual(arrears_domain.ActionBalance, arrears_action.action_balance);
            Assert.AreEqual(arrears_domain.ActionCat, arrears_action.action_cat);
            Assert.AreEqual(arrears_domain.ActionCode, arrears_action.action_code);
            Assert.AreEqual(arrears_domain.ActionComment, arrears_action.action_comment);
            Assert.AreEqual(arrears_domain.ActionDate, arrears_action.action_date);
            Assert.AreEqual(arrears_domain.ActionDeferred, arrears_action.action_deferred);
            Assert.AreEqual(arrears_domain.ActionDocNo, arrears_action.action_doc_no);
            Assert.AreEqual(arrears_domain.ActionNo, arrears_action.action_no);
            Assert.AreEqual(arrears_domain.ActionNrBalance, arrears_action.action_nr_balance);
            Assert.AreEqual(arrears_domain.ActionProcessNo, arrears_action.action_process_no);
            Assert.AreEqual(arrears_domain.ActionSet, arrears_action.action_set);
            Assert.AreEqual(arrears_domain.ActionStatus, arrears_action.act_status);
            Assert.AreEqual(arrears_domain.ActionSubcode, arrears_action.action_subcode);
            Assert.AreEqual(arrears_domain.ActionSubNo, arrears_action.action_subno);
            Assert.AreEqual(arrears_domain.ActionType, arrears_action.action_type);
            Assert.AreEqual(arrears_domain.AractionSid, arrears_action.araction_sid);
            Assert.AreEqual(arrears_domain.CommOnly, arrears_action.comm_only);
            Assert.AreEqual(arrears_domain.CompAvail, arrears_action.comp_avail);
            Assert.AreEqual(arrears_domain.CompDisplay, arrears_action.comp_display);
            Assert.AreEqual(arrears_domain.CourtordSid, arrears_action.courtord_sid);
            Assert.AreEqual(arrears_domain.DeferralReason, arrears_action.deferral_reason);
            Assert.AreEqual(arrears_domain.DeferredUntil, arrears_action.deferred_until);
            Assert.AreEqual(arrears_domain.NoticeSid, arrears_action.notice_sid);
            Assert.AreEqual(arrears_domain.OleObj, arrears_action.ole_obj);
            Assert.AreEqual(arrears_domain.SeverityLevel, arrears_action.severity_level);
            Assert.AreEqual(arrears_domain.TenancyAgreementRef, arrears_action.tag_ref);
            Assert.AreEqual(arrears_domain.USaffAractionRef, arrears_action.u_saff_araction_ref);
            Assert.AreEqual(arrears_domain.Username, arrears_action.username);
            Assert.AreEqual(arrears_domain.WarrantSid, arrears_action.warrant_sid);
        }
    }
}
