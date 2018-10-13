using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelastelleCipher.Crypter.Models;
using DelastelleCipher.Crypter.Utils;

namespace DelastelleCipher.Crypter.Cyphers
{
    public class DelastelleCypherHorizontal : DelastelleCypher, ICypher
    {
        public DelastelleCypherHorizontal(PolybiusMatrixGenerator matrixGenerator) : base(matrixGenerator)
        {
        }

        public string Encode(string text)
        {
            var position = GetPositionsOfElements(Matrix, text);
            string readHorizontal = position.ReadHorizontal();
            var newPositions = GetPairs(readHorizontal);

            return EncodeText(newPositions);
        }
        public string Decode(string text)
        {
            List<CharPosition> encodedPositions = new List<CharPosition>();
            var positions = GetPositionsOfElements(Matrix, text);
            var postionsCount = positions.Length;
            var columnRowCount = postionsCount / 2;

            var columns = String.Join("",
                Array.ConvertAll<object, string>(positions.AsEnumerable().Take(columnRowCount).ToArray(),
                    Convert.ToString));
            var rows = String.Join("",
                Array.ConvertAll<object, string>(positions.AsEnumerable().Skip(columnRowCount).Take(columnRowCount).ToArray(),
                    Convert.ToString));

            for (int i = 0; i < postionsCount; i++)
            {
                encodedPositions.Add(new CharPosition
                {
                    Column = (int) Char.GetNumericValue(columns[i]),
                    Row = (int) Char.GetNumericValue(rows[i]),
                });
            }
            return EncodeText(encodedPositions.ToArray());
            ;
        }
    }
}
