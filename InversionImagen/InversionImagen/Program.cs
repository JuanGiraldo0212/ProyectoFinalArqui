using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Security;
using System.Text;

namespace InversionImagen
{
	class Program
	{

       
        

        static void Main(string[] args)
		{
            //StreamWriter sw = new StreamWriter("D:/Users/Usuario/Desktop/Experimento/Datos.txt");
            var csv = new StringBuilder();
            for (int i=0;i<3;i++) {
                var reader = new StreamReader(File.OpenRead("D:/Users/Usuario/Desktop/Experimento/Inputs.csv"));
                while (!reader.EndOfStream)
                {
                    int algoritmo;
                    int tam;
                    int prof;
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    algoritmo = Int32.Parse(values[0]);
                    tam = Int32.Parse(values[1]);
                    prof = Int32.Parse(values[2]);
                    String ruta = "D:/Users/Usuario/Desktop/Experimento/" + tam + "/" + prof + ".bmp";
                    if (algoritmo == 1)
                    {
                        var first = algoritmo;
                        var second = tam;
                        var third = prof;
                        var fourth = Version1(ruta);
                        var newLine = string.Format("{0},{1},{2},{3}", first, second, third, fourth);
                        csv.AppendLine(newLine);

                    }
                    else if (algoritmo == 2)
                    {
                        var first = algoritmo;
                        var second = tam;
                        var third = prof;
                        var fourth = Version2(ruta);
                        var newLine = string.Format("{0},{1},{2},{3}", first, second, third, fourth);
                        csv.AppendLine(newLine);

                    }
                    else if (algoritmo == 3)
                    {
                        var first = algoritmo;
                        var second = tam;
                        var third = prof;
                        var fourth = Version3(ruta);
                        var newLine = string.Format("{0},{1},{2},{3}", first, second, third, fourth);
                        csv.AppendLine(newLine);

                    }
                    else if (algoritmo == 4)
                    {
                        var first = algoritmo;
                        var second = tam;
                        var third = prof;
                        var fourth = Version4(ruta);
                        var newLine = string.Format("{0},{1},{2},{3}", first, second, third, fourth);
                        csv.AppendLine(newLine);

                    }
                    else if (algoritmo == 5)
                    {
                        var first = algoritmo;
                        var second = tam;
                        var third = prof;
                        var fourth = Version5(ruta);
                        var newLine = string.Format("{0},{1},{2},{3}", first, second, third, fourth);
                        csv.AppendLine(newLine);

                    }

                }
            }
            File.WriteAllText("D:/Users/Usuario/Desktop/Experimento/Datos.txt", csv.ToString());
            


        }

        
        public static long Version1(string bitmapFilePath)
        {

            Stopwatch timeA = new Stopwatch();
            timeA.Restart();
            timeA.Start();
            long tiempo = 0;



            Bitmap b1 = new Bitmap(bitmapFilePath);

            int height = b1.Height;
            int width = b1.Width;

            Bitmap result = new Bitmap(width, height);


            for (int i=0;i< width; i++) {
                for (int j=0;j< height; j++) {
                    Color col = b1.GetPixel(i, j);
                    var R = 255 - col.R;
                    var G = 255 - col.G;
                    var B = 255 - col.B;
                    result.SetPixel(i,j,Color.FromArgb(R,G,B));
                }
            }
            timeA.Stop();
            tiempo = (long)(timeA.Elapsed.TotalMilliseconds);
            result.Save("D:/Users/Usuario/Desktop/Test/Out1.bmp", ImageFormat.Bmp);
            return tiempo;
        }

        public static long Version2(string bitmapFilePath)
        {
            Stopwatch timeA = new Stopwatch();
            timeA.Restart();
            timeA.Start();
            long tiempo = 0;

            Bitmap b1 = new Bitmap(bitmapFilePath);

            int height = b1.Height;
            int width = b1.Width;

            Bitmap result = new Bitmap(width, height);

            
            for (int i=0;i< width; i++) {
                for (int j=0;j< height; j++) {
                    Color col = b1.GetPixel(i, j);
                    var R = 255 - col.R;
                    result.SetPixel(i, j, Color.FromArgb(R, col.G ,col.B));
                   
                }
            }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color col = b1.GetPixel(i, j);
                    Color pass = result.GetPixel(i,j);
                    var G = 255 - col.G;
                    result.SetPixel(i, j, Color.FromArgb(pass.R, G, col.B));

                }
            }


            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color col = b1.GetPixel(i, j);
                    Color pass = result.GetPixel(i, j);
                    var B = 255 - col.B;
                    result.SetPixel(i, j, Color.FromArgb(pass.R, pass.G, B));

                }
            }

            timeA.Stop();
            tiempo = (long)(timeA.Elapsed.TotalMilliseconds);
            result.Save("D:/Users/Usuario/Desktop/Test/Out2.bmp", ImageFormat.Bmp);
            return tiempo;
        }

        public static long Version3(string bitmapFilePath)
        {

            Stopwatch timeA = new Stopwatch();
            timeA.Restart();
            timeA.Start();
            long tiempo = 0;
            Bitmap b1 = new Bitmap(bitmapFilePath);

            int height = b1.Height;
            int width = b1.Width;

            Bitmap result = new Bitmap(width, height);


            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    Color col = b1.GetPixel(i, j);
                    var R = 255 - col.R;
                    var G = 255 - col.G;
                    var B = 255 - col.B;
                    result.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }
            timeA.Stop();
            tiempo = (long)(timeA.Elapsed.TotalMilliseconds);
            result.Save("D:/Users/Usuario/Desktop/Test/Out3.bmp", ImageFormat.Bmp);
            return tiempo;

        }

        public static long Version4(String bitmapFilePath) {
            Stopwatch timeA = new Stopwatch();
            timeA.Restart();
            timeA.Start();
            long tiempo = 0;
            Bitmap b1 = new Bitmap(bitmapFilePath);

            int height = b1.Height;
            int width = b1.Width;

            Bitmap result = new Bitmap(width, height);

            for (int i=0;i< width; i++) {
                for (int j=0;j<height;j++) {
                    Color col = b1.GetPixel(i, j);
                    var R = 255 - col.R;
                    result.SetPixel(i, j, Color.FromArgb(R, col.G, col.B));
                }
            
            }

            for (int i= width-1; i>=0;i--) {
                for (int j=height-1;j>=0;j--) {
                    Color col = b1.GetPixel(i, j);
                    Color pass = result.GetPixel(i, j);
                    var G = 255 - col.G;
                    var B = 255 - col.B;
                    result.SetPixel(i,j,Color.FromArgb(pass.R,G,B));
                }
            }
            timeA.Stop();
            tiempo = (long)(timeA.Elapsed.TotalMilliseconds);
            result.Save("D:/Users/Usuario/Desktop/Test/Out4.bmp", ImageFormat.Bmp);
            return tiempo;

        }



        public static long Version5(String bitmapFilePath) {
            Stopwatch timeA = new Stopwatch();
            timeA.Restart();
            timeA.Start();
            long tiempo = 0;

            Bitmap b1 = new Bitmap(bitmapFilePath);

            int height = b1.Height;
            int width = b1.Width;

            Bitmap result = new Bitmap(width, height);

            for (int i=0;i<width-1;i+=2) {

                for (int j=0;j<height-1;j+=2) {

                    Color col = b1.GetPixel(i, j);
                    Color col2 = b1.GetPixel(i, j+1);
                    Color col3 = b1.GetPixel(i+1, j);
                    Color col4 = b1.GetPixel(i+1, j+1);
                    result.SetPixel(i, j, Color.FromArgb(255-col.R, 255-col.G, 255-col.B));
                    result.SetPixel(i,j+1,Color.FromArgb(255-col2.R,255-col2.G,255-col2.B));
                    result.SetPixel(i+1, j, Color.FromArgb(255-col3.R, 255-col3.G, 255-col3.B));
                    result.SetPixel(i+1, j + 1, Color.FromArgb(255-col4.R, 255-col4.G, 255-col4.B));
                }
            
            }
            timeA.Stop();
            tiempo = (long)(timeA.Elapsed.TotalMilliseconds);
            result.Save("D:/Users/Usuario/Desktop/Test/Out5.bmp", ImageFormat.Bmp);
            return tiempo;
        }

    }

    
}
