namespace pixel
{
    public partial class Form1 : Form
    {
        Bitmap pixelVector;
        Bitmap lienzo = new Bitmap(700, 420);

        bool[] banderas = {true,true, true, true, true, true, true, true, true };

        
        
        
        public Form1()
        {
            InitializeComponent();
            button1.BackColor = Color.LightGreen;
            button2.BackColor = Color.LightGreen;
            button3.BackColor = Color.LightGreen;
            button4.BackColor = Color.LightGreen;
            button5.BackColor = Color.LightGreen;
            button6.BackColor = Color.LightGreen;
            button7.BackColor = Color.LightGreen;
            button8.BackColor = Color.LightGreen;
            button9.BackColor = Color.LightGreen;
            
            for (int i = 0; i < 700; i++)
            {
                for(int j = 0; j <420; j++)
                {
                    lienzo.SetPixel(i,j, Color.White);
                }

            }
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            pixelVector = new Bitmap(520, 260);
            panel1.BackgroundImage = pixelVector;
            Color color0 = Color.Blue;

            Point point = panel1.PointToClient(Cursor.Position);
            int x = point.X;
            int y = point.Y;
            pixelVector.SetPixel(x, y, color0);
            panel1.Image = pixelVector;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap pintura = lienzo;
            Vector v = new Vector(0, 1);
            if (banderas[0]) pintura = v.encender(pintura);
            else pintura = v.apagar(pintura);
            v.X0 = -1; v.Y0 = 0;
            if (banderas[0]) pintura = v.encender(pintura);
            else pintura = v.apagar(pintura);
            v.X0 = 1; if (banderas[0]) pintura = v.encender(pintura);
            else pintura = v.apagar(pintura);
            v.X0 = 0; v.Y0 = 0; if (banderas[0]) pintura = v.encender(pintura);
            else pintura = v.apagar(pintura);
            v.X0 = 5; v.Y0 = 0; if (banderas[0]) pintura = v.encender(pintura);
            else pintura = v.apagar(pintura);
            v.Y0 = 3; if (banderas[0]) pintura = v.encender(pintura);
            else pintura = v.apagar(pintura);


            panel1.Image = v.encender(pintura);
            banderas[0] = !banderas[0];
            if (banderas[0])
                button1.BackColor = Color.LightGreen;
            else
                button1.BackColor = Color.PaleVioletRed;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            
            Segmento seg = new Segmento(-10, 0, 10, 0); seg.Color = Color.Red;
            lienzo = seg.encender(lienzo, banderas[1]);
            seg = new Segmento(0, -5.97, 0, 5.97);
            lienzo = seg.encender(lienzo,banderas[1]);
            panel1.Image = lienzo;
            if (banderas[1])
                button2.BackColor = Color.LightGreen;
            else
                button2.BackColor = Color.PaleVioletRed;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Segmento seg = new Segmento(7, 1.5, -7, 5);
            seg.Color = Color.Blue;
            lienzo = seg.encender(lienzo, banderas[2]);
            seg.Xo = 7; seg.Yo = 1.5; seg.Xf = -7; seg.Yf = -4;
            //seg = new Segmento(7, 1.5, -7, -4);
            lienzo = seg.encender(lienzo, banderas[2]);
            panel1.Image = lienzo;
            banderas[2] = !banderas[2];
            if (banderas[2])
                button3.BackColor = Color.LightGreen;
            else
                button3.BackColor = Color.PaleVioletRed;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Circunferencia c = new Circunferencia(1.3, 7, 1.5); c.Color = Color.Black;
            lienzo = c.encenderC(lienzo,banderas[3]);
            c.Rad = 2.5; c.X0 = -3.5; c.Y0 = 1;
            lienzo = c.encenderC(lienzo,banderas[3]);
            panel1.Image = lienzo;
            banderas[3] = !banderas[3];

            if (banderas[3])
                button4.BackColor = Color.LightGreen;
            else
                button4.BackColor = Color.PaleVioletRed;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Lazo l = new Lazo(0.4, -3.5, 2); l.Color = Color.DarkGreen;
            lienzo = l.encender(lienzo,banderas[4]);
            l.Rad = 1; l.X0 = 3; l.Y0 = -3;
            lienzo = l.encender(lienzo,banderas[4]);
            panel1.Image = lienzo;
            banderas[4] = !banderas[4];

            if (banderas[4])
                button5.BackColor = Color.LightGreen;
            else
                button5.BackColor = Color.PaleVioletRed;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Raiz r = new Raiz(0.8, 1.5, 4); r.Color = Color.Pink;
            lienzo = r.encenderR(lienzo,banderas[5]);
            panel1.Image = lienzo;
            banderas[5] = !banderas[5];

            if (banderas[5])
                button6.BackColor = Color.LightGreen;
            else
                button6.BackColor = Color.PaleVioletRed;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            espiral(2, 2, 2, 2, 5, 15, Color.Green);
            espiral(3, 4, 0, 0.5, 20, 20, Color.Black);
            espiral(4, 0, 1, 0.8, 15, 20, Color.Blue);
            banderas[6] = !banderas[6];

            if (banderas[6])
                button7.BackColor = Color.LightGreen;
            else
                button7.BackColor = Color.PaleVioletRed;
        }


        //proceso de espiral parametrizado
        public void espiral(double x, double y, double z, double radio, double elong, double vueltas, Color c)
        {
            double h = 0;
            vector3D V3D = new vector3D(0, 0, 0); V3D.Color = c;
            do
            { //ubicar al objeto en el espacio = [num] traslacion
                //radio = +[num] 
                //h/[num] mide la elongación del resorte mientras grande el numero mas compacto
                //h<= [num] mide cuentas vueltas da el espiral, mas vueltas aumentar num
                V3D.X = x + radio * Math.Cos(h);
                V3D.Y = y + radio * Math.Sin(h);
                V3D.Z = z + (h / elong);
                if (banderas[6])
                    lienzo = V3D.encender3d(lienzo);
                else
                    lienzo = V3D.apagar3d(lienzo);
                h += 0.002;
            } while (h <= vueltas);
            panel1.Image = lienzo;
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Segmento3D s3d = new Segmento3D();
            s3d.Color = Color.Red;
            s3d.Zf = 5;
            lienzo = s3d.encenderSeg3D(lienzo,banderas[7]);
            s3d.Zf = 0; s3d.Yf = 5;
            lienzo = s3d.encenderSeg3D(lienzo, banderas[7]);
            s3d.Yf = 0; s3d.Xf = 8;
            lienzo = s3d.encenderSeg3D(lienzo, banderas[7]);
            s3d = new Segmento3D(0, 0, 5, 8, 0, 5);
            lienzo = s3d.encenderSeg3D(lienzo, banderas[7]);
            s3d = new Segmento3D(8, 0, 5, 8, 0, 0);
            lienzo = s3d.encenderSeg3D(lienzo, banderas[7]);
            s3d = new Segmento3D(8, 0, 0, 8, 5, 0);
            lienzo = s3d.encenderSeg3D(lienzo, banderas[7]);
            s3d = new Segmento3D(8, 5, 0, 0, 5, 0);
            lienzo = s3d.encenderSeg3D(lienzo, banderas[7]);
            s3d = new Segmento3D(0, 5, 0, 0, 5, 5);
            lienzo = s3d.encenderSeg3D(lienzo, banderas[7]);
            s3d = new Segmento3D(0, 5, 5, 0, 0, 5);
            lienzo = s3d.encenderSeg3D(lienzo, banderas[7]);
            //mostrar segmentos
            panel1.Image = lienzo;
            banderas[7] = !banderas[7];

            if (banderas[7])
                button8.BackColor = Color.LightGreen;
            else
                button8.BackColor = Color.PaleVioletRed;
        }

        
        
        //datos lagrange
        //int[] b = { 0, 0 };
        //lagrange
        //public double lagrange(double x)
        //{
        //    double s = 0, p = 1;
        //    int i = 0, j = 0;
        //    int n = 4;//tamaño del vecto

        //    for (i = 0; i < n; i++)
        //    {
        //        p = 1;
        //        for (int j = 0; j < n; j++)
        //        {
        //            if (i != j)
        //            {
        //                p = p * (x - xj) / (xi - xj);
        //            }
        //        }
        //        s += (yi * p);
        //    }


        //    return s;
        //}

        private void button9_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 700; i++)
            {
                for(int j = 0; j < 420; j++)
                {

                    //int b = (int)((255) * ((i - 700) / -700));

                    //int b= (int)((-255 * (i - 700)) / 700);
                    //int g = (int)((255 * i) / 700);

                    //azul to aqua
                    //int g = (int)((245 *i) /700);

                    //blue to white to aque
                    //int r = (int)(-255 * (i/350)*((i-700)/350));
                    //int g = (int)((255*(i/350)*((i-700)/-350)) + (255*(i/700)*(i/350)));

                    if (i <= 700 / 2)
                    {
                        int red = (int)((51 * i) / 70);
                        int green = (int)((51 * i) / 70);
                        lienzo.SetPixel(i, j, Color.FromArgb(255, red > 255 ? 255 : red, green > 255 ? 255 : green, 255));
                    }
                    else
                    {
                        int red = (int)(510 - ((51 * i) / 70));
                        int green = (int)((256 * i) / 35);
                        lienzo.SetPixel(i, j, Color.FromArgb(255, red > 255 ? 255 : red, green > 255 ? 255 : green, 255));
                    }

                    
                   

                    //if (i > 350)
                    //{
                    //    lienzo.SetPixel(i, j, Color.Green);
                    //}
                    //else
                    //{
                    //    lienzo.SetPixel(i, j, Color.FromArgb(0,0,255));
                    //}
                    //lienzo.SetPixel(i, j, Color.FromArgb(255, 0, (int)((255 * i) / 700), (-255 * (i - 700)) / 700));

                }
            }
            panel1.Image = lienzo;
            banderas[8]=!banderas[8];
        }

        private void button10_Click(object sender, EventArgs e)
        {
            vector3D v3d= new vector3D(0,0,0);
            double t = -5;

            v3d.Color = Color.Blue;
            do
            {
                double h = -4;
                do
                {
                    v3d.X = t;
                    v3d.Y = h;
                    v3d.Z = 0.11 * (Math.Pow(t, 2) - Math.Pow(h, 2)) - 3;
                    v3d.encender3d(lienzo);
                    h += 0.13;
                } while (h <= 4);
                t += 0.13;
            } while (t <= 5);
            panel1.Image = lienzo;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //Dibujo de la parabola
            double t = -8;
            double dt = 0.001;
            Vector vector = new Vector(0,0);
            vector.Color = Color.Black;
            do
            {
                vector.X0 = t;
                vector.Y0 = (-Math.Pow(t, 2) - (12 * t) - 32)*1.4 ;
                lienzo = vector.encender(lienzo);
                t += dt;
            } while (t <= -4);
            //segunda parabola
            t = -4;
            do
            {
                vector.X0 = t;
                vector.Y0 = (-Math.Pow(t, 2) - (4 * t))*1.125;
                lienzo = vector.encender(lienzo);
                t += dt;
            } while (t <= 0);

            t = 0;
            //tercera parabola
            do
            {
                vector.X0 = t;
                vector.Y0 = (-Math.Pow(t, 2) + (4 * t))/1.33;
                lienzo = vector.encender(lienzo);
                t += dt;
            } while (t <= 4);

            //cuarta parabola
            t = 4;
            do
            {
                vector.X0 = t;
                vector.Y0 = (-Math.Pow(t, 2) + (12 * t)-32)/2.6;
                lienzo = vector.encender(lienzo);
                t += dt;
            } while (t <= 8);
            panel1.Image = lienzo;
        }

        private async void button12_Click(object sender, EventArgs e)
        {

            double t = -8;
            double dt = 0.3;
            Circunferencia cir = new Circunferencia(0.18, 0, 0);
            
            cir.Color = Color.Green;
            //primera animacion
            for (double i = t; i <=-4; i+=dt)
            {
                await Task.Delay(60);
                //limpiar lienzo
                lienzo= new Bitmap(700, 420);
                //fotograma
                button2.PerformClick();
                button11.PerformClick();
                //Thread.Sleep(200);
                
                cir.X0 = i;
                cir.Y0 = (-Math.Pow(t, 2) - (12 * t) - 32) * 1.4;
                lienzo = cir.encenderC(lienzo, true);

                panel1.Image = lienzo;
                //esperar x tiempo
                t += dt;                
            }

            //segunda animacion
            t = -4;
            for (double i = t; i <= 0; i += dt)
            {
                await Task.Delay(60);
                //limpiar lienzo
                lienzo = new Bitmap(700, 420);
                //fotograma
                button2.PerformClick();
                button11.PerformClick();
                

                cir.X0 = i;
                cir.Y0 = (-Math.Pow(t, 2) - (4 * t)) * 1.125;
                lienzo = cir.encenderC(lienzo, true);

                panel1.Image = lienzo;
                //esperar x tiempo
                t += dt;
            }

            //tercera animacion
            t = 0;
            for (double i = t; i <= 4; i += dt)
            {
                await Task.Delay(60);
                //limpiar lienzo
                lienzo = new Bitmap(700, 420);
                //fotograma
                button2.PerformClick();
                button11.PerformClick();


                cir.X0 = i;
                cir.Y0 = (-Math.Pow(t, 2) + (4 * t)) / 1.33;
                lienzo = cir.encenderC(lienzo, true);

                panel1.Image = lienzo;
                //esperar x tiempo
                t += dt;
            }
            //cuarta animacion
            t = 4;
            for (double i = t; i <= 8; i += dt)
            {
                await Task.Delay(60);
                //limpiar lienzo
                lienzo = new Bitmap(700, 420);
                //fotograma
                button2.PerformClick();
                button11.PerformClick();


                cir.X0 = i;
                cir.Y0 = (-Math.Pow(t, 2) + (12 * t) - 32) / 2.6;
                lienzo = cir.encenderC(lienzo, true);

                panel1.Image = lienzo;
                //esperar x tiempo
                t += dt;
            }
        }


        

        
        
        private void button13_Click(object sender, EventArgs e)
        {
            //valores de puntos
            List<Punto> red = new List<Punto>();
            red.Add(new Punto(0, 0));
            red.Add(new Punto(350,255)); 
            red.Add(new Punto(700, 0));
            
            List<Punto> green = new List<Punto>();
            green.Add(new Punto(0, 0));
            green.Add(new Punto(350, 255));
            green.Add(new Punto(700, 255));
            
            List<Punto> blue = new List<Punto>();
            blue.Add(new Punto(0, 255));
            blue.Add(new Punto(350, 255));
            blue.Add(new Punto(700, 255));
            
            TestFunctions fun = new TestFunctions();
            
            for (int i = 0; i < 700; i++)
            {
                for (int j = 0; j < 420; j++)
                {
                    int r = (int)fun.lagrange(red,i);
                    int g = (int) fun.lagrange(green,i);
                    int b= (int)fun.lagrange(blue, i);
                    lienzo.SetPixel(i, j, Color.FromArgb(255, r > 255 ? 255 : r, g > 255 ? 255 : g, b > 255 ? 255 : b));
                    //Console.WriteLine(b);
                }
            }
            panel1.Image = lienzo;
            //banderas[8] = !banderas[8];
        }

        private async void button14_Click(object sender, EventArgs e)
        {
            //pintar cir de radio 3
            
            double rad = 3;

            //pintar segmento
            Segmento seg = new Segmento(0, 0, 0, 0); seg.Color = Color.Blue;
            double t = 0;
            double dt = 0.04;
            do
            {
                lienzo = new Bitmap(700, 420);
                Circunferencia cir = new Circunferencia(3, 0, 0);
                lienzo = cir.encenderC(lienzo, true);

                seg.Xf=(rad * (Math.Cos(t)));
                seg.Yf=(rad * (Math.Sin(t)));


                lienzo = seg.encender(lienzo,true);
               
                t += dt;
                panel1.Image = lienzo;

                await Task.Delay(60);
            } while (t <= (2 * Math.PI));
            
            


            //pintar lienzo
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Vector v = new Vector(0, 0);
            Vector v1 = new Vector(0, 0);

            double t = -2;
            double dt = 0.001;
            do
            {
                v.Color = Color.Blue;
                v.X0 = t;
                v.Y0 = 1 / (t + 3);
                lienzo = v.encender(lienzo);

                v1.Color = Color.Black;
                v1.X0 = t;
                v1.Y0 = (0.3333) - (t / 9) + (Math.Pow(t, 2) / 27);
                lienzo = v1.encender(lienzo);
                t += dt;

            } while (t < 10);

            panel1.Image = lienzo;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Onda on = new Onda();
            lienzo= on.graficarOnda(lienzo);
            panel1.Image = lienzo;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Onda on = new Onda();
            lienzo = on.grafOnda3d(lienzo);
            panel1.Image = lienzo;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Onda on = new Onda();
            lienzo = on.interferencia(lienzo);
            panel1.Image = lienzo;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            lienzo= new Bitmap(700, 420);
            Onda on = new Onda();
            lienzo = on.interferencia3D(lienzo);
            panel1.Image = lienzo;
        }

        private async void button20_Click(object sender, EventArgs e)
        {
            double t = 0;
            double dtp = 0.05;

            Onda on = new Onda();
            do
            {
                on.TO = t;
               lienzo = on.graficarOnda(lienzo);
                t += dtp;
                panel1.Image = lienzo;
                await Task.Delay(5);
            } while (t < 6);
            

        }

        private async void button21_Click(object sender, EventArgs e)
        {
            double t = 0;
            double dtp = 0.05;

            Onda on = new Onda();
            do
            {
                on.TO = t;
                lienzo = on.interferencia(lienzo);
                t += dtp;
                panel1.Image = lienzo;
                await Task.Delay(5);
            } while (t < 6);
        }

        private async void button22_Click(object sender, EventArgs e)
        {
            double t = 0;
            double dtp = 0.05;

            Onda on = new Onda();
            do
            {
                on.TO = t;
                lienzo = on.grafOnda3d(lienzo);
                t += dtp;
                panel1.Image = lienzo;
                await Task.Delay(60);
                lienzo = new Bitmap(700, 420);
            } while (t < 6);

        }

        private async void button23_Click(object sender, EventArgs e)
        {
            double t = 0;
            double dtp = 0.05;

            Onda on = new Onda();
            do
            {
                on.TO = t;
                lienzo = on.interferencia3D(lienzo);
                t += dtp;
                panel1.Image = lienzo;
                await Task.Delay(60);
                lienzo = new Bitmap(700, 420);
            } while (t < 6);

        }

        private void button24_Click(object sender, EventArgs e)
        {
            lienzo = new Bitmap(700, 420);
            Onda on = new Onda();
            lienzo = on.huyguens(lienzo);
            panel1.Image = lienzo;
        }

        private async void button25_Click(object sender, EventArgs e)
        {
            double t = 0;
            double dtp = 0.05;

            Onda on = new Onda();
            do
            {
                on.TO = t;
                lienzo = on.huyguens(lienzo);
                t += dtp;
                panel1.Image = lienzo;
                panel1.Refresh();
            } while (t < 6);

        }

        private async void button26_Click(object sender, EventArgs e)
        {
            double t = 0;
            double dt = 0.03;
            Segmento seg = new Segmento(-7, -3, -2, 3);
            
            Circunferencia cir = new Circunferencia(0.18, 0, 0);
            cir.Color = Color.Green;
            do
            {
                seg.encender(lienzo,true);
                panel1.Image = lienzo;
                button2.PerformClick();
                button27.PerformClick();
                cir.X0 = (-7 * (1 - t) + (-2 * t));
                cir.Y0 = (-3 * (1 - t) + (3 * t));
                cir.encenderC(lienzo, true);
                t += dt;
                panel1.Image = lienzo;
                await Task.Delay(60);
                lienzo = new Bitmap(700, 420);
                

            } while (t <= 1);



            t = -2;
            dt = 0.1;
            

            for (double i = t; i <= 4; i += dt)
            {
                await Task.Delay(60);
                //limpiar lienzo
                lienzo = new Bitmap(700, 420);
                //fotograma
                button2.PerformClick();
                button27.PerformClick();
                //Thread.Sleep(200);

                cir.X0 = i;
                cir.Y0 = (((-Math.Pow(t, 2)) + (2 * t) + 8) / (4.5)) + 3;
                lienzo = cir.encenderC(lienzo, true);

                panel1.Image = lienzo;
                //esperar x tiempo
                t += dt;
            }


        }

        private void button27_Click(object sender, EventArgs e)
        {
            Circunferencia cir1 = new Circunferencia(0.4, -7, -3);
            cir1.encenderC(lienzo,true);
            panel1.Image = lienzo;
            cir1.X0 = -2; cir1.Y0 = 3;
            cir1.encenderC(lienzo, true);
            panel1.Image=lienzo;
            cir1.X0 = 1; cir1.Y0 = 5;
            cir1.encenderC(lienzo, true);
            panel1.Image = lienzo;
            cir1.X0 = 4; cir1.Y0 = 3;
            cir1.encenderC(lienzo, true);
            panel1.Image = lienzo;
            



        }

        private void button28_Click(object sender, EventArgs e)
        {
            CuerdaV cuerda = new CuerdaV();
            cuerda.graficarCuerda(lienzo);
            panel1.Image = lienzo;

        }

        private async void button29_Click(object sender, EventArgs e)
        {
            CuerdaV cuerda = new CuerdaV();
            double t = 0;
            double dtp = 0.02;

            
            do
            {
                cuerda.T = t;
                button2.PerformClick();
                lienzo = cuerda.graficarCuerda(lienzo);
                t += dtp;
                panel1.Image = lienzo;
                await Task.Delay(5);
                lienzo = new Bitmap(700, 420);
            } while (t < 15);

        }
    }
}
