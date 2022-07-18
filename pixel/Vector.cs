using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pixel
{
    internal class Vector
    {
        //valores del vector
        double x0;
        double y0;

        
        // color del vector
        Color color = Color.Red;

        double x1=-10, x2=10, y1=-5.98, y2=5.98;
        //double x1 = -20, x2 = 20, y1 = -11.96, y2 =11.96;
        double sx1=0, sx2=700, sy1=0, sy2=420;


        //factor de proporcionalidad 1.67 width/high
        public int[] pantalla(double x,double y)
        {
            int sx = (int)((((x-x1)/(x1-x2))*(sx1-sx2))+sx1);
            int sy = (int)((((y-y2)/(y2-y1))*(sy1-sy2))+sy1);
            return new int[] {sx, sy};
            
        }

        public double[] vReal(int sx, int sy)
        {
            double x = (((sx - sx1) / (sx1 - sx2)) * (x1 - x2)) + x1;
            double y = (((sy - sy1) / (sy1 - sy2)) * (y2 - y1)) + y2;

            return new double[] { x,y };
        }
        
        /**
         * llamar al proceso pantalla  de x0, y0
         * devuelve sx,sy
         */
        public Bitmap encender(Bitmap pintura)
        {   
            int[] cordenadas = pantalla(X0, Y0);
            pintura.SetPixel(cordenadas[0], cordenadas[1], color);
            return pintura;
        }
        public Bitmap apagar(Bitmap pintura)
        {
            int[] cordenadas = pantalla(X0, Y0);
            pintura.SetPixel(cordenadas[0], cordenadas[1], Color.White);
            return pintura;
        }


        //constructor

        public Vector(double x0, double y0)
        {
            this.X0 = x0;
            this.Y0 = y0;
        }
                
        public Color Color { get => color; set => color = value; }
        public double X0 { get => x0; set => x0 = value; }
        public double Y0 { get => y0; set => y0 = value; }
    }
}
