//ejercicio#3 
using System;
using System.Collections.Generic;

namespace Diccionario
{



    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Tuple<string, string>> diccionario = CrearDiccionario();
            Traducir(diccionario);

            Console.ReadKey();
        }

        public static List<Tuple<string, string>> CrearDiccionario()
        {
            List<Tuple<string, string>> diccionario = new List<Tuple<string, string>>();
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Ingrese la palabra en inglés: ");
                string palabraIngles = Console.ReadLine();

                Console.Write("Ingrese la palabra en español: ");
                string palabraEspanol = Console.ReadLine();

                diccionario.Add(new Tuple<string, string>(palabraIngles, palabraEspanol));
            }

            return diccionario;
        }

        public static void Traducir(List<Tuple<string, string>> diccionario)
        {
            Console.Write("Ingrese la palabra a traducir: ");
            string clave = Console.ReadLine();

            bool encontrado = false;

            foreach (var duo in diccionario)
            {
                if (duo.Item1.Equals(clave, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"La traducción de la palabra {clave} es: {duo.Item2}.");
                    encontrado = true;
                    break;
                }

                if (duo.Item2.Equals(clave, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"La traducción de la palabra {clave} es: {duo.Item1}.");
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine($"La palabra {clave} no se encontró en el diccionario.");
            }
        }
    }

}

