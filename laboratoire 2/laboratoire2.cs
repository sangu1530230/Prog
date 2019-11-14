using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratoire_2
{
    enum Sorte { Coeur = 1, Pique = 2, Carreau = 3, Trèfle = 4 };
    class Program
    {
        static Random rnd = new Random();
        public struct Carte
        {
            public Sorte sorteCarte;
            public int valeur;
            public int ptsJeu;

            public Carte(Sorte _sorteCarte, int _valeur, int _ptsJeu) : this()
            {
                sorteCarte = _sorteCarte;
                valeur = _valeur;
                ptsJeu = _ptsJeu;
            }
        }
        public struct Joueur
        {
            public Carte[] carteJoueur;
            public int nbreVie;
            public Joueur(Carte carte1, Carte carte2, Carte carte3) : this()
            {
                carteJoueur = new Carte[3];
                nbreVie = 3;
                carteJoueur[0] = carte1;
                carteJoueur[1] = carte2;
                carteJoueur[2] = carte3;
            }
            static public void InitialiserCarte(ref Carte[] tabCarte)
            {
                int k = 0;
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 14; j++)
                    {
                        tabCarte[k].sorteCarte = (Sorte)i;
                        tabCarte[k].valeur = j;
                        if (j == 1)
                            tabCarte[k].ptsJeu = 11;
                        else if (j > 9)
                            tabCarte[k].ptsJeu = 10;
                        else
                            tabCarte[k].ptsJeu = j;
                        k++;

                    }
                }
            }


            static public void PermutCarte(ref Carte[] tabCarte, int carteSelect, int maxTab)
            {
                Carte carteTemp;
                carteTemp = tabCarte[carteSelect];
                tabCarte[carteSelect] = tabCarte[maxTab];
                tabCarte[maxTab] = carteTemp;
            }
            static public void ChangerCarte(ref Carte[] tabCarte, int carteChangee, ref Joueur Joueur1, ref int maxTab)
            {
                int carteSelect;
                carteSelect = rnd.Next(0, maxTab + 1);
                PermutCarte(ref tabCarte, carteSelect, maxTab);
                Joueur1.carteJoueur[carteChangee] = tabCarte[maxTab];
                maxTab--;

            }
            static public void ChangerCarteRetournee(ref Carte[] tabCarte, int carteChangee, ref Joueur Joueur1, ref int maxTab, ref int carteRetournee )
            {
                int carteSelect;               
                carteSelect = rnd.Next(0, maxTab + 1);
                PermutCarte(ref tabCarte, carteSelect, maxTab);
                carteRetournee = maxTab;
                Joueur1.carteJoueur[carteChangee] = tabCarte[carteRetournee];
                maxTab--;
            }
            static public int CalculerptsCartes(Joueur joueur)
            {
                int valeurCarte;
                int[] tabValeur = new int[3];
                for (int i = 0; i < 3; i++)
                {
                    int v = (int)joueur.carteJoueur[i].sorteCarte;
                    int w = joueur.carteJoueur[i].ptsJeu;
                    tabValeur[v - 1] = tabValeur[v - 1] + w;
                }
                valeurCarte = tabValeur[0];
                for (int i = 1; i < 4; i++)
                {
                    if (tabValeur[i] > valeurCarte)
                        valeurCarte = tabValeur[i];
                }
                return valeurCarte;
            }
            static void Main(string[] args)
            {
                bool nouvelManche= false, nouveauTour , dernierTour ; Joueur joueur1, joueurPc;
                Carte tabIni = new Carte(0, 0, 0);
                joueur1 = new Joueur(tabIni, tabIni, tabIni);
                joueurPc = new Joueur(tabIni, tabIni, tabIni);
                do
                {
                    // distribuer les cartes aux joueurs
                    Carte[] tabCarte = new Carte[52];
                    nouveauTour = true; dernierTour = false;
                    int carteSelect; int maxTab = 51; Carte carteTemp; int carteRetournee; int carteChangee;
                    Carte[] carteJoueur = new Carte[3];
                    carteRetournee = Convert.ToInt32(rnd.Next(0, maxTab + 1));
                    PermutCarte(ref tabCarte, carteRetournee, maxTab);
                    carteRetournee = maxTab;
                    maxTab--;
                    // initialiser et remplir les 52 cartes
                    InitialiserCarte(ref tabCarte);
                    // DISTRIBUTION DES CARTES
                    for (int i = 0; i < 3; i++)
                    {
                        carteSelect = rnd.Next(0, maxTab + 1);
                        PermutCarte(ref tabCarte, carteSelect, maxTab);
                        joueur1.carteJoueur[i] = tabCarte[maxTab];
                        maxTab--;
                      
                        joueurPc.carteJoueur[i] = tabCarte[maxTab];
                        maxTab--;
                    }
                    do
                    {
                        Console.WriteLine(" Distribution des cartes : ");
                        for (int i = 0; i < 3; i++)
                        {
                            Console.WriteLine((i + 1) + "  sorte : " + joueur1.carteJoueur[i].sorteCarte + "  points  : " + joueur1.carteJoueur[i].ptsJeu);
                        }
                        Console.WriteLine("   sorte carte retournee : " + tabCarte[carteRetournee].sorteCarte +  "  points  : " + tabCarte[carteRetournee].ptsJeu);
                        int choix;
                        Console.WriteLine(" Que voulez vous faire ?");
                        Console.WriteLine(" 1 - utiliser la carte retournee ");
                        Console.WriteLine(" 2 - utiliser une nouvelle carte ");
                        Console.WriteLine(" 3 - Game over ");
                        choix = Convert.ToInt32(Console.ReadLine());
                        switch (choix)
                        {
                            case 1:
                                {
                                    Console.WriteLine("Quelle carte voulez vous changez?  ");
                                    carteChangee = Convert.ToInt32(Console.ReadLine());
                                    ChangerCarteRetournee(ref tabCarte,  carteChangee-1, ref joueur1, ref maxTab, ref carteRetournee);
                                }; break;

                            case 2:
                                {
                                    Console.WriteLine("Quelle carte voulez vous changer?  ");
                                    carteChangee = Convert.ToInt32(Console.ReadLine());
                                    ChangerCarte(ref tabCarte, carteChangee-1, ref joueur1, ref maxTab);
                                }; break;

                            case 3:
                                {
                                    Console.WriteLine(" total point  : " + CalculerptsCartes(joueur1));
                                    if (CalculerptsCartes(joueur1) < 21)
                                        Console.WriteLine("votre jeu vaut  moins de 21 points, vous ne pouvez pas mettre fin a ce tour  ");
                                    else
                                    {
                                        Console.WriteLine("game over ");
                                        nouveauTour = false;
                                    }
                                }; break;
                            default: break;
                        }
                        if (dernierTour == true)
                        {
                            nouveauTour = false;
                        }

                    } while (nouveauTour == true && maxTab > 1);

                    Console.WriteLine("pts joueur1 : " + CalculerptsCartes(joueur1) + " pts pc : " + CalculerptsCartes(joueurPc));

                    if (CalculerptsCartes(joueur1) < CalculerptsCartes(joueurPc))
                    {
                        Console.WriteLine(" vous avez perdu cette cette manche!");

                        joueur1.nbreVie--;

                    }
                    else if (CalculerptsCartes(joueur1) > CalculerptsCartes(joueurPc))
                    {
                        Console.WriteLine(" vous avez gagne cette manche!");

                        joueurPc.nbreVie--;
                    }
                    else
                    {
                        Console.WriteLine(" partie egale!");
                    }
                    Console.WriteLine("vie jouueur1 : " + joueur1.nbreVie + " vie du pc: " + joueurPc.nbreVie);
                    if (joueur1.nbreVie == 0 || joueurPc.nbreVie == 0) nouvelManche = false;

                } while (nouvelManche);

                if (joueur1.nbreVie != 0)
                {
                    Console.WriteLine(" vous avez gagne!");
                }
                else
                {
                    Console.WriteLine(" vous avez perdu!");
                }
            }
        }
    }
}
