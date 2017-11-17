using System;
using CppSharpGenerated;

namespace InterfaceUser
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var hello = new HelloClass())
            {
                hello.Hello();
            }
        }
    }
}
