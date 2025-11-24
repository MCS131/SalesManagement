using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SalesManagement_SysDev;

public partial class TOrderDetail
{
    public int OrDetailId { get; set; }

    public int OrId { get; set; }

    public int PrId { get; set; }

    public int OrQuantity { get; set; }

    public decimal OrTotalPrice { get; set; }

    public virtual TOrder Or { get; set; } = null!;

    public virtual MProduct Pr { get; set; } = null!;
}

internal class TOrderDetailDsp
{
    [DisplayName("受注詳細ID")]
    public int OrDetailId { get; set; }
    [DisplayName("受注ID")]
    public int OrId { get; set; }
    [DisplayName("商品ID")]
    public int PrId { get; set; }
    [DisplayName("商品名")]
    public string PrName { get; set; }
    [DisplayName("数量")]
    public int OrQuantity { get; set; }
    [DisplayName("合計")]
    public decimal OrTotalPrice { get; set; }
}
