using Common.Helpers;
using Data.Base;
using Data.Dtos;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Usuarios> ValidarUsuario(LoginDto loginDto)
        {
            return await contextSingleton.Usuarios.Include(x => x.Roles).FirstOrDefaultAsync(x => x.Mail == loginDto.Mail && x.Clave == EncryptHelper.Encriptar(loginDto.Password));
        }
    }
}
