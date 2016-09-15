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
    public class FichierXmlStrategy : IStrategyPersistable
    {    
        #region Champs et Propriétés       
        #endregion

        #region Constructeurs

        //Constructeur par défaut
        public FichierXmlStrategy(){}

        #endregion

        #region Methodes
        #endregion

        #region Methodes héritées et substituées
        #endregion

        #region Methodes à implementer pour les interfaces

        //Methodes Load et Save pour persistance et récupération de l'objet liste de classement
        public Classement Load()
        {
            if (File.Exists("saveClassement.xml"))
            {
                //Utilisation de using car implémentation IDisposable
                using (Stream fichier = File.OpenRead("saveClassement.xml"))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Entree>));
                    Object obj = serializer.Deserialize(fichier);

                    //L'objet doit être casté pour qu'on puisse accéder à ces méthodes

                    fichier.Close();
                    return (Classement)(obj);                  
                }
            }
            else return null;
        }

        public void Save(Classement classement)
        {
            //Utilisation de using car implémentation de IDisposable
            using (Stream fichier = File.Create("saveClassement.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Entree>));
                serializer.Serialize(fichier, classement);
                fichier.Close();
            }
        }
        #endregion

    }
}
