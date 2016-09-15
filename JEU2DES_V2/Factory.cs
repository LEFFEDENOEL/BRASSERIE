using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEU2DES_V2
{
    public abstract class Factory
    {
        public static IStrategyPersistable IStrategyPersistable(int choice)
        {
            IStrategyPersistable objPersistable = null;

            switch (choice)
            {
                //Binary case
                case 1:
                    objPersistable = new FichierBinaireStrategy();
                    break;
                //XML case
                case 2:
                    objPersistable = new FichierXmlStrategy();
                    break;
            }
            return objPersistable;
        }
    }
}
