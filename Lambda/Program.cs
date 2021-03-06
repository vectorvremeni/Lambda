using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            VectorList<User> Users = new VectorList<User>(5);
            Users[0] = new User { Id = 1, Name = "John", Phone = "1234567", Age = 20 };
            Users[1] = new User { Id = 2, Name = "Jane", Phone = "4365745674", Age = 40 };
            Users[2] = new User { Id = 3, Name = "Max", Phone = "34563546", Age = 60 };
            Users[3] = new User { Id = 4, Name = "Eva", Phone = "96798", Age = 80 };
            Users[4] = new User { Id = 5, Name = "Mickel", Phone = "3245", Age = 100 };

            var tu1 = Users.Select(x => new { User = x.Name, Phone = long.Parse(x.Phone) });

            var olds = Users.Where(x => x.Age > 40).Where(x => x.Age < 80).Select(x => new { User = x.Name, Phone = long.Parse(x.Phone) });
        }

        //пример функции
        public int test(int x)
        {
            return x * x;
        }

        //та же функция только в виде лямбды
        public int test2(int x) => x * x;
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }

        //перегрузка операторов
        public static User operator +(User a, User b)
        {
            return new User
            {
                Age = a.Age + b.Age,
                Id = a.Id + b.Id,
                Name = a.Name + b.Name,
                Phone = (long.Parse(a.Phone) + long.Parse(b.Phone)).ToString()
            };
        }
    }

    public class VectorList<T>
    {
        public T[] elements;

        public T this[int x]
        {
            get
            {
                return elements[x];
            }
            set 
            {
                elements[x] = value;
            }
        }
        public VectorList(int count)
        {
            elements = new T[count];
        }

        public VectorList<Tunknown> Select<Tunknown>(Func<T,Tunknown> f)
        {
            VectorList<Tunknown> tu = new VectorList<Tunknown>(this.Length);
            for (int i = 0; i < this.Length; i++)
            {
                tu[i] = f(this[i]);
            }
            return tu;
        }

        public VectorList<T> Where(Func<T,bool> f)
        {
            int[] selected = new int[Length];
            int count = 0;
            for(int i=0;i<Length;i++)
            {
                if(f(this[i]))
                {
                    selected[count] = i;
                    count++;
                }
            }

            VectorList<T> res = new VectorList<T>(count);
            for(int i=0;i<count;i++)
            {
                res[i] = this[selected[i]];
            }
            return res;
        }

        public void ForEach(Action<T> f)
        {
            for(int i=0;i<Length;i++)
            {
                f(this[i]);
            }
        }

        public bool Any(Func<T,bool> f)
        {
            for(int i=0;i<Length;i++)
            {
                if(f(this[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public int Length 
        { 
            get
            {
                return elements.Length;
            }
            private set { }
        }
    }
}
