using System;
namespace Net_Avanzado
{
	public class Eventos
	{
		public delegate void EjemploDelegado();
		public event  EjemploDelegado? EjemploEvento;

		public void Sumar(int a, int b) {
			if (EjemploEvento != null)
			{
                EjemploEvento();
                Console.WriteLine($"La suma es:{a + b} ");
            }
			else {
                Console.WriteLine("No está suscrito al evento en la suma");
            }
		
		}
        public void Restar(int a, int b)
        {
            if (EjemploEvento != null)
            {
                EjemploEvento();
                Console.WriteLine($"La resta es:{a - b} ");
            }
            else
            {
                Console.WriteLine("No está suscrito al evento en la resta ");
            }
           
        }

		
    }

    public class SuscriptorOperacionesVirtual{

        private Eventos eventos;
        private int A, B;

        public void EjemploEventHandler() {
            Console.WriteLine("La operación será ejecutada");
        }

        public SuscriptorOperacionesVirtual(int a, int b) {
            eventos = new Eventos();

            A = a;
            B = b;

            eventos.EjemploEvento += EjemploEventHandler;
        }

        public void OperacionSuma() {
            eventos.Sumar(A, B);
        }

        public void OperacionResta() {
            eventos.Restar(A, B);
        }



    }
}

