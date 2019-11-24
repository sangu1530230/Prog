using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratoire3
{
    class Program
    {

        static void Main(string[] args)
        {
            int choix = 0;
            Console.WriteLine(" Que voulez vous choisir? ");
            Console.WriteLine(" 1- Afficher le nombre de mots contenu dans la phrase ");
            Console.WriteLine(" 2- Afficher combien de fois chaque lettre apparait  ");
            Console.WriteLine(" 3- Afficher la lettre qui apparait le plus souvent ");
            Console.WriteLine(" 4- Encoder la phrase en utilisant une cle de +2 et afficher le resultat ");
            choix = Convert.ToInt32(Console.ReadLine());
            string texte = "Je suis couche sur le lit dans ma chambre";
            string[] tabTexte = texte.Split(' '); 
            int[] tabLettre = new int[26]; int max = 0; int lettre = 0; string nouveauTexte = "  ";

            switch (choix)
            {
                case 1: Console.WriteLine( " le texte compte " + tabTexte.Length + " mots"); break;
                case 2:
                    {
                        for(int i = 0; i<texte.Length; i++)
                        {
                            int indice = (int)texte[i] - 97;
                            if (indice >= 0 && indice < 26)                        
                            tabLettre[indice]++;                            
                        }
                        for (int i=0; i<tabLettre.Length; i++)
                        {
                            Console.WriteLine(" le nombre de " + (char)(i + 97) + " est de " + tabLettre[i]);
                        };break;
                    }
                case 3:
                    for (int i = 0; i < texte.Length; i++)
                    {
                        int indice = (int)texte[i] - 97;
                        if (indice >= 0 && indice < 26)
                            tabLettre[indice]++;
                    }
                    for (int i = 0; i < tabLettre.Length; i++)
                    {
                        if (tabLettre[i] > max)
                        {
                            max = tabLettre[i];
                            lettre = i;
                        }
                    }
                    Console.WriteLine(" la lettre qui apparait le plus souvent est  "  + (char)(lettre+97));break;
                case 4:
                    for (int i = 0; i < texte.Length; i++)
                    {
                        int valeurAscii = (int)texte[i];
                        nouveauTexte += char.ConvertFromUtf32(valeurAscii + 2);
                           
                    }
                    Console.WriteLine(" la phrase encodée est \n " + nouveauTexte); break;



            }

        }
    }
}
