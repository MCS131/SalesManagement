using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SalesManagement_SysDev;

public partial class TStock
{
    public int StId { get; set; }

    public int PrId { get; set; }

    public int StQuantity { get; set; }

    public int StFlag { get; set; }

    public virtual MProduct Pr { get; set; } = null!;
}

internal class TStockDsp
{
    [DisplayName("在庫ID")]
    public int StId { get; set; }
    [DisplayName("商品ID")]
    public int PrId { get; set; }
    [DisplayName("商品名")]
    public string PrName { get; set; }
    [DisplayName("在庫数")]
    public int StQuantity { get; set; }
    [DisplayName("在庫管理フラグ")]
    public int StFlag { get; set; }
}