using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodega_Manager.Entities;

namespace Bodega_Manager.Repositories
{
    public class MecanicoRepository
    {
        Bodega_RepuestosEntities1 context = new Bodega_RepuestosEntities1();

        public Mecanico BuscarMecanicoId(int id)
        {
            return context.Mecanicoes.FirstOrDefault(x => x.Codigo == id);
        }
    }
}
