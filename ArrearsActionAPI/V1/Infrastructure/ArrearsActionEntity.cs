using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql;
using NpgsqlTypes;

namespace ArrearsActionAPI.V1.Infrastructure
{
    [Table("araction")]
    public class ArrearsActionEntity
    {
        [Column("tag_ref")]             public string           tag_ref { get; set; }
        [Column("action_set")]          public int              action_set { get; set; }
        [Column("action_no")]           public int              action_no { get; set; }
        [Column("action_code")]         public string           action_code { get; set; }
        [Column("action_date")]         public DateTime         action_date { get; set; }
        [Column("action_balance")]      public decimal?         action_balance { get; set; }
        [Column("action_comment")]      public string           action_comment { get; set; }
        [Column("username")]            public string           username { get; set; }
        [Column("comm_only")]           public bool             comm_only { get; set; }
        [Column("ole_obj")]             public byte[]           ole_obj { get; set; }
        [Key]
        [Column("araction_sid")]        public int?             araction_sid { get; set; }
        [Column("action_deferred")]     public bool?            action_deferred { get; set; }
        [Column("deferred_until")]      public DateTime         deferred_until { get; set; }
        [Column("deferral_reason")]     public string           deferral_reason { get; set; }
        [Column("severity_level")]      public int?             severity_level { get; set; }
        [Column("action_nr_balance")]   public decimal?         action_nr_balance { get; set; }
        [Column("action_type")]         public string           action_type { get; set; }
        [Column("act_status")]          public string           act_status { get; set; }
        [Column("action_cat")]          public string           action_cat { get; set; }
        [Column("action_subno")]        public int?             action_subno { get; set; }
        [Column("action_subcode")]      public string           action_subcode { get; set; }
        [Column("action_process_no")]   public int?             action_process_no { get; set; }
        [Column("notice_sid")]          public int?             notice_sid { get; set; }
        [Column("courtord_sid")]        public int?             courtord_sid { get; set; }
        [Column("warrant_sid")]         public int?             warrant_sid { get; set; }
        [Column("action_doc_no")]       public int?             action_doc_no { get; set; }
        [Column("tstamp")]              public byte[]           tstamp { get; set; }
        [Column("comp_avail")]          public string           comp_avail { get; set; }
        [Column("comp_display")]        public string           comp_display { get; set; }
        [Column("u_saff_araction_ref")] public string           u_saff_araction_ref { get; set; }
    }
}