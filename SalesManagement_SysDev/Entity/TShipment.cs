using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SalesManagement_SysDev;

public partial class TShipment
{
    public int ShId { get; set; }

    public int ClId { get; set; }

    public int? EmId { get; set; }

    public int SoId { get; set; }

    public int OrId { get; set; }

    public int? ShStateFlag { get; set; }

    public DateTime? ShFinishDate { get; set; }

    public int ShFlag { get; set; }

    public string? ShHidden { get; set; }

    public virtual MClient Cl { get; set; } = null!;

    public virtual MEmployee? Em { get; set; }

    public virtual TOrder Or { get; set; } = null!;

    public virtual MSalesOffice So { get; set; } = null!;

    public virtual ICollection<TShipmentDetail> TShipmentDetails { get; set; } = new List<TShipmentDetail>();
}
internal class TShipmentDsp
{
    [DisplayName("出荷ID")]
    public int ShId { get; set; }
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
    public DateTime? ShDate { get; set; }
    [DisplayName("入荷状態フラグ")]
    public int? ShStateFlg { get; set; }
    [DisplayName("入荷管理フラグ")]
    public int ShFlg { get; set; }
    [DisplayName("非表示理由")]
    public string? ShHidden { get; set; }
}
