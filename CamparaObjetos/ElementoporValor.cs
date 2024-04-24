using System;
namespace CamparaObjetos
{
	public class ElementoporValor
	{
        public int valor1 { get; set; }
        public int valor2 { get; set; }

	

		public bool IsEquals() {
			if (valor1.Equals(valor2)) return true;
			return false;
		}
	
	}
}

