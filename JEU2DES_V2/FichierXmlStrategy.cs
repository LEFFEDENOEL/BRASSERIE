using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;


namespace JEU2DES_V2
{
    [Serializable]
    /// <summary>
    /// Classe implémentant l'interface IStrategyPersistable
    /// </summary>
    public class FichierXmlStrategy<T> : IStrategyPersistable<T>
    {
        #region Champs et Propriétés       
        #endregion

        #region Constructeurs

        //Constructeur par défaut
        public FichierXmlStrategy() { }

        #endregion

        #region Methodes
        #endregion

        #region Methodes héritées et substituées
        #endregion

        #region Methodes à implementer pour les interfaces

        //Methodes Load et Save pour persistance et récupération de l'objet
        public bool Load(string nomFichier, out T t)
        {
            if (File.Exists(nomFichier + ".xml"))
            {
                //Utilisation de using car implémentation IDisposable
                using (Stream fichier = File.OpenRead(nomFichier + ".xml"))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    Object obj = serializer.Deserialize(fichier);

                    //L'objet doit être casté pour qu'on puisse accéder à ces méthodes

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
                using (Stream fichier = File.Create(nomFichier + ".xml"))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(fichier, t);
                    fichier.Close();

                    return true;
                }
            } catch (Exception e)
            {
                return false;
            }
        }
        #endregion

    }
}
