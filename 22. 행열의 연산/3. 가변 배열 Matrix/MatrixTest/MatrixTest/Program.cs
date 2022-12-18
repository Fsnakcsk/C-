using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTest
{
    class Matrix
    {
        protected double[][] m_ptr; //상속
        protected int m_row;
        protected int m_col;
        protected int m_precision; //소수점은 몇 개 자리까지 표시
        public Matrix()
        {
            m_row = 0;
            m_col = 0;
            m_precision = 0;
            m_ptr = null;
        }
        public Matrix(int row, int col)
        {
            m_row = row;
            m_col = col;
            m_precision = 0;

            m_ptr = new double[m_row][];
            for (int i = 0; i < m_row; i++)
            {
                m_ptr[i] = new double[m_col];
            }
        }
        public int row()
        {
            return m_row;
        }
        public int col()
        {
            return m_col;
        }
        public void set(int i, int j, double v)
        {
            m_ptr[i][j] = v;
        }
        public void print()
        {
            for (int i = 0; i < m_row; i++)
            {
                for (int j = 0; j < m_col; j++)
                {
                    Console.Write(m_ptr[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public Matrix add(Matrix m)
        {
            if (m_row != m.m_row || m_col != m.m_col)
            {
                Console.WriteLine("error occuer!!! - size mismatch");
                Environment.Exit(-1);
            }
            Matrix c = new Matrix(m_row, m_col);

            for (int i = 0; i < m_row; i++)
            {
                for (int j = 0; j < m_col; j++)
                {
                    c.m_ptr[i][j] = this.m_ptr[i][j] + m.m_ptr[i][j];
                }
            }
            return c;
        }
        public Matrix subtract(Matrix m)
        {
            if (m_row != m.m_row || m_col != m.m_col)
            {
                Console.WriteLine("error occuer!!! - size mismatch");
                Environment.Exit(-1);
            }
            Matrix c = new Matrix(m_row, m_col);

            for (int i = 0; i < m_row; i++)
            {
                for (int j = 0; j < m_col; j++)
                {
                    c.m_ptr[i][j] = this.m_ptr[i][j] - m.m_ptr[i][j];
                }
            }
            return c;
        }
        public Matrix multiply(int s)
        {
            Matrix c = new Matrix(m_row, m_col);

            for (int i = 0; i < m_row; i++)
            {
                for (int j = 0; j < m_col; j++)
                {
                    c.m_ptr[i][j] = s * this.m_ptr[i][j];
                }
            }
            return c;
        }
        public Matrix multiply(Matrix m)
        {
            if (m_col != m.m_row)
            {
                Console.WriteLine("error occuer!!! - size mismatch");
                Environment.Exit(-1);
            }
            //                    this    fomar
            //                     m*n     n*l
            Matrix c = new Matrix(m_row, m.m_col);

            for (int i = 0; i < m_row; i++)
            {
                for (int j = 0; j < m.m_col; j++)
                {
                    c.m_ptr[i][j] = 0;
                    for (int k = 0; k < m_col; k++)
                    {
                        c.m_ptr[i][j] = c.m_ptr[i][j] + m_ptr[i][k] * m.m_ptr[k][j];
                    }
                }
            }
            return c;
        }
        public void readDataFromConsle()
        {
            int row = m_row;
            int col = m_col;
            double[][] p = m_ptr;
            int i, j;
            for (i = 0; i < row; i++)

                for (j = 0; j < col; j++)
                {
                    double x;
                    Console.Write("data[" + i + "][" + j + "] = ");
                    x = double.Parse(Console.ReadLine());
                    p[i][j] = x;
                }
        }
        public override string ToString()
        {
            String tmp = "";
            for (int i = 0; i < m_row; i++)
            {
                for (int j = 0; j < m_col; j++)
                {
                    tmp = tmp + m_ptr[i][j] + " ";
                    //Console.Write(m_ptr[i][j] + " ");
                }
                tmp = tmp + "\n";
                //Console.WriteLine();
            }
            tmp = tmp + "\n";
            //Console.WriteLine();
            return tmp;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Matrix x = new Matrix(3, 4);
            Console.WriteLine("Type matrix  X(3,4):");
            x.readDataFromConsle();

            Matrix y = new Matrix(3, 4);
            Console.WriteLine("Type matrix  Y(3,4):");
            y.readDataFromConsle();

            Matrix w = new Matrix(4, 2);
            Console.WriteLine("Type matrix  W(4,2):");
            w.readDataFromConsle();

            Matrix z;

            Console.WriteLine(x);
            Console.WriteLine(y);


            z = x.add(y);      // 합 구하기
            Console.WriteLine(z);

            z = x.subtract(y); // 차 구하기
            Console.WriteLine(z);

            z = x.multiply(2); // 합 구하기 scalar mutiplication
            Console.WriteLine(z);


            Console.WriteLine(z);
            Console.WriteLine(w);

            z = x.multiply(w); // 합  구하기 
            Console.WriteLine(z);

        }
    }
}
