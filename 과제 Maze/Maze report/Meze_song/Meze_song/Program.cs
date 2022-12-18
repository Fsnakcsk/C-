using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Meze_song
{
	class MazeTest
	{
		static void Main(string[] args)
		{
			int nRow = 0;
			int nCol = 0;
			FileStream _in = null;

			Maze maze = null;
			try
			{
				_in = new FileStream("data.txt", FileMode.Open, FileAccess.Read);
				StreamReader reader = new StreamReader(_in);
				String temp = reader.ReadLine();
				String[] numbers = temp.Split(' ');
				nRow = int.Parse(numbers[0]);
				nCol = int.Parse(numbers[1]);
				maze = new Maze(nRow, nCol);
				maze.loadMapFromFile(reader);
				maze.printMap();
				_in.Close();
			}
			catch (Exception)
			{
			}
			Position start = new Position(0, 0);
			Position destination = new Position(nRow - 1, nCol - 1);
			maze.findWay(start, destination);
		}
	}
	class Position
	{
		public int x;
		public int y;

		public Position()
		{
			x = 0; 
			y = 0;
			
		}
		public Position(int a, int b)
		{
			x = a; 
			y = b;
		}
		public Position(Position pos)
		{
			x = pos.x;
			y = pos.y;
		}
		public bool equals(Position pos)
		{
			if (x == pos.x && y == pos.y) return true;
			return false;
		}
	}

	class PositionStack
	{
		static int MAXSTACK = 1000;
		private int _top;
		private Position[] _s;
		public PositionStack()
		{
			_top = -1;
			_s = new Position[MAXSTACK];
		}
		public void push(Position pos)
		{
			if (_top >= MAXSTACK - 1)
			{
				Console.WriteLine("stack overflow error");
				Environment.Exit(-1);
			}
			_top++;
			_s[_top] = new Position(pos);
		}
		public Position pop()
		{
			if (_top < 0)
			{
				Console.WriteLine("stack empty error");
				Environment.Exit(-1);
			}
			_top--;
			return _s[_top + 1];
		}
		public Position top()
		{
			if (_top < 0)
			{
				Console.WriteLine("stack empty error");
				Environment.Exit(-1);
			}
			return _s[_top];
		}
		public void print()
		{
			if (_top < 0)
			{
				Console.WriteLine("stack empty error");
				Environment.Exit(-1);
			}
			Console.WriteLine();
			Console.WriteLine("=== Success !!! ===");
			char[,] t = new char[10,10];

			for (int i = 0; i <10; i++)
			{
				for (int j = 0; j <10; j++)
				{
					t[i, j] = '1';
				}	
			}

			for (int i = 0; i <= _top; i++)
			{
				t[_s[i].x, _s[i].y] = '*';
			}

			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					Console.Write(t[i, j]);
				}
				Console.WriteLine();
			}
		}
		public bool isEmpty()
		{
			if (_top == -1) return true;
			else return false;
		}
	}

	class Maze
	{
		private int[,] _room;
		private int[,] _visitedRoom;
		private int _nRow;
		private int _nCol;
		private Position[] _offset;

		public Maze(int r, int c)
		{
			_nRow = r;
			_nCol = c;
			_room = new int[_nRow, _nCol];
			_visitedRoom = new int[_nRow, _nCol];
			_offset = new Position[4];
			for (int i = 0; i < 4; i++)
			{
				_offset[i] = new Position();
			}
			_offset[0].x = -1;
			_offset[0].y = 0;
			_offset[1].x = 0;
			_offset[1].y = 1;
			_offset[2].x = 1;
			_offset[2].y = 0;
			_offset[3].x = 0;
			_offset[3].y = -1;
		}

		public void loadMapFromFile(StreamReader _in)
		{
			try
			{
				for (int i = 0; i < _nRow; i++)
				{
					String temp = _in.ReadLine();
					String[] numbers = temp.Split(' ');
					for (int j = 0; j < _nCol; j++)
					{
						_room[i, j] = int.Parse(numbers[j]);
					}
				}
			}
			catch (Exception)
			{
			}
		}
		public void printMap()
		{
			for (int i = 0; i < _nRow; i++)
			{
				for (int j = 0; j < _nCol; j++)
				{
					Console.Write(_room[i,j]);
				}
				Console.WriteLine();
			}
		}
		public void findWay(Position start, Position destination)
		{
			int dir;

			PositionStack stack = new PositionStack();

			_visitedRoom[start.x, start.y] = 1;
			stack.push(start);

			while (!stack.isEmpty())
			{
				Position currentRoom = new Position(stack.top());

				if (currentRoom.equals(destination))
				{
					Console.WriteLine("found");
					stack.print();
					return;
				}
				for (dir = 0; dir < 4; dir++)
				{
					int nextX, nextY;
					nextX = currentRoom.x + _offset[dir].x;
					nextY = currentRoom.y + _offset[dir].y;
					if (nextX < 0 || nextX >= _nRow || nextY < 0 || nextY >= _nCol) continue;
					if (_room[nextX, nextY] == 1 || _visitedRoom[nextX, nextY] == 1) continue;
					_visitedRoom[nextX,nextY] = 1;
					currentRoom.x = nextX;
					currentRoom.y = nextY;
					stack.push(currentRoom);
					break;
				}
				if (dir >= 4) stack.pop();
			}
			Console.WriteLine("can't find exit");
		}
	}

	/***** data.txt
	10 10
	0 1 1 1 1 1 1 1 1 1
	0 0 1 1 1 1 1 1 1 1
	1 0 0 0 0 0 1 1 1 1
	1 1 1 1 1 0 0 1 1 1
	1 1 1 1 1 0 1 1 1 1
	1 1 0 0 0 0 1 1 1 1
	1 1 0 1 1 1 1 1 1 1
	1 1 0 0 0 0 0 1 1 1
	1 1 1 1 1 1 0 0 1 1
	1 1 1 1 1 1 1 0 0 0

	*****/
}
