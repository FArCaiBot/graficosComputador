using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pixel
{
    internal class Onda
    {
        private Double tO=0;
        private static Color[] paleta4 = new Color[16];
 
        private void llenarPale()
        {
            int i;
            for (i = 0; i < 16; i++)
            {
                paleta4[i] = Color.FromArgb(255, 17*i, 0);
            }

        }


    private static Color[] paleta = 
            { 
            Color.Black,
            Color.Navy,
                Color.Green,
                Color.Aqua,
                Color.Red,
                Color.Purple,
                Color.Maroon,
                Color.LightGray,
                Color.DarkGray,
                Color.Blue,
                Color.Lime,
                Color.Silver,
                Color.Teal,
                Color.Fuchsia,
                Color.Yellow,
                Color.White
        };
        private static Color[] paleta2 =
            {
            Color.FromName("7d1128"),
            Color.Navy,
                Color.Green,
                Color.Aqua,
                Color.Red,
                Color.RosyBrown,
                Color.Black,
                Color.Sienna,
                Color.Orange,
                Color.Blue,
                Color.Lime,
                Color.Silver,
                Color.Teal,
                Color.RoyalBlue,
                Color.SeaShell,
                Color.White
        };



        private static Color[] paleta3 = new Color[16];

        public double TO { get => tO; set => tO = value; }

        public Bitmap graficarOnda(Bitmap pintura)
        {
            int i;
            int j;
            int color0;
            Color color;
            Vector vec = new Vector(0, 0);
            double v = 9.3, m = 1, w=2; 

            for (i = 0; i < 16; i++)
            {
                paleta3[i] = Color.FromArgb(0, (int)((-1.33 * (i - 15))+(17*i)),(int)((15*i)+30));
            }

            llenarPale();

            double x=0, y=0, z=0;
            for (i = 0; i < 700; i++)
            {
                for (j = 0; j <420; j++)
                {
                    double[] real=vec.vReal(i, j);
                    x= real[0];
                    y= real[1];
                    //llamar a transformar
                    z = w * (Math.Sqrt((x * x) + (y * y))) - (v * tO);
                    z = m * Math.Sin(z)+1;
                    color0 = (int)(z * 7.5);
                    color= paleta4[color0];
                    vec.X0 = i;
                    vec.Y0 = j;
                    pintura.SetPixel(i, j, color);

                }
            }
            return pintura;
        }

        public Bitmap grafOnda3d(Bitmap pintura)
        {
            vector3D v3 = new vector3D(0, 0, 0);
            v3.Color = Color.Black;
            double y, dt, h, dh;
            double w = 2.5, m=0.3, v=9.3;
            y = -8; dt = 0.1;
            double t = 1;
            do
            {
                h = -5;
                dh = 0.1;
                do
                {
                    v3.X = y;
                    v3.Y = h;
                    v3.Z= w * (Math.Sqrt(Math.Pow((y-0),2) + Math.Pow((h - 0), 2)))-(tO*v);
                    v3.Z = m * Math.Sin(v3.Z);
                    v3.encender3d(pintura);
                    h += dh;
                } while(h < 5);
                y += dt;
            }while (y<8);


            return pintura;
        }

        public Bitmap interferencia3D(Bitmap pintura)
        {
            vector3D v3 = new vector3D(0, 0, 0);
            v3.Color = Color.Black;
            double y, dt, h, dh;
            double w = 2.5, m = 0.3, v = 9.3;
            y = -8; dt = 0.1;
            double t = 1;
            do
            {
                h = -5;
                dh = 0.1;
                do
                {
                    v3.X = y;
                    v3.Y = h;
                    v3.Z = w * (Math.Sqrt(Math.Pow((y - 4), 2) + Math.Pow((h - 0), 2))) - (tO * v);
                    double z1 = m * Math.Sin(v3.Z);
                    
                    v3.Z = w * (Math.Sqrt(Math.Pow((y + 4), 2) + Math.Pow((h - 0), 2))) - (tO * v);
                    double z2 = m * Math.Sin(v3.Z);
                    v3.Z = z1 + z2;
                    
                    v3.encender3d(pintura);
                    h += dh;
                } while (h < 5);
                y += dt;
            } while (y < 8);


            return pintura;
        }

        public Bitmap interferencia(Bitmap pintura)
        {
            double x, y, z, z1, z2,z3;
            int color;
            Color c;
            double w = 3.2, m = 1, v = 9.3, t=0;
            for (int i = 0; i < 16; i++)
            {
                paleta3[i] = Color.FromArgb(0, (int)((-1.33 * (i - 15)) + (17 * i)), (int)((15 * i) + 30));
            }

            Vector ve = new Vector(0,0);
            for (int i = 0; i < 700; i++)
            {
                for (int j = 0; j < 420; j++)
                {
                    double[] val = ve.vReal(i, j);
                    x = val[0];
                    y  = val[1];

                    z1 = w * (Math.Sqrt(Math.Pow((x + 4), 2) + Math.Pow((y - 3.5), 2))) - (tO * v);
                    z2 = 2 * (Math.Sqrt(Math.Pow((x + 4), 2) + Math.Pow((y + 3.5), 2))) - (tO * v);

                    z1 = Math.Sin(z1) + 1;
                    z2 = Math.Sin(z2) + 1;

                    z = z1 + z2;

                    color = (int)(z * 3.75);
                    c = paleta[color];

                    pintura.SetPixel(i, j, c);

                }

            }
            return pintura;
        }

        public Bitmap huyguens(Bitmap pintura)
        {
            int i;
            int j;
            int color0;
            Color color;
            Vector vec = new Vector(0, 0);
            double v = 9.3, m = 1, w = 2.5;

            for (i = 0; i < 16; i++)
            {
                paleta3[i] = Color.FromArgb(0, (int)((-1.33 * (i - 15)) + (17 * i)), (int)((15 * i) + 30));
            }

            double x = 0, y = 0, z = 0,z1=0;
            for (i = 0; i < 700; i++)
            {
                for (j = 0; j < 420; j++)
                {
                    double[] real = vec.vReal(i, j);
                    x = real[0];
                    y = real[1];

                    z = 0;
                    for (int l = 0; l < 13; l++)
                    {

                        //llamar a transformar
                        //z1 = w * (Math.Sqrt(Math.Sqrt(x -6+l) +Math.Sqrt (y)) - (v * 1));
                        z1 = w * (Math.Sqrt(Math.Pow((x - 6 + l), 2) + Math.Pow((y), 2))) - (tO * v);
                        z += m * Math.Sin(z1);

                    }
                    
                    color0 = (int)((13+z)*(15.0/26.0));
                    color = paleta3[color0];
                    pintura.SetPixel(i, j, color);
                }
            }
            return pintura;
        }
    }
}
