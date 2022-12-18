using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * void movehanoi (int n, char form, char temp, char to) {
 * 
 *      만약 n = 1 이면, from => to
 *      아니면 
 *          movehanoi( n-1, from,  to , temp);
 *          moveHanoi(  1 , from, temp,  to );
 *          moveHanoi( n-1, temp, from,  to ); 
 * }
*/
namespace Hanoi
{
    class Program
    {
        static void moveHanoi(int n, char from, char temp, char to)
        {
          //  Console.WriteLine("n = {0}, from = {1}, temp ={2}, to = {3)", n, from, temp, to);
            if (n == 1)
            {
                Console.WriteLine(from + " => " + to);
                return ;
            }
            moveHanoi(n - 1, from, to, temp);
            moveHanoi(1, from, temp, to);
            moveHanoi(n - 1, temp, from, to);

        }

        static void Main(string[] args)
        {
            moveHanoi(3, 'A', 'B', 'C');
        }
    }
}
