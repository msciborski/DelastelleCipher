using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelastelleCipher.Crypter.Cyphers;

namespace DelastelleCipher.Crypter.Factory
{
    public static class DelastellaCypherFactory
    {
        public static ICypher Create(string key, DelastelleCypherType type)
        {
            PolybiusMatrixGenerator matrixGenerator = new PolybiusMatrixGenerator(key);
            switch (type)
            {
                case DelastelleCypherType.Horizontal:
                    return new DelastelleCypherHorizontal(matrixGenerator);
                case DelastelleCypherType.DownToUp:
                    return new DelastelleCypherDownToUp(matrixGenerator);
                case DelastelleCypherType.UpToDown:
                    return new DelastelleCypherUpToDown(matrixGenerator);
            }

            throw new Exception("Type doesn't exist");
        }
    }
}
