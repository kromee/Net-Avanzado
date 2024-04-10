using System;
using System.Text.RegularExpressions;

namespace Net_Avanzado
{
	public class Coche {

		public string Modelo { get; set; }
		public  MarcaCcoche Marca { get; set; }
        public Coche(MarcaCcoche marca, string modelo) {
            Marca = marca;
            Modelo = modelo;

        }
	}

    public enum MarcaCcoche{
        Audi,
        Opel
    }

	public class Yield {


        public void EjemploYield()
        {
            List<Coche> coches = new List<Coche>()
            {
                new Coche(MarcaCcoche.Audi, "A3"),
                new Coche(MarcaCcoche.Audi, "A5"),
                new Coche(MarcaCcoche.Opel, "Vectra"),
                new Coche(MarcaCcoche.Opel, "Astra"),
            };

            foreach (string modelo in FiltrarCochesGetModelYield(coches)) {
                Console.WriteLine($"El modelo del coche es: {modelo}");
            }
        }


        public IEnumerable<string> FiltrarCochesGetModelYield(List<Coche> coches)
        {
            foreach (Coche coche in coches)
            {
                if (coche.Marca == MarcaCcoche.Opel)
                {
                    yield return coche.Modelo;
                }
            }
        }



    }



	
}

