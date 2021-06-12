using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodega_Manager.Entities;

namespace Bodega_Manager.Repositories
{
    public class Factura_HeaderRepository
    {
        Bodega_RepuestosEntities1 context = new Bodega_RepuestosEntities1();
        public int CrearFacturaHeader(int Mecanico, decimal Total, int Cant)
        {
            Factura_Header adder = new Factura_Header()
            {
                Codigo_Mecanico = Mecanico,
                Costo_Total = Total,
                Cantidad_Repuestos = Cant,
                Fecha = DateTime.Now
            };

            context.Factura_Header.Add(adder);
            context.SaveChanges();

            return adder.Id;
        }

    }
}
