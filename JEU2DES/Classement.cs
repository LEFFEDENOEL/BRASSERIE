using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEU2DES
{
    public class Classement
    {
        private class Entree
        {
            #region Champs et Propriétés
            private string _Nom;

            public string Nom
            {
                get { return _Nom}
                set { _Nom = value; }
            }

            private int _Score;
            public int Score
            {
                get { return _Score}
                set { _Score = value; }
            }
            #endregion

            #region Constructeurs

            //Constructeur par defaut
            public Entree() { }

            //Constructeur complet
            public Entree(Classement classement, string nom, int score)
            {
                Nom = nom;
                Score = score;
            }
            #endregion


            #region Methodes

            public bool AjouterEntree(string nom, int score)
            {
                //TODO
                return true;
            }

            public void TopN()
            {
                //TODO
            }

            #endregion

            #region Methodes héritées et substituées

            public override string ToString()
            {
                return "Nom du joueur : " + Nom + "Score est égal à : " + Score;
            }

            #endregion
        }
    }
}
