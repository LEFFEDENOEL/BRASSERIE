using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using System.Runtime.Serialization.Json;

namespace ConsoleJEU2DES
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sérialisation JSON
            //Rem classe Classement Sérialisable

            using (Stream fichier = File.Create("sav.json"))
            {
                //TODO
                //List<> le = new List<>();              
                //DataContractJsonSerializer serializer = new DataContractJsonSerializer(lp.GetType());
                //serializer.WriteObject(fichier, lp);
                //fichier.Close();

            }

            //Déserialisation JSON

            using (Stream fichier = File.OpenRead("sav.json"))
            {
                //TODO
                //DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<>));
                //List<> listeRecup = (List<>)serializer.ReadObject(fichier);
                //foreach (var v in listeRecup)
                //{
                //    Console.Out.WriteLine(v);
                //}
                //Console.ReadKey();
                //fichier.Close();
            }


        }
    }
}
