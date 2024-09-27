using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProyectoIt
{
    public class UnitTest
    {
        private readonly Calculadora _calculadora;
        public UnitTest()
        {
            _calculadora = new Calculadora();
        }

        [Fact]
        public void Sumar_DosNumerosPositivos()
        {
            var result = _calculadora.Sumar(3, 4);
            Assert.Equal(7, result);
        }

        [Fact]
        public void Restar_DosNumerosPositivos()
        {
            var result = _calculadora.Restar(10, 4);
            Assert.Equal(6, result);
        }

        [Fact]
        public void Multiplicar_DosNumerosPositivos()
        {
            var result = _calculadora.Multiplicar(3, 5);
            Assert.Equal(15, result);
        }

        [Fact]
        public void Dividir_DosNumerosPositivos()
        {
            var result = _calculadora.Dividir(10, 2);
            Assert.Equal(5.1, result);
        }

        [Fact]
        public void Dividir_EntreCero_ZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => _calculadora.Dividir(10, 0));
        }
    }
}
