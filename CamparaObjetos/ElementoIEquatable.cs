using System;
namespace CamparaObjetos
{
	public class ElementoIEquatable: IEquatable<ElementoIEquatable>
	{

        public int valor1 { get; set; }
        public int valor2 { get; set; }
        public DateTime Fecha { get; set; }



        public static bool operator ==(ElementoIEquatable c1, ElementoIEquatable c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(ElementoIEquatable c1, ElementoIEquatable c2)
        {
            return !c1.Equals(c2);
        }


        //Comparamos los objetos, pero sin tener en cuenta la fecha.
        public bool Equals(ElementoIEquatable other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return valor1 == other.valor1 && valor2 == other.valor2;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals((ElementoIEquatable)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(valor1, valor2);
        }

    }
}

