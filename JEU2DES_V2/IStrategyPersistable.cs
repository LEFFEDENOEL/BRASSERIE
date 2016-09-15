using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEU2DES_V2
{
    public interface IStrategyPersistable
    {

        void Save(Classement classement);
        Classement Load();
    }
}
