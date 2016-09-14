using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JEU2DES
{
    /// <summary>
    /// Classe dérivée de Classement pour sérialisation en XML
    /// </summary>
    class ClassementXml : Classement
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
            //Utilisation de using car implémentation IDisposable
            using (Stream fichier = File.OpenRead("saveClassement.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ClassementXml));
                Object obj = serializer.Deserialize(fichier);

                //L'objet doit être casté pour qu'on puisse accéder à ces méthodes

                this.ListeDesEntrees = ((ClassementXml)obj).ListeDesEntrees;
                fichier.Close();
            }
        }

        public override void Save()
        {
            //Utilisation de using car implémentation de IDisposable
            using (Stream fichier = File.Create("saveClassement.xml"))
            {                
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(fichier, this);
                fichier.Close();
            }
        }
        #endregion

        #region Methodes à implementer pour les interfaces
        #endregion

    }
}
