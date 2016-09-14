using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEU2DES
{
    /// <summary>
    /// Classe mère Classement abstraite dérivée en ClassementBinaire et ClassementXml
    /// </summary>
    [Serializable]
    public abstract class Classement
    {
        #region Champs et Propriétés de Classement

        private List<Entree> _ListeDesEntrees;

        protected List<Entree> ListeDesEntrees
        {
            get { return _ListeDesEntrees; }
            set { _ListeDesEntrees = value; }
        }
        #endregion

        #region Methodes de Classement

        public void AjouterEntree(string nom, int score)
        {
            bool nouveauNom = true;

            foreach (Entree e in ListeDesEntrees)
            {
                if (e.Nom == nom)
                {
                    e.Score += score;
                    nouveauNom = false;
                    break;
                }
            }

            if (nouveauNom) ListeDesEntrees.Add(new Entree(nom, score));
            
            
        }

        public string TopN(int n)
        {
            ListeDesEntrees.OrderByDescending(e => e.Score);

            int compteur = 0;
            string topN = "Voici les "+n+" high scores :\n";

            foreach (Entree e in ListeDesEntrees)
            {
                compteur++;
                topN += e.Nom + " Score : " + e.Score + "\n";
                if (compteur == n) break;
            }
            return topN;
        }

        public string TopN()
        {
            return TopN(ListeDesEntrees.Count);

        }

        //Signatures de Load et Save pour classes dérivées sérialisation
        public abstract void Load();
        public abstract void Save();

        #endregion

        /// <summary>
        /// Déclaration de la classe Entree dans la classe Classement du fait de la composition
        /// </summary>
        protected class Entree : IComparable
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
    

