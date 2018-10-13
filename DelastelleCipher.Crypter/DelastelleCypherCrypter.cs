using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelastelleCipher.Crypter.Models;

namespace DelastelleCipher.Crypter
{
    public enum DelastelleCypherType
    {
        Horizontal, UpToDown, DownToUp
    }
    public class DelastelleCypherCrypter
    {
        private readonly string _textToCypher;
        private readonly PolybiusMatrixGenerator _matrixGenerator;
        public readonly char[,] Matrix;

        public DelastelleCypherCrypter(string textToCypher, PolybiusMatrixGenerator matrixGenerator)
        {
            _textToCypher = textToCypher;
            _matrixGenerator = matrixGenerator;
            Matrix = _matrixGenerator.PobliusMatrix;
        }

        public CharPosition[] GetPositionsOfElements()
        {
            CharPosition[] positions = new CharPosition[_textToCypher.Length];
            for (int i = 0; i < _textToCypher.Length; i++)
            {
                positions[i] = GetPositionOfElementInMatrix(_textToCypher[i]);
            }

            return positions;
        }

        private CharPosition GetPositionOfElementInMatrix(char element)
        {
            int width = Matrix.GetLength(0);
            int height = Matrix.GetLength(1);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (Matrix[i, j].Equals(element))
                    {
                        return new CharPosition {Column = j, Row = i};
                    }
                }
            }
            throw new Exception("Element doesn't exist in matrix, bad matrix");
        }
    }
}
