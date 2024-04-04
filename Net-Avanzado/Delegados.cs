using System;
namespace Net_Avanzado
{
	//public delegate void Imprimir(string valor);
    public delegate void Imprimir<T>(T valor);



    public class Delegados
	{
        public void ImprimirPantalla(string v)
        {
            Console.WriteLine(v);

        }

        public void ImprimirPantalla(int v) {
            Console.WriteLine($"el valor entero es {v}");
        }

        public void EjemploDelegado() {
            Imprimir<string> imprimirDelegado = new Imprimir<string>(ImprimirPantalla);
            imprimirDelegado("Imprime un String");

            Imprimir<int> imprimirEntero = new Imprimir<int>(ImprimirPantalla);
            imprimirEntero(10);

        }

        //action siempre retorna void
        public void EjemploAction() {
            Action<string> actionEjemplo = ImprimirPantalla;
            actionEjemplo("Imprime desde action");

        }

        public void EjemploMetodoAnonimo() {
            Action<string> actionEjemploAnonimo = delegate (string valor)
            {
                Console.WriteLine(valor);
            };
            actionEjemploAnonimo("Valor imprimir action método anónimo");

            Action<string> actionEjemploLambda = v => Console.WriteLine(v);
            actionEjemploLambda("Valor imprimir desde lambda método anónimo");

        }

        //Func tiene un valor de retorno, y acepta desde 1 a 16 valores
        public void EjemploFunc() {
            Func<int, string> delegadoFunc1 = v => $"El valor desde Func es {v}";
            Console.WriteLine(delegadoFunc1(20));
        }
        public void EjemploFun2() {
            Func<int, int, string> delegadoFunc2 = (x, y) => $"El valor es desde func con dos valores {x * y}";
            string result = delegadoFunc2(5, 6);
            Console.WriteLine(result);
        }

        public void EjemploPredicate() {
            Predicate<int> delegadoPredicate = v => v >= 18;
            bool val = delegadoPredicate(20);
            Console.WriteLine("Con Predicate el valor es mayor a 20 " + val);
        }





        


    }
}

