using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEU2DES_V2
{
    public interface IStrategyPersistable<T>
    {
        bool Save(string nomFichier, T t);
        bool Load(string nomFichier, out T t);
    }
}
