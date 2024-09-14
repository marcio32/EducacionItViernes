using Data.Dtos;
using Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.ViewModels
{
    public class ProductosViewModels
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        public string? Imagen { get; set; }
        public bool Activo { get; set; }
        public IFormFile Imagen_Archivo { get; set; }

        public static implicit operator ProductosViewModels(ProductosDto productoDto)
        {
            var productoViewModel = new ProductosViewModels();
            productoViewModel.Id = productoDto.Id;
            productoViewModel.Descripcion = productoDto.Descripcion;
            productoViewModel.Precio = productoDto.Precio;
            productoViewModel.Stock = productoDto.Stock;
            productoViewModel.Imagen = productoDto.Imagen;
            productoViewModel.Activo = productoDto.Activo;
            return productoViewModel;
        }
    }
}
