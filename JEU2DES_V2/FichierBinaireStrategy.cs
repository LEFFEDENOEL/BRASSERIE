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
    public class FichierBinaireStrategy<T> : IStrategyPersistable<T>
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

        //Methodes Load et Save pour persistance et récupération de l'objet

        public bool Load(string nomFichier, out T t)
        {
            if (File.Exists(nomFichier + ".txt"))
            {
                //Utilisation de using car implémentation IDisposable
                using (Stream fichier = File.OpenRead(nomFichier + ".txt"))
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    object obj = serializer.Deserialize(fichier);

                    fichier.Close();
                    t = (T)(obj);
                    return true;
                }
            }
            else
            {
                t = default(T);
                return false;
            }
        }

        public bool Save(string nomFichier, T t)
        {
            try
            {
                //Utilisation de using car implémentation de IDisposable
                using (Stream fichier = File.Create(nomFichier + ".txt"))
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    serializer.Serialize(fichier, t);
                    fichier.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                File.Delete(nomFichier + ".txt");
                return false;
            }
        }

        #endregion

    }
}