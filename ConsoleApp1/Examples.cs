using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Examples
    {
        public static void Fibonacci(int x)
        {
            //an example of using corteges and Net class Tuple with anonymous functions:
            if (x < 0) throw new ArgumentException("Не надо негатива!", nameof(x));

            Console.WriteLine("Fib with cortege:\t" + Fib(x).current);
            Console.WriteLine("Fib with Tuple:  \t" + TupleFib(x).Item1);


            (int current, int previous) Fib(int i)
            {
                if (i == 0) return (1, 0);
                var (p, pp) = Fib(i - 1);
                return (p + pp, p);
            }
            Tuple<int, int> TupleFib(int i)
            {
                if (i == 0) return new Tuple<int, int>(1, 0);
                var T = TupleFib(i - 1);
                return new Tuple<int, int>(T.Item1 + T.Item2, T.Item1);
            }
        }
        public static void PatternExamples()
        {
            //const pattern: o is null
            //type pattern: o is int i ( i gets o value if o is int)
            //var pattern: o is var i (i gets o value always)

            //is:
            object o = "5";
            if (o is int i || (o is string str && int.TryParse(str, out i)))
            {
                Console.WriteLine(new string('*', i));
            }
            //switch
            object p = 123m;
            switch (p)
            {
                case int c:
                    Console.WriteLine($"p is a number {c}");
                    break;
                case string s when (s.Length == 3):
                    Console.WriteLine("p is a string with length 3");
                    break;
                case string ss:
                    Console.WriteLine($"p is a string with length {ss.Length}");
                    break;
                case var v:
                    Console.WriteLine($"type of p: {v.GetType()}");
                    break;
            }
        }
        public static void StringFormats()
        {
            //настраиваемые описатели: https://docs.microsoft.com/ru-ru/dotnet/standard/base-types/custom-numeric-format-strings
            //if u want to convert num to str use String.Format()
            //min limit of symbols(using "0" template)
            Console.WriteLine("\t0 template");
            Console.WriteLine($"{{123.4567:0.00}}: {123.4567:0.00}");
            Console.WriteLine($"{{0.4:00.00}}: {0.4:00.00}");
            //max limit of symbols (using "#" template)
            Console.WriteLine("\n\t# template");
            Console.WriteLine($"{{123.4567:#.##}}: {123.4567:#.##}");
            Console.WriteLine($"{{0.4:##.##}}: {0.4:##.##}");
            //thousand separator (",")
            Console.WriteLine("\n\tThousand separator");
            Console.WriteLine($"{{12345.67:0,0.0}}: {12345.67:0,0.0}");
            Console.WriteLine($"{{1234589.67:0,0}}: {12345.67:0,0}");
            //percents (using "%" multiplicate number on 100 and adds percent symbol
            Console.WriteLine("\n\tPercents");
            Console.WriteLine($"{{0.086:0.###%}}: {0.086:0.###%}");
            //lining
            Console.WriteLine("\n\tLining");
            Console.WriteLine($"{{123, 5}}:{123,5}");
            Console.WriteLine($"{{123,-5}}:{123,-5}");
            //formats (msdn: описатели формата)
            Console.WriteLine("\n\tFormat examples on 10761.937554f");
            CultureInfo ci = new CultureInfo("en-us");
            double floating = 10761.937554f;
            Console.WriteLine("C: {0}",
                    floating.ToString("C", ci));           // Displays "C: $10,761.94"
            Console.WriteLine("E03: {0}",
                    floating.ToString("E03", ci));         // Displays "E: 1.076E+004"
            Console.WriteLine("F04: {0}",
                    floating.ToString("F04", ci));         // Displays "F: 10761.9376"         
            Console.WriteLine("G: {0}",
                    floating.ToString("G", ci));           // Displays "G: 10761.937554"
            Console.WriteLine("N03: {0}",
                    floating.ToString("N03", ci));         // Displays "N: 10,761.938"
            Console.WriteLine("R: {0}",
                    floating.ToString("R", ci));           // Displays "R: 10761.937554"
            Console.WriteLine();

        }
    }

}
