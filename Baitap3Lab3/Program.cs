
using System;

namespace BaiTap3
{
    class DaThuc
    {
        private double[] heSo;

        public int Bac
        {
            get { return heSo.Length - 1; }
        }

        public DaThuc(int n)
        {
            if (n < 0)
                throw new ArgumentException("Bac da thuc phai >= 0");

            heSo = new double[n + 1];
        }

        public double this[int k]
        {
            get
            {
                if (k < 0 || k > Bac)
                    throw new IndexOutOfRangeException();

                return heSo[k];
            }
            set
            {
                if (k < 0 || k > Bac)
                    throw new IndexOutOfRangeException();

                heSo[k] = value;
            }
        }

        public static DaThuc operator +(DaThuc a, DaThuc b)
        {
            int n = Math.Max(a.Bac, b.Bac);
            DaThuc kq = new DaThuc(n);

            for (int i = 0; i <= n; i++)
            {
                double x = i <= a.Bac ? a[i] : 0;
                double y = i <= b.Bac ? b[i] : 0;

                kq[i] = x + y;
            }

            return kq;
        }

        public static DaThuc operator -(DaThuc a, DaThuc b)
        {
            int n = Math.Max(a.Bac, b.Bac);
            DaThuc kq = new DaThuc(n);

            for (int i = 0; i <= n; i++)
            {
                double x = i <= a.Bac ? a[i] : 0;
                double y = i <= b.Bac ? b[i] : 0;

                kq[i] = x - y;
            }

            return kq;
        }

        public double TinhGiaTri(double b)
        {
            double kq = 0;

            for (int i = Bac; i >= 0; i--)
            {
                kq = kq * b + heSo[i];
            }

            return kq;
        }

        public override string ToString()
        {
            string s = "";

            for (int i = Bac; i >= 0; i--)
            {
                if (heSo[i] == 0)
                    continue;

                double a = heSo[i];

                if (s != "")
                    s += a >= 0 ? " + " : " - ";
                else if (a < 0)
                    s += "-";

                double abs = Math.Abs(a);

                if (i == 0 || abs != 1)
                    s += abs.ToString();

                if (i >= 1)
                    s += "x";

                if (i >= 2)
                    s += "^" + i;
            }

            return s == "" ? "0" : s;
        }
    }

    internal class Program
    {
        static DaThuc NhapDaThuc()
        {
            int n;

            do
            {
                Console.Write("Nhap bac da thuc: ");
            }
            while (!int.TryParse(Console.ReadLine(), out n) || n < 0);

            DaThuc p = new DaThuc(n);

            for (int i = 0; i <= n; i++)
            {
                Console.Write("Nhap he so a{0}: ", i);
                p[i] = double.Parse(Console.ReadLine());
            }

            return p;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("NHAP DA THUC P");
            DaThuc p = NhapDaThuc();

            Console.WriteLine("\nNHAP DA THUC Q");
            DaThuc q = NhapDaThuc();

            Console.WriteLine("\nP(x) = " + p);
            Console.WriteLine("Q(x) = " + q);

            DaThuc tong = p + q;
            DaThuc hieu = p - q;

            Console.WriteLine("P + Q = " + tong);
            Console.WriteLine("P - Q = " + hieu);

            Console.Write("\nNhap gia tri x = ");
            double x = double.Parse(Console.ReadLine());

            Console.WriteLine("P({0}) = {1}", x, p.TinhGiaTri(x));
            Console.WriteLine("Q({0}) = {1}", x, q.TinhGiaTri(x));

            Console.ReadKey();
        }
    }
}
