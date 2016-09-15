using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace JEU2DES_V2
{
    [Serializable]
    /// <summary>
    /// Classe implémentant la persistance dans un fichier binaire 
    /// </summary>
    public class FichierBinaireStrategy : IStrategyPersistable
    {
        #region Champs et Propriétés

        #endregion

        #region Constructeurs

        #endregion

        #region Methodes
        #endregion

        #region Methodes héritées et substituées


        #endregion

        #region Methodes à implementer pour les interfaces

        //Methodes Load et Save pour persistance et récupération de l'objet liste de classement

        public void Load()
        {
            if (File.Exists("saveClassementBinaire.txt"))
            {
                //Utilisation de using car implémentation IDisposable
                using (Stream fichier = File.OpenRead("saveClassementBinaire.txt"))
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    object obj = serializer.Deserialize(fichier);

                    //L'objet doit être casté pour qu'on puisse accéder à ces méthodes

                    ListeDesEntrees = (List<Entree>)obj;
                    

                    fichier.Close();
                }
            }
        }

        public void Save()
        {

            //Utilisation de using car implémentation de IDisposable
            using (Stream fichier = File.Create("saveClassementBinaire.txt"))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(fichier, ListeDesEntrees);
                fichier.Close();
            }
        }

        #endregion

    }
}
