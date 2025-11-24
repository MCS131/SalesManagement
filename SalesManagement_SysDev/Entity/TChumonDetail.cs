using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SalesManagement_SysDev;

public partial class TChumonDetail
{
    public int ChDetailId { get; set; }

    public int ChId { get; set; }

    public int PrId { get; set; }

    public int ChQuantity { get; set; }

    public virtual TChumon Ch { get; set; } = null!;

    public virtual MProduct Pr { get; set; } = null!;
}
internal class TChumonDetailDsp
{
    [DisplayName("注文詳細ID")]
    public int ChDetailId { get; set; }
    [DisplayName("注文ID")]
    public int ChId { get; set; }
    [DisplayName("商品ID")]
    public int PrId { get; set; }
    [DisplayName("商品名")]
    public string PrName { get; set; }
    [DisplayName("数量")]
    public int ChQuantity { get; set; }
}