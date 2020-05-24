using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Security;

namespace InversionImagen
{
	class Program
	{
		static void Main(string[] args)
		{
            String ruta = "D:/Users/Usuario/Desktop/Test/Mario.bmp";
            Version1(ruta);
            Version2(ruta);
            Version3(ruta);
            Version4(ruta);
            Version5(ruta);

		}

        
        public static Bitmap Version1(string bitmapFilePath)
        {
        
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
            result.Save("D:/Users/Usuario/Desktop/Test/Out1.bmp", ImageFormat.Bmp);
            return result;
        }

        public static void Version2(string bitmapFilePath)
        {

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

            result.Save("D:/Users/Usuario/Desktop/Test/Out2.bmp", ImageFormat.Bmp);
         
        }

        public static void Version3(string bitmapFilePath)
        {

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
            result.Save("D:/Users/Usuario/Desktop/Test/Out3.bmp", ImageFormat.Bmp);

        }

        public static void Version4(String bitmapFilePath) {
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
            result.Save("D:/Users/Usuario/Desktop/Test/Out4.bmp", ImageFormat.Bmp);

        }



        public static void Version5(String bitmapFilePath) {

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
            result.Save("D:/Users/Usuario/Desktop/Test/Out5.bmp", ImageFormat.Bmp);
        }

    }

    
}
