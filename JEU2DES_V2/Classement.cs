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
    public  class Classement
    {
        #region Champs et Propriétés de Classement

        private List<Entree> _ListeDesEntrees;
  
        public List<Entree> ListeDesEntrees
        {
            get { return _ListeDesEntrees; }
            set { _ListeDesEntrees = value; }
        }

        private IStrategyPersistable<Classement> _IStrategyPersistable;

        private IStrategyPersistable<Classement> IStrategyPersistable
        {
            get { return _IStrategyPersistable; }
            set { _IStrategyPersistable = value; }
        }
        #endregion

        #region Constructeurs

        //Constructeur par défaut
        public Classement()
        {
            ListeDesEntrees = new List<Entree>();
        }
        public Classement(IStrategyPersistable<Classement> iStrategyPersistable)
        {
            IStrategyPersistable = iStrategyPersistable;
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

        public bool Load(string nomFichier, out Classement c)
        {
            if (IStrategyPersistable.Load(nomFichier, out c)) { return true; } else { return false; }
        }

        public bool Save(string nomFichier, Classement classement)
        {
            return IStrategyPersistable.Save(nomFichier, classement);
        }

        #endregion     
    }
}
