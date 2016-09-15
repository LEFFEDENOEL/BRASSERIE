using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEU2DES_V2
{
    public class De : IComparable
    {
        public enum Chiffre { Zero, Un, Deux, Trois, Quatre, Cinq, Six };

        #region Champs et properties

        private Chiffre _Valeur = Chiffre.Zero;

        public Chiffre Valeur
        {
            get { return _Valeur; }
            private set { _Valeur = value; }
        }

        private static Random _Random = new Random();

        private Random Random
        {
            get { return _Random; }
            set { _Random = value; }
        }

        #endregion

        #region Constructeurs



        #endregion

        #region Méthodes héritées et substituées

        public override string ToString()
        {
            return "De de valeur " + Valeur;
        }

        public override bool Equals(object obj)
        {
            De d = obj as De;
            return d != null && d.Valeur == Valeur;
        }

        public override int GetHashCode()
        {
            return (int)this.Valeur;
        }

        #endregion

        #region Méthodes à implementer pour les interfaces

        public int CompareTo(object obj)
        {
            De d = obj as De;
            if (d == null) return 1;
            else return Valeur > d.Valeur ? 1 : (Valeur == d.Valeur ? 0 : -1);
        }

        #endregion

        #region Autres méthodes

        public Chiffre Lancer()
        {
            Chiffre resultatLancer = (Chiffre)Random.Next((int)Chiffre.Un, (int)Chiffre.Six);
            Valeur = resultatLancer;
            return resultatLancer;
        }

        #endregion


    }
}
