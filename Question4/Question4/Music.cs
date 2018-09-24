using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question4
{
    class Music
    {
        static void Main(string[] args)
        {
            Console.Write("Please input the number of different songs: ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("Please input the number of different songs, played before: ");
            int K = int.Parse(Console.ReadLine());
            Console.Write("Please input the number of songs in a playlist: ");
            int L = int.Parse(Console.ReadLine());

            int result = NumOfPlaylists(N, K, L);
            int answer = result % 1000000007;

            Console.WriteLine(answer);
            Console.ReadLine();
            
        }

        public static int Factorial(int n)
        {
            int f = 1;
            for (int i = 1; i <= n; i++)
            {
                f = f * i;
            }
            return f;
        }

        public static int NumOfPlaylists(int N, int K, int L)
            {

                int r = 0;
                int factorial = 0;

                if (K > N || (K == N && N == 1 && L > 1))
                {
                    return r;
                }

                if (K == 0)
                {
                    r = Factorial(N);
                    return r;
                }

                int blocks = (int)(L / (K + 1));
                //get all the L/(K+1) blocks
                for (int i = 1; i <= blocks; i++)
                {
                    
                    if( i % K != 0)
                    {
                        //Variation n elements, k+1 class
                        factorial = Factorial((N))/Factorial(N - K + 1);
                 
                    }

                    //Mix all blocks with L-K-1
                    r = factorial * (N - K) * Factorial((L - K - 1));
                }
                return r;

            }

          
        
    }
}
