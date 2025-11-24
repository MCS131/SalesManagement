using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SalesManagement_SysDev;

public partial class TChumon
{
    public int ChId { get; set; }

    public int SoId { get; set; }

    public int? EmId { get; set; }

    public int ClId { get; set; }

    public int OrId { get; set; }

    public DateTime? ChDate { get; set; }

    public int? ChStateFlag { get; set; }

    public int ChFlag { get; set; }

    public string? ChHidden { get; set; }

    public virtual MClient Cl { get; set; } = null!;

    public virtual MEmployee? Em { get; set; }

    public virtual TOrder Or { get; set; } = null!;

    public virtual MSalesOffice So { get; set; } = null!;

    public virtual ICollection<TChumonDetail> TChumonDetails { get; set; } = new List<TChumonDetail>();
}

internal class TChumonDsp
{
    [DisplayName("注文ID")]
    public int ChId { get; set; }
    [DisplayName("受注ID")]
    public int OrId { get; set; }
    [DisplayName("営業所ID")]
    public int SoId { get; set; }
    [DisplayName("営業所名")]
    public string SoName { get; set; }
    [DisplayName("社員ID")]
    public int? EmpID { get; set; }
    [DisplayName("社員名")]
    public string EmName { get; set; }
    [DisplayName("顧客ID")]
    public int ClID { get; set; }
    [DisplayName("顧客名")]
    public string ClName { get; set; }
    [DisplayName("注文年月日")]
    public DateTime? ChDate { get; set; }
    [DisplayName("注文状態フラグ")]
    public string ChStateFlg { get; set; }
    [DisplayName("注文管理フラグ")]
    public string  ChFlg { get; set; }
    [DisplayName("非表示理由")]
    public string ChHidden { get; set; }
}
