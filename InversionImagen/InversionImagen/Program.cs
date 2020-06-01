using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace InversionImagen
{

    /*
     * Clase que representa un pixel con sus tres canales compuestos de variables de 8 bits de profundidad
     */
    class PixelByte {
        public Byte R;
        public Byte G;
        public Byte B;
    }

    /*
    * Clase que representa un pixel con sus tres canales compuestos de variables de 16 bits de profundidad
    */
    class PixelShort {
        public ushort R;
        public ushort G;
        public ushort B;
    }

    /*
   * Clase que representa un pixel con sus tres canales compuestos de variables de 32 bits de profundidad
   */
    class PixelInt {
        public UInt32 R;
        public UInt32 G;
        public UInt32 B;
    }

	class Program
	{

      
        static void Main(string[] args)
		{
          
            var csv = new StringBuilder();
            
            //Algoritmo para ejecutar todas las pruebas especificadas en los inputs
             for (int i=0;i<3;i++) {
                //Se leen los inputs
                var reader = new StreamReader(File.OpenRead("D:/Users/Usuario/Desktop/Experimento/Inputs.csv"));
                 while (!reader.EndOfStream)
                 {
                     int algoritmo;
                     int tam;
                     int prof;
                     var line = reader.ReadLine();
                     var values = line.Split(';');
                  
                     algoritmo = Int32.Parse(values[0]);
                     Console.WriteLine(algoritmo);
                     tam = Int32.Parse(values[1]);
                     prof = Int32.Parse(values[2]);
                     String ruta = "D:/Users/Usuario/Desktop/Experimento/" + tam + "/" + prof + ".bmp";
                    //Seleccion del algoritmo indicado en los inputs
                     if (algoritmo == 1)
                     {
                         var first = algoritmo;
                         var second = tam;
                         var third = prof;
                         var fourth = Version1(tam,prof);
                         var newLine = string.Format("{0},{1},{2},{3}", first, second, third, fourth);
                         csv.AppendLine(newLine);

                     }
                     else if (algoritmo == 2)
                     {
                         var first = algoritmo;
                         var second = tam;
                         var third = prof;
                         var fourth = Version2(tam,prof);
                         var newLine = string.Format("{0},{1},{2},{3}", first, second, third, fourth);
                         csv.AppendLine(newLine);

                     }
                     else if (algoritmo == 3)
                     {
                         var first = algoritmo;
                         var second = tam;
                         var third = prof;
                         var fourth = Version3(tam,prof);
                         var newLine = string.Format("{0},{1},{2},{3}", first, second, third, fourth);
                         csv.AppendLine(newLine);

                     }
                     else if (algoritmo == 4)
                     {
                         var first = algoritmo;
                         var second = tam;
                         var third = prof;
                         var fourth = Version4(tam,prof);
                         var newLine = string.Format("{0},{1},{2},{3}", first, second, third, fourth);
                         csv.AppendLine(newLine);

                     }
                     else if (algoritmo == 5)
                     {
                         var first = algoritmo;
                         var second = tam;
                         var third = prof;
                         var fourth = Version5(tam,prof);
                         var newLine = string.Format("{0},{1},{2},{3}", first, second, third, fourth);
                         csv.AppendLine(newLine);

                     }

                 }
             }
            File.WriteAllText("D:/Users/Usuario/Desktop/Experimento/Datos.txt", csv.ToString());
            


        }

        //Metodo para generar una matriz de la clase PixelByte con un tamaño especifico
        public static PixelByte[,] initByte(int tam) {

            PixelByte[,] mat = new PixelByte[tam, tam];
            for (int i=0;i<tam;i++) {
                for (int j=0;j<tam;j++) {
                    mat[i, j] = new PixelByte();
                }
            }

            return mat;
        
        }

        //Metodo para generar una matriz de la clase PixelShort con un tamaño especifico
        public static PixelShort[,] initShort(int tam)
        {

            PixelShort[,] mat = new PixelShort[tam, tam];
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                {
                    mat[i, j] = new PixelShort();
                }
            }

            return mat;

        }

        //Metodo para generar una matriz de la clase PixelInt con un tamaño especifico
        public static PixelInt[,] initInt(int tam)
        {

            PixelInt[,] mat = new PixelInt[tam, tam];
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                {
                    mat[i, j] = new PixelInt();
                }
            }

            return mat;

        }

        //Primera version del algoritmo de inversion
        public static long Version1(int tam, int prof)
        {
            Stopwatch timeA = new Stopwatch();
            timeA.Restart();
            long tiempo = 0;

            if (prof == 24) {
                PixelByte[,] input = initByte(tam);
                PixelByte[,] output = initByte(tam);
                timeA.Start();
                for (int i = 0; i < tam; i++)
                {
                    for (int j = 0; j < tam; j++)
                    {
                        output[i, j].R = (byte)(255-input[i, j].R);
                        output[i, j].G = (byte)(255 - input[i, j].G);
                        output[i, j].B = (byte)(255 - input[i, j].B); 
                    }
                }
                timeA.Stop();
                tiempo = (long)(timeA.Elapsed.TotalMilliseconds * 1000000);
                return tiempo;

            }
            else if (prof == 48) {
                PixelShort[,] input = initShort(tam);
                PixelShort[,] output = initShort(tam);
                timeA.Start();
                for (int i = 0; i < tam; i++)
                {
                    for (int j = 0; j < tam; j++)
                    {
                        output[i, j].R = (ushort)(255 - input[i, j].R);
                        output[i, j].G = (ushort)(255 - input[i, j].G);
                        output[i, j].B = (ushort)(255 - input[i, j].B);
                    }
                }
                timeA.Stop();
                tiempo = (long)(timeA.Elapsed.TotalMilliseconds * 1000000);
                return tiempo;

            }
            else {
                PixelInt[,] input = initInt(tam);
                PixelInt[,] output = initInt(tam);
                timeA.Start();
                for (int i = 0; i < tam; i++)
                {
                    for (int j = 0; j < tam; j++)
                    {
                        output[i, j].R = (UInt32)(255 - input[i, j].R);
                        output[i, j].G = (UInt32)(255 - input[i, j].G);
                        output[i, j].B = (UInt32)(255 - input[i, j].B);
                    }
                }
                timeA.Stop();
                tiempo = (long)(timeA.Elapsed.TotalMilliseconds * 1000000);
                return tiempo;

            }
          
        }

        //Segunda version del algoritmo de inversion
        public static long Version2(int tam, int prof)
        {
            Stopwatch timeA = new Stopwatch();
            timeA.Restart();
            long tiempo = 0;
            if (prof == 24)
            {
                PixelByte[,] input = initByte(tam);
                PixelByte[,] output = initByte(tam);
                timeA.Start();
                for (int i = 0; i < tam; i++)
                {
                    for (int j = 0; j < tam; j++)
                    {
                        output[i, j].R = (byte)(255-input[i, j].R);

                    }
                }

                for (int i = 0; i < tam; i++)
                {
                    for (int j = 0; j < tam; j++)
                    {
                        output[i, j].G = (byte)(255 - input[i, j].G);

                    }
                }


                for (int i = 0; i < tam; i++)
                {
                    for (int j = 0; j < tam; j++)
                    {
                        output[i, j].B = (byte)(255 - input[i, j].B);

                    }
                }
                timeA.Stop();
                tiempo = (long)(timeA.Elapsed.TotalMilliseconds * 1000000);
                return tiempo;

            }
            else if (prof == 48)
            {

                PixelShort[,] input = initShort(tam);
                PixelShort[,] output = initShort(tam);
                timeA.Start();
                for (int i = 0; i < tam; i++)
                {
                    for (int j = 0; j < tam; j++)
                    {
                        output[i, j].R = (ushort)(255 - input[i, j].R);

                    }
                }

                for (int i = 0; i < tam; i++)
                {
                    for (int j = 0; j < tam; j++)
                    {
                        output[i, j].G = (ushort)(255 - input[i, j].G);

                    }
                }


                for (int i = 0; i < tam; i++)
                {
                    for (int j = 0; j < tam; j++)
                    {
                        output[i, j].B = (ushort)(255 - input[i, j].B);

                    }
                }
                timeA.Stop();
                tiempo = (long)(timeA.Elapsed.TotalMilliseconds * 1000000);
                return tiempo;
            }
            else {
                PixelInt[,] input = initInt(tam);
                PixelInt[,] output = initInt(tam);
                timeA.Start();
                for (int i = 0; i < tam; i++)
                {
                    for (int j = 0; j < tam; j++)
                    {
                        output[i, j].R = (UInt32)(255 - input[i, j].R);

                    }
                }

                for (int i = 0; i < tam; i++)
                {
                    for (int j = 0; j < tam; j++)
                    {
                        output[i, j].G = (UInt32)(255 - input[i, j].G);

                    }
                }


                for (int i = 0; i < tam; i++)
                {
                    for (int j = 0; j < tam; j++)
                    {
                        output[i, j].B = (UInt32)(255 - input[i, j].B);

                    }
                }
                timeA.Stop();
                tiempo = (long)(timeA.Elapsed.TotalMilliseconds * 1000000);
                return tiempo;

            }
  
        }

        //Tercera version del algoritmo de inversion
        public static long Version3(int tam,int prof)
        {
            Stopwatch timeA = new Stopwatch();
            timeA.Restart();
            long tiempo = 0;
            if (prof == 24)
            {
                PixelByte[,] input = initByte(tam);
                PixelByte[,] output = initByte(tam);
                timeA.Start();

                for (int j = 0; j < tam; j++)   
                {
                    for (int i = 0; i < tam; i++)
                    {
                        output[i, j].R = (byte)(255 - input[i, j].R);
                        output[i, j].G = (byte)(255 - input[i, j].G);
                        output[i, j].B = (byte)(255 - input[i, j].B);
                    }
                }
                timeA.Stop();
                tiempo = (long)(timeA.Elapsed.TotalMilliseconds * 1000000);
                return tiempo;
            }
            else if (prof == 48)
            {
                PixelShort[,] input = initShort(tam);
                PixelShort[,] output = initShort(tam);
                timeA.Start();

                for (int j = 0; j < tam; j++)
                {
                    for (int i = 0; i < tam; i++)
                    {
                        output[i, j].R = (ushort)(255 - input[i, j].R);
                        output[i, j].G = (ushort)(255 - input[i, j].G);
                        output[i, j].B = (ushort)(255 - input[i, j].B);
                    }
                }
                timeA.Stop();
                tiempo = (long)(timeA.Elapsed.TotalMilliseconds * 1000000);
                return tiempo;

            }
            else
            {
                PixelInt[,] input = initInt(tam);
                PixelInt[,] output = initInt(tam);
                timeA.Start();

                for (int j = 0; j < tam; j++)
                {
                    for (int i = 0; i < tam; i++)
                    {
                        output[i, j].R = (UInt32)(255 - input[i, j].R);
                        output[i, j].G = (UInt32)(255 - input[i, j].G);
                        output[i, j].B = (UInt32)(255 - input[i, j].B);
                    }
                }
                timeA.Stop();
                tiempo = (long)(timeA.Elapsed.TotalMilliseconds * 1000000);
                return tiempo;

            }

        }

        //Cuarta version del algoritmo de inversion
        public static long Version4(int tam, int prof) {
            Stopwatch timeA = new Stopwatch();
            timeA.Restart();
            long tiempo = 0;
            if (prof == 24)
            {
                PixelByte[,] input = initByte(tam);
                PixelByte[,] output = initByte(tam);
                timeA.Start();
                for (int i = 0; i < tam; i++)
                {
                    for (int j = 0; j < tam; j++)
                    {
                        output[i, j].R = (byte)(255 - input[i, j].R);
                    }

                }

                for (int i = tam - 1; i >= 0; i--)
                {
                    for (int j = tam - 1; j >= 0; j--)
                    {
                        output[i, j].G = (byte)(255 - input[i, j].G);
                        output[i, j].B = (byte)(255 - input[i, j].B);
                    }
                }
                timeA.Stop();
                tiempo = (long)(timeA.Elapsed.TotalMilliseconds * 1000000);
                return tiempo;



            }
            else if (prof == 48)
            {
                PixelShort[,] input = initShort(tam);
                PixelShort[,] output = initShort(tam);
                timeA.Start();
                for (int i = 0; i < tam; i++)
                {
                    for (int j = 0; j < tam; j++)
                    {
                        output[i, j].R = (byte)(255 - input[i, j].R);
                    }

                }

                for (int i = tam - 1; i >= 0; i--)
                {
                    for (int j = tam - 1; j >= 0; j--)
                    {
                        output[i, j].G = (ushort)(255 - input[i, j].G);
                        output[i, j].B = (ushort)(255 - input[i, j].B);
                    }
                }
                timeA.Stop();
                tiempo = (long)(timeA.Elapsed.TotalMilliseconds * 1000000);
                return tiempo;

            }
            else
            {
                PixelInt[,] input = initInt(tam);
                PixelInt[,] output = initInt(tam);
                timeA.Start();
                for (int i = 0; i < tam; i++)
                {
                    for (int j = 0; j < tam; j++)
                    {
                        output[i, j].R = (byte)(255 - input[i, j].R);
                    }

                }

                for (int i = tam - 1; i >= 0; i--)
                {
                    for (int j = tam - 1; j >= 0; j--)
                    {
                        output[i, j].G = (UInt32)(255 - input[i, j].G);
                        output[i, j].B = (UInt32)(255 - input[i, j].B);
                    }
                }
                timeA.Stop();
                tiempo = (long)(timeA.Elapsed.TotalMilliseconds * 1000000);
                return tiempo;


            }

            

        }

        //Quinta version del algoritmo de inversion
        public static long Version5(int tam, int prof) {
            Stopwatch timeA = new Stopwatch();
            timeA.Restart();
            long tiempo = 0;
            if (prof == 24)
            {
                PixelByte[,] input = initByte(tam);
                PixelByte[,] output = initByte(tam);
                timeA.Start();
                for (int i = 0; i < tam - 1; i += 2)
                {

                    for (int j = 0; j < tam - 1; j += 2)
                    {
                        output[i, j].R = (byte)(255 - input[i, j].R);
                        output[i, j].G = (byte)(255 - input[i, j].G);
                        output[i, j].B = (byte)(255 - input[i, j].B);

                        output[i, j].R = (byte)(255 - input[i, j+1].R);
                        output[i, j].G = (byte)(255 - input[i, j+1].G);
                        output[i, j].B = (byte)(255 - input[i, j+1].B);

                        output[i, j].R = (byte)(255 - input[i+1, j].R);
                        output[i, j].G = (byte)(255 - input[i+1, j].G);
                        output[i, j].B = (byte)(255 - input[i+1, j].B);

                        output[i, j].R = (byte)(255 - input[i+1, j+1].R);
                        output[i, j].G = (byte)(255 - input[i+1, j+1].G);
                        output[i, j].B = (byte)(255 - input[i+1, j+1].B);
                    }

                }
                timeA.Stop();
                tiempo = (long)(timeA.Elapsed.TotalMilliseconds * 1000000);
                return tiempo;


            }
            else if (prof == 48)
            {
                PixelShort[,] input = initShort(tam);
                PixelShort[,] output = initShort(tam);
                timeA.Start();
                for (int i = 0; i < tam - 1; i += 2)
                {

                    for (int j = 0; j < tam - 1; j += 2)
                    {
                        output[i, j].R = (ushort)(255 - input[i, j].R);
                        output[i, j].G = (ushort)(255 - input[i, j].G);
                        output[i, j].B = (ushort)(255 - input[i, j].B);

                        output[i, j].R = (ushort)(255 - input[i, j + 1].R);
                        output[i, j].G = (ushort)(255 - input[i, j + 1].G);
                        output[i, j].B = (ushort)(255 - input[i, j + 1].B);

                        output[i, j].R = (ushort)(255 - input[i + 1, j].R);
                        output[i, j].G = (ushort)(255 - input[i + 1, j].G);
                        output[i, j].B = (ushort)(255 - input[i + 1, j].B);

                        output[i, j].R = (ushort)(255 - input[i + 1, j + 1].R);
                        output[i, j].G = (ushort)(255 - input[i + 1, j + 1].G);
                        output[i, j].B = (ushort)(255 - input[i + 1, j + 1].B);
                    }

                }
                timeA.Stop();
                tiempo = (long)(timeA.Elapsed.TotalMilliseconds * 1000000);
                return tiempo;

            }
            else
            {

                PixelInt[,] input = initInt(tam);
                PixelInt[,] output = initInt(tam);
                timeA.Start();
                for (int i = 0; i < tam - 1; i += 2)
                {

                    for (int j = 0; j < tam - 1; j += 2)
                    {
                        output[i, j].R = (UInt32)(255 - input[i, j].R);
                        output[i, j].G = (UInt32)(255 - input[i, j].G);
                        output[i, j].B = (UInt32)(255 - input[i, j].B);

                        output[i, j].R = (UInt32)(255 - input[i, j + 1].R);
                        output[i, j].G = (UInt32)(255 - input[i, j + 1].G);
                        output[i, j].B = (UInt32)(255 - input[i, j + 1].B);

                        output[i, j].R = (UInt32)(255 - input[i + 1, j].R);
                        output[i, j].G = (UInt32)(255 - input[i + 1, j].G);
                        output[i, j].B = (UInt32)(255 - input[i + 1, j].B);

                        output[i, j].R = (UInt32)(255 - input[i + 1, j + 1].R);
                        output[i, j].G = (UInt32)(255 - input[i + 1, j + 1].G);
                        output[i, j].B = (UInt32)(255 - input[i + 1, j + 1].B);
                    }

                }
                timeA.Stop();
                tiempo = (long)(timeA.Elapsed.TotalMilliseconds * 1000000);
                return tiempo;


            }
         
        }

    }

    
}
