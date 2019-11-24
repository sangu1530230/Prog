using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratoire3__exo3
{
    class Program
    {
        enum ÉtatJeu { EnCours, XGagne, OGagne, Nulle };
        enum Case { X,Y};
        public struct Case
        {
         
            public int X;
            public int Y;
            public Case(int _X, int _Y):this()
            {
               
                X = _X;
                Y = _Y;
            }
        }
        static void AfficherMenu()
        {
            Console.WriteLine(" quelle option voulez vous choisir?");
            Console.WriteLine(" 1- Jouer contre un joueur ");
            Console.WriteLine(" 2- Jouer contre l'ordinateur ");
        }
        
     
        const char CASE_VIDE = ' ';
      
        static void caseVide(char[,]tabGrille)
        {
            for (int i = 0; i < tabGrille.GetLength(0); i++)
            {
                for (int j = 0; j < tabGrille.GetLength(0); j++)
                {
                    tabGrille[i, j] = '_';
                }
            }
        }
        
        static void InitialiserGrille(char[,] tabGrille)
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tabGrille[i, j] = [i,j].ToString();
                }
            }
        }
     
        static bool CaseDisponible(char[,] tabGrille, Case maCase)
        {
                      
                while (maCase == false)
                {
                    Console.WriteLine(" saisir un emplacement : ");
                    if (tabGrille[maCase - 1, maCase - 1]= ' ')
                    {
                       maCase = true;
                    }
                    else
                    {
                        Console.WriteLine(" cette case est occupée");
                    }
                }
           
            return maCase;
        }
       
        static Case ChoisirCaseLibre(char[,] tabGrille, Random rnd)
        {
            Case maCase = new Case(rnd.Next(0, tabGrille.GetLength(0)), rnd.Next(0, tabGrille.GetLength(1)));
            
            while (!CaseDisponible(tabGrille, maCase))
                maCase = new Case(rnd.Next(0, tabGrille.GetLength(0)), rnd.Next(0, tabGrille.GetLength(1)));
            return maCase;
        }
       
        static Case SaisirCase()
        {
            int x,
                y;
            Console.Write("Entrez la coordonnée 'x' de votre choix : ");
            x = int.Parse(Console.ReadLine());
            Console.Write("Entrez la coordonnée 'y' de votre choix : ");
            y = int.Parse(Console.ReadLine());
            return new Case(x, y);
        }
        
        static Case LireCaseLibre(char[,] tabGrille)
        {
            Case maCase = SaisirCase();
            while (!CaseDisponible(tabGrille, maCase))
                maCase = SaisirCase();
            return maCase;
        }

        static void AfficherGrille(char[,] tabGrille)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    switch (tabGrille[i, j])
                    {
                        case CASE_VIDE:
                            Console.Write("|_|");
                            break;
                        case Case.Y:
                            Console.Write("|O|");
                            break;
                        case Case.X:
                            Console.Write("|X|");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
     
        static bool LigneGagnante(char[,] tabGrille, int ligne)
        {
            char symbole = tabGrille[0, 0];
            bool gagnant = symbole != CASE_VIDE;
            if (tabGrille[1,0] == tabGrille[2,0] && tabGrille[2,0] == tabGrille[3,0])
            { gagnant = true; }   

            else if (tabGrille[4,0] == tabGrille[5,0] && tabGrille[5,0] == tabGrille[6,0])
            { gagnant = true;  }         

            else if (tabGrille[6,0] == tabGrille[7,0] && tabGrille[7,0] == tabGrille[8,0])
            {  gagnant = true; }
            return gagnant;
        }
       
        static bool ColonneGagnante(char[,] tabGrille, int colonne)
        {
            char symbole = tabGrille[0, 0];
            bool gagnant = symbole != CASE_VIDE;
            if (tabGrille[0, 1] == tabGrille[0, 4] && tabGrille[0, 4] == tabGrille[0, 7])
            { gagnant = true; }

            else if (tabGrille[0, 2] == tabGrille[0, 5] && tabGrille[0,5] == tabGrille[0, 8])
            { gagnant = true; }

            else if (tabGrille[0, 3] == tabGrille[0, 6] && tabGrille[0, 6] == tabGrille[0, 9])
            { gagnant = true; }
            return gagnant;
           
        }      
        static bool DiagonaleGagnante(char[,] tabGrille)
        {
            
            char symbole = tabGrille[0, 0];
            bool gagnant = symbole != CASE_VIDE;
            for (int i = 1; i < tabGrille.GetLength(0) && gagnant; ++i)
            {
                if (tabGrille[i, i] != symbole)
                {
                    gagnant = false;
                }
            }
            if (!gagnant)
            {
                symbole = tabGrille[2, 0];
                gagnant = symbole != CASE_VIDE;
                for (int i = 1; i < tabGrille.GetLength(0) && gagnant; ++i)
                {
                    if (tabGrille[tabGrille.GetLength(0) - i, i] != symbole)
                    {
                        gagnant = false;
                    }
                }
            }
            return gagnant;
        }
       
        static ÉtatJeu DéterminerGagnantSelon(char contenuCase)
        {
            ÉtatJeu résultat;
            if (contenuCase == 'X')
            {
                résultat = ÉtatJeu.XGagne;
            }
            else
            {
                résultat = ÉtatJeu.OGagne;
            }
            return résultat;
        }
        
        static int Compter(char[,] tabGrille, char choix)
        {
            int cpt = 0;
            for (int i = 0; i < tabGrille.GetLength(0); i++)
            {
                for (int j = 0; j < tabGrille.GetLength(0); j++)
                {
                    if (tabGrille[i, 0] == 'x')
                        cpt++;
                    else if (tabGrille[0, j] == 'Y')
                        cpt++;
                    else if(tabGrille[i,j]== ' ')
                            cpt++;
                }
            }
            return cpt;
        }
  
        static bool CasePleine(char[,] tabGrille)
        {
            return Compter(tabGrille, CASE_VIDE) == 0;
        }
      
        static ÉtatJeu AnalyserGrille(char[,] tabGrille)
        {
            ÉtatJeu résultat = ÉtatJeu.EnCours;

            for (int ligne = 0; ligne < tabGrille.GetLength(0) && résultat == ÉtatJeu.EnCours; ++ligne)
            {
                if (LigneGagnante(tabGrille, ligne))
                {
                    résultat = DéterminerGagnantSelon(tabGrille[ligne, 0]);
                }
            }

            if (résultat == ÉtatJeu.EnCours)
            {
                for (int colonne = 0; colonne < tabGrille.GetLength(1) && résultat == ÉtatJeu.EnCours; ++colonne)
                {
                    if (ColonneGagnante(tabGrille, colonne))
                    {
                        résultat = DéterminerGagnantSelon(tabGrille[0, colonne]);
                    }
                }
            }
           
            if (résultat == ÉtatJeu.EnCours)
            {
                if (DiagonaleGagnante(tabGrille))
                {
                    résultat = DéterminerGagnantSelon(tabGrille[1, 1]);
                }
            }

            if (résultat == ÉtatJeu.EnCours && CasePleine(tabGrille))
            {
                résultat = ÉtatJeu.Nulle;
            }
            return résultat;
        }

        static void Main(string[] args)
        {
            const int nbe = 3;
            Random rnd = new Random();
            char[,] tabGrille = new char[nbe, nbe];
            char[] Case = { 'X', 'O' };
            int tour = 0;
            Case maCase ;
            ÉtatJeu partie = ÉtatJeu.EnCours;
            int choix = 0;
            AfficherMenu();                     
            InitialiserGrille(tabGrille);
            while (partie == ÉtatJeu.EnCours)
            {
                AfficherGrille(tabGrille);
                choix = Convert.ToInt32(Console.ReadLine());
               
                if (choix == 2)
                {
                    maCase = ChoisirCaseLibre(tabGrille, rnd);
                }
                else
                {
                    maCase = LireCaseLibre(tabGrille);
                }
                Console.WriteLine("{0} a choisi ({1},{2})", choix, maCase.X, maCase.Y);
                tabGrille[maCase.X, maCase.Y] = Case[tour % 2];
                partie = AnalyserGrille(tabGrille);
                ++tour;             
            }
            Console.WriteLine("La partie s'est terminée en {0} tours", tour);
            AfficherGrille(tabGrille);
            switch (partie)
            {
                case ÉtatJeu.Nulle:
                    Console.WriteLine("Partie nulle");
                    break;
                case ÉtatJeu.OGagne:
                    Console.WriteLine("Les 'O' ont gagné");
                    break;
                case ÉtatJeu.XGagne:
                    Console.WriteLine("Les 'X' ont gagné");
                    break;
            }
            Console.WriteLine(" quelle option voulez vous?");
            Console.WriteLine(" 1- rejouer une nouvelle partie");
            Console.WriteLine(" 2- quitter le  programme ");
            choix = Convert.ToInt32(Console.ReadLine());
            if (choix == 1)
            {
                do
                {
                    while (partie == ÉtatJeu.EnCours)
                    {
                        AfficherGrille(tabGrille);
                        choix = Convert.ToInt32(Console.ReadLine());

                        if (choix == 2)
                        {
                            maCase = ChoisirCaseLibre(tabGrille, rnd);
                        }
                        else
                        {
                            maCase = LireCaseLibre(tabGrille);
                        }
                        Console.WriteLine("{0} a choisi ({1},{2})", choix, maCase.X, maCase.Y);
                        tabGrille[maCase.Y, maCase.X] = Case[tour % 2];
                        partie = AnalyserGrille(tabGrille);
                        ++tour;
                    }
                    Console.WriteLine("La partie s'est terminée en {0} tours", tour);
                    AfficherGrille(tabGrille);
                    switch (partie)
                    {
                        case ÉtatJeu.Nulle:
                            Console.WriteLine("Partie nulle");
                            break;
                        case ÉtatJeu.OGagne:
                            Console.WriteLine("Les 'O' ont gagné");
                            break;
                        case ÉtatJeu.XGagne:
                            Console.WriteLine("Les 'X' ont gagné");
                            break;
                    }
                    Console.WriteLine(" quelle option voulez vous?");
                    Console.WriteLine(" 1- rejouer une nouvelle partie");
                    Console.WriteLine(" 2- quitter le  programme ");
                } while (choix != 1);
            }
            if(choix==2)
            {
                Console.WriteLine("merci! a la prochaine");
            }

        }
    }
}
