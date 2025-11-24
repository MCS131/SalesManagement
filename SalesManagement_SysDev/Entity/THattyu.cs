using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SalesManagement_SysDev;

public partial class THattyu
{
    public int HaId { get; set; }

    public int MaId { get; set; }

    public int EmId { get; set; }

    public DateTime HaDate { get; set; }

    public int? WaWarehouseFlag { get; set; }

    public int HaFlag { get; set; }

    public string? HaHidden { get; set; }

    public virtual MEmployee Em { get; set; } = null!;

    public virtual MMaker Ma { get; set; } = null!;

    public virtual ICollection<THattyuDetail> THattyuDetails { get; set; } = new List<THattyuDetail>();

    public virtual ICollection<TWarehousing> TWarehousings { get; set; } = new List<TWarehousing>();
}
internal class THattyuDsp
{
    [DisplayName("発注ID")]
    public int HaId { get; set; }
    [DisplayName("メーカID")]
    public int MaId { get; set; }
    [DisplayName("メーカ名")]
    public string MaName { get; set; }
    [DisplayName("社員ID")]
    public int EmId { get; set; }
    [DisplayName("社員名")]
    public string EmName { get; set; }
    [DisplayName("発注年月日")]
    public DateTime HaDate { get; set; }
    [DisplayName("入庫済フラグ(倉庫)")]
    public int? WaWarehouseFlag { get; set; }
    [DisplayName("発注管理フラグ")]
    public int HaFlag { get; set; }
    [DisplayName("非表示理由")]
    public string? HaHidden { get; set; }
}