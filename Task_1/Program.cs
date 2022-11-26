using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_1
{
    internal class Program
    {
        const int M = 6;
        const int N = 4;
        static int[,] path = new int[N, M];

        static void Main(string[] args)
        {
            Random random = new Random();

            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    path[i, j] = random.Next(0, 20);

            Console.WriteLine("Не вспаханный огород:");
            PrintArray();

            ThreadStart threadStart = new ThreadStart(Gardener2);
            Thread thread = new Thread(threadStart);            
            thread.Start();                                     


            Console.WriteLine("Вспаханный двумя садовниками огород:");
            Console.WriteLine();
            Gardener1();
            PrintArray();

            Console.ReadKey();
        }

        static void PrintArray()
        {
            for (int i = 0; i < N; i++) 
            {

                for (int j = 0; j < M; j++)
                {

                    Console.Write(path[i, j] + "\t");

                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }

        static void Gardener1()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (path[i, j] >= 0)
                    {
                        int delay = path[i, j];
                        path[i, j] = -1;
                        Thread.Sleep(delay);
                        // PrintArray();
                    }
                }

            }
        }
        static void Gardener2()
        {
            for (int j = M - 1; j >= 0; j--)
            {
                for (int i = N - 1; i >= 0; i--)
                {
                    if (path[i, j] >= 0)
                    {
                        int delay = path[i, j];
                        path[i, j] = -2;
                        Thread.Sleep(delay);
                        // PrintArray();
                    }
                }

            }
        }
    }
}
