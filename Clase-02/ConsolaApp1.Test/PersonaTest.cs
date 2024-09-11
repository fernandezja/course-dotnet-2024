using ConsoleApp1.Entidades;

namespace ConsolaApp1.Test
{
    public class PersonaTest
    {
        [Fact]
        public void Debe_crear_una_persona()
        {
            var p1 = new Persona();
            p1.Nombre = "Juan";
            p1.Apellido = "Perez";

            Assert.Equal("Juan", p1.Nombre);
            Assert.Equal("Perez", p1.Apellido);
        }


    }
}