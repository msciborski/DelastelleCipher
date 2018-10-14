using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelastelleCipher.Crypter.Models;
using DelastelleCipher.Crypter.Utils;

namespace DelastelleCipher.Crypter.Cyphers
{
    public enum DelastelleCypherType
    {
        Horizontal, UpToDown, DownToUp
    }

    public abstract class DelastelleCypher
    {
        public PolybiusMatrixGenerator MatrixGenerator { get; }

        public readonly char[,] Matrix;

        protected DelastelleCypher(PolybiusMatrixGenerator matrixGenerator)
        {
            MatrixGenerator = matrixGenerator;
            Matrix = MatrixGenerator.PobliusMatrix;
        }


        protected CharPosition[] GetPairs(string polybiusPositions)
        {
            var arrayLength = polybiusPositions.Length / 2;
            List<CharPosition> newPositions = new List<CharPosition>(arrayLength);

            int i = 0;
            while (i < polybiusPositions.Length)
            {
                CharPosition charPosition = new CharPosition
                {
                    Column = (int)Char.GetNumericValue(polybiusPositions[i++]),
                    Row = (int)Char.GetNumericValue(polybiusPositions[i++])
                };
                newPositions.Add(charPosition);
            }

            return newPositions.ToArray();
        }

        public CharPosition[] GetPositionsOfElements(char[,] matrix, string text)
        {
            CharPosition[] positions = new CharPosition[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                positions[i] = GetPositionOfElementInMatrix(matrix, text[i]);
            }

            return positions;
        }

        protected CharPosition GetPositionOfElementInMatrix(char[,] matrix, char element)
        {
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (matrix[i, j].Equals(element))
                    {
                        return new CharPosition { Column = j, Row = i };
                    }
                }
            }
            throw new Exception("Element doesn't exist in matrix, bad matrix");
        }

        protected char GetValueFromPosition(char[,] matrix, CharPosition position)
        {
            return matrix[position.Row, position.Column];
        }

        public string EncodeText(CharPosition[] positions)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var charPosition in positions)
            {
                builder.Append(GetValueFromPosition(Matrix, charPosition));
            }

            return builder.ToString();
        }
    }
}
