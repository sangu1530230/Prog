using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_final
{
    class Program
    {
        public struct Metaux
        {
            public string nom;
            public int resistance;
            public int pointFusion;
            public int poids;
            public int conductiviteTher;
           
           

            public Metaux(string _nom, int _resistance, int _pointFusion, int _poids, int _conductiviteTher) : this()
            {
                nom = _nom;
                resistance = _resistance;
                pointFusion = _pointFusion;
                poids = _poids;
                conductiviteTher = _conductiviteTher;
               
                
            }
        }
        static void AfficherMenu()
        {
            Console.WriteLine(" veuillez choisir l’une des options suivantes");
            Console.WriteLine("1-Connaitre le metal avec la pire resistance");
            Console.WriteLine("2-connaitre le metal avec le meilleur score");
            Console.WriteLine("3-savoir si un metal avec un point de fusion superieur de plus de 8 existe");
            Console.WriteLine("4-creer un nouvel alliage");
            Console.WriteLine("5-quitter");
        }
        static void AfficherSiMetauxExisteAvecPointFusionPlus8(Metaux[] tabMetaux)
        {
            bool trouve = false;
            int pointFusionRecherche = 8, cpt = 0;
            while (trouve == false && cpt < tabMetaux.Length)
            {
                if (tabMetaux[cpt].pointFusion > pointFusionRecherche)
                {
                    trouve = true;
                }
                else
                {
                    cpt++;
                }
            }

            if (trouve==true)
            {
                Console.WriteLine("il existe un metal avec plus de 8 point de fusion");
            }
            else
            {
                Console.WriteLine("il n existe pas de metal avec plus de 8 point de fusion");
            }
        }
        static void AfficherMetalPireResistance(Metaux[] tabMetaux)
        {
            int pireResistance = 7;
            int pos = 0;

            for (int i = 0; i < tabMetaux.Length; i++)
            {
                if (tabMetaux[i].resistance < pireResistance)
                {
                    pireResistance = tabMetaux[i].resistance;
                    pos = i;
                }
            }

            Console.WriteLine("Le metal avec la pire resistance est :" + tabMetaux[pos].nom);
        }
        static void afficherMeilleurScore(Metaux[] tabMetaux, int somme, double moyenne)
        {

            for (int i = 0; i < tabMetaux.Length; i++)
            {
                somme += tabMetaux[i].resistance + tabMetaux[i].pointFusion + tabMetaux[i].poids + tabMetaux[i].conductiviteTher;
            }
            moyenne = somme / tabMetaux.Length;
            Console.WriteLine("le moyenne est" + " " + moyenne);
        
            double meilleurScore =0;
            int pos = 0;

            for (int i = 0; i < tabMetaux.Length; i++)
            {
                if (moyenne > meilleurScore)
                {
                    meilleurScore = moyenne;
                    pos = i;
                }
            }

            Console.WriteLine("Le metal avec la meilleure score est :"+ tabMetaux[pos].nom);

        }
        static void creerAlliage()
        {
            string choix = "metal"; int pourcentage = 0; int result = 0;
            Console.WriteLine(" veillez choisir deux metaux");
            choix = Convert.ToString(Console.ReadLine());
            switch(choix)
            {
                case "fer": pourcentage = 20; break;
                case " cuivre": pourcentage = 30 ; break;
                case " plomb": pourcentage = 25 ; break;
                case " zinc ": pourcentage = 25 ;break;
            }
                      
         
        }
        static void Main(string[] args)
        {
            bool quitter = false;  int somme = 0; double moyenne=0;          
            Metaux[] tabMetaux = new Metaux[4];
            tabMetaux[0] = new Metaux("Fer", 7, 9,4,3);
            tabMetaux[1] = new Metaux("Cuivre", 4, 8, 8, 2);
            tabMetaux[2] = new Metaux("Plomb", 1, 3, 7, 2);
            tabMetaux[3] = new Metaux("Zinc", 2, 5, 3, 6);
            while(quitter!=true)
            {
                AfficherMenu();
                int choix = Convert.ToInt32(Console.ReadLine());
                switch (choix)
                {
                    case 1: AfficherMetalPireResistance(tabMetaux); break;
                    case 2: afficherMeilleurScore( tabMetaux, somme, moyenne); break;
                    case 3: AfficherSiMetauxExisteAvecPointFusionPlus8(tabMetaux); break;
                    case 4: ; break;
                    case 5: quitter = true; break;
                }
               
            }
            
        }
    }
}
