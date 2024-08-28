using Data.Base;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Manager
{
    public class UsuariosManager : BaseManager<Usuarios>
    {
        public override Task<bool> Borrar(Usuarios entity)
        {
            throw new NotImplementedException();
        }

        public override Task<Usuarios> BuscarAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<List<Usuarios>> BuscarListaAsync()
        {
            throw new NotImplementedException();
        }
    }
}
