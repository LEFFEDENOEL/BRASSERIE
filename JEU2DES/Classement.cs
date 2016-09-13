using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEU2DES
{
    [Serializable]
    public class Classement
    {
        #region Champs et Propriétés de Classement

        private List<Entree> _ListeDesEntrees;

        private List<Entree> ListeDesEntrees
        {
            get { return _ListeDesEntrees; }
            set { _ListeDesEntrees = value; }
        }
        #endregion

        #region Methodes de Classement

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

        /// <summary>
        /// Déclaration de la classe Entree dans la classe Classement du fait de la composition
        /// </summary>
        private class Entree : IComparable
        {
            #region Champs et Propriétés de Entree

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

            #region Constructeurs de Entree

            //Constructeur par defaut
            public Entree() { }

            //Constructeur complet
            public Entree(string nom, int score)
            {
                Nom = nom;
                Score = score;
            }
            #endregion

            #region Methodes héritées et substituées de Entree

            //Redéfinition de ToString pour afficher l'objet dans son intégralité
            public override string ToString()
            {
                return "Nom du joueur : " + Nom + " Score : " + Score;
            }

            //Redéfinition de la methode CompareTo pour trier les entrées (car implémentation de IComparable) 
            public int CompareTo(object obj)
            {
                Entree ent = obj as Entree;
                if (ent != null)
                    return Score > ent.Score ? 1 : (Score < ent.Score ? -1 : 0);
                else return 0;
            }

            #endregion
        }
    }
}
    

