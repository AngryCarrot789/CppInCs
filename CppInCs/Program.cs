using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CppInCs
{
    public class Program
    {
        // You need to provide a location to the .dll file the C++ project creates.
        // Also, you need to make sure in the C++ project, 
        // in Configuration Properties > General > Configuration Type is Dynamic Link, not Application
        private const string MyFunctions = @"..\..\..\Debug\CppFunctions.dll";

        // Then import it. Make sure CallingConvention is Cdecl. This i think declares
        // the imported code is C code so that the C# compiler knows it's importing unmanaged stuff,
        // and can deal with it accordingly without you needing to do much.
        [DllImport(MyFunctions, CallingConvention = CallingConvention.Cdecl)]
        public static extern int AddNumbers(int a, int b);

        [DllImport(MyFunctions, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SubtractNumbers(int a, int b);

        static void Main(string[] args)
        {
            int input1;
            int input2;

            Console.Write("Input 1: ");

            if (!int.TryParse(Console.ReadLine(), out input1))
            {
                Console.WriteLine("NO!");
                return;
            }

            Console.Write("\nInput 2: ");

            if (!int.TryParse(Console.ReadLine(), out input2))
            {
                Console.WriteLine("NO!");
                return;
            }

            Console.WriteLine("Calculating from C++...");

            // Then you simply just call the function like so. very easy.
            int output = AddNumbers(input1, input2);

            Console.WriteLine(output);

            Console.ReadLine();
        }
    }
}
