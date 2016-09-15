﻿using System;
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
            

            Classement classement;

            Console.WriteLine("Persistance ? Tapez :\n" +
                              "- 1 pour du binaire\n" +
                              "- Autre chose pour du XML");

            string choixPersistance = Console.ReadLine();
            int choice;
            Int32.TryParse(choixPersistance, out choice);

            
            IStrategyPersistable objet = Factory.IStrategyPersistable((ChoixPersistance)choice);
            classement = new Classement(objet);
          

            
            Jeu j;
            Classement clt = classement.Load();
            j = new Jeu(clt);


            while (true)
            {
                Console.WriteLine("Que souhaitez vous faire ? Tapez :\n"+
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

            classement.Save(clt);
        }
    }
}
