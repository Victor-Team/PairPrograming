using System.IO;
namespace Ejer2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese el nombre del archivo: ");
            string nombreFichero = Console.ReadLine();
            while (nombreFichero.Length < 1)
            {
                Console.WriteLine("El nombre no puede estar vacio");
                nombreFichero = Console.ReadLine();
            }
            Console.Write("Ingrese el número de líneas a mostrar: ");
            int n;
            while ((!int.TryParse(Console.ReadLine(), out n)) || (n < 0))
                    Console.WriteLine("Tiene que ser un numero positivo");
            try
            {
                List<string> lineas = File.ReadAllLines(nombreFichero).ToList();

                if (n < lineas.Count)
                    for (int i = 0; i < n; i++)
                        Console.WriteLine(lineas[lineas.Count - n + i]);
                else
                    foreach (string line in lineas)
                        Console.WriteLine(line);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}