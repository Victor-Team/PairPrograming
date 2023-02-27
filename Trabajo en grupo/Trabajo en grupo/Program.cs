using System.Drawing;
using System.IO;
namespace Ejer4
{
    class Program
    {
        public const string NOMFICH = "Datos notas.csv";
        public const string EXITFICH = "Salida.txt";
        static void Main(string[] args)
        {
            StreamReader reader = null;
            StreamWriter writer = null;
            try
            {
                reader = new StreamReader(NOMFICH);
                writer = new StreamWriter(EXITFICH);
                int i = 1;
                while (!reader.EndOfStream)
                {
                    if (i % 2 != 0)
                    {
                        string linea = reader.ReadLine();
                        string[] datos = linea.Split(';');
                        int[] notas = new int[datos.Length - 1];
                        for (int j = 0; j < notas.Length; j++) notas[j] = int.Parse(datos[j + 1]);
                        double notaEjercicios = ((notas[0] + notas[1] + notas[2])/3 * 0.3);
                        double notaIntervenciones = ((notas[3] + notas[4] + notas[5])/3 * 0.2);
                        double notaExamenes = (notas[6] + notas[7])/2 * 0.5;
                        int notaFinal = (int)(notaEjercicios + notaIntervenciones + notaExamenes);
                        writer.WriteLine(datos[0] + ";"+ notaFinal);
                        i++;
                    }
                    else
                    {
                        string linea = reader.ReadLine();
                        i++;
                    }
                }
                reader.Close();
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}