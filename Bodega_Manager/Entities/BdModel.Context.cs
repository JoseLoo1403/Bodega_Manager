//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bodega_Manager.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Bodega_RepuestosEntities1 : DbContext
    {
        public Bodega_RepuestosEntities1()
            : base("name=Bodega_RepuestosEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Maquina> Maquinas { get; set; }
        public virtual DbSet<Mecanico> Mecanicoes { get; set; }
        public virtual DbSet<Factura_Detail> Factura_Detail { get; set; }
        public virtual DbSet<Factura_Header> Factura_Header { get; set; }
        public virtual DbSet<Repuesto_Data> Repuesto_Data { get; set; }
        public virtual DbSet<Repuesto> Repuestos { get; set; }
    }
}
