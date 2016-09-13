using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEU2DES
{
    public class Joueur
    {
        #region Champs et properties

        private string _Nom;

        public string Nom
        {
            get { return _Nom; }
            set { _Nom = value; }
        }

        private int _Score = 0;

        public int Score
        {
            get { return _Score; }
            set { _Score = value; }
        }


        #endregion

        #region Constructeurs

        public Joueur(string nom)
        {
            Nom = nom;
        }


        #endregion

        #region Méthodes héritées et substituées

        public override string ToString()
        {
            return "Joueur " + Nom + " Score" + Score;
        }

        #endregion

        #region Méthodes à implementer pour les interfaces
        #endregion

        #region Autres méthodes

        public int Jouer(De d1, De d2)
        {
            for (int i = 1; i < 11; i++)
            {
                d1.Lancer();
                d2.Lancer();
                Score = (int)d1.Valeur + (int)d2.Valeur;
            }
            return Score;
        }

        #endregion
    }
}
