using DelastelleCipher.Crypter.Utils;

namespace DelastelleCipher.Crypter.Cyphers
{
    public class DelastelleCypherUpToDown : DelastelleCypher, ICypher
    {
        public DelastelleCypherUpToDown(PolybiusMatrixGenerator matrixGenerator) : base(matrixGenerator)
        {
        }

        public string Encode(string text)
        {
            var position = GetPositionsOfElements(Matrix, text);
            string downToUpRead = position.ReadUpToDown();
            var newPositions = GetPairs(downToUpRead);

            return EncodeText(newPositions);
        }

        public string Decode(string text)
        {
            var positions = GetPositionsOfElements(Matrix, text);
            foreach (var charPosition in positions)
            {
                charPosition.Row = (charPosition.Row - 1) < 0 ? 4 : charPosition.Row - 1;
            }

            return EncodeText(positions);
        }
    }
}
