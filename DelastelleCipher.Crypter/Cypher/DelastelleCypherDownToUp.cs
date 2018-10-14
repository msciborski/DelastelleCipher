using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelastelleCipher.Crypter.Utils;

namespace DelastelleCipher.Crypter.Cyphers
{
    public class DelastelleCypherDownToUp : DelastelleCypher, ICypher
    {
        public DelastelleCypherDownToUp(PolybiusMatrixGenerator matrixGenerator) : base(matrixGenerator)
        {
        }

        public PolybiusMatrixGenerator MatrixGenerator { get; }

        public string Encode(string text)
        {
            var position = GetPositionsOfElements(Matrix, text);
            string downToUpRead = position.ReadDownToUp();
            var newPositions = GetPairs(downToUpRead);

            return EncodeText(newPositions);
        }

        public string Decode(string text)
        {
            var position = GetPositionsOfElements(Matrix, text);

            foreach (var charPosition in position)
            {
                var column = (charPosition.Row -1) < 0 ? 4 : charPosition.Row - 1;
                var row = charPosition.Column;

                charPosition.Column = column;
                charPosition.Row = row;
            }

            return EncodeText(position);
        }
    }
}
