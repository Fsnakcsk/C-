using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetSumTest
{
    class Program
    {
        static int getSum(int n) {

            int total = 0;
            int i;

            if (n < 0){
                Console.WriteLine("Please use positive number.");
                Environment.Exit(-1);
            }

            for (i = 1; i <= n; i++){
                total = total + i;
            }

            return total;
        }
        static void Main(string[] args) {
        
            int sum;

            sum = Program.getSum(100);
            Console.WriteLine("sum = "+ sum);

        }
    }
}
