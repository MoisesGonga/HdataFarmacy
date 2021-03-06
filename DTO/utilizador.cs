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

public partial class utilizador
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public utilizador()
    {
        this.caixas = new HashSet<caixa>();
        this.custoes = new HashSet<custo>();
        this.estoque_produto = new HashSet<estoque_produto>();
        this.logs = new HashSet<log>();
        this.movimento_estoque = new HashSet<movimento_estoque>();
        this.reservas = new HashSet<reserva>();
        this.vendas = new HashSet<venda>();
    }

    public int id_utilizador { get; set; }
    public string nome { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public int id_tipo_user { get; set; }
    public Nullable<System.DateTime> data_cadastro { get; set; }
    public Nullable<System.DateTime> data_actualizacao { get; set; }
    public int status { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<caixa> caixas { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<custo> custoes { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<estoque_produto> estoque_produto { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<log> logs { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<movimento_estoque> movimento_estoque { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<reserva> reservas { get; set; }
    public virtual tipo_utilizador tipo_utilizador { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<venda> vendas { get; set; }
}
