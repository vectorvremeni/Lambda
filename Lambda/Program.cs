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
            VectorList<User> Users1 = new VectorList<User>(5);
            Users1.elements[0] = new User { Id = 1, Name = "John", Phone = "1234567", Age = 20 };
            Users1.elements[1] = new User { Id = 2, Name = "Jane", Phone = "4365745674", Age = 40 };
            Users1.elements[2] = new User { Id = 3, Name = "Max", Phone = "34563546", Age = 60 };
            Users1.elements[3] = new User { Id = 4, Name = "Eva", Phone = "96798", Age = 80 };
            Users1.elements[4] = new User { Id = 5, Name = "Mickel", Phone = "3245", Age = 100 };
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
    }

    public class VectorList<T>
    {
        public T[] elements;

        public VectorList(int count)
        {
            elements = new T[count];
        }
    }
}
