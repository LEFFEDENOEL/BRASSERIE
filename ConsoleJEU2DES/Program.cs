using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using JEU2DES;
using JEU2DES_V2;

namespace ConsoleJEU2DES
{
    class Program
    {
        static void Main(string[] args)
        {
            //IStrategyPersistable<Jeu> obj = (IStrategyPersistable<Jeu>)new Jeu();
            

            Classement classement;

            Console.WriteLine("Persistance ? Tapez :\n" +
                              "- 1 pour du binaire\n" +
                              "- Autre chose pour du XML");

            string choixPersistance = Console.ReadLine();
            int choice;
            Int32.TryParse(choixPersistance, out choice);


            IStrategyPersistable<Classement> strategieDePersistance = Factory.IStrategyPersistable((ChoixPersistance)choice);


            classement = new Classement(strategieDePersistance);



            Jeu j;
            
            Classement clt;
            if (classement.Load("Classement", out clt))
            {
                j = new Jeu(clt);
            }
            else
            {
                j = new Jeu();
            }

            while (true)
                {
                    Console.WriteLine("Que souhaitez vous faire ? Tapez :\n" +
                                        "- 1 pour jouer\n" +
                                        "- 2 pour visualiser les scores\n" +
                                        "- Autre chose pour sortir du jeu");

                    string choix = Console.ReadLine();

                    if (choix != "1" && choix != "2") break;
                    else if (choix == "1")
                    {
                        Console.WriteLine("Nom du joueur ?");
                        string nom = Console.ReadLine();
                        j.JouerPartie(nom);
                    }
                    else
                    {
                        Console.WriteLine(j.VoirClassement());
                    }
                }
            

            if (!classement.Save("Classement", j.Classmt)) Console.WriteLine("Problème lors de la sauvegarde du classement");
            //Jeu j = new Jeu();
            if (new FichierBinaireStrategy<Jeu>().Save("testJeu", j))
            {
                Console.WriteLine("Le jeu a été sauvé en binaire");
            }
            else Console.WriteLine("Le jeu n'a pas été sauvé en binaire");

            if (new FichierXmlStrategy<Jeu>().Save("testJeu", j))
            {
                Console.WriteLine("Le jeu a été sauvé en XML");
            }
            else Console.WriteLine("Le jeu n'a pas été sauvé en XML");
            Console.ReadKey();
        }
    }
}
