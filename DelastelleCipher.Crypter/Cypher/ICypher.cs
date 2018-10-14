using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelastelleCipher.Crypter.Models;

namespace DelastelleCipher.Crypter.Cyphers
{
    public interface ICypher
    {
        PolybiusMatrixGenerator MatrixGenerator { get; }
        string Encode(string text);
        string Decode(string text);
        CharPosition[] GetPositionsOfElements(char[,] matrix, string text);
    }
}
