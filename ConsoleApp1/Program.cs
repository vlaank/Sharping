using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class Program
    {

        static void Main(string[] args)
        {
            var smiles = new string[0];// { ":)", ":(", ":D", ":O", ":;" };
            int total = smiles.Count(str => str.Length == 2
            ? (str[0].Equals(':') || str[0].Equals(';')) && (str[1].Equals(')') || str[1].Equals('D'))
            : (str[0].Equals(':') || str[0].Equals(';')) && (str[1].Equals('-') || str[1].Equals('~')) && (str[2].Equals(')') || str[2].Equals('D'))
            );
            Console.WriteLine(total);
        }
    }
}
