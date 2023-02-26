using System;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;

namespace Ejercicio3
{
    class Paro
    {
        public const string SalidaFICH = "Salida.txt";
        static void Main(string[] args)
        {
                int añoPalmas = 2008;
                int añoTenerife = 2008;
                string[] lineas = File.ReadAllLines("paro.csv");
                string[] meses = {"enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviemrbe", "diciembre" };
                
                int aux =0;
            //crear salida

            FileStream ficheroSalida = null;

            try
            {
                ficheroSalida = File.Create(SalidaFICH);
                ficheroSalida.Close();
                Console.Clear();
                Console.WriteLine("Fichero de salida creado");
                Console.WriteLine("Pulsa una tecla para seguir");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            //introducir datos en Salida.txt

            StreamWriter Escritura = null;
            try
            {
                Escritura = new StreamWriter(SalidaFICH);
               
                Console.Clear();
                
                Escritura.WriteLine("AÑO;MES;MUNICIPIO;DATOS");   
                
                foreach (var linea in lineas)
                {
                    var valores = linea.Split(',');
                    int mesIndex = 0;

                    for (int i = 3; i < lineas.Length; i++)
                    {
                        if (valores[i].Contains("Palmas"))
                        {
                            for (int k = 0; k < meses.Length; k++)
                            {   
                                for (int j = 6; j < valores.Length; j++)
                                {
                                    int CantPalmas = 0;
                                  
                                    Int32.TryParse(valores[j], out CantPalmas);

                                    if (añoPalmas > 2018)
                                    {

                                        break;
                                    }
                                    else
                                    {

                                        if (Int32.TryParse(valores[3], out aux))
                                        {
                                            Escritura.WriteLine((añoPalmas) + ";" + meses[mesIndex++] + ";" + valores[3] + ";" + CantPalmas);

                                            if (mesIndex == 12)
                                            {
                                                mesIndex = 0;
                                                añoPalmas++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (valores[i].Contains("Tenerife"))
                        {
                            for (int k = 0; k < meses.Length; k++)
                            {   
                                for (int j = 6; j < valores.Length; j++)
                                {

                                    int CantTenerife = 0;

                                    Int32.TryParse(valores[j], out CantTenerife);

                                    if (añoTenerife > 2018)
                                    {
                                        Escritura.Close();
                                        break;
                                    }
                                    else
                                    {
                                        if (Int32.TryParse(valores[3], out aux))
                                        {
                                            Escritura.WriteLine((añoPalmas) + ";" + meses[mesIndex++] + ";" + valores[3] + ";" + CantTenerife);

                                            if (mesIndex == 12)
                                            {
                                                mesIndex = 0;
                                                añoPalmas++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("Datos CSV introducidos en salida.txt");
                Console.WriteLine("Pulse para continuar");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
