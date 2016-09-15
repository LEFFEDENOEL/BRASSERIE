﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using JEU2DES;

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

            if (choixPersistance == "1") classement = new ClassementBinaire();
            else classement = new ClassementXml();

            classement.Load();

            Jeu j;
            j = new Jeu(classement);


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

            classement.Save();
        }
    }
}
