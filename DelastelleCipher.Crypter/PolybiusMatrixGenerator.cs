using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelastelleCipher.Crypter
{
    public class PolybiusMatrixGenerator
    {
        public readonly int _matrixSize = 25;
        private readonly string _key;
        public readonly int _otherElementsCount;
        private readonly Random random = new Random(new Guid().GetHashCode());

        public char[,] PobliusMatrix { get; private set; }

        public PolybiusMatrixGenerator(string key)
        {
            _key = key;
            _otherElementsCount = _matrixSize - key.Length;
            PobliusMatrix = GeneratePobliusMatrix();
        }

        public PolybiusMatrixGenerator()
        {
            _key = String.Empty;
            _otherElementsCount = _matrixSize;
            PobliusMatrix = GeneratePobliusMatrix();
        }

        private char[,] GeneratePobliusMatrix()
        {
            var otherElements = GenerateOtherElements();
            string pobliusMatrixString = _key + otherElements;

            char[,] pobliusMatrix = new char[5, 5];

            var charCounter = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    pobliusMatrix[i, j] = pobliusMatrixString[charCounter];
                    charCounter++;
                }
            }

            return pobliusMatrix;
        }

        private string GenerateOtherElements()
        {
            var asciiOfFirstLetter = 65; // ASCII of A
            var asciiOfLastLetter = 90; // ASCII of Z

            StringBuilder builder = new StringBuilder(_otherElementsCount);
            for (int i = asciiOfFirstLetter; i <= asciiOfLastLetter; i++)
            {
                var charValue = (char) i;
                if (charValue == 'J' || _key.Contains(charValue))
                {
                    continue;
                }

                builder.Append(charValue);
            }

            return RandomizedElements(builder.ToString());
        }

        private string RandomizedElements(string elements)
        {
            return new string(elements.OrderBy(x => random.Next()).ToArray());
        }

    }
}
