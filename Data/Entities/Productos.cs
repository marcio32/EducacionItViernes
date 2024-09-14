using Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Productos
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string? Imagen { get; set; }
        public bool Activo { get; set; }

        public static implicit operator Productos(ProductosDto productoDto)
        {
            var producto = new Productos();
            producto.Id = productoDto.Id;
            producto.Descripcion = productoDto.Descripcion;
            producto.Precio = productoDto.Precio;
            producto.Stock = productoDto.Stock;
            producto.Imagen = productoDto.Imagen;
            producto.Activo = productoDto.Activo;
            return producto;
        }
    }
}
