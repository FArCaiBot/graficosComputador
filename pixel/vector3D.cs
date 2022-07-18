using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pixel
{
    internal class vector3D : Vector
    {
        double x = 0;
        double y = 0;
        double z = 0;

        public vector3D(double x, double y, double z):base(0,0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Z { get => z; set => z = value; }

        public void axonometria()
        {
            base.X0= y - (x / 2) * Math.Cos(Math.PI / 4);
            base.Y0= z - (x/2) * Math.Sin(Math.PI / 4);            
        }

        public Bitmap encender3d(Bitmap pintura)
        {
            axonometria();
            return encender(pintura);
        }

        public Bitmap apagar3d(Bitmap pintura)
        {
            axonometria();
            return apagar(pintura);
        }

    }

}
