using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace JEU2DES
{
    [Serializable]
    /// <summary>
    /// Classe dérivée de Classement pour sérialisation en binaire
    /// </summary>
    public class ClassementBinaire : Classement
    {    
        #region Champs et Propriétés

        #endregion

        #region Constructeurs

        public ClassementBinaire() : base()
        {

        }

        #endregion

        #region Methodes
        #endregion

        #region Methodes héritées et substituées

        //Methodes Load et Save pour persistance et récupération de l'objet liste de classement

        public override void Load()
        {
            if (File.Exists("saveClassementBinaire.txt"))
            {
                //Utilisation de using car implémentation IDisposable
                using (Stream fichier = File.OpenRead("saveClassementBinaire.txt"))
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    Object obj = serializer.Deserialize(fichier);

                    //L'objet doit être casté pour qu'on puisse accéder à ces méthodes

                    ListeDesEntrees = (List<Entree>)obj;
                  
                    fichier.Close();
                }
            }
        }

        public override void Save()
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

        #region Methodes à implementer pour les interfaces
        #endregion

    }
}
