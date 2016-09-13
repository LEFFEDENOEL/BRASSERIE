using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEU2DES
{
    public class De
    {
        public enum Chiffre { Zero, Un, Deux, Trois, Quatre, Cinq, Six };

        #region Champs et properties

        private Chiffre _Valeur = Chiffre.Zero;

        public Chiffre Valeur
        {
            get { return _Valeur; }
            private set { _Valeur = value; }
        }


        #endregion

        #region Constructeurs

        public De()
        {

        }

        #endregion


        #region Méthodes héritées et substituées
        #endregion

        #region Méthodes à implementer pour les interfaces
        #endregion

        #region Autres méthodes

        public void Lancer()
        {
            Valeur = (Chiffre)new Random().Next((int)Chiffre.Un, (int)Chiffre.Six);
        }

        #endregion


    }
}
