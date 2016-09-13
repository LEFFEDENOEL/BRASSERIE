using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace JEU2DES
{
    public class ClassementBinaire : Classement
    {
     
        #region Champs et Propriétés

        #endregion

        #region Constructeurs
        #endregion

        #region Methodes
        #endregion

        #region Methodes héritées et substituées

        public override void Load()
        {
            if (File.Exists("sav.txt"))
            {
                using (Stream fichier = File.OpenRead("sav.txt"))
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    Object obj = serializer.Deserialize(fichier);

                    //L'objet doit être casté pour qu'on puisse accéder à ces méthodes

                    GroupePersonne gp = (GroupePersonne)obj;

                    Console.ReadKey();
                    fichier.Close();
                }
            }
        }

        public override void Save()
        {
            List<Entree> listClassement = new Entree();

            using (Stream fichier = File.Create("sav.txt"))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(fichier, listClassement);
                fichier.Close();
            }

        }


        #endregion

        #region Methodes à implementer pour les interfaces
        #endregion

    }
}
