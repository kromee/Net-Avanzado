// See https://aka.ms/new-console-template for more information
using CamparaObjetos;

Console.WriteLine("Hello, World!");

ElementoporValor elementopor = new ElementoporValor();
elementopor.valor1 = 1;
elementopor.valor2 = 1;
bool valor = elementopor.IsEquals();
try {
    Console.WriteLine(valor);
    Console.WriteLine("Terminado");


    ElemPorReferencia();
    TestElementoIEquatable();

    TestElementoIComparable();
}
catch (Exception ex) {
    Console.WriteLine("Error "+ ex.Message);
}


 void ElemPorReferencia() {

    ElementosPorReferencia elem1 = new ElementosPorReferencia()
    {
        valor1 = 1,
        valor2 = 2

    };

    ElementosPorReferencia elem2 = new ElementosPorReferencia()
    {
        valor1 = 1,
        valor2 = 2

    };

    bool elementosIguales = elem1 == elem2;
    ElementosPorReferencia copia = elem1;
    bool igualCopia = copia == elem1;

}



void TestElementoIEquatable()
{
    ElementoIEquatable elemento1 = new ElementoIEquatable()
    {
        valor1 = 1,
        valor2 = 2,
        Fecha = DateTime.UtcNow
    
    };

    ElementoIEquatable elemento2 = new ElementoIEquatable()
    {
        valor1 = 1,
        valor2 = 2,
        Fecha = DateTime.UtcNow.AddDays(1)
    };

    bool comparacion = elemento1 == elemento2;

}

 void TestElementoIComparable() {

    ElementoIComparar elemento1 = new ElementoIComparar(1, 2, DateTime.UtcNow);
    ElementoIComparar elemento2 = new ElementoIComparar(2, 2, DateTime.UtcNow);
    ElementoIComparar elemento3 = new ElementoIComparar(1, 2, DateTime.UtcNow);

    List<ElementoIComparar> listacomprarar = new List<ElementoIComparar>()
    {
        elemento1, elemento2, elemento3
    };

    List<ElementoIComparar> ordenados = listacomprarar.OrderBy(x => x).ToList();

}

