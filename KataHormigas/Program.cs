using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataHormigas
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int a = 0;
            int n = 0;
            int t = 0;
            int ant = 0;

            int x = 0; //Aqui reinvente la rueda, esto lo use para identificar el patron A-> N-> T y saber cuantas habian vivas 
            int y = 0; //Contar partes del cuerpo era la parte facil
            int z = 0; //Vi otros lenguajes que escaneaban ANT de lo mas sencillo pero quise solucionarlo de mi cabeza

            var secuencia = "...ant...ant..nat.ant.t..ant...ant..ant..ant.anant..t";

            foreach(char c in secuencia)
            {
                  
                x++;        //Uso la variable X para ir contando por cual paso de la secuencia voy
                                    //Uso Y para identificar si encontre una cabeza "a"
                if (c == 'a') {     //Uso Z para identificar si encontre un torzo "n" justo despues de la cabeza "a"
                                    //si aparece una "t" justo despues, borro los contadores Y y Z, sumo 1 a las hormigas vivas, y vuelvo a empezar.
                    a++;
                    y = x;             
                } else if (c == 'n')
                {
                    n++;
                    if (y + 1 == x)
                    {
                        z = x;
                    }
                } else if (c == 't')
                {
                    t++;
                    if (z + 1 == x)
                    {
                        ant++;
                        y = 0;
                        z = 0;
                    }
                }
            }

            if (a > n && a > t)
            {
                Console.WriteLine($"Hay: {a-ant} hormigas muertas");
            }
            else if (n > a && n > t)
            {
                Console.WriteLine($"Hay: {n - ant} hormigas muertas");
            }
            else if (t > a && t > n)
            {
                Console.WriteLine($"Hay: {t - ant} hormigas muertas");
            }

        }
    }
}
