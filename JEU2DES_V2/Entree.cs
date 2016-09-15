using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEU2DES_V2
{
    [Serializable]
    /// <summary>
    /// Déclaration de la classe Entree dans la classe Classement du fait de la composition
    /// </summary>
    public class Entree : IComparable<Entree>
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
        public int CompareTo(Entree other)
        {
            if (other != null)
                return Score > other.Score ? 1 : (Score < other.Score ? -1 : 0);
            else return 0;
        }

        #endregion
    }
}
