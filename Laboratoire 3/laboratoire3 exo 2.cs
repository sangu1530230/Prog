
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratoire3_exo_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] motsChoisis = { "orange", "vert", "jaune", "noir", "blanc", "violet", "bleu", "rouge", "rose", "grise" };
            string motAtrouve = motsChoisis[6];
            char[] motAffiche = new char[motAtrouve.Length];
            for (int i = 0; i < motAffiche.Length; i++)
            {
                motAffiche[i] = '_';
            }
            Console.WriteLine(" Bienvenue dans le jeu du pendu ");


            bool finPartie = false;
            while (finPartie == false)
            {
                for (int i = 0; i < motAffiche.Length; i++)
                {
                    Console.Write(motAffiche[i] + '_');
                }

                char lettreSaisie = 'a'; bool lettreTrouvee = false; int erreur = 0;
                Console.WriteLine(" veuillez entrer une lettre ");
                lettreSaisie = Convert.ToChar(Console.ReadLine());
                for (int i = 0; i < motAtrouve.Length; i++)
                {
                    if (lettreSaisie == motAtrouve[i])
                    {
                        motAffiche[i] = lettreSaisie;
                        lettreTrouvee = true;
                        Console.WriteLine(" la lettre saisie  figure  dans le mot ");
                    }
                }
                if (lettreTrouvee == false)
                {
                    Console.WriteLine(" la lettre saisie  ne figure pas  dans le mot ");
                    erreur++;
                    if (erreur >= 6)
                    {
                        finPartie = true;
                    }
                }
                else
                {
                    for (int i = 0; i < motAffiche.Length; i++)
                    {
                        if (motAffiche[i] == '_')
                        {
                            finPartie = false;

                        }
                        else
                        {
                            finPartie = true;
                        }
                    }
                }

            }
        }
    }
}
