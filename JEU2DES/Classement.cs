using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEU2DES
{
    public class Classement
    {
        private List<Entree> _ListeDesEntrees;

        private List<Entree> ListeDesEntrees
        {
            get { return _ListeDesEntrees; }
            set { _ListeDesEntrees = value; }
        }

        #region Methodes

        public void AjouterEntree(string nom, int score)
        {
            ListeDesEntrees.Add(new Entree(nom, score));
            ListeDesEntrees.Sort();   
        }

        public SortedDictionary<int, string> TopN(int n)
        {
            SortedDictionary<int, string> d = new SortedDictionary<int, string>();
            int compteur = 0;

            foreach (Entree e in ListeDesEntrees)
            {
                compteur++;
                d.Add(e.Score, e.Nom);
                if (compteur == n) break;
            }
            return d;

        }

        #endregion

        private class Entree : IComparable
        {
            #region Champs et Propriétés
            private string _Nom;

            public string Nom
            {
                get { return _Nom; }
                set { _Nom = value; }
            }

            private int _Score;
            public int Score
            {
                get { return _Score; }
                set { _Score = value; }
            }
            #endregion

            #region Constructeurs

            //Constructeur par defaut
            public Entree() { }

            //Constructeur complet
            public Entree(string nom, int score)
            {
                Nom = nom;
                Score = score;
            }
            #endregion

            #region Methodes héritées et substituées

            public override string ToString()
            {
                return "Nom du joueur : " + Nom + " Score : " + Score;
            }

            public int CompareTo(object obj)
            {
                //TODO
                return 0;
            }

            #endregion
        }
    }
}
    

