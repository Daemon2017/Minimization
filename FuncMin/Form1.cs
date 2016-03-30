using System;
using System.Windows.Forms;

namespace Minimization
{
    public partial class Minimization : Form
    {
        public Minimization()
        {
            InitializeComponent();
        }

        double X, Y;
        double a, b;
        double acc;

        void metPolDil()
        {
            getValues();
            double x = 0;
            while ((b - a) >= acc)
            {
                x = (b + a) / 2;
                X = x - acc / 2;
                Y = x + acc / 2;
                if (f(X) >= f(Y))
                {
                    a = x;
                }
                else
                {
                    b = x;
                }
                x = b - a;
            }
            double res = ((b + a) / 2);
            label1.Text = res.ToString();
        }

        void metZolSech()
        {
            getValues();
            double gold = (Math.Sqrt(5) - 1) / 2;
            double c = b - gold * (b - a);
            double d = a + gold * (b - a);
            while (Math.Abs(c - d) > acc)
            {
                double fc = f(c);
                double fd = f(d);
                if (fc < fd)
                {
                    b = d;
                    d = c;
                    c = b - gold * (b - a);
                }
                else
                {
                    a = c;
                    c = d;
                    d = a + gold * (b - a);
                }
            }
            double res = ((b + a) / 2);
            label2.Text = res.ToString();
        }

        void metFib()
        {
            getValues();
            double[] Fibo = new double[] { 0, 1, 1 };
            double calcNum;
            double Y1, Y2;
            int N = 3;
            calcNum = (b - a) / (2 * acc);
            while (Fibo[2] < calcNum)
            {
                N++;
                Fibo[0] = Fibo[1];
                Fibo[1] = Fibo[2];
                Fibo[2] = Fibo[1] + Fibo[0];
            }
            X = (b - a) * Fibo[0] / Fibo[2] + a;
            Y = (b - a) * Fibo[1] / Fibo[2] + a;
            while (N > 1)
            {
                Y1 = f(X);
                Y2 = f(Y);
                if (Y1 <= Y2)
                {
                    b = Y;
                    Y = X;
                    X = a + Fibo[0] * (b - a) / Fibo[2];
                }
                else
                {
                    a = X;
                    X = Y;
                    Y = a + Fibo[1] * (b - a) / Fibo[2];
                }
                Fibo[2] = Fibo[1];
                Fibo[1] = Fibo[0];
                Fibo[0] = Fibo[2] - Fibo[1];
                N--;
            }
            double res = ((b + a) / 2);
            label3.Text = res.ToString();
        }

        double f(double x)
        {
            return 7 * Math.Pow(x, 2) - 10 * Math.Pow(x, 1) - 4;
        }

        double choose(double i)
        {
            if (i < 0)
            {
                return -i;
            }
            else
            {
                return i;
            }
        }

        void getValues()
        {
            acc = Convert.ToDouble(textBox3.Text);
            b = Convert.ToDouble(textBox1.Text);
            a = Convert.ToDouble(textBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                metPolDil();
            }
            if (checkBox2.Checked == true)
            {
                metFib();
            }
            if (checkBox3.Checked == true)
            {
                metZolSech();
            }
        }
    }
}
