using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace execice_1_boucle_1
{
    class Program
    {
        static void TrouverFacto(ref int fact,int nbre)
        {
            for (int i = 1; i <= nbre; i++)
            {
                fact = fact * i;
            }
            Console.WriteLine("la factorielle de" + " " + nbre + " " + "est " + " " + fact);

        }
        static void Main(string[] args)
        {
            int nbre = 0;
            int fact = 1 ;
            Console.WriteLine("Entrer un entier");
            nbre = Convert.ToInt32(Console.ReadLine());
            TrouverFacto(ref fact, nbre);
        }
    }
}
