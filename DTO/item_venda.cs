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

public partial class item_venda
{
    public int id_venda { get; set; }
    public int id_lote { get; set; }
    public int id_produto { get; set; }
    public int qtd { get; set; }
    public float preco { get; set; }
    public float subtotal { get; set; }

    public virtual lote lote { get; set; }
    public virtual venda venda { get; set; }
}
