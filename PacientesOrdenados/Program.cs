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

        while (!sR.EndOfStream)
            listaPacientes.Add(sR.ReadLine());

        sR.Close();
        List<string> listaAuxiliar = new List<string>(listaPacientes);


        int opcion = Menu();
        string[] vectorCampos;

        Console.Clear();
        //-------------- Mostramos los datos  -----------------
        if (opcion != 0)
        {
            Console.WriteLine("\n\tId  Paciente\t\t\t Movil\t   Fecha Nac. Edad Alt. Peso");
            Console.WriteLine("\t--- ---------------------------- --------- ---------- ---- ---- -----");
        }
        double totalPesoPacientes = 0.0;
        switch (opcion)
        {
            case 1:
                listaAuxiliar = new List<string>(listaPacientes);
                for (int i = 0; i < listaPacientes.Count; i++)
                {
                    vectorCampos = listaPacientes[i].Split(';');
                    listaAuxiliar[i] = AñadeCero(vectorCampos[0], 3) + ";" + listaPacientes[i];
                }
                listaAuxiliar.Sort((str1, str2) =>
                {
                    int id1 = int.Parse(str1.Substring(0, 3));
                    int id2 = int.Parse(str2.Substring(0, 3));
                    return id1.CompareTo(id2);
                });
                MuestraListaOrdenada(listaAuxiliar);
                listaAuxiliar.Clear();
                break;
            case 2:
                listaAuxiliar = new List<string>(listaPacientes);
                for (int i = 0; i < listaPacientes.Count; i++)
                {
                    vectorCampos = listaPacientes[i].Split(';');
                    listaAuxiliar[i] = vectorCampos[1] + ";" + listaPacientes[i];
                }
                listaAuxiliar.Sort();
                MuestraListaOrdenada(listaAuxiliar);
                listaAuxiliar.Clear();
                break;
            case 3:
                listaAuxiliar = new List<string>(listaPacientes);
                int añoActual, mesActual = 0, diaActual = 0, mesNacimiento = 0, diaNacimiento = 0, edad;
                DateTime fechaActual = DateTime.Now;
                añoActual = int.Parse(fechaActual.ToString("dd/MM/yyyy").Substring(6, 4));
                for (int i = 0; i < listaPacientes.Count; i++)
                {
                    vectorCampos = listaPacientes[i].Split(';');

                    edad = añoActual - int.Parse(vectorCampos[3].Substring(0, 4));
                    if (mesNacimiento > mesActual || (mesNacimiento == mesActual && diaNacimiento > diaActual))
                        edad = edad - 1;

                    listaAuxiliar[i] = AñadeCero(edad.ToString(), 3) + ";" + listaPacientes[i];
                }
                listaAuxiliar.Sort((str1, str2) =>
                {
                    int edad1 = int.Parse(str1.Substring(0, 3));
                    int edad2 = int.Parse(str2.Substring(0, 3));
                    return edad1.CompareTo(edad2);
                });
                MuestraListaOrdenada(listaAuxiliar);
                listaAuxiliar.Clear();
                break;
            case 4:
                listaAuxiliar = new List<string>(listaPacientes);
                for (int i = 0; i < listaPacientes.Count; i++)
                {
                    vectorCampos = listaPacientes[i].Split(';');
                    listaAuxiliar[i] = vectorCampos[4] + ";" + listaPacientes[i];
                }
                listaAuxiliar.Sort((str1, str2) =>
                {
                    int altura1 = int.Parse(str1.Substring(0, 3));
                    int altura2 = int.Parse(str2.Substring(0, 3));
                    return altura1.CompareTo(altura2);
                });
                MuestraListaOrdenada(listaAuxiliar);
                listaAuxiliar.Clear();
                break;
            case 5:
                listaAuxiliar = new List<string>(listaPacientes);
                for (int i = 0; i < listaPacientes.Count; i++)
                {
                    vectorCampos = listaPacientes[i].Split(';');
                    listaAuxiliar[i] = AñadeCero(vectorCampos[5], 5) + ";" + listaPacientes[i];
                }
                listaAuxiliar.Sort((str1, str2) =>
                {
                    double peso1 = Double.Parse(str1.Substring(0, 5));
                    double peso2 = Double.Parse(str2.Substring(0, 5));
                    return peso1.CompareTo(peso2);
                });
                MuestraListaOrdenada(listaAuxiliar);
                listaAuxiliar.Clear();
                break;
            case 6:
                foreach (string registro in listaPacientes)
                {
                    vectorCampos = registro.Split(';');

                    Console.WriteLine("\t{0} {1} {2} {3} {4}   {5}  {6}",
                         CuadraTexto(vectorCampos[0], 3), CuadraTexto(vectorCampos[1], 28, ' '), vectorCampos[2],
                         vectorCampos[3].Substring(6, 2) + "/" + vectorCampos[3].Substring(4, 2) + "/" + vectorCampos[3].Substring(0, 4),
                         CalculaEdad(vectorCampos[3]),
                         CuadraTexto(vectorCampos[4], 3), CuadraTexto(vectorCampos[5], 5));
                    totalPesoPacientes += Double.Parse(vectorCampos[5]);
                    CalculaEdad(vectorCampos[3]);
                }
                break;
        }

        Console.WriteLine("\n\n\t Pulsa una tecla para salir...");
        Console.ReadKey();
    }


    static int Menu()
    {
        int opcion = 0;


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

        opcion = CapturaEntero("Introduce una opción", 0, 6);


        //Console.WriteLine("\t\t║   6) Nombre Apellidos   ║");
        //Console.WriteLine("\t\t║                         ║");
        //Console.WriteLine("\t\t║   7) Sin ordenar        ║");

        return opcion;
    }
 
    static int CapturaEntero(string texto, int min, int max)
    {
        int num;
        bool numOk;
        do
        {
            Console.Write("\n\t{0} [{1}..{2}]: ", texto, min, max);
            numOk = Int32.TryParse(Console.ReadLine(), out num);
            if (!numOk)
                Console.WriteLine("\n\t** Error, el valor introducido no es un número entero **");
            else if (num < min || num > max)
            {
                numOk = false;
                Console.WriteLine("\n\t** Error, el valor introducido no se encuentra en el rango posible **");
            }
        } while (!numOk);

        return num;
    }
    static string CuadraTexto(string texto, int numCaracteres, char caracter)
    {
        if (texto.Length > numCaracteres)
            return texto.Substring(0, numCaracteres);
        while (texto.Length < numCaracteres)
            texto += caracter;

        return texto;
    }
    static string CuadraTexto(string texto, int numCaracteres)
    {
        string espacios = "                                    ";
        texto = espacios + texto;
        return texto.Substring(texto.Length - numCaracteres);
    }
    static string AñadeCero(string texto, int numCaracteres)
    {
        string ceros = "0000000000000000000000000000";
        texto = ceros + texto;
        return texto.Substring(texto.Length - numCaracteres);
    }
    static void MuestraListaOrdenada(List<string> listaOrdenada)
    {
        string[] vectorCampos;
        double totalPesoPacientes = 0.0;
        foreach (string registro in listaOrdenada)
        {
            vectorCampos = registro.Split(';');

            Console.WriteLine("\t{0} {1} {2} {3} {4}   {5}  {6}",
                 CuadraTexto(vectorCampos[1], 3), CuadraTexto(vectorCampos[2], 28, ' '), vectorCampos[3],
                 vectorCampos[4].Substring(6, 2) + "/" + vectorCampos[4].Substring(4, 2) + "/" + vectorCampos[4].Substring(0, 4),
                 CalculaEdad(vectorCampos[4]),
                 CuadraTexto(vectorCampos[5], 3), CuadraTexto(vectorCampos[6], 5));
            totalPesoPacientes += Double.Parse(vectorCampos[6]);
        }
        Console.WriteLine("\n\tEl peso medio de los pacientes es " + Math.Round(totalPesoPacientes / listaOrdenada.Count, 2));

    }
    static string CalculaEdad(string fecha) 
    {
        int añoActual, mesActual = 0, diaActual = 0, mesNacimiento = 0, diaNacimiento = 0, edad;
        DateTime fechaActual = DateTime.Now;
        añoActual = int.Parse(fechaActual.ToString("dd/MM/yyyy").Substring(6, 4));

        mesNacimiento = int.Parse(fecha.Substring(4, 2));
        diaNacimiento = int.Parse(fecha.Substring(5, 2));
        edad = añoActual - int.Parse(fecha.Substring(0, 4));

        if (mesNacimiento > mesActual || (mesNacimiento == mesActual && diaNacimiento > diaActual))
            edad = edad - 1;
        
        return edad.ToString();
    }
}