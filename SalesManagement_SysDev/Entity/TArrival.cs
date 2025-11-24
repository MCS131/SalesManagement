using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SalesManagement_SysDev;

public partial class TArrival
{
    public int ArId { get; set; }

    public int SoId { get; set; }

    public int? EmId { get; set; }

    public int ClId { get; set; }

    public int OrId { get; set; }

    public DateTime? ArDate { get; set; }

    public int? ArStateFlag { get; set; }

    public int ArFlag { get; set; }

    public string? ArHidden { get; set; }

    public virtual MClient Cl { get; set; } = null!;

    public virtual MEmployee? Em { get; set; }

    public virtual TOrder Or { get; set; } = null!;

    public virtual MSalesOffice So { get; set; } = null!;

    public virtual ICollection<TArrivalDetail> TArrivalDetails { get; set; } = new List<TArrivalDetail>();
}
internal class TArrivalDsp
{
    [DisplayName("入荷ID")]
    public int ArId { get; set; }
    [DisplayName("営業所ID")]
    public int SoId { get; set; }
    [DisplayName("営業所名")]
    public string SoName { get; set; }
    [DisplayName("社員ID")]
    public int? EmId { get; set; }
    [DisplayName("社員名")]
    public string EmName { get; set; }
    [DisplayName("顧客ID")]
    public int ClId { get; set; }
    [DisplayName("顧客名")]
    public string ClName { get; set; }
    [DisplayName("受注ID")]
    public int OrId { get; set; }
    [DisplayName("入荷年月日")]
    public DateTime? ArDate { get; set; }
    [DisplayName("入荷状態フラグ")]
    public int? ArStateFlg { get; set; }
    [DisplayName("入荷管理フラグ")]
    public int ArFlg { get; set; }
    [DisplayName("非表示理由")]
    public string? ArHidden { get; set; }
}
