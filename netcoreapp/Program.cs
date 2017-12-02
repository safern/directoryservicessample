using fullframeworklibrary;
using System;

namespace netcoreapp
{
    class Program
    {
        static void Main(string[] args)
        {
            var groups = Class1.GetGroupNames("user");

            foreach (var group in groups)
            {
                Console.WriteLine(group);
            }
        }
    }
}
