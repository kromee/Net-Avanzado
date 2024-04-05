using System;
namespace Net_Avanzado
{
	public class ExpresionsLambda
	{

	

		Func<int, bool> mayorEdad = edad =>edad>=18;
		public int MayorEdadLambda() {
			List<Persona> personas = new List<Persona>()
			{
				new Persona(){ Id=1, edad=30, Nombre= "Eduardo", Apellidos="Dome"},

                new Persona(){ Id=2, edad=10, Nombre= "Carlos", Apellidos="Dome"},

                new Persona(){ Id=3, edad=4, Nombre= "Mario", Apellidos="Dome"},

                new Persona(){ Id=4, edad=10, Nombre= "Richar", Apellidos="Dome"}
            };

			List<Persona> mayorEdadPersona1 = personas.Where(a => mayorEdad(a.edad)).ToList();
			return mayorEdadPersona1.Count();

        }

        public int MayorEdadLambda2()
        {
            List<Persona> personas = new List<Persona>()
            {
                new Persona(){ Id=1, edad=30, Nombre= "Eduardo", Apellidos="Dome"},

                new Persona(){ Id=2, edad=10, Nombre= "Carlos", Apellidos="Dome"},

                new Persona(){ Id=3, edad=50, Nombre= "Mario", Apellidos="Dome"},

                new Persona(){ Id=4, edad=10, Nombre= "Richar", Apellidos="Dome"}
            };

            List<Persona> mayorEdadPersona2 = personas.Where(a => a.edad >= 18 ).ToList();
            return mayorEdadPersona2.Count();

        }

    }

	public class Persona {
		public int Id { get; set; }
		public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public int edad { get; set; }
		
	}
}

