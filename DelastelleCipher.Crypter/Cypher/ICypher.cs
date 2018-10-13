using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelastelleCipher.Crypter.Cyphers
{
    public interface ICypher
    {
        string Encode(string text);
        string Decode(string text);
    }
}
