using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArrearsActionAPI.V1.Infrastructure
{
    [Table("tenagree")]
    public class TenancyAgreementEntity
    {
        [Key]
        [Column("tag_ref")]              public string          tag_ref { get; set; }
        [Column("prop_ref")]             public string          prop_ref { get; set; }
        [Column("house_ref")]            public string          house_ref { get; set; }
        [Column("cot")]                  public DateTime        cot { get; set; }
        [Column("eot")]                  public DateTime        eot { get; set; }
        [Column("spec_terms")]           public bool            spec_terms { get; set; }
        [Column("other_accounts")]       public bool            other_accounts { get; set; }
        [Column("active")]               public bool            active { get; set; }
        [Column("present")]              public bool            present { get; set; }
        [Column("terminated")]           public bool            terminated { get; set; }
        [Column("free_active")]          public bool            free_active { get; set; }
        [Column("nop")]                  public bool            nop { get; set; }
        [Column("additional_debit")]     public bool            additional_debit { get; set; }
        [Column("fd_charge")]            public bool            fd_charge { get; set; }
        [Column("receiptcard")]          public bool            receiptcard { get; set; }
        [Column("nosp")]                 public bool            nosp { get; set; }
        [Column("ntq")]                  public bool            ntq { get; set; }
        [Column("eviction")]             public bool            eviction { get; set; }
        [Column("committee")]            public bool            committee { get; set; }
        [Column("suppossorder")]         public bool            suppossorder { get; set; }
        [Column("possorder")]            public bool            possorder { get; set; }
        [Column("courtapp")]             public bool            courtapp { get; set; }
        [Column("open_item")]            public bool            open_item { get; set; }
        [Column("potentialenddate")]     public DateTime        potentialenddate { get; set; }
        [Column("u_payment_expected")]   public string          u_payment_expected { get; set; }
        [Column("dtstamp")]              public DateTime        dtstamp { get; set; }
        [Column("intro_date")]           public DateTime        intro_date { get; set; }
        [Column("intro_ext_date")]       public DateTime        intro_ext_date { get; set; }
    }
}
