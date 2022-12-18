using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTest
{
    class Matrix
    {
        int[,] m_ptr;
        int m_row;
        int m_col;
        public Matrix(int row, int col)
        {
            m_row = row;
            m_col = col;
            m_ptr = new int[m_row, m_col];
        }
        public int row()
        {
            return m_row;
        }
        public int col()
        {
            return m_col;
        }
        public void set(int i, int j, int v)
        {
            m_ptr[i, j] = v;
        }
        public void print()
        {
            for (int i = 0; i < m_row; i++)
            {
                for (int j = 0; j < m_col; j++)
                {
                    Console.Write(m_ptr[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public Matrix add(Matrix m)
        {
            if(m_row != m.m_row || m_col != m.m_col)
            {
                Console.WriteLine("error occuer!!! - size mismatch");
                Environment.Exit(-1); 
            }
            Matrix c = new Matrix(m_row, m_col);

            for (int i = 0; i < m_row; i++)
            {
                for (int j = 0; j < m_col; j++)
                {
                    c.m_ptr[i, j] = this.m_ptr[i, j] + m.m_ptr[i, j];
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
                    c.m_ptr[i, j] = this.m_ptr[i, j] - m.m_ptr[i, j];
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
                    c.m_ptr[i, j] = s * this.m_ptr[i, j];
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
            //                     thi    fomar
            //                     m*n     n*l
            Matrix c = new Matrix(m_row, m.m_col);

            for (int i = 0; i < m_row; i++)
            {
                for (int j = 0; j < m.m_col; j++)
                {
                    c.m_ptr[i, j] = 0;
                    for (int k = 0; k < m_col; k++)
                    {
                        c.m_ptr[i, j] = c.m_ptr[i, j] + m_ptr[i, k] * m.m_ptr[k, j];
                    }
                }
            }
            return c;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Matrix x = new Matrix(3, 4);
            x.set(0, 0, 1);
            x.set(0, 1, 2);
            x.set(0, 2, 3);
            x.set(0, 3, 4);
            x.set(1, 0, 5);
            x.set(1, 1, 6);
            x.set(1, 2, 7);
            x.set(1, 3, 8);
            x.set(2, 0, 9);
            x.set(2, 1, 10);
            x.set(2, 2, 11);
            x.set(2, 3, 12);

            Matrix y = new Matrix(3, 4);
            y.set(0, 0, 1);
            y.set(0, 1, 1);
            y.set(0, 2, 1);
            y.set(0, 3, 1);
            y.set(1, 0, 2);
            y.set(1, 1, 2);
            y.set(1, 2, 2);
            y.set(1, 3, 2);
            y.set(2, 0, 3);
            y.set(2, 1, 3);
            y.set(2, 2, 3);
            y.set(2, 3, 3);

            Matrix w = new Matrix(4, 2);
            w.set(0, 0, 1);
            w.set(0, 1, 1);
            w.set(1, 0, 1);
            w.set(1, 1, 1);
            w.set(2, 0, 2);
            w.set(2, 1, 2);
            w.set(3, 0, 2);
            w.set(3, 1, 2);

            Matrix z;

            x.print();
            y.print();


            z = x.add(y);      // 합 구하기
            z.print();

            z = x.subtract(y); // 차 구하기
            z.print();

            z = x.multiply(2); // 합 구하기 scalar mutiplication
            z.print();


            x.print();
            w.print();

            z = x.multiply(w); // 합  구하기 
            z.print();

        }
    }
}
