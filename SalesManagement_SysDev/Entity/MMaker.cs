using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SalesManagement_SysDev;

public partial class MMaker
{
    public int MaId { get; set; }

    public string MaName { get; set; } = null!;

    public string MaAddress { get; set; } = null!;

    public string MaPhone { get; set; } = null!;

    public string MaPostal { get; set; } = null!;

    public string MaFax { get; set; } = null!;

    public int MaFlag { get; set; }

    public string? MaHidden { get; set; }

    public virtual ICollection<MProduct> MProducts { get; set; } = new List<MProduct>();

    public virtual ICollection<THattyu> THattyus { get; set; } = new List<THattyu>();
}

internal class MMakerDsp
{
    [DisplayName("メーカーID")]
    public int MakerId { get; set; }
    [DisplayName("メーカー名")]
    public string MakerName { get; set; }
    [DisplayName("住所")]
    public string MakerAddress { get; set; }
    [DisplayName("電話番号")]
    public string MakerPhone { get; set; }
    [DisplayName("郵便番号")]
    public string MakerPostal { get; set; }
    [DisplayName("FAX")]
    public string MakerFax { get; set; }
    [DisplayName("メーカー管理フラグ")]
    public int MakerFlg { get; set; }
    [DisplayName("非表示理由")]
    public string MakerHidden{ get; set; }
}
