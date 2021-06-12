using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodega_Manager.Entities;

namespace Bodega_Manager.Repositories
{
    public class RepuestosRepository
    {

        Bodega_RepuestosEntities1 context = new Bodega_RepuestosEntities1();
        public void CrearNuevoRepuesto(int _codigo, string lawson, string descripcion, int cantidad, decimal precio, string localidad)
        {
            Repuesto repuesto = new Repuesto() { 
                Codigo = _codigo,
                Codigo_Lawson = lawson,
                Descripcion = descripcion,
                Cantidad_Stock = cantidad,
                Precio = precio,
                Localidad = localidad
            };

            context.Repuestos.Add(repuesto);
            context.SaveChanges();
        }

        public Repuesto EncontrarRepuestoCodigo(int code)
        {
            return context.Repuestos.FirstOrDefault(x => x.Codigo == code);
        }

        public void RestarInventarioFactura(List<Factura_Detail> repuestos)
        {
            foreach (var item in repuestos)
            {
                var repuesto = context.Repuestos.FirstOrDefault(x => x.Codigo == item.Codigo_Repuesto);
                repuesto.Cantidad_Stock -= item.Cantidad;
            }

            context.SaveChanges();
        }
    }
}
