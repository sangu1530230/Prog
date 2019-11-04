using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_pratique

  
    class Program
    {
        enum nom { aa = 1, ab = 2, ac = 3, ad = 4, ae = 5, af = 6, ag = 7, ah = 8, ai = 9, aj = 10 }
        enum rarete { commun = 1, rare = 2, epique = 3, legendaire = 4 }

        public struct Vaisseau
        {
            public string nom;
            public rarete[] tabRar;
            public int vitesse;
            public int vie;
            public int prix;
            public Vaisseau (string _nom, int _vitesse,int _vie, int _prix):this()
            {

                nom = _nom;              
                vitesse = _vitesse;
                vie = _vie;
                prix = _prix;
                rarete[] tabRar = new rarete[4];
                Random rnd = new Random();
                for (int i=0; i< tabRar.Length; i++)
                {
                    tabRar[i] = rnd.Next(1, 5);
                }
            }
        }
        public struct rarete
        {
            public string type;           
            public int vitesse;
            public int vie;
            public int prix;
            public rarete(string _type, int _vitesse, int _vie, int _prix) : this()
            {
            rarete[] tabRar = new rarete[4];
            Random rnd = new Random();
            for (int i = 0; i < tabRar.Length; i++)
            {
                tabRar[i].type = rnd.Next(1,5);
                tabRar[i].vitesse = rnd.Next(10, 71);
                tabRar[i].vie = rnd.Next(100, 2001);
                tabRar[i].prix = rnd.Next(2000, 20001);
            }
                type = _type;            
                vitesse = _vitesse;
                vie = _vie;
                prix = _prix;
            }


        }
        static void Main(string[] args)
        {
            string rarete = "";
            Console.WriteLine("Veuillez la rarete du vaisseau ");
            rarete = Console.ReadLine();
            Vaisseau[] tabVai = new Vaisseau[10];
            rarete[] tabRar = new rarete[4];
        Random rnd = new Random();
        for (int i = 0; i < tabVai.Length; i++)
        {
            tabVai[i].nom = rnd.Next(1, 11);
            tabVai[i].vitesse = rnd.Next(10, 71);
            tabVai[i].vie = rnd.Next(100, 2001);
            tabVai[i].prix = rnd.Next(2000, 20001);
        }

        int choix = 0;
            Console.WriteLine(" entrer une option");
            Console.WriteLine(" 1- Afficher les vaisseaux avec toutes les caracteristiques");
            Console.WriteLine("2-verifier si un vaisseau legendaire existe");
            Console.WriteLine(" 3- trouver le vaisseau avec la vie la plus haute");
            Console.WriteLine(" 4- Afficher la moyenne des prix des vaisseaux");
            Console.WriteLine(" Quitter le programme");
            choix = Convert.ToInt32(Console.ReadLine());
             
            switch(choix)
            {
                case 1:
                    {
                        for ( int i=0; i<tabVai.Length; i++)
                        {
                            Console.WriteLine(" vaisseau " + (i + 1) + " nom: " + tabVai[i].nom + " rarete: " + tabVai[i].rarete + " vitesse: " + tabVai[i].vitesse + " vie " + tabVai[i].vie + " prix " + tabVai[i].prix);
                        }
                    }; break;
                case 2:
                    {
                        bool vaisseauLegExiste = false;
                        int cpt = 0;
                        int vaisseauLeg = 0;
                        Console.WriteLine("Quelle type de rarete voulez-vous ?");
                        vaisseauLeg = Convert.ToInt32(Console.ReadLine());
                        while (vaisseauLegExiste == false && cpt < tabVai.Length)
                        {
                            if (tabVai[cpt].rarete == vaisseauLeg)
                                vaisseauLegExiste = true;
                            else
                                cpt++;
                        }

                        if (vaisseauLegExiste)
                            Console.WriteLine("Il existe un vaisseau legendaire ");
                        else
                            Console.WriteLine("il n'existe pas de vaisseau legendaire ");
                    }; break;
                case 3:
                    {
                        int viePluHaut = 0; int position = 0;
                        for (int i = 0; i < tabVai.Length; i++)
                        {
                            if(viePluHaut<tabVai[i].vie)
                            {
                                viePluHaut = tabVai[i].vie;
                                position = i;
                            }
                        }
                        Console.WriteLine(" le vaisseau " + (position + 1) + " a une vie plus haute qui est de :" + viePluHaut);
                    };break;
                case 4:
                    {
                        int somme = 0; double moyenne = 0.0;
                        for (int i = 0; i < tabVai.Length; i++)
                        {
                            somme += tabVai[i].prix;
                        }

                        moyenne = somme / tabVai.Length;
                        Console.WriteLine("La moyenne des prix des vaisseaux est de " + moyenne);

                    };break;
                case 5:
                    {
                        Console.WriteLine(" merci! a la prochaine!");
                    };break;
                default: Console.WriteLine(" entrer un choix valide ");break;
            }
        }
    }
}
