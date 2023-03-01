using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Zoo
{
    class RandomNumber       
    {
        static Random rand = new Random();
        public static int getNext(int range)
        {
            int number = rand.Next();
            return number % range + 1;
        }

    }
    abstract class Animal
    {
        protected String name;
        protected int weight; // 몸무게 kg
        public Animal(String name)
        {
            this.name = name;
        }
        protected void increaseWeight(int w)
        {
            weight = weight + w;
        }
        public abstract void makeSound();
        public virtual void eat(int x)
        {
            increaseWeight(x);
        }

        public override string ToString()
        {
            String s = "";
            s = s + name + " " + "몸무게" + weight;
            return s;
        }

    }
    class Lion : Animal
    {
        int nPig;   // 먹은 돼지 갯수

        public Lion(String name)
            : base(name)
        {
            weight = 10;
            nPig = 0;
        }
        public override void makeSound() //배고픈 소리
        {
            Console.WriteLine("으르렁~~~~");
        }
        public override void eat(int pig)
        {
            nPig = nPig + pig;
            base.eat(10 * pig);  // 돼지 10kg
        }
        public void fart()
        {
            Console.WriteLine("뿌우웅~~~~웅");
            increaseWeight(-1);
        }
        public override string ToString()
        {
            String s = base.ToString();
            s = s + "돼지수 : " + nPig;
            return s;
        }
    }
    class Rabbit : Animal
    {

        int nCarrot;   // 먹은 당근 갯수

        public Rabbit(String name)
            : base(name)
        {
            weight = 1;
            nCarrot = 0;
        }
        public override void makeSound() //배고픈 소리
        {
            Console.WriteLine("찍찍~~~~");
        }
        public override void eat(int carrot)
        {
            nCarrot = nCarrot + carrot;
            base.eat(carrot);  // 돼지 10kg
        }
        public void dig()
        {
            Console.WriteLine("스스슥~~~슥슥~~~");
            increaseWeight(-1);
        }
        public override string ToString()
        {
            String s = base.ToString();
            s = s + "당근수 : " + nCarrot;
            return s;
        }
    }
    class Elephant : Animal
    {

        int nBnana;   // 먹은 당근 갯수

        public Elephant(String name)
            : base(name)
        {
            weight = 1;
            nBnana = 0;
        }
        public override void makeSound() //배고픈 소리
        {
            Console.WriteLine("뿌우~~~~");
        }
        public override void eat(int Bnana)
        {
            nBnana = nBnana + Bnana;
            base.eat(5 * Bnana);  // 돼지 10kg
        }
        public void shootWater()
        {
            Console.WriteLine("쓔웅~쓩~~~");
            increaseWeight(-2);
        }
        public override string ToString()
        {
            String s = base.ToString();
            s = s + "당근수 : " + nBnana;
            return s;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();

            list.Add(new Lion("사원"));
            list.Add(new Lion("사투"));
            list.Add(new Lion("사쓰"));
            list.Add(new Rabbit("토원"));
            list.Add(new Rabbit("토투"));
            list.Add(new Elephant("코원"));
            list.Add(new Elephant("코투"));
            list.Add(new Elephant("코쓰"));

            for (int day = 0; day < 10; day++)
            {
                //                  list -> ptr 파이썬 처럼
                foreach (Animal ptr in list)
                {
                    // dynamic binding
//                  Animal ptr = arr[i];
                    ptr.makeSound();

                    int food = 0;
                    if (ptr is Lion) // RTTI Runtime Type Identification 가리키는 곳은 사자냐?
                    {
                        food = RandomNumber.getNext(2);
                    }
                    else if (ptr is Rabbit)
                    {
                        food = RandomNumber.getNext(10);
                    }
                    else if (ptr is Elephant)
                    {
                        food = RandomNumber.getNext(100);
                    }
                    ptr.eat(food);

                    if (ptr is Lion) // RTTI
                    {
                        //downcasting
                        ((Lion)ptr).fart();
                    }
                    else if (ptr is Rabbit)
                    {
                        ((Rabbit)ptr).dig();
                    }
                    else if (ptr is Elephant)
                    {
                        ((Elephant)ptr).shootWater();
                    }

                }
            } 
            foreach (Animal ptr in list)
            {
                Console.WriteLine(ptr);
            }
        }
    }
}

/* 
// polymorphism(다형개념)
// 객체들의 특성이 "서로 다르면서 같은 점"
//                 "서로 같으면서 다른 점" 을 다루는 제도

// polymorphic container (컬렉션 객체 배열, Likedlst의 다른 말 container(컨테이너)

namespace Zoo
{
    class RandomNumber
    {
        static Random rand = new Random();
        public static int getNext(int range)
        {
            int number = rand.Next();
            return number % range + 1;
        }

    }
    abstract class Animal
    {
        protected String name;
        protected int weight; // 몸무게 kg
        public Animal(String name)
        {
            this.name = name;
        }
        protected void increaseWeight(int w)
        {
            weight = weight + w;
        }
        public abstract void makeSound();
        public virtual void eat(int x)
        {
            increaseWeight(x);
        }

        public override string ToString()
        {
            String s = "";
            s = s + name + " " + "몸무게" + weight;
            return s;
        }

    }
    class Lion : Animal
    {
        int nPig;   // 먹은 돼지 갯수

        public Lion(String name)
            : base(name)
        {
            weight = 10;
            nPig = 0;
        }
        public override void makeSound() //배고픈 소리
        {
            Console.WriteLine("으르렁~~~~");
        }
        public override void eat(int pig)
        {
            nPig = nPig + pig;
            base.eat(10 * pig);  // 돼지 10kg
        }
        public void fart()
        {
            Console.WriteLine("뿌우웅~~~~웅");
            increaseWeight(-1);
        }
        public override string ToString()
        {
            String s = base.ToString();
            s = s + "돼지수 : " + nPig;
            return s;
        }
    }
    class Rabbit : Animal
    {

        int nCarrot;   // 먹은 당근 갯수

        public Rabbit(String name)
            : base(name)
        {
            weight = 1;
            nCarrot = 0;
        }
        public override void makeSound() //배고픈 소리
        {
            Console.WriteLine("찍찍~~~~");
        }
        public override void eat(int carrot)
        {
            nCarrot = nCarrot + carrot;
            base.eat(carrot);  // 돼지 10kg
        }
        public void dig()
        {
            Console.WriteLine("스스슥~~~슥슥~~~");
            increaseWeight(-1);
        }
        public override string ToString()
        {
            String s = base.ToString();
            s = s + "당근수 : " + nCarrot;
            return s;
        }
    }
    class Elephant : Animal
    {

        int nBnana;   // 먹은 당근 갯수

        public Elephant(String name)
            : base(name)
        {
            weight = 1;
            nBnana = 0;
        }
        public override void makeSound() //배고픈 소리
        {
            Console.WriteLine("뿌우~~~~");
        }
        public override void eat(int Bnana)
        {
            nBnana = nBnana + Bnana;
            base.eat(5 * Bnana);  // 돼지 10kg
        }
        public void shootWater()
        {
            Console.WriteLine("쓔웅~쓩~~~");
            increaseWeight(-2);
        }
        public override string ToString()
        {
            String s = base.ToString();
            s = s + "당근수 : " + nBnana;
            return s;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // upcasting *** Animal l1 = new Lion(); ***
            // 하위 클레스의 객체는 상위 클레스의 객체처럼 인식하는 행위

            //          polymorphic container
            Animal[] arr = new Animal[100];
            int n = 0;
            
            arr[n++] = new Lion("사원");
            arr[n++] = new Lion("사투");
            arr[n++] = new Lion("사쓰");
            arr[n++] = new Rabbit("토원");
            arr[n++] = new Rabbit("토투");
            arr[n++] = new Elephant("코원");
            arr[n++] = new Elephant("코투");
            arr[n++] = new Elephant("코쓰");

            for (int day = 0; day < 10; day++)
            {
                for (int i = 0; i < n; i++)
                {
                    // dynamic binding
                    Animal ptr = arr[i];
                    ptr.makeSound();

                    int food = 0;
                    if (ptr is Lion) // RTTI Runtime Type Identification 가리키는 곳은 사자냐?
                    {
                        food = RandomNumber.getNext(2);
                    }
                    else if (ptr is Rabbit)
                    {
                        food = RandomNumber.getNext(10);
                    }
                    else if (ptr is Elephant)
                    {
                        food = RandomNumber.getNext(100);
                    }
                    ptr.eat(food);

                    if (ptr is Lion) // RTTI
                    {
                        //downcasting
                        ((Lion)ptr).fart();
                    }
                    else if (ptr is Rabbit)
                    {
                        ((Rabbit)ptr).dig();
                    }
                    else if (ptr is Elephant)
                    {
                        ((Elephant)ptr).shootWater();
                    }

                }
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(arr[i]);
            }


            /*
            for (int day = 0; day < 10; day++)
            {
                l1.makeSound();
                l1.eat(RandomNumber.getNext(2));
                //                l1.fart();

                l2.makeSound();
                l2.eat(RandomNumber.getNext(2));
                //                l2.fart();

                l3.makeSound();
                l3.eat(RandomNumber.getNext(2));
                //                l3.fart();

                //--------------------------------

                r1.makeSound();
                r1.eat(RandomNumber.getNext(10));
                //                r1.dig();

                r2.makeSound();
                r2.eat(RandomNumber.getNext(10));
                //                r2.dig();

                //-------------------------------------

                e1.makeSound();
                e1.eat(RandomNumber.getNext(100));
                //                e1.shootWater();
                e2.makeSound();
                e2.eat(RandomNumber.getNext(100));
                //                e2.shootWater();
                e3.makeSound();
                e3.eat(RandomNumber.getNext(100));
                //                e3.shootWater();
            
            }

             Console.WriteLine(l1);
            Console.WriteLine(l2);
            Console.WriteLine(l3);

            Console.WriteLine(r1);
            Console.WriteLine(r2);

            Console.WriteLine(e1);
            Console.WriteLine(e2);
            Console.WriteLine(e3);

        }
    }
}
*/


/* version 3 dynamic binding(동적 바인딩)
namespace Zoo
{
    class RandomNumber
    {
        static Random rand = new Random();
        public static int getNext(int range)
        {
            int number = rand.Next();
            return number % range + 1;
        }

    }
    abstract class Animal
    {
        protected String name;
        protected int weight; // 몸무게 kg
        public Animal(String name)
        {
            this.name = name;
        }
        protected void increaseWeight(int w)
        {
            weight = weight + w;
        }
        public abstract void makeSound();
        public virtual void eat(int x)
        {
            increaseWeight(x);
        }

        public override string ToString()
        {
            String s = "";
            s = s + name + " " + "몸무게" + weight;
            return s;
        }

    }
    class Lion : Animal
    {
        int nPig;   // 먹은 돼지 갯수

        public Lion(String name)
            : base(name)
        {
            weight = 10;
            nPig = 0;
        }
        public override void makeSound() //배고픈 소리
        {
            Console.WriteLine("으르렁~~~~");
        }
        public override void eat(int pig)
        {
            nPig = nPig + pig;
            base.eat(10 * pig);  // 돼지 10kg
        }
        public void fart()
        {
            Console.WriteLine("뿌우웅~~~~웅");
            increaseWeight(-1);
        }
        public override string ToString()
        {
            String s = base.ToString();
            s = s + "돼지수 : " + nPig;
            return s;
        }
    }
    class Rabbit : Animal
    {

        int nCarrot;   // 먹은 당근 갯수

        public Rabbit(String name)
            : base(name)
        {
            weight = 1;
            nCarrot = 0;
        }
        public override void makeSound() //배고픈 소리
        {
            Console.WriteLine("찍찍~~~~");
        }
        public override void eat(int carrot)
        {
            nCarrot = nCarrot + carrot;
            base.eat(carrot);  // 돼지 10kg
        }
        public void dig()
        {
            Console.WriteLine("스스슥~~~슥슥~~~");
            increaseWeight(-1);
        }
        public override string ToString()
        {
            String s = base.ToString();
            s = s + "당근수 : " + nCarrot;
            return s;
        }
    }
    class Elephant : Animal
    {

        int nBnana;   // 먹은 당근 갯수

        public Elephant(String name)
            : base(name)
        {
            weight = 1;
            nBnana = 0;
        }
        public override void makeSound() //배고픈 소리
        {
            Console.WriteLine("뿌우~~~~");
        }
        public override void eat(int Bnana)
        {
            nBnana = nBnana + Bnana;
            base.eat(5 * Bnana);  // 돼지 10kg
        }
        public void shootWater()
        {
            Console.WriteLine("쓔웅~쓩~~~");
            increaseWeight(-2);
        }
        public override string ToString()
        {
            String s = base.ToString();
            s = s + "당근수 : " + nBnana;
            return s;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // upcasting *** Animal l1 = new Lion(); ***
            // 하위 클레스의 객체는 상위 클레스의 객체처럼 인식하는 행위

            Animal l1 = new Lion("사원");
            Animal l2 = new Lion("사투");
            Animal l3 = new Lion("사쓰");
            Animal r1 = new Rabbit("토원");
            Animal r2 = new Rabbit("토투");
            Animal e1 = new Elephant("코원");
            Animal e2 = new Elephant("코투");
            Animal e3 = new Elephant("코쓰");

            for (int day = 0; day < 10; day++)
            {
                l1.makeSound(); 
                l1.eat(RandomNumber.getNext(2));
//                l1.fart();

                l2.makeSound();
                l2.eat(RandomNumber.getNext(2));
//                l2.fart();

                l3.makeSound();
                l3.eat(RandomNumber.getNext(2));
//                l3.fart();

                //--------------------------------

                r1.makeSound();
                r1.eat(RandomNumber.getNext(10));
//                r1.dig();

                r2.makeSound();
                r2.eat(RandomNumber.getNext(10));
//                r2.dig();

                //-------------------------------------

                e1.makeSound();
                e1.eat(RandomNumber.getNext(100));
//                e1.shootWater();
                e2.makeSound();
                e2.eat(RandomNumber.getNext(100));
//                e2.shootWater();
                e3.makeSound();
                e3.eat(RandomNumber.getNext(100));
//                e3.shootWater();
            }

            Console.WriteLine(l1);
            Console.WriteLine(l2);
            Console.WriteLine(l3);

            Console.WriteLine(r1);
            Console.WriteLine(r2);

            Console.WriteLine(e1);
            Console.WriteLine(e2);
            Console.WriteLine(e3);

        }
    }
}
*/
/* version 2 상속
namespace Zoo
{
    class RandomNumber
    {
        static Random rand = new Random();
        public static int getNext(int range)
        {
            int number = rand.Next();
            return number % range + 1;
        }

    }
    class Animal
    {
        protected String name;
        protected int weight; // 몸무게 kg
        public Animal(String name)
        {
            this.name = name;
        }
        protected void increaseWeight(int w)
        {
            weight = weight + w;
        }
        public override string ToString()
        {
            String s = "";
            s = s + name + " " + "몸무게" + weight;
            return s;
        }
    }
    class Lion : Animal
    {
        int nPig;   // 먹은 돼지 갯수

        public Lion(String name)
            : base(name)
        {
            weight = 10;
            nPig = 0;
        }
        public void makeSound() //배고픈 소리
        {
            Console.WriteLine("으르렁~~~~");
        }
        public void eat(int pig)
        {
            nPig = nPig + pig;
            increaseWeight(10 * pig);  // 돼지 10kg
        }
        public void fart()
        {
            Console.WriteLine("뿌우웅~~~~웅");
            increaseWeight(- 1);
        }
        public override string ToString()
        {
            String s = base.ToString();
            s = s + "돼지수 : " + nPig;
            return s;
        }
    }
    class Rabbit : Animal
    {

        int nCarrot;   // 먹은 당근 갯수

        public Rabbit(String name)
            : base(name)
        {
            weight = 1;
            nCarrot = 0;
        }
        public void makeSound() //배고픈 소리
        {
            Console.WriteLine("찍찍~~~~");
        }
        public void eat(int carrot)
        {
            nCarrot = nCarrot + carrot;
            increaseWeight(carrot);  // 돼지 10kg
        }
        public void dig()
        {
            Console.WriteLine("스스슥~~~슥슥~~~");
            increaseWeight(-1);
        }
        public override string ToString()
        {
            String s = base.ToString();
            s = s + "당근수 : " + nCarrot;
            return s;
        }
    }
    class Elephant : Animal
    {

        int nBnana;   // 먹은 당근 갯수

        public Elephant(String name)
            : base(name)
        {
            weight = 1;
            nBnana = 0;
        }
        public void makeSound() //배고픈 소리
        {
            Console.WriteLine("뿌우~~~~");
        }
        public void eat(int Bnana)
        {
            nBnana = nBnana + Bnana;
            increaseWeight(5* Bnana);  // 돼지 10kg
        }
        public void shootWater()
        {
            Console.WriteLine("쓔웅~쓩~~~");
            increaseWeight(-2);
        }
        public override string ToString()
        {
            String s = base.ToString();
            s = s + "당근수 : " + nBnana;
            return s;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Lion l1 = new Lion("사원");
            Lion l2 = new Lion("사투");
            Lion l3 = new Lion("사쓰");
            Rabbit r1 = new Rabbit("토원");
            Rabbit r2 = new Rabbit("토투");
            Elephant e1 = new Elephant("코원");
            Elephant e2 = new Elephant("코투");
            Elephant e3 = new Elephant("코쓰");

            for (int day = 0; day < 10; day++)
            {
                l1.makeSound();
                l1.eat(RandomNumber.getNext(2));
                l1.fart();

                l2.makeSound();
                l2.eat(RandomNumber.getNext(2));
                l2.fart();

                l3.makeSound();
                l3.eat(RandomNumber.getNext(2));
                l3.fart();

                //--------------------------------

                r1.makeSound();
                r1.eat(RandomNumber.getNext(10));
                r1.dig();

                r2.makeSound();
                r2.eat(RandomNumber.getNext(10));
                r2.dig();

                //-------------------------------------

                e1.makeSound();
                e1.eat(RandomNumber.getNext(100));
                e1.shootWater();
                e2.makeSound();
                e2.eat(RandomNumber.getNext(100));
                e2.shootWater();
                e3.makeSound();
                e3.eat(RandomNumber.getNext(100));
                e3.shootWater();
            }

            Console.WriteLine(l1);
            Console.WriteLine(l2);
            Console.WriteLine(l3);

            Console.WriteLine(r1);
            Console.WriteLine(r2);

            Console.WriteLine(e1);
            Console.WriteLine(e2);
            Console.WriteLine(e3);

        }
    }
}
*/
/*
 * version 1 자료 추상화
namespace Zoo
{
    class RandomNumber
    {
        static Random rand = new Random();
        public static int getNext(int range)
        {
            int number = rand.Next();
            return number % range + 1;
        }

    }
    class Lion
    {
        String name;
        int weight; // 몸무게 kg
        int nPig;   // 먹은 돼지 갯수

        public Lion(String name)
        {
            this.name = name;
            weight = 10;
            nPig = 0;
        }
        public void makeSound() //배고픈 소리
        {
            Console.WriteLine("으르렁~~~~");
        }
        public void eat(int pig)
        {
            nPig = nPig + pig;
            weight = weight + 10 * pig;  // 돼지 10kg
        }
        public void fart()
        {
            Console.WriteLine("뿌우웅~~~~웅");
            weight = weight - 1;
        }
        public override string ToString()
        {
            String s = "";
            s = s + name + " " + "몸무게" + weight;
            s = s + "돼지수 : " + nPig;
            return s;
        }
    }
    class Rabbit
    {
        String name;
        int weight; // 몸무게 kg
        int nCarrot;   // 먹은 당근 갯수

        public Rabbit(String name)
        {
            this.name = name;
            weight = 1;
            nCarrot = 0;
        }
        public void makeSound() //배고픈 소리
        {
            Console.WriteLine("찍찍~~~~");
        }
        public void eat(int carrot)
        {
            nCarrot = nCarrot + carrot;
            weight = weight + carrot;  // 돼지 10kg
        }
        public void dig()
        {
            Console.WriteLine("스스슥~~~슥슥~~~");
            weight = weight - 1;
        }
        public override string ToString()
        {
            String s = "";
            s = s + name + " " + "몸무게" + weight;
            s = s + "당근수 : " + nCarrot;
            return s;
        }
    }
    class Elephant
    {
        String name;
        int weight; // 몸무게 kg
        int nBnana;   // 먹은 당근 갯수

        public Elephant(String name)
        {
            this.name = name;
            weight = 1;
            nBnana = 0;
        }
        public void makeSound() //배고픈 소리
        {
            Console.WriteLine("뿌우~~~~");
        }
        public void eat(int Bnana)
        {
            nBnana = nBnana + Bnana;
            weight = weight + 5 * Bnana;  // 돼지 10kg
        }
        public void shootWater()
        {
            Console.WriteLine("쓔웅~쓩~~~");
            weight = weight - 2;
        }
        public override string ToString()
        {
            String s = "";
            s = s + name + " " + "몸무게" + weight;
            s = s + "당근수 : " + nBnana;
            return s;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Lion l1 = new Lion("사원");
            Lion l2 = new Lion("사투");
            Lion l3 = new Lion("사쓰");
            Rabbit r1 = new Rabbit("토원");
            Rabbit r2 = new Rabbit("토투");
            Elephant e1 = new Elephant("코원");
            Elephant e2 = new Elephant("코투");
            Elephant e3 = new Elephant("코쓰");

            for (int day = 0; day < 10; day++)
            {
                l1.makeSound();
                l1.eat(RandomNumber.getNext(2));
                l1.fart();

                l2.makeSound();
                l2.eat(RandomNumber.getNext(2));
                l2.fart();

                l3.makeSound();
                l3.eat(RandomNumber.getNext(2));
                l3.fart();

                //--------------------------------

                r1.makeSound();
                r1.eat(RandomNumber.getNext(10));
                r1.dig();

                r2.makeSound();
                r2.eat(RandomNumber.getNext(10));
                r2.dig();

                //-------------------------------------

                e1.makeSound();
                e1.eat(RandomNumber.getNext(100));
                e1.shootWater();
                e2.makeSound();
                e2.eat(RandomNumber.getNext(100));
                e2.shootWater();
                e3.makeSound();
                e3.eat(RandomNumber.getNext(100));
                e3.shootWater();
            }

            Console.WriteLine(l1);
            Console.WriteLine(l2);
            Console.WriteLine(l3);

            Console.WriteLine(r1);
            Console.WriteLine(r2);

            Console.WriteLine(e1);
            Console.WriteLine(e2);
            Console.WriteLine(e3);

        }
    }
}
*/