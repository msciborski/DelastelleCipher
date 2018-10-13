using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelastelleCipher.Crypter.Cyphers;

namespace DelastelleCipher.Crypter.Factory
{
    public abstract class Creator
    {
        public abstract ICypher Create(string key, DelastelleCypherType type);
    }
}
