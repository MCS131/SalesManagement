using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Policy;

namespace SalesManagement_SysDev;

public partial class TWarehousing
{
    public int WaId { get; set; }

    public int HaId { get; set; }

    public int? EmId { get; set; }

    public DateTime WaDate { get; set; }

    public int? WaShelfFlag { get; set; }

    public string? WaHidden { get; set; }

    public int WaFlag { get; set; }

    public virtual MEmployee Em { get; set; } = null!;

    public virtual THattyu Ha { get; set; } = null!;

    public virtual ICollection<TWarehousingDetail> TWarehousingDetails { get; set; } = new List<TWarehousingDetail>();
}
internal class TWarehousingDsp
{
    [DisplayName("入庫ID")]
    public int WaId { get; set; }
    [DisplayName("発注ID")]
    public int HaId { get; set; }
    [DisplayName("社員ID")]
    public int? EmId { get; set; }
    [DisplayName("社員名")]
    public string EmName { get; set; }
    [DisplayName("入庫年月日")]
    public DateTime WaDate { get; set; }
    [DisplayName("入庫済フラグ(棚)")]
    public int? WaShelfFlg { get; set; }
    [DisplayName("非表示理由")]
    public string? WaHidden { get; set; }
    [DisplayName("入庫管理フラグ")]
    public int WaFlag { get; set;}
}
