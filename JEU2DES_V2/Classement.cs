using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEU2DES_V2
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

        #region Constructeurs

        public Classement()
        {
            ListeDesEntrees = new List<Entree>();
        }

        #endregion

        #region Methodes de Classement

        public void AjouterEntree(string nom, int score)
        {
            ListeDesEntrees.Add(new Entree(nom, score));

        }

        public string TopN(int n)
        {
            ListeDesEntrees.Sort();
            ListeDesEntrees.Reverse();

            int compteur = 0;
            string topN = "Voici les " + n + " high scores :\n";

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

        
    }
}
