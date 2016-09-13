using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEU2DES
{
    public class Jeu
    {
        #region Champs et properties
        /// <summary>
        /// Declaration instance properties
        /// </summary>

        private De _De2;
        private De _De1;

        public De De1
        {
            get { return _De1; }
            set { _De1 = value; }
        }

        public De De2
        {
            get { return _De2; }
            set { _De2 = value; }
        }

        private  Classement _Classmt;

        public  Classement Classmt
        {
            get { return _Classmt; }
            set { _Classmt = value; }
        }

        private Joueur _Joueur;

        public Joueur Joueur
        {
            get { return _Joueur; }
            set { _Joueur = value; }
        }

        #endregion

        #region Constructeurs        
        /// <summary>
        /// Initializes a new instance of the <see cref="Jeu"/> class.
        /// Full manufacturer. 
        /// </summary>
        /// <param name="de1">The de1.</param>
        /// <param name="de2">The de2.</param>
        /// <param name="classement">The classement.</param>
        /// <param name="joueur">The joueur.</param>
        public Jeu(De de1, De de2, Classement classement, Joueur joueur)
        {
            De1 = de1;
            De2 = de2;
            Classmt = classement;
            Joueur = joueur; 
        }
        #endregion

        #region Méthodes

        public int JouerPartie(string nom)
        {
            Joueur = new Joueur(nom);
            int score = Joueur.Jouer(new De());
            Classmt.AjouterEntree(nom, score);
            return score;

        }
        //Classement _Classement = new Classement();
        public SortedDictionary<int, string> VoirClassement()
        {
            return Classement.TopN(Classmt.Count());
        }
        #endregion

        #region Méthodes substituées ou héritées
        public override string ToString()
        {
            return (De1 + " " + De2 + "" + Classmt + "" + Joueur);
        }
        #endregion

        #region Méthodes pour implémenter les interfaces
        #endregion




    }
}
