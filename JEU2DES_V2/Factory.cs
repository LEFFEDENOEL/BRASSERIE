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
        public static IStrategyPersistable IStrategyPersistable(ChoixPersistance choice)
        {
            IStrategyPersistable objPersistable = null;

            switch (choice)
            {
                //Binary case
                case ChoixPersistance.Binaire:
                    objPersistable = new FichierBinaireStrategy();
                    break;
                //XML case
                default:
                    objPersistable = new FichierXmlStrategy();
                    break;
            }
            return objPersistable;
        }
    }
}
