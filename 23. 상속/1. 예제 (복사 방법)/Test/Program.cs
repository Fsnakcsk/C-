using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointTest
{
    class Point2D
    {
        int m_x;
        int m_y;
        public Point2D(int x, int y)
        {
            m_x = x;
            m_y = y;
        }
        public void setX(int x)
        {
            m_x = x;
        }
        public void setY(int y)
        {
            m_y = y;
        }
        public Point2D add(Point2D p)
        {
            Point2D tmp = new Point2D(m_x + p.m_x, m_y + p.m_y);
            return tmp;
        }
        public int getX()
        {
            return m_x;
        }
        public int getY()
        {
            return m_y;
        }
        public void move(int dx, int dy)
        {
            m_x = m_x + dx;
            m_y = m_y = dy;
        }
        public void move(int delta)
        {
            move(delta, delta);
        }
        public double magnitude()
        {
            return Math.Sqrt(m_x * m_x + m_y * m_y);
        }
        public override string ToString()
        {
            return "[" + m_x + "," + m_y + "]";
        }
    }
    class Point3D
    {
        int m_x;
        int m_y;
        int m_z;
        public Point3D(int x, int y, int z)
        {
            m_x = x;
            m_y = y;
            m_z = z;
        }
        public void setX(int x)
        {
            m_x = x;
        }
        public void setY(int y)
        {
            m_y = y;
        }
        public void setZ(int z)
        {
            m_y = z;
        }
        public Point3D add(Point3D p)
        {
            Point3D tmp = new Point3D(m_x + p.m_x, m_y + p.m_y, m_z + p.m_z);
            return tmp;
        }
        public int getX()
        {
            return m_x;
        }
        public int getY()
        {
            return m_y;
        }
        public int getZ()
        {
            return m_y;
        }
        public void move(int dx, int dy, int dz)
        {
            m_x = m_x + dx;
            m_y = m_y = dy;
            m_z = m_z = dz;
        }
        public void move(int delta)
        {
            move(delta, delta, delta);
        }
        public double magnitude()
        {
            return Math.Sqrt(m_x * m_x + m_y * m_y + m_z * m_z);
        }
        public override string ToString()
        {
            return "[" + m_x + "," + m_y + "," + m_z + "]";
        }


    }
    class Program
    {
            static void Main(string[] args)
        {
            Point2D p = new Point2D(10, 20);
            Point2D q = new Point2D(30, 40);
            Point2D r; 

            p.setX(100); p.setY(200);

            r = p.add(q);
            Console.WriteLine("[" + r.getX() +","+ r.getY() + "]");

            p.move(200, 300);
            q.move(1000);

            Console.WriteLine("p = " + p);
            Console.WriteLine("q = " + q);
            Console.WriteLine("r = " + r);
            Console.WriteLine(r.magnitude());

            Point3D pp = new Point3D(10, 20, 30);
            Point3D qq = new Point3D(30, 40, 50);
            Point3D rr;

            pp.setX(100); pp.setY(200);

            rr = pp.add(qq);
            Console.WriteLine("[" + rr.getX() + "," + rr.getY() + ","+ rr.getZ() +"]");

            pp.move(200, 300, 400);
            qq.move(1000);

            Console.WriteLine("pp = " + pp);
            Console.WriteLine("qq = " + qq);
            Console.WriteLine("rr = " + rr);
            Console.WriteLine(r.magnitude());
        }
    }
}
