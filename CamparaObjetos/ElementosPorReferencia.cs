using System;
namespace CamparaObjetos
{
	public class ElementosPorReferencia
	{
		public int valor1 { get; set; }
		public int valor2 { get; set; }

		public static bool operator ==(ElementosPorReferencia c1, ElementosPorReferencia c2) {
			return c1.valor1 == c2.valor1 && c1.valor2 == c2.valor2;

		}

		public static bool operator !=(ElementosPorReferencia c1, ElementosPorReferencia c2) {
			return !(c1 == c2);
		}


	}
}

