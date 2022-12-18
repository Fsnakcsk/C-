using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point
{
	class Point
	{
		// data member 
		private int x;
		private int y;

//-------------------------------------------------------------------------------
//   MS property(문법)
/*	 public type Name 
 *	 {
 *		get { return name; }
 *		set { value = name; }
 *	 }
 */
		public int X
        {
            get
            {
				return x;
            }
            set
            {
				value = x; 
            }
        }

		public int Y
		{
			get
			{
				return y;
			}
			set
			{
				value = y;
			}
		}

//------------------------------ Java -------------------------------------

		public int getX()
        {
			return x;
        }

		public void setX(int x)
        {
			this.x = x;
        }
		public int getY()
		{
			return x;
		}

		public void setY(int y)
		{
			this.y = y;
		}

		//-------------------------------------------------------------------------------------

		//deffault constructor 초기화 함수. 인수없는 함수
		public Point()  // namespace와 이름이 일치해야 함
			: this(0, 0)
		{
		//	x = y = 0;
		}

		public Point(int x, int y)  
		{
			this.x = x;
			this.y = y;
		}

		//menber function
		public void findCenterPoint(Point q, Point r)
		{
			x = (q.x + r.x) / 2;
			y = (q.y + r.y) / 2;
		}

		// function overloading 함수 이름을 중복해도 된다.
		// 일반 호출 방법은 객체에 바운드(bound)되어 있는 함수
		// 혹은 this가 있는 함수
		public void add(int dx, int dy)
		{
			x = x + dx;
			y = y + dy;
		}

		// 일반 호출 방법은 객체에 바운드(bound)되어 있지 않는 함수
		// 혹은 this가 없는 함수
		public static void add(Point p, int dx, int dy)
        {
			p.x = p.x + dx;
			p.y = p.y + dy;
        }

		public void add(int delta)
		{
			add(delta, delta);
		}

		public Point add(Point p2)
		{

			//	Point* p = (Point*)malloc(sizeof(Point));

			Point p = new Point();
			p.x = x + p2.x;
			p.y = y + p2.y;
			
			return p;
		}

		public void printPoint(String name)
		{
			Console.WriteLine("{0} = ({1},{2})", name, x, y);
		}
	}    

	class Program
    {
        static void Main(string[] args)
        {
			// constructor(생성자) 변수를 반들 때 바로 초기화 함
			Point pa = new Point(10, 10);
			Point pb = new Point(20, 30);
			Point pc = new Point();
			Point pd;

			// initialization  변수를 반들고 나서 초가화 시킬 때 
			/* 
			pa.x = 100;
			pa.y = 100;

			pb.x = 200;
			pb.y = 300;
			*/

/* -------------------------- Java 또는 C#  --------------------------
			pa.setX(100);
			pa.setY(100);

			pb.setX(200); 
			pb.setY(300);

			int xxx = pa.getX();
			int yyy = pa.getY();
			*/

// ------------------------- MS property(문법) -------------------------
			pa.X = 100;
			pa.Y = 100;
			pb.X = 200;
			pb.Y = 300;

			int xxx = pa.X;
			int yyy = pa.Y;




			// 엤날 function call 이제는 message sending 라고 함
			// pc는 receiver 라고함 (받는 존재다) findCenterPoint(pa, pb)의 프로그래머의 명령을 받는 존재다.
			// 더 정확한 이름은  <객체 레퍼런스> 다 
			pc.findCenterPoint(pa, pb); 
			pa.add(100, 200);
			pb.add(1000);
			pd = pa.add(pb);
			// 위에는 일반 함수 호출하는 방법이다.   총 2개의 종류가 있다.


			// 정적 멤버함수 호출 C와 똑같다.
		//	Point.add(pa, 100, 200);

			pa.printPoint("a");
			pb.printPoint("b");
			pc.printPoint("c");
			pd.printPoint("d");

		}
    }
}
