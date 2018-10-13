using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelastelleCipher.Crypter;
using DelastelleCipher.Crypter.Utils;

namespace DelastelleCipher.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = "Klucz";
            var textToCypher = "Lampka".ToUpperInvariant();

            PolybiusMatrixGenerator matrixGenerator = new PolybiusMatrixGenerator(key.UnifyKey());
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(matrixGenerator.PobliusMatrix[i,j] + " ");
                }
                Console.WriteLine();
            }

            DelastelleCypherCrypter crypter = new DelastelleCypherCrypter(textToCypher, matrixGenerator);
            var positions = crypter.GetPositionsOfElements();
            foreach (var charPosition in positions)
            {
                Console.WriteLine($"Column: {charPosition.Column}, Row: {charPosition.Row}");
            }
            Console.WriteLine(positions.ReadHorizontal());

            Console.ReadKey();
        }
    }
}
