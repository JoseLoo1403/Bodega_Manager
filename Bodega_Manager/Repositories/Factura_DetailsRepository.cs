using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodega_Manager.Entities;

namespace Bodega_Manager.Repositories
{
    public class Factura_DetailsRepository
    {
        Bodega_RepuestosEntities1 context = new Bodega_RepuestosEntities1();
        public void CrearDetails(List<Factura_Detail> elements, int id)
        {
            foreach (var x in elements)
            {
                x.Id_Factura_Header = id;
                context.Factura_Detail.Add(x);
            }

            context.SaveChanges();
        }
    }
}
