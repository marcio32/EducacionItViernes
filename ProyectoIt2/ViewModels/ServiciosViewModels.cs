using Data.Dtos;
using Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.ViewModels
{
    public class RolesViewModels
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        

        public static implicit operator RolesViewModels(RolesDto rolDto)
        {
            var rolViewModel = new RolesViewModels();
            rolViewModel.Id = rolDto.Id;
            rolViewModel.Nombre = rolDto.Nombre;
            rolViewModel.Activo = rolDto.Activo;

            return rolViewModel;
        }
    }
}
