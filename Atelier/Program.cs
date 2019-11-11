using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atelier_1_string
{
    class Program
    {
        static void Main(string[] args)
        {
            int choix = 0;
            
            Console.WriteLine(" quel option voulez vous choisir? ");
            Console.WriteLine(" 1- afficher la longueur de la chaine de caractere ");
            Console.WriteLine(" 2- determiner si la phrase contient << octopus>> ");
            Console.WriteLine(" 3- connaitre la position du premier 'e' ");
            Console.WriteLine(" 4- afficher une sous phrase ");
            Console.WriteLine(" 5- transforme la chaine en majuscule puis l'affiche ");
            Console.WriteLine(" 6- transforme la chaine en minuscule puis l'affiche ");
            Console.WriteLine(" 7- terminer le programme ");
            choix = Convert.ToInt32(Console.ReadLine());
            string texte = " je recherche  un octopus ";

            switch (choix)
            {
                case 1: Console.WriteLine(texte.Length); break;
                case 2:
                    if (texte.Contains("octopus") == true)
                    {
                        Console.WriteLine(" le mot octopus existe ");
                    }
                    else
                    {
                        Console.WriteLine(" le mot octopus n'existe pas ");
                    }; break;
                case 3:
                    int positionPremiere = texte.IndexOf('e');
                    Console.WriteLine(positionPremiere) ; break;
                case 4: string[] tabMot = texte.Split(' '); Console.WriteLine(tabMot[1]);
                     break;
                case 5: string messageEnMajuscule = texte.ToUpper(); Console.WriteLine(messageEnMajuscule); break;
                case 6: string messageEnMinuscule = texte.ToLower(); Console.WriteLine(messageEnMinuscule); break;
                case 7: Console.WriteLine(" merci a la prochaine !!! "); break;
            }

        }
    }
}
