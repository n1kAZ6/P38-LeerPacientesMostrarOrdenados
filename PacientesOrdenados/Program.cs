using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


class Program
{
	static void Main(string[] args)
	{
		StreamReader sR = new StreamReader(".\\Datos\\Pacientes.txt", Encoding.Default);	
		List<string> listaPacientes = new List<string>();

		while(!sR.EndOfStream)
			listaPacientes.Add(sR.ReadLine());

		sR.Close();

		int opcion = Menu();
		string[] vectorCampos;

        Console.Clear();
        //-------------- Mostramos los datos  -----------------

        Console.WriteLine("\n\tId  Paciente\t\t\t\tMovil\t\tFecha Nac.\tAlt.\t Peso");
        Console.WriteLine("\n\t---------------------------------------------------------------------------------------");
        switch (opcion)
		{
			case 1:
				break;
			case 2:
				break;
			case 3:
				break;
			case 4:
				break;
			case 5:
				break;
			case 6:
			foreach (string registro in listaPacientes) 
			{
				vectorCampos = registro.Split(';');

				Console.WriteLine("\t{0} {1} {2} {3} {4} {5}", 
					  vectorCampos[0], vectorCampos[1], vectorCampos[2], vectorCampos[3], vectorCampos[4], vectorCampos[5]);
			}
				break;
		}
		
		

        


        Console.WriteLine("\n\n\t Pulsa una tecla para salir");
		Console.ReadKey();
	}


	static int Menu()
    {
		int opcion = 0;
		
		do
		{
			Console.Clear();
			Console.WriteLine("\n\n\t\t╔═════════════════════════╗");
			Console.WriteLine("\t\t║   Ordenar datos por...  ║");
			Console.WriteLine("\t\t╠═════════════════════════╣");
			Console.WriteLine("\t\t║   1) id                 ║");
			Console.WriteLine("\t\t║                         ║");
			Console.WriteLine("\t\t║   2) Apellidos, Nombre  ║");
			Console.WriteLine("\t\t║                         ║");
			Console.WriteLine("\t\t║   3) Edad (creciente)   ║");
			Console.WriteLine("\t\t║                         ║");
			Console.WriteLine("\t\t║   4) Altura             ║");
			Console.WriteLine("\t\t║                         ║");
			Console.WriteLine("\t\t║   5) Peso               ║");
			Console.WriteLine("\t\t║                         ║");
			Console.WriteLine("\t\t║   6) Sin ordenar        ║");
			Console.WriteLine("\t\t║_________________________║");
			Console.WriteLine("\t\t║                         ║");
			Console.WriteLine("\t\t║      0)  Salir          ║");
			Console.WriteLine("\t\t╚═════════════════════════╝");

			opcion =CapturaEntero("Introduce una opción",0,6);

			//Pausa("continuar...");
			
		} while (opcion < 0 || opcion > 6);



		//Console.WriteLine("\t\t║   6) Nombre Apellidos   ║");
		//Console.WriteLine("\t\t║                         ║");
		//Console.WriteLine("\t\t║   7) Sin ordenar        ║");

		return opcion;
	}
	static void Pausa(string texto) 
	{
		Console.WriteLine("\n\tPulse una tecla para {0}",texto);
		Console.ReadKey(true);
	}
	static int CapturaEntero(string texto, int min, int max) 
	{
		int num;
		bool numOk;
		do
		{
			Console.Write("\n\t{0} [{1}..{2}]: ",texto,min,max);
			numOk=Int32.TryParse(Console.ReadLine(), out num);
			if (!numOk)
				Console.WriteLine("\n\t** Error, el valor introducido no es un número entero **");
			else if (num < min || num > max)
			{
				numOk=false;
				Console.WriteLine("\n\t** Error, el valor introducido no se encuentra en el rango posible **");
			}
		} while (!numOk);

		return num;
	}
	static string CuadraTexto(string texto, int numCaracteres, char caracter) 
	{
		if(texto.Length>numCaracteres)
			return texto.Substring(0,numCaracteres);
		while (texto.Length < numCaracteres)
			texto += caracter;

		return texto;
	}

}

