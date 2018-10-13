using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelastelleCipher.Crypter;
using DelastelleCipher.Crypter.Cyphers;
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

            DelastelleCypherDownToUp crypter = new DelastelleCypherDownToUp(matrixGenerator);
            var encodedText = crypter.Encode(textToCypher);
            Console.WriteLine(encodedText);
            var decodedText = crypter.Decode(encodedText);
            Console.WriteLine(decodedText);
            //var encodedText = crypter.GetEncodedText(textToCypher, DelastelleCypherType.Horizontal);
            //Console.WriteLine($"Szyfr: {encodedText}");
            //Console.WriteLine($"Po deszyfracji: {crypter.DecodeText(encodedText, DelastelleCypherType.Horizontal)}");
            Console.ReadKey();
        }
    }
}
