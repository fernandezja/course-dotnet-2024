using ConsoleApp1.Entidades;

namespace ConsolaApp1.Test
{
    public class CuentaCorrienteTest
    {
        [Fact]
        public void Test1()
        {
            var resultado = 1 + 1;
            Assert.Equal(2, resultado);
            
        }


        [Fact]
        public void Crear_una_instancia_de_cuenta_corrriente()
        {
            CuentaCorriente c1 = new ConsoleApp1.Entidades.CuentaCorriente();
            var c2 = new ConsoleApp1.Entidades.CuentaCorriente();
            var c3 = new CuentaCorriente();
            CuentaCorriente c4 = new();

            Assert.NotNull(c1);
            Assert.NotNull(c2);
            Assert.NotNull(c3);
            Assert.NotNull(c4);
        }

        [Fact]
        public void Depositar_test()
        {
            var c1 = new CuentaCorriente();

            c1.Depositar(100);
            //c1.Saldo = 1000;

            Assert.Equal(100, c1.Saldo);
        }

        [Fact]
        public void Titular_test()
        {
            var c1 = new CuentaCorriente();

            var p1 = new Persona();
            p1.Nombre = "Juan";
            p1.Apellido = "Perez";

            c1.Titular = p1;

            Assert.Equal("Juan", c1.Titular.Nombre);
            Assert.Equal("Perez", c1.Titular.Apellido);

            p1.Nombre = "Xarlos";
            Assert.Equal("Xarlos", c1.Titular.Nombre);

        }

        [Fact]
        public void Extraer_test()
        {
            var c1 = new CuentaCorriente();
            c1.Depositar(100);

            var resultado = c1.Extraer(99);

            Assert.Equal(99, resultado);

        }

        [Fact]
        public void Extraer_sin_saldo_test()
        {
            var c1 = new CuentaCorriente();
            c1.Depositar(100);
        
            var resultado = c1.Extraer(500);
        
            Assert.Equal(500, resultado);
        
        }
    }
}