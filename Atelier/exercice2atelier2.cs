using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice_2_atelier_2
{
    class Program
    {
        static void AfficherMenu()
        {
            Console.WriteLine("quel est le niveau de difficulté");
            Console.WriteLine("1- Facile: 1 a 100");
            Console.WriteLine("2- Moyen: 1 a 1000");
            Console.WriteLine("3- Difficile: 1 a 10000");
        }
        static void ValeurGrande(ref int nbre, int nombre)
        {
           if (nbre > nombre)
           {
              Console.WriteLine("la valeur saisie est plus grande que la valeur normale");
           }
        }
        static void ValeurPetite(ref int nbre, int nombre)
        { 
            if (nbre < nombre)
            {
                Console.WriteLine("la valeur saisie est plus petite que la valeur normale");
            }

        }
        static void ValeurEgale(ref int nbre, int nombre, int compt)
        {
            if (nbre == nombre)
            {
                Console.WriteLine("la valeur saisie est egale a la valeur normale");
                Console.WriteLine("le nombre a éte saisi" +  " " +  compt +  " fois " );
            }
        }
        static void ValeurIntervalle(ref int nbre, int nombre)
        {
            if (nbre > nombre - 5 && nbre < nombre + 5 && nbre!=nombre)
            {
                Console.WriteLine("la valeur saisie est dans une marge de plus ou moins 5 de la valeur normale");
            }
        }

    static void Main(string[] args)
        {
            int choix = 0;
            AfficherMenu();
            choix = Convert.ToInt32(Console.ReadLine());

            if (choix == 1)
            {
                    int nombre = 0;
                    int nbre = 0;
                    int compt = 0;
                    Random generateurNb = new Random();
                    nombre = (int)generateurNb.Next(1, 101);
                      do
                      {                
                        Console.WriteLine("Entrer un nombre");
                         nbre = Convert.ToInt32(Console.ReadLine());
                          compt++;

                          ValeurGrande(ref nbre, nombre);
                          ValeurPetite(ref nbre, nombre);
                          ValeurEgale(ref nbre, nombre, compt);
                          ValeurIntervalle(ref nbre, nombre);

                      } while (nbre!=nombre);
            }
            if (choix == 2)
            {
                
                    int nombre = 0;
                    int nbre = 0;
                    int compt = 0;
                    Random generateurNb = new Random();
                    nombre = (int)generateurNb.Next(1, 1001);
                    do
                    { 
                        Console.WriteLine("Entrer un nombre");
                        nbre = Convert.ToInt32(Console.ReadLine());
                        compt++;

                        ValeurGrande(ref nbre, nombre);
                        ValeurPetite(ref nbre, nombre);
                        ValeurEgale(ref nbre, nombre, compt);
                        ValeurIntervalle(ref nbre, nombre);

                    } while (nbre != nombre);
            }
            if (choix == 3)
            {              

                    int nombre = 0;
                    int nbre = 0;
                    int compt = 0;
                    Random generateurNb = new Random();
                    nombre = (int)generateurNb.Next(1, 10001);
                   do
                   {
 
                        Console.WriteLine("Entrer un nombre");
                        nbre = Convert.ToInt32(Console.ReadLine());
                        compt++;

                        ValeurGrande(ref nbre, nombre);
                        ValeurPetite(ref nbre, nombre);
                        ValeurEgale(ref nbre, nombre, compt);
                        ValeurIntervalle(ref nbre, nombre);

                   } while (nbre != nombre);
                 
            }   
        }
    }
}
        