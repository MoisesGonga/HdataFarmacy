//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class elementos_promocao
{
    public int id_promocao { get; set; }
    public int id_lote { get; set; }
    public int id_produto { get; set; }
    public Nullable<double> margem_venda { get; set; }
    public Nullable<double> preco_venda { get; set; }

    public virtual lote lote { get; set; }
    public virtual promocao promocao { get; set; }
}
