using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pixel
{
    internal class CuerdaV:Vector
    {

        double t = 6;
        double l = 5;
        double elasticidad=0.4;

        public double T { get => t; set => t = value; }

        public CuerdaV() : base(0, 0)
        {

        }

        public Bitmap graficarCuerda(Bitmap pintura)
        {
            double x = 0;
             do
            {
                base.X0 = x;
                base.Y0 = procesoFourier(x);
                base.encender(pintura);
                x += 0.001;
            }while(x<=l);
            return pintura;
        }

        public double procesoFourier(double x)
        {
            //variables utiles
            double ak = 0;
            double bk = 0;
            double sum = 0; //solucion 
            int k=1;
            //formula de integral de simpson - no exacto | aproximacion
            do
            {

            ak=(2/l) * (l / 6) * (f(0) * Math.Sin((k * Math.PI * 0) / l)
                    + (4 * f(l / 2) * Math.Sin((k * Math.PI) / 2)))
                    + (f(l) * Math.Sin(k * Math.PI));

            bk = (2 / (k * Math.PI * elasticidad)) * (l / 6) * (g(0) * Math.Sin((k * Math.PI * 0) / l) 
                    + (4 * g(l / 2) * Math.Sin((k * Math.PI) / 2))) 
                    + (g(l) * Math.Sin(k * Math.PI));

            
            sum+=((ak*Math.Cos((k * Math.PI * elasticidad * T)/l))
                    +(bk*Math.Sin((k*Math.PI*elasticidad*T)/l)))*Math.Sin((k * Math.PI*x)/l);
            

                k++;
            }while(k<=20);
            return sum/1.8;
            
        }

        public double f(double x)
        {
            double res= (-x*(x-l))/ 15;
            return res;
        }

        public double g(double x)
        {
            return x/4;
        }
    }
}
