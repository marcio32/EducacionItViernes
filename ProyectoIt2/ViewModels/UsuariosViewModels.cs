using Data.Dtos;
using Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.ViewModels
{
    public class UsuariosViewModels
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Mail { get; set; }
        public string Clave { get; set; }
        public int Id_Rol { get; set; }
        public int? Codigo { get; set; }
        public bool Activo { get; set; }
        public IEnumerable<SelectListItem> Lista_Roles { get; set; }

        public static implicit operator UsuariosViewModels(UsuariosDto usuarioDto)
        {
            var usuarioViewModel = new UsuariosViewModels();
            usuarioViewModel.Id = usuarioDto.Id;
            usuarioViewModel.Nombre = usuarioDto.Nombre;
            usuarioViewModel.Apellido = usuarioDto.Apellido;
            usuarioViewModel.Mail = usuarioDto.Mail;
            usuarioViewModel.Fecha_Nacimiento = usuarioDto.Fecha_Nacimiento;
            usuarioViewModel.Id_Rol = usuarioDto.Id_Rol;
            usuarioViewModel.Clave = usuarioDto.Clave;
            usuarioViewModel.Activo = usuarioDto.Activo;

            return usuarioViewModel;
        }
    }
}
