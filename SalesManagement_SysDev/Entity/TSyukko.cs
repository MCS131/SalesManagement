using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SalesManagement_SysDev;

public partial class TSyukko
{
    public int SyId { get; set; }

    public int? EmId { get; set; }

    public int ClId { get; set; }

    public int SoId { get; set; }

    public int OrId { get; set; }

    public DateTime? SyDate { get; set; }

    public int? SyStateFlag { get; set; }

    public int SyFlag { get; set; }

    public string? SyHidden { get; set; }

    public virtual MClient Cl { get; set; } = null!;

    public virtual MEmployee? Em { get; set; }

    public virtual TOrder Or { get; set; } = null!;

    public virtual MSalesOffice So { get; set; } = null!;

    public virtual ICollection<TSyukkoDetail> TSyukkoDetails { get; set; } = new List<TSyukkoDetail>();
}
internal class TSyukkoDsp
{
    [DisplayName("出庫ID")]
    public int SyId { get; set; }
    [DisplayName("社員ID")]
    public int? EmId { get; set; }
    [DisplayName("社員名")]
    public string EmName { get; set; }
    [DisplayName("顧客ID")]
    public int ClId { get; set; }
    [DisplayName("顧客名")]
    public string ClName { get; set; }
    [DisplayName("営業所ID")]
    public int SoId { get; set; }
    [DisplayName("営業所名")]
    public string SoName { get; set; }
    [DisplayName("受注ID")]
    public int OrID { get; set; }
    [DisplayName("出庫年月日")]
    public DateTime? SyDate { get; set; }
    [DisplayName("出庫状態フラグ")]
    public int? SyStateFlg { get; set; }
    [DisplayName("出庫管理フラグ")]
    public int SyFlag { get; set; }
    [DisplayName("非表示理由")]
    public string? SyHidden { get; set; }
}