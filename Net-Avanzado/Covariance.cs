using System;
using System.Collections.Generic;
using static Net_Avanzado.Covariance;

namespace Net_Avanzado
{
    public class Persona1
    {
        public string? Name { get; set; }
    }
    public class Empleado : Persona1
    {
        public int? IdPersona { get; set; }
    }
    public class Jefe : Empleado
    {
        public int Clave { get; set; }
    }
    public class Becario : Empleado
    {
        public string? maticula { get; set; }
    }

    public class Ejemplo
    {
        public void imprimir(List<Persona1> personas)
        {
            foreach (var persona in personas)
            {
                Console.WriteLine($"El elemento actual es de tipo {persona.GetType()}");
            }
        }
        public void imprimir(IEnumerable<Persona1> personas)
        {
            foreach (var persona in personas)
            {
                Console.WriteLine($"El elemento actual es de tipo {persona.GetType()}");
            }
        }

        public void RealizarAccionBecario(Action<Becario> actionBecario) {
            Becario b = new Becario();
            actionBecario(b);
        }

    }

    public class Covariance
    {
        public void CovarianceTest()
        {

            List<Persona1> personas = new List<Persona1>()
            {
                new Becario(),
                new Jefe(),

            };

            Ejemplo ejemplo = new Ejemplo();
            ejemplo.imprimir(personas);
        }

        public void CovarianceTest2()
        {

            List<Becario> becario = new List<Becario>()
            {
                new Becario(),
                new Becario(),

            };

            Ejemplo ejemplo = new Ejemplo();
            ejemplo.imprimir(becario);
        }

        public void ContravarianceTest3() {
            var actionBecario = new Action<Becario>(a => Console.WriteLine("Preparar el café"));
            Ejemplo ejemplo = new Ejemplo();
            ejemplo.RealizarAccionBecario(actionBecario);

            //var actionJefe = new Action<Jefe>(a => Console.WriteLine("Preparar zoom"));
            //ejemplo.RealizarAccionBecario(actionJefe);


            var actionEmpleado = new Action<Empleado>(a => Console.WriteLine("Trabaja"));
            ejemplo.RealizarAccionBecario(actionEmpleado);

        }

    }
}

