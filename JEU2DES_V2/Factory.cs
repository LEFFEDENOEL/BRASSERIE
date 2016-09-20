using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEU2DES_V2
{
    public enum ChoixPersistance { Binaire = 1, XML}

    public abstract class Factory
    {
        public static IStrategyPersistable<Classement> IStrategyPersistable(ChoixPersistance choice)
        {
            IStrategyPersistable<Classement> objPersistable = null;

            switch (choice)
            {
                //Binary case
                case ChoixPersistance.Binaire:
                    objPersistable = new FichierBinaireStrategy<Classement>();
                    break;
                //XML case
                default:
                    objPersistable = new FichierXmlStrategy<Classement>();
                    break;
            }
            return objPersistable;
        }
    }
}
