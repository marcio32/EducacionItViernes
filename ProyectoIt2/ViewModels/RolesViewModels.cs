using Data.Dtos;
using Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.ViewModels
{
    public class ServiciosViewModels
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        

        public static implicit operator ServiciosViewModels(ServiciosDto servicioDto)
        {
            var servicioViewModel = new ServiciosViewModels();
            servicioViewModel.Id = servicioDto.Id;
            servicioViewModel.Nombre = servicioDto.Nombre;
            servicioViewModel.Activo = servicioDto.Activo;

            return servicioViewModel;
        }
    }
}
