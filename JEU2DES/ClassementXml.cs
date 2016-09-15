using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace JEU2DES
{
    [Serializable]
    /// <summary>
    /// Classe dérivée de Classement pour sérialisation en XML
    /// </summary>
    public class ClassementXml : Classement
    {
        #region Champs et Propriétés
        #endregion

        #region Constructeurs

        public ClassementXml() : base()
        {

        }

        #endregion

        #region Methodes
        #endregion

        #region Methodes héritées et substituées

        //Methodes Load et Save pour persistance et récupération de l'objet liste de classement
        public override void Load()
        {
            if (File.Exists("saveClassement.xml"))
            {
                //Utilisation de using car implémentation IDisposable
                using (Stream fichier = File.OpenRead("saveClassement.xml"))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Entree>));
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
            using (Stream fichier = File.Create("saveClassement.xml"))
            {                
                XmlSerializer serializer = new XmlSerializer(typeof(List<Entree>));
                serializer.Serialize(fichier, ListeDesEntrees);
                fichier.Close();
            }
        }
        #endregion

        #region Methodes à implementer pour les interfaces
        #endregion

    }
}
