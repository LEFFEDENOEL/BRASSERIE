using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEU2DES_V2
{
    [Serializable]
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

        public Joueur()
        {
            Nom = "joueur quelconque";
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
                Console.WriteLine(String.Format("{0} ème jet des dés, dé 1 : {1}, dé 2 : {2}", i, d1.Lancer(), d2.Lancer()));
                Score += (((int)d1.Valeur + (int)d2.Valeur) == 7) ? 10 : 0;
            }

            Console.WriteLine(String.Format("Score de {0} pour cette partie: {1}", Nom, Score));
            return Score;
        }

        #endregion
    }
}
