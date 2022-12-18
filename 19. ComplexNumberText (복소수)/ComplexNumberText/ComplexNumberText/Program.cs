using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumberText
{
    class ComplexNumber
    {
        double m_x;
        double m_y;
        public ComplexNumber()
        {
            m_x = m_y = 0;
        }                       //    real   imaginary
        public ComplexNumber(double x, double y)
        {
            m_x = x;
            m_y = y;
        } 
        public double real()
        {
            return m_x;
        }
        public double imaginary()
        {
            return m_y; 
        }
        public double magnitude()
        {
            return Math.Sqrt(m_x * m_x + m_y * m_y);
        }
        public static double magnitude(ComplexNumber n)
        {
            return Math.Sqrt(n.m_x * n.m_x + n.m_y * n.m_y);
        }//                                    b
        public ComplexNumber add(ComplexNumber c) 
        { //                            a1.2    b 2.1     a         b
            return new ComplexNumber(this.m_x + c.m_x, this.m_y + c.m_y);
        }
        public static ComplexNumber add(ComplexNumber x, ComplexNumber y)
        { //                           a1.2    b 2.1    a      b
            return new ComplexNumber(x.m_x + y.m_x, x.m_y + y.m_y);
        }
        public ComplexNumber subtract(ComplexNumber c)
        {
            return new ComplexNumber(m_x - c.m_x, m_y - c.m_y);
        }
        public ComplexNumber multiply(ComplexNumber c)
        {
            double realPart = m_x * c.m_x - m_y * c.m_y;
            double imaginaryPart = m_x * c.m_y + m_y * c.m_x;

            return new ComplexNumber(realPart, imaginaryPart);
        }
        static public ComplexNumber multiply(ComplexNumber x, ComplexNumber y)
        {
            double realPart = x.m_x * y.m_x - x.m_y * y.m_y;
            double imaginaryPart = x.m_x * y.m_y + x.m_y * y.m_x;

            return new ComplexNumber(realPart, imaginaryPart);
        }
        // override 원래 있던 함수를 해야 될 기능을 내 마음대로 변경해서 사용할 수 있는 것이다.
        public override String ToString()
        {
            return "" + m_x + "+" + m_y + "i";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber a = new ComplexNumber(1.2, 1.5);
            ComplexNumber b = new ComplexNumber(2.1, 3.2);
            ComplexNumber c;

            //   receiver 객체
            Console.WriteLine("magitude of a = " + a.magnitude());
            //   static function
            Console.WriteLine("magitude of a = " + ComplexNumber.magnitude(a));

//-------------< 합 >---------------------------------------------------------------------
            //   receiver 객체
            c = a.add(b); // 프고르래머에 입장에서 a야 add를 해라 b를 줄테니까 - 이런 형태는 (receiver객체)
            Console.WriteLine("a + b = " + c.real() + " + " + c.imaginary() + "i");

            //   static function
            c = ComplexNumber.add(a,b);
            Console.WriteLine("a + b = " + c.real() + " + " + c.imaginary() + "i");

//-------------< 곱 >---------------------------------------------------------------------
            c = a.multiply(b);                //   receiver 객체
            Console.WriteLine("a * b = " + c.real() + " + " + c.imaginary() + "i");

            c = ComplexNumber.multiply(a, b); //   static function
            Console.WriteLine("a * b = " + c.real() + " + " + c.imaginary() + "i");
//-------------< ToString >---------------------------------------------------------------
            Console.WriteLine("=====================================================");
            Console.WriteLine(a + "," + b + "," + c);
            Console.WriteLine(a.ToString());



        }
    }
}
