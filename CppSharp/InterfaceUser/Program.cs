using System;
using CppSharpGenerated;

namespace InterfaceUser
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var hello = new Foo(1, 7))
            {
                for (int i = 0; i < Int32.MaxValue; i++)
                {
                    hello.Print();
                }
            }
        }
    }
}
