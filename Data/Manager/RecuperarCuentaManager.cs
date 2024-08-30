using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Base;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Manager
{
    public class RecuperarCuentaManager : BaseManager<Usuarios>
    {
        public override Task<bool> Borrar(Usuarios entity)
        {
            throw new NotImplementedException();
        }

        public override Task<Usuarios> BuscarAsync()
        {
            throw new NotImplementedException();
        }

        public override async Task<List<Usuarios>> BuscarListaAsync()
        {
            return await contextSingleton.Usuarios.Where(x=> x.Activo == true).ToListAsync();
        }
    }
}
