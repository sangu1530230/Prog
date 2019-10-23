using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice2_atelier1
{
    class Program
    {
        static void AfficherMenu()
        {
            Console.WriteLine("que voulez vous faire?");
            Console.WriteLine("1-trouvez le plus grand nombre");
            Console.WriteLine("2-trouvez le plus petit nombre");
            Console.WriteLine("3-verifier si le nombre saisi existe dans le tableau");
            Console.WriteLine("4-faire la moyenne");
            Console.WriteLine("5-verifier s'il éxiste un nombre plus grand que 9995");
            Console.WriteLine("6-verifier si un nombre  revient plus de trois fois");
            Console.WriteLine("7-quitter le programme");
        }
        static void TrouverGrandNombre( int plusGrandNombre, ref int[] tableauValeur)
        {
            for (int i = 0; i < 300; i++)
                if (plusGrandNombre < tableauValeur[i])
                {
                    plusGrandNombre = tableauValeur[i];
                }
            Console.WriteLine("le plus grand nombre est" + " " + plusGrandNombre);
        }
        static void TrouverPetitNombre(int plusPetitNombre, ref int[] tableauValeur)
        {
            for (int i = 0; i < 300; i++)
                if (plusPetitNombre > tableauValeur[i])
                {
                    plusPetitNombre = tableauValeur[i];
                }
            Console.WriteLine("le plus petit nombre est" + " " + plusPetitNombre);
        }
        static void NombrExistetPosition(int nombreSaisi, int position,bool nombreExiste , ref int[] tableauValeur)
        {
            for (int i = 0; i < 300; i++)
            {
                if (nombreSaisi == tableauValeur[i])
                {
                    nombreExiste = true;
                    position = i;
                }
            }
            if (nombreExiste == true)
            {
                Console.WriteLine("le nombre saisi  existe dans le tableau a la position" + "" + position + "");
            }
            else if (nombreExiste == false)
            {
                Console.WriteLine("le nombre saisi  n'existe pas dans le tableau");
            }
        }
        static void TrouverMoyenne(double moyenne,int somme, ref int[] tableauValeur)
        {
            for (int i = 0; i < 300; i++)
            {
                somme += tableauValeur[i];
            }
            moyenne = somme / 300;
            Console.WriteLine("la moyenne est de :" + " " + moyenne);
        }
        static void PlusGrand9995( int plusGrandNombre, ref int[] tableauValeur)
        {
            for (int i = 0; i < 300; i++)
                if (plusGrandNombre < tableauValeur[i])
                {
                    plusGrandNombre = tableauValeur[i];
                }

            if (plusGrandNombre > 9995)
            {

                Console.WriteLine("le nombre plus grand que 9995 existe dans le tableau");
            }
            else
            {
                Console.WriteLine("le nombre plus grand que 9995 n'existe pas dans le tableau");
            }


        }
        static void PlusTroisfois(int nombreSaisi, int compt, ref int[] tableauValeur)
        {
            for (int i = 0; i < 300; i++)
            {
                if (nombreSaisi == tableauValeur[i])
                    compt++;
            }

            if (compt > 3)
                Console.WriteLine("le nombre saisi apparait plus de trois fois  dans le tableau");
            else
                Console.WriteLine("le nombre saisi n'apparait pas plus de trois fois  dans le tableau");
        }
        static void QuitterProgramme()
        { Console.WriteLine("ce fut un plaisr, a la prochaine!"); }



        static void Main(string[] args)
        {
            int[] tableauValeur = new int[300];
            Random generateurNb = new Random();
            //affectation des valeurs generees par le programme
            for(int i=0; i<300; i++)
                tableauValeur[i] = (int)generateurNb.Next(1, 10001);

            // affichage du menu
            int choix = 0;
            AfficherMenu();
            choix = Convert.ToInt32(Console.ReadLine());

            int nombreSaisi = 0;
            int position = 1;
            int compt = 0;
            int plusGrandNombre = tableauValeur[0];
            int plusPetitNombre = tableauValeur[0];
            int somme = 0;
            double moyenne = 0.0;

            //Trouver le plus grand nombre 
            if (choix == 1)
            {
                TrouverGrandNombre(plusGrandNombre, ref tableauValeur);
            }

            //Trouver le plus petit nombre          
            else if (choix == 2)
            {
                TrouverPetitNombre(plusPetitNombre, ref tableauValeur);
            }

            //Verifier si le nombre saisi existe dans le tableau et donner sa position                                        
            else if (choix == 3)
            {

                bool nombreExiste = false;
                Console.WriteLine("saisi un nombre");
                nombreSaisi = Convert.ToInt32(Console.ReadLine());
                NombrExistetPosition(nombreSaisi, position, nombreExiste, ref tableauValeur);
            }

            // faire la moyenne          
            else if (choix == 4)
            {
                TrouverMoyenne(moyenne, somme, ref tableauValeur);
            }
            //verifier s'il éxiste un nombre  plus grand que 9995
            else if (choix == 5)
            {
                PlusGrand9995(plusGrandNombre, ref tableauValeur);
            }
            // verifier si le nombre saisi apparait plus de trois fois 
            
            else if (choix == 6)
            {
                Console.WriteLine("saisi un nombre");
                nombreSaisi = Convert.ToInt32(Console.ReadLine());
                PlusTroisfois(nombreSaisi, compt, ref tableauValeur);
            }

            // quitter le programme
            else if (choix == 7)
            {
                QuitterProgramme();
            }
        }
    }
}
