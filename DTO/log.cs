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

public partial class log
{
    public int id_log { get; set; }
    public string titulo { get; set; }
    public System.DateTime data_logs { get; set; }
    public string descricao { get; set; }
    public int id_tipo_log { get; set; }
    public int id_utilizador { get; set; }

    public virtual tipo_log tipo_log { get; set; }
    public virtual utilizador utilizador { get; set; }
}
