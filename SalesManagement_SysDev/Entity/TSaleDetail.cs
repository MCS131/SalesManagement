using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SalesManagement_SysDev;

public partial class TSaleDetail
{
    public int SaDetailId { get; set; }

    public int SaId { get; set; }

    public int PrId { get; set; }

    public int SaQuantity { get; set; }

    public decimal SaPrTotalPrice { get; set; }

    public virtual MProduct Pr { get; set; } = null!;

    public virtual TSale Sa { get; set; } = null!;
}

internal class TSaleDetailDsp
{
    [DisplayName("売上詳細ID")]
    public int SalesDetailID { get; set; }
    [DisplayName("売上ID")]
    public int SalesID { get; set; }
    [DisplayName("商品ID")]
    public int ProductID { get; set; }
    [DisplayName("商品名")]
    public string ProductName { get; set; }
    [DisplayName("個数")]
    public int SalesQuantity { get; set; }
    [DisplayName("合計金額")]
    public decimal SalesTotalPrice { get; set; }
}