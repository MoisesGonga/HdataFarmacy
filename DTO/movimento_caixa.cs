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

public partial class movimento_caixa
{
    public int id_movimento { get; set; }
    public string descricao { get; set; }
    public string notas { get; set; }
    public System.DateTime data_movimento { get; set; }
    public double valor_movimento { get; set; }
    public int id_caixa { get; set; }
    public int id_tipo_movimento { get; set; }

    public virtual caixa caixa { get; set; }
    public virtual tipo_movimento tipo_movimento { get; set; }
}
