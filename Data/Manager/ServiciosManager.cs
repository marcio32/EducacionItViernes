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
    public class ServiciosManager : BaseManager<Servicios>
    {
        public override Task<bool> Borrar(Servicios entity)
        {
            throw new NotImplementedException();
        }

        public override Task<Servicios> BuscarAsync()
        {
            throw new NotImplementedException();
        }

        public override async Task<List<Servicios>> BuscarListaAsync()
        {
            return  contextSingleton.Servicios.FromSqlRaw("ObtenerServicios").ToList();
        }

        public async Task<bool> GuardarServicio(Servicios servicios)
        {
            return contextSingleton.Database.ExecuteSqlRaw($"GuardarEditarServicios {servicios.Id}, {servicios.Nombre}, {servicios.Activo}") == 0;
        }

    }
}
