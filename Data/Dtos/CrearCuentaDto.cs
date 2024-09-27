using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class CrearCuentaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Clave { get; set; }
        public string Mail { get; set; }
        public int Id_Rol { get; set; } = 1;
        public bool Activo { get; set; } = true;
    }
}
