using System;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;

namespace Ejercicio3
{

    class Paro
    {
        public const string SalidaFICH = "Salida.txt";
        public const string ParoFICH = "paro.csv";

        static void Main(string[] args)
        {



            //crear salida
            
             FileStream ficheroSalida=null;
            
            try
            {
                ficheroSalida = File.Create(SalidaFICH);
                ficheroSalida.Close();
                Console.Clear();
                Console.WriteLine("Fichero de salida creado");
                Console.WriteLine("Pulsa una tecla para seguir");
                Console.ReadKey();
            }
          catch(Exception ex)
            {
              Console.WriteLine(ex.Message);

            }

            StreamWriter Escritura=null;
            try
            {
                Escritura = new StreamWriter(SalidaFICH);
                Console.Clear();
                Escritura.WriteLine("AÑO;MES;MUNICIPIO;DATOS");
                int CantPalmas = 0;
                int CantTenerife = 0;
                int aux = 0;
                int año = 2008;
                string[] lineas = File.ReadAllLines("paro.csv");
                string[] meses = { "enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviemrbe", "diciembre" };

                foreach (var linea in lineas)
                {
                    var valores = linea.Split(',');

                    for (int i = 3; i < lineas.Length; i++)
                    {
                        if (valores[i].Contains("Palmas"))
                        {
                            for (int j = 6; j < valores.Length; j++)
                            {
                                Int32.TryParse(valores[j], out aux);
                                CantPalmas += aux;
                            }

                            for (int k = 0; k < meses.Length; k++)
                                Escritura.WriteLine((año++) + ";" + meses[k] + ";" + valores[3] + ";" + CantPalmas);
                        }
                        if (valores[i].Contains("Tenerife"))
                        {
                            for (int j = 6; j < valores.Length; j++)
                            {
                                Int32.TryParse(valores[j], out aux);
                                CantTenerife += aux;
                            }

                            for (int k = 0; k < meses.Length; k++)
                                Escritura.WriteLine((año++) + ";" + meses[k] + ";" + valores[3] + ";" + CantTenerife);
                        }
                    }

                }
            }
            catch(Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }
        
        }
    }
}