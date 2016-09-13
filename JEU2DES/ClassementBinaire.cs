using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace JEU2DES
{
    /// <summary>
    /// Classe dérivée de Classement pour sérialisation en binaire
    /// </summary>
    public class ClassementBinaire : Classement
    {    
        #region Champs et Propriétés

        #endregion

        #region Constructeurs
        #endregion

        #region Methodes
        #endregion

        #region Methodes héritées et substituées

        //Methodes Load et Save pour persistance et récupération de l'objet liste de classement
        public override void Load()
        {
            if (File.Exists("sav.txt"))
            {
                //Utilisation de using car implémentation IDisposable
                using (Stream fichier = File.OpenRead("sav.txt"))
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    Object obj = serializer.Deserialize(fichier);

                    //L'objet doit être casté pour qu'on puisse accéder à ces méthodes

                    ClassementBinaire lc = (ClassementBinaire)obj;
                  
                    fichier.Close();
                }
            }
        }

        public override void Save()
        {
            List<Entree> listClassement = new Entree();

            //Utilisation de using car implémentation IDisposable
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
