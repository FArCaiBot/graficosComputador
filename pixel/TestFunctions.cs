using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pixel
{
    internal class TestFunctions
    {
        /**
         * Funcion que realiza el calculo de lagrande de manera automática, dado un conjunto de puntos
         */
        public double lagrange(List<Punto> puntos, int x)
        {
            double s = 0, p = 1;
            for (int i = 0; i < puntos.Count; i++)
            {
                p = 1;
                for (int j = 0; j < puntos.Count; j++)
                {
                    if(puntos[i].Y!=0)
                    {
                        if (i != j)
                        {
                            p = p * (x - puntos[j].X) / (puntos[i].X - puntos[j].X);
                        }

                    }
                    
                }
                s += (puntos[i].Y * p);

            }
            return s;

        }
    }
}
