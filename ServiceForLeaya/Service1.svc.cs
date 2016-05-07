using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceForLeaya
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService1
    {
    public Complexdata[] gauss_c(Complexdata[] ww, int n)
    {
        int nn = n;

        Complex[,] w = oneToMany(ww, nn);

        n = n - 1;
        Complex c, d, t;
        Complex cn = new Complex(0, 0);
        int i, j, k, l;
        //Прямой ход
        for (k = 1; k < n; k++)
        {  //Перестановка строк по максимальному значению
            l = k;
            for (i = k + 1; i <= n; i++)
                if (Complex.abs(w[i, k]) > Complex.abs(w[l, k]))
                    l = i;
            if (l != k)
                for (j = 0; j <= n; j++)
                    if (j == 0 || j >= k)
                    {
                        t = w[k, j];
                        w[k, j] = w[l, j];
                        w[l, j] = t;
                    }  //Конец перестановки строк
            int kk = k;
            d = 1 / w[k, k];
            for (i = k + 1; i <= n; i++)
            {
                if (w[i, k] == cn) continue;
                c = w[i, k] * d;
                for (j = k + 1; j <= n; j++)
                    if (w[k, j] != cn) w[i, j] -= c * w[k, j];
                if (w[k, 0] != cn) w[i, 0] -= c * w[k, 0];
            }
        }
        //Обратный ход
        w[0, n] = -1 * (w[n, 0] / w[n, n]);//?????-1*(
        for (i = n - 1; i >= 1; i--)
        {
            t = w[i, 0];
            for (j = i + 1; j <= n; j++)
                t += w[i, j] * w[0, j];
            w[0, i] = -1 * (t / w[i, i]);//????
        }

           Complexdata[] retun = ManyToone(w, nn);

           return retun;
    }


        public Complexdata[] ManyToone(Complex[,] c, int n)
        {

            Complex[] mat = new Complex[c.Length];
            int k = 0;
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    mat[k] = new Complex(c[i, j].Real, c[i, j].Imaginary);
                    k++;
                }
            }

            Complexdata[] comdata = new Complexdata[mat.Length];

            for (int z = 0; z < mat.Length; z++)
            {
                comdata[z] = new Complexdata() { Real = (double)mat[z].Real, Imaginary = (double)mat[z].Imaginary };

            }
            return comdata;

        }

        public Complex[,] oneToMany(Complexdata[] c, int n)
        {
            Complex[] com = new Complex[c.Length];

            for (int z = 0; z < c.Length; z++)
            {
                com[z] = new Complex(c[z].Real, c[z].Imaginary);

            }

            Complex[,] mat = new Complex[n + 1, n + 1];
            int k = 0;
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    mat[i, j] = new Complex(com[k].Real, com[k].Imaginary);
                    k++;
                }
            }
            return mat;

        }
    }
}
