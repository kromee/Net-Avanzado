// See https://aka.ms/new-console-template for more information
using Net_Avanzado;

Console.WriteLine("DELEGADOS");


/*Clase Delegados*/

Delegados delegados = new Delegados();
delegados.EjemploDelegado();

delegados.EjemploAction();
delegados.EjemploMetodoAnonimo();

delegados.EjemploFunc();
delegados.EjemploFun2();
delegados.EjemploPredicate();

Console.WriteLine("\n\n");

Console.WriteLine("EVENTOS");
SuscriptorOperacionesVirtual operaciones = new SuscriptorOperacionesVirtual(5, 6);
operaciones.OperacionSuma();
operaciones.OperacionResta();


Console.WriteLine("\n\n");

Console.WriteLine("EXPRESIONES LAMBDA");
ExpresionsLambda lambda = new ExpresionsLambda();
var mayor = lambda.MayorEdadLambda();

var mayor2 = lambda.MayorEdadLambda2();
Console.WriteLine($"{mayor2} son las personas mayores a 18 años");


