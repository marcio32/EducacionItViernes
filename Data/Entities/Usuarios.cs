﻿using Common.Helpers;
using Data.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Mail { get; set; }
        public string Clave { get; set; }
        [ForeignKey("Roles")]
        public int Id_Rol { get; set; }
        public int? Codigo { get; set; }
        public bool Activo { get; set; }

        public Roles Roles { get; set; }

        public static implicit operator Usuarios(CrearCuentaDto crearCuentaDto)
        {
            var usuario = new Usuarios();
            usuario.Id = crearCuentaDto.Id;
            usuario.Nombre = crearCuentaDto.Nombre;
            usuario.Apellido = crearCuentaDto.Apellido;
            usuario.Fecha_Nacimiento = crearCuentaDto.Fecha_Nacimiento;    
            usuario.Mail = crearCuentaDto.Mail;
            usuario.Clave = crearCuentaDto.Clave; 
            usuario.Id_Rol = crearCuentaDto.Id_Rol;
            usuario.Activo = crearCuentaDto.Activo;
            return usuario;
        }

        public static implicit operator Usuarios(UsuariosDto usuariosDto)
        {
            var usuario = new Usuarios();
            usuario.Id = usuariosDto.Id;
            usuario.Nombre = usuariosDto.Nombre;
            usuario.Apellido = usuariosDto.Apellido;
            usuario.Fecha_Nacimiento = usuariosDto.Fecha_Nacimiento;
            usuario.Mail = usuariosDto.Mail;
            usuario.Clave = usuariosDto.Clave;
            usuario.Id_Rol = usuariosDto.Id_Rol;
            usuario.Codigo = usuariosDto.Codigo;
            usuario.Activo = usuariosDto.Activo;
            return usuario;
        }
    }
}
