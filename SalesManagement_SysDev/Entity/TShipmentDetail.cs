using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SalesManagement_SysDev;

public partial class TShipmentDetail
{
    public int ShDetailId { get; set; }

    public int ShId { get; set; }

    public int PrId { get; set; }

    public int ShQuantity { get; set; }

    public virtual MProduct Pr { get; set; } = null!;

    public virtual TShipment Sh { get; set; } = null!;
}
internal class TShipmentDetailDsp
{
    [DisplayName("出荷詳細ID")]
    public int ShDetailId { get; set; }
    [DisplayName("出荷ID")]
    public int? ShId { get; set; }
    [DisplayName("商品ID")]
    public int? PrId { get; set; }
    [DisplayName("商品名")]
    public string PrName { get; set; }
    [DisplayName("数量")]
    public int? ShQuantity { get; set; }
}
